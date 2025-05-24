using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace Deurdata_beheer
{
    public enum ExportType
    {
        Archimede = 1,
    }

    public enum DataSource
    {
        ArchimedeImport = 1,
        IniImport = 2,
    }

    public partial class Form1 : Form
    {
        public Ini.handling ini = new Ini.handling();

        public string iniPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + $"\\Instellingen.ini";

        public ExportType exportType;
        public DataSource dataSource;

        private List<ProjectInfo> Projects = new List<ProjectInfo>();
        private Sash selectedSash = null;
        private ProjectInfo selectedProject = null;

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            exportType = (ExportType)Convert.ToInt32(ini.INIRead(iniPath, "GeneralSettings", "export", "1"));
            dataSource = (DataSource)Convert.ToInt32(ini.INIRead(iniPath, "GeneralSettings", "configurationSource", "1"));

            FillOpenings();
            FillLockConf();

            UpdateGridWidth();

        }
        private void UpdateGridWidth()
        {
            int totalWidth = 0;

            foreach (DataGridViewColumn col in dgv_GeoTopTransom.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                totalWidth += col.Width;
            }

            dgv_GeoTopTransom.Width = totalWidth + (dgv_GeoTopTransom.RowHeadersVisible ? dgv_GeoTopTransom.RowHeadersWidth : 0) + SystemInformation.VerticalScrollBarWidth;
        }

        private void FillLockConf()
        {
            switch (dataSource)
            {
                case DataSource.ArchimedeImport:
                    break;
                case DataSource.IniImport:
                    var items = ReadHardwareItemsFromIni(iniPath, "HardwareConfigurations");
                    cb_LockConf.DisplayMember = "Name";
                    cb_LockConf.ValueMember = "Code";
                    cb_LockConf.DataSource = items;
                    break;
                default:
                    break;
            }
        }

        public List<HardwareItem> ReadHardwareItemsFromIni(string iniFile, string section)
        {
            var result = new List<HardwareItem>();
            int index = 1;
            string value;

            while (true)
            {
                value = ini.INIRead(iniFile, section, index.ToString(), "");
                if (string.IsNullOrWhiteSpace(value))
                    break;

                var parts = value.Split('|');
                if (parts.Length >= 2)
                {
                    result.Add(new HardwareItem
                    {
                        Code = parts[0].Trim(),
                        Name = parts[1].Trim()
                    });
                }

                index++;
                if (index > 1000)
                    throw new InvalidOperationException("INI-section loops to infinity");
            }

            return result;
        }

        public void FillOpenings()
        {
            cb_Opening.DataSource = Enum.GetValues(typeof(OpeningType))
                .Cast<OpeningType>()
                .Select(v => new EnumItem<OpeningType>
                {
                    Value = v,
                    Label = GetEnumDescription(v)
                }).ToList();

            cb_Opening.DisplayMember = "Label";
            cb_Opening.ValueMember = "Value";
            cb_Opening.Tag = "Opening";
        }

        public static string GetEnumDescription(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attr = field?.GetCustomAttributes(typeof(DescriptionAttribute), false)
                             .FirstOrDefault() as DescriptionAttribute;
            return attr?.Description ?? value.ToString();
        }

        private void msi_NewSash_Click(object sender, EventArgs e)
        {
            AddSash();
        }

        private void msi_NewProject_Click(object sender, EventArgs e)
        {
            AddProject();
        }

        public void AddProject()
        {
            var newProject = new ProjectInfo();
            Projects.Add(newProject);
            selectedProject = newProject;

            TreeNode node = BuildTreeFromObject($"Project ", newProject);
            node.Tag = newProject;

            tv_Projects.Nodes.Add(node);

            TreeNode selectedProjectNode = tv_Projects.Nodes.Cast<TreeNode>().FirstOrDefault(n => n.Tag == selectedProject);
            selectedProjectNode.Expand();
        }

        public void AddSash()
        {
            if (Projects.Count == 0)
            {
                AddProject();
            }

            if (selectedProject == null)
            {
                selectedProject = Projects.Last();
            }

            var newSash = new Sash();
            selectedProject.Sashes.Add(newSash);
            selectedSash = newSash;

            TreeNode selectedProjectNode = tv_Projects.Nodes.Cast<TreeNode>().FirstOrDefault(n => n.Tag == selectedProject);
            if (selectedProjectNode == null) return;

            int sashIndex = selectedProject.Sashes.Count;

            TreeNode newSashNode = BuildTreeFromObject($"Deur {sashIndex}", newSash);
            newSashNode.Tag = newSash;

            string sashesLabel = typeof(ProjectInfo)
                .GetProperty(nameof(ProjectInfo.Sashes))
                ?.GetCustomAttribute<LabelAttribute>()
                ?.Text ?? nameof(ProjectInfo.Sashes);

            TreeNode sashesNode = selectedProjectNode.Nodes.Cast<TreeNode>().FirstOrDefault(n => n.Text == $"{sashesLabel}:");
            if (sashesNode == null) return;

            sashesNode.Nodes.Add(newSashNode);

            TreeNode selectedSashNode = sashesNode.Nodes.Cast<TreeNode>().FirstOrDefault(n => n.Tag == newSash);
            if (selectedSashNode == null) return;

            selectedSashNode.Expand();
        }

        private void msi_Save_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            // ------------ Projects ------------ //

            if (selectedProject == null)
                return;

            // Update selected project object values

            if (int.TryParse(txt_OrderNumber.Text, out int orderNumber))
                selectedProject.OrderNumber = orderNumber;

            selectedProject.ProjectName = txt_ProjectName.Text;
            selectedProject.ProjectReference = txt_ProjectReference.Text;

            // Search project node

            TreeNode selectedProjectNode = tv_Projects.Nodes.Cast<TreeNode>().FirstOrDefault(n => n.Tag == selectedProject);
            if (selectedProjectNode == null) return;

            // Update selected project node text

            UpdateTreeNodeFromObject(selectedProjectNode, selectedProject);

            // ------------ Sashes ------------ //
            if (selectedSash == null && selectedProject.Sashes.Count != 0) selectedSash = selectedProject.Sashes.Last();

            if (selectedSash == null)
                return;

            // Update selected sash object values

            if (double.TryParse(txt_Width.Text, out double width))
                selectedSash.Width = width;

            if (double.TryParse(txt_Height.Text, out double height))
                selectedSash.Height = height;

            if (double.TryParse(txt_Thickness.Text, out double thickness))
                selectedSash.Thickness = thickness;

            if (cb_Opening.SelectedValue is OpeningType selectedOpening)
            {
                selectedSash.Opening = selectedOpening;
            }
            else if (cb_Opening.SelectedItem != null)
            {
                Enum.TryParse(cb_Opening.SelectedItem.ToString(), out OpeningType parsedOpening);
                selectedSash.Opening = parsedOpening;
            }

            selectedSash.LockConfiguration = cb_LockConf.SelectedItem as HardwareItem;

            if (double.TryParse(txt_HandleHeight.Text, out double handleHeight))
                selectedSash.HandleHeight = handleHeight;

            selectedSash.Geometry.TopTransom.Clear();

            foreach (DataGridViewRow row in dgv_GeoTopTransom.Rows)
            {
                if (row.IsNewRow) continue;
                Point point = new Point
                {
                    Length = Convert.ToDouble(row.Cells["geoTopTransomLength"].Value),
                    Offset = Convert.ToDouble(row.Cells["geoTopTransomOffset"].Value)
                };
                selectedSash.Geometry.TopTransom.Add(point);
            }

            selectedSash.Geometry.BottomTransom.Clear();

            foreach (DataGridViewRow row in dgv_GeoBottomTransom.Rows)
            {
                if (row.IsNewRow) continue;
                Point point = new Point
                {
                    Length = Convert.ToDouble(row.Cells["geoBottomTransomLength"].Value),
                    Offset = Convert.ToDouble(row.Cells["geoBottomTransomOffset"].Value)
                };
                selectedSash.Geometry.BottomTransom.Add(point);
            }

            selectedSash.Geometry.LeftPost.Clear();

            foreach (DataGridViewRow row in dgv_GeoLeftPost.Rows)
            {
                if (row.IsNewRow) continue;
                Point point = new Point
                {
                    Length = Convert.ToDouble(row.Cells["geoLeftPostLength"].Value),
                    Offset = Convert.ToDouble(row.Cells["geoLeftPostOffset"].Value)
                };
                selectedSash.Geometry.LeftPost.Add(point);
            }

            selectedSash.Geometry.RightPost.Clear();

            foreach (DataGridViewRow row in dgv_GeoRightPost.Rows)
            {
                if (row.IsNewRow) continue;
                Point point = new Point
                {
                    Length = Convert.ToDouble(row.Cells["geoRightPostLength"].Value),
                    Offset = Convert.ToDouble(row.Cells["geoRightPostOffset"].Value)
                };
                selectedSash.Geometry.RightPost.Add(point);
            }

            // Get sashes label

            string sashesLabel = typeof(ProjectInfo)
                .GetProperty(nameof(ProjectInfo.Sashes))
                ?.GetCustomAttribute<LabelAttribute>()
                ?.Text ?? nameof(ProjectInfo.Sashes);

            // Search sash node

            TreeNode selectedSashNode = selectedProjectNode.Nodes
                .Cast<TreeNode>().FirstOrDefault(n => n.Text == $"{sashesLabel}:").Nodes
                .Cast<TreeNode>().FirstOrDefault(n => n.Tag == selectedSash);


            if (selectedSashNode == null) return;

            // Update selected project node text

            UpdateTreeNodeFromObject(selectedSashNode, selectedSash);

        }
        private void UpdateTreeNodeFromObject(TreeNode node, object obj)
        {
            if (node == null || obj == null)
                return;

            Type type = obj.GetType();

            foreach (var prop in type.GetProperties())
            {
                object value = prop.GetValue(obj);
                string label = prop.GetCustomAttribute<LabelAttribute>()?.Text ?? prop.Name;

                string newText = value == null
                    ? $"{label}: "
                    : $"{label}: {value}";

                TreeNode propNode = node.Nodes.Cast<TreeNode>()
                    .FirstOrDefault(n => n.Text.StartsWith($"{label}:"));

                if (value == null)
                {
                    if (propNode != null)
                        propNode.Text = $"{label}: ";
                    continue;
                }

                else if (value is Enum enumValue)
                {
                    string enumLabel = GetEnumDescription(enumValue);
                    propNode.Text = $"{label}: {enumLabel}";
                    continue;
                }

                if (value is string || value.GetType().IsValueType)
                {
                    if (propNode != null)
                        propNode.Text = $"{label}: {value}";
                    continue;
                }

                // Specifiek: List<Sash> → sla over (die verwerk je bij opslaan met BuildTree opnieuw)
                if (value is IEnumerable<Sash>) continue;

                else if (value is IEnumerable<object> lijst && !(value is string))
                {
                    // bestaande lijstnode vinden
                    TreeNode lijstNode = node.Nodes.Cast<TreeNode>()
                        .FirstOrDefault(n => n.Text.StartsWith($"{label}:"));

                    if (lijstNode != null)
                    {
                        lijstNode.Nodes.Clear(); // leegmaken en opnieuw opbouwen
                        int index = 1;
                        foreach (var item in lijst)
                        {
                            TreeNode itemNode = BuildTreeFromObject($"{label} {index}", item);
                            itemNode.Tag = item;
                            lijstNode.Nodes.Add(itemNode);
                            index++;
                        }
                    }

                    continue;
                }

                // Subobject (zoals HardwareItem) → recursief bijwerken
                if (propNode != null)
                {
                    UpdateTreeNodeFromObject(propNode, value);
                }

            }
        }

        public static TreeNode BuildTreeFromObject(string name, object obj)
        {
            TreeNode root = new TreeNode($"{name}: ");

            if (obj == null)
                return root;

            Type type = obj.GetType();
            foreach (var prop in type.GetProperties())
            {
                if (prop.GetIndexParameters().Length > 0)
                    continue;

                object value = prop.GetValue(obj);
                string label = prop.GetCustomAttribute<LabelAttribute>()?.Text ?? prop.Name;

                if (value == null)
                {
                    root.Nodes.Add(new TreeNode($"{label}: "));
                }

                else if (value is Enum enumValue)
                {
                    string enumLabel = GetEnumDescription(enumValue);
                    root.Nodes.Add(new TreeNode($"{label}: {enumLabel}"));
                }

                else if (value is string || value.GetType().IsValueType)
                {
                    root.Nodes.Add(new TreeNode($"{label}: {value}"));
                }

                else if (value is IEnumerable<Sash> sashList)
                {
                    TreeNode lijstNode = new TreeNode($"{label}:");
                    int index = 1;
                    foreach (var sash in sashList)
                    {
                        var sashNode = BuildTreeFromObject($"Deur {index}", sash);
                        sashNode.Tag = sash;
                        lijstNode.Nodes.Add(sashNode);
                        index++;
                    }
                    root.Nodes.Add(lijstNode);
                }

                else if (value is IEnumerable<object> lijst && !(value is string))
                {
                    TreeNode lijstNode = new TreeNode($"{label}:");
                    int index = 1;
                    foreach (var item in lijst)
                    {
                        //lijstNode.Nodes.Add(BuildTreeFromObject($"{label} {index}", item));
                        //index++;

                        var itemNode = BuildTreeFromObject($"{label} {index}", item);
                        itemNode.Tag = item; // essentieel
                        lijstNode.Nodes.Add(itemNode);
                        index++;
                    }
                    root.Nodes.Add(lijstNode);
                }

                else if (!value.GetType().IsValueType && !(value is string))
                {
                    //root.Nodes.Add(BuildTreeFromObject(label, value));

                    TreeNode childNode = BuildTreeFromObject(label, value);
                    childNode.Tag = value; // essentieel voor updates
                    root.Nodes.Add(childNode);
                }

                else
                {
                    root.Nodes.Add(BuildTreeFromObject(label, value));
                }
            }

            return root;
        }

        private void tv_Projects_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;

            if (selectedNode?.Tag == null)
            {
                selectedNode = FindParentWithTag(selectedNode, typeof(object), true);
            }

            if (selectedNode?.Tag is Geometry || selectedNode?.Tag is Point )
            {
                selectedNode = FindParentWithTag(selectedNode, typeof(Sash), true);
            }

            if (selectedNode?.Tag is Sash sash)
            {
                selectedSash = sash;
                txt_Width.Text = sash.Width.ToString();
                txt_Height.Text = sash.Height.ToString();
                txt_Thickness.Text = sash.Thickness.ToString();
                cb_Opening.SelectedValue = sash.Opening;
                if (sash.LockConfiguration != null)
                {
                    cb_LockConf.SelectedValue = sash.LockConfiguration.Code;
                }
                txt_HandleHeight.Text = sash.HandleHeight.ToString();
                // Hier kun je de andere eigenschappen van de Sash instellen

                TreeNode projectNode = FindParentWithTag(e.Node, typeof(ProjectInfo), false);
                if (projectNode?.Tag is ProjectInfo parentProject)
                    selectedProject = parentProject;
            }
            else if (selectedNode?.Tag is ProjectInfo project)
            {
                selectedProject = project;
                txt_OrderNumber.Text = project.OrderNumber.ToString();
                txt_ProjectName.Text = project.ProjectName ?? "";
                // Hier kun je de andere eigenschappen van de Sash instellen

            }
            else
            {
                selectedProject = null;
                selectedSash = null;
            }
        }

        private TreeNode FindParentWithTag(TreeNode node, Type targetType, bool selectParent)
        {
            while (node?.Parent != null)
            {
                node = node.Parent;
                if (node.Tag != null && targetType.IsAssignableFrom(node.Tag.GetType()))
                {

                    if (selectParent)
                    {
                        tv_Projects.SelectedNode = node;
                    }
                    return node;
                }
            }
            return null;
        }

        private void txt_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Save();
            }
        }

        private void tv_Projects_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                TreeNode selectedNode = tv_Projects.SelectedNode;
                DeleteSelectedNode(selectedNode);
            }
        }

        private void DeleteSelectedNode(TreeNode node)
        {
            if (node == null)
                return;

            if (node.Tag is Sash sash)
            {
                selectedProject.Sashes.Remove(sash);
                tv_Projects.Nodes.Remove(node);
                selectedSash = null;
            }

            else if (node.Tag is ProjectInfo project)
            {
                Projects.Remove(project);
                tv_Projects.Nodes.Remove(node);
                selectedProject = null;
            }

            TreeNode parentNode = FindParentWithTag(node, typeof(object), false);
            if (parentNode == null) return;

            if (parentNode.Tag is Sash parentSash)
            {
                selectedProject.Sashes.Remove(parentSash);
                tv_Projects.Nodes.Remove(parentNode);
                selectedSash = null;
            }
        }

        private void msi_Export_Click(object sender, EventArgs e)
        {
            switch (exportType)
            {
                case ExportType.Archimede:
                    ExportArchimedeIniFormat();
                    break;
                default:
                    break;
            }
        }

        private void ExportArchimedeIniFormat()
        {
            string outputPath = "C://temp//output.ini";

            File.WriteAllText(outputPath, string.Empty);


            foreach (ProjectInfo project in Projects)
            {
                if (project == null) continue;

                ini.INIWrite(outputPath, "TESTATA_COMMESSA", "NUMERO_COMMESSA", project.OrderNumber.ToString());
                ini.INIWrite(outputPath, "TESTATA_COMMESSA", "DESCRIZIONE_COMMESSA", project.ProjectName);
                ini.INIWrite(outputPath, "TESTATA_COMMESSA", "RIFERIMENTO", project.ProjectReference);
                ini.INIWrite(outputPath, "TESTATA_COMMESSA", "NUMERO_RIGHE", project.Sashes.Count.ToString());

                for (int i = 0; i < project.Sashes.Count; i++)
                {
                    int pos = i + 1;
                    Sash sash = project.Sashes[i];
                    string section = pos.ToString();

                    ini.INIWrite(outputPath, section, "RIFERIMENTO", "");
                    ini.INIWrite(outputPath, section, "DESCRIZIONE_RIGA", $"Deur {pos}");
                    ini.INIWrite(outputPath, section, "PROGETTO_DEFAULT", "EMPTY");
                    ini.INIWrite(outputPath, section, "POSIZIONE", pos.ToString());
                    ini.INIWrite(outputPath, section, "QUANTITA", "1");

                    ini.INIWrite(outputPath, section, "CONFIGURAZIONE_TELAIO", "000 - GEEN KOZIJN");
                    ini.INIWrite(outputPath, section, "CONFIGURAZIONE_ANTA", "SAOMAD - 56 - RAAM - BU VJBU 12X16");
                    ini.INIWrite(outputPath, section, "CONFIGURAZIONE_TIPOLOGICA_ANTA", "S20");
                    ini.INIWrite(outputPath, section, "CONFIGURAZIONE_FERRAMENTA", sash.LockConfiguration.Name);
                    ini.INIWrite(outputPath, section, "CONFIGURAZIONE_CERNIERE", "00 - GEEN SLOT");

                    ini.INIWrite(outputPath, section, "LARGHEZZA_SERRAMENTO", sash.Width.ToString("F2").Replace('.', ','));
                    ini.INIWrite(outputPath, section, "ALTEZZA_SERRAMENTO", sash.Height.ToString("F2").Replace('.', ','));
                    ini.INIWrite(outputPath, section, "FORMA_ESTERNA", "RETTANGOLO");
                    ini.INIWrite(outputPath, section, "SOGLIA", "L");
                    ini.INIWrite(outputPath, section, "SPESSORE_TELAIO", "0");

                    ini.INIWrite(outputPath, section, "APERTURA", sash.Opening == OpeningType.LeftOpenOut || sash.Opening == OpeningType.LeftOpenIn ? "ND" : "NS");

                    ini.INIWrite(outputPath, section, "SORMONTA_DX", "0");
                    ini.INIWrite(outputPath, section, "SORMONTA_SUP", "0");
                    ini.INIWrite(outputPath, section, "SORMONTA_SX", "0");
                    ini.INIWrite(outputPath, section, "SORMONTA_INF", "0");
                    ini.INIWrite(outputPath, section, "HMANIGLIA", sash.HandleHeight.ToString());

                    section = pos + "_TELAIO";

                    ini.INIWrite(outputPath, section, "SEZIONE_MONT_SX", "0");
                    ini.INIWrite(outputPath, section, "SEZIONE_TRA_SUP", "0");
                    ini.INIWrite(outputPath, section, "SEZIONE_MONT_DX", "0");
                    ini.INIWrite(outputPath, section, "SEZIONE_TRA_INF", "0");
                    ini.INIWrite(outputPath, section, "SPESSORE", "114");

                    if (sash.Geometry.TopTransom.Count != 0)
                    {
                        ini.INIWrite(outputPath, section, "APPLICPROF_TRA_SUP", "A");

                        string geoLines = "";
                        int count = 0;

                        double startX = sash.Geometry.TopTransom[0].Length;
                        double startY = sash.Geometry.TopTransom[0].Offset;

                        for (i = 1; i < sash.Geometry.TopTransom.Count; i++)
                        {
                            double endX = sash.Geometry.TopTransom[i].Length;
                            double endY = sash.Geometry.TopTransom[i].Offset;

                            geoLines += $"|L|{startX}|{-startY}|{endX}|{-endY}";
                            count++;

                            startX = endX;
                            startY = endY;
                        }

                        geoLines = count.ToString() + geoLines;
                        ini.INIWrite(outputPath, section, "PROFILO_TRA_SUP", geoLines);

                    }
                    if (sash.Geometry.BottomTransom.Count != 0)
                    {
                        ini.INIWrite(outputPath, section, "APPLICPROF_TRA_INF", "A");

                        string geoLines = "";
                        int count = 0;

                        double startX = sash.Geometry.BottomTransom[0].Length;
                        double startY = sash.Geometry.BottomTransom[0].Offset;

                        for (i = 1; i < sash.Geometry.BottomTransom.Count; i++)
                        {
                            double endX = sash.Geometry.BottomTransom[i].Length;
                            double endY = sash.Geometry.BottomTransom[i].Offset;

                            geoLines += $"|L|{startX}|{-startY}|{endX}|{-endY}";
                            count++;

                            startX = endX;
                            startY = endY;
                        }

                        geoLines = count.ToString() + geoLines;
                        ini.INIWrite(outputPath, section, "PROFILO_TRA_INF", geoLines);

                    }
                    if (sash.Geometry.LeftPost.Count != 0)
                    {
                        ini.INIWrite(outputPath, section, "APPLICPROF_MONT_DX", "A");

                        string geoLines = "";
                        int count = 0;

                        double startX = sash.Geometry.LeftPost[0].Length;
                        double startY = sash.Geometry.LeftPost[0].Offset;

                        for (i = 1; i < sash.Geometry.LeftPost.Count; i++)
                        {
                            double endX = sash.Geometry.LeftPost[i].Length;
                            double endY = sash.Geometry.LeftPost[i].Offset;

                            geoLines += $"|L|{startX}|{-startY}|{endX}|{-endY}";
                            count++;

                            startX = endX;
                            startY = endY;
                        }

                        geoLines = count.ToString() + geoLines;
                        ini.INIWrite(outputPath, section, "PROFILO_MONT_DX", geoLines);

                    }
                    if (sash.Geometry.RightPost.Count != 0)
                    {
                        ini.INIWrite(outputPath, section, "APPLICPROF_MONT_SX", "A");

                        string geoLines = "";
                        int count = 0;

                        double startX = sash.Geometry.RightPost[0].Length;
                        double startY = sash.Geometry.RightPost[0].Offset;

                        for (i = 1; i < sash.Geometry.RightPost.Count; i++)
                        {
                            double endX = sash.Geometry.RightPost[i].Length;
                            double endY = sash.Geometry.RightPost[i].Offset;

                            geoLines += $"|L|{startX}|{-startY}|{endX}|{-endY}";
                            count++;

                            startX = endX;
                            startY = endY;
                        }

                        geoLines = count.ToString() + geoLines;
                        ini.INIWrite(outputPath, section, "PROFILO_MONT_SX", geoLines);

                    }


                    section = pos + "_ANTA";

                    ini.INIWrite(outputPath, section, "SEZIONE_MONT_SX", "0");
                    ini.INIWrite(outputPath, section, "SEZIONE_TRA_SUP", "0");
                    ini.INIWrite(outputPath, section, "SEZIONE_MONT_DX", "0");
                    ini.INIWrite(outputPath, section, "SEZIONE_TRA_INF", "0");
                    ini.INIWrite(outputPath, section, "SPESSORE", sash.Thickness.ToString());

                }
            }
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            UpdateGridWidth();
        }
    }
}
