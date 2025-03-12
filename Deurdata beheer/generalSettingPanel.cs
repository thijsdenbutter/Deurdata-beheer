using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deurdata_beheer
{
    public partial class generalSettingPanel : UserControl
    {
        public event EventHandler NewSash_Click;
        public event EventHandler GenerateIniFile_Click;

        private Form1 form1;


        public generalSettingPanel()
        {
            InitializeComponent();
        }

        public generalSettingPanel(Form1 form)
        {
            InitializeComponent();
            form1 = form;
        }

        public void SetMainForm(Form1 form)
        {
            this.form1 = form;
        }

        private void bt_newSash_Click_1(object sender, EventArgs e)
        {
            AddSash();
        }

        public void AddSash()
        {
            if (form1.orderHeader == null)
            {
                form1.orderHeader = new OrderHeader
                {
                    OrderNumber = -1,
                };
            }

            Row row = new Row
            {
                Reference = "",
                RowDescription = "",
                Position = form1.orderHeader.Rows.Count == 0 ? 1 : form1.orderHeader.Rows.Count + 1,
                Quantity = 1,
                FrameConfiguration = "000 - GEEN KOZIJN",
                SashConfiguration = "UNITEAM - 56 - BU KADER 18X16 DEUR",
                HardwareConfiguration = "MACO 3PUNTSLUITING G-TS Z-TS",
                Width = 930,
                Height = 2115,
                NumberOfSashes = 1,
                OpeningDirection = OpeningDirectionType.ND,
                RowNotes = "Notities order regel",
                Frame = new Frame
                {
                    StructureParameters = new StructureParameters
                    {
                        LeftPostSection = 0,
                        TopTransomSection = 0,
                        RightPostSection = 0,
                        BottomTransomSection = 0,
                        Thickness = 114,
                    }
                },
                Sash = new Sash
                {
                    StructureParameters = new StructureParameters
                    {
                        LeftPostSection = 114,
                        TopTransomSection = 114,
                        RightPostSection = 114,
                        BottomTransomSection = 114,
                        Thickness = 56,
                    }
                }

            };


            CheckBox checkBox = new CheckBox();
            checkBox.Name = $"Deur {form1.pan_Sashes.Controls.Count + 1}";
            checkBox.Text = checkBox.Name;
            checkBox.Tag = row;
            checkBox.Appearance = Appearance.Button;
            checkBox.Height = 45;
            checkBox.Width = form1.pan_Sashes.Width;
            checkBox.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;
            checkBox.Top = (form1.pan_Sashes.Controls.Count > 0) ? form1.pan_Sashes.Controls.Count * (checkBox.Height + 5) : 0;


            form1.orderHeader.Rows.Add(row);
            form1.pan_Sashes.Controls.Add(checkBox);
        }

        private void bt_generateIniFile_Click(object sender, EventArgs e)
        {
            GenerateIniFile();
        }

        public void GenerateIniFile()
        {
            WriteToIni<OrderHeader>(
                form1.orderHeader,
                "TESTATA_COMMESSA",
                "C:\\Temp\\Deurdata beheer\\INITest.ini");

            foreach (var orderRow in form1.orderHeader.Rows)
            {
                WriteToIni<Row>(
                    orderRow,
                    orderRow.Position.ToString(),
                    "C:\\Temp\\Deurdata beheer\\INITest.ini");
                WriteToIni<StructureParameters>(
                    orderRow.Frame.StructureParameters,
                    orderRow.Position.ToString() + "_TELAIO",
                    "C:\\Temp\\Deurdata beheer\\INITest.ini");
                WriteToIni<StructureParameters>(
                    orderRow.Sash.StructureParameters,
                    orderRow.Position.ToString() + "_ANTA1",
                    "C:\\Temp\\Deurdata beheer\\INITest.ini");
            }
        }

        public void WriteToIni<T>(T obj, string section, string filePath)
        {
            var type = typeof(T);

            foreach (var prop in type.GetProperties())
            {
                var attr = prop.GetCustomAttribute<ExportNameAttribute>();
                if (attr != null)
                {
                    var key = attr.Name;
                    var value = prop.GetValue(obj)?.ToString() ?? string.Empty;

                    if (prop.PropertyType == typeof(OpeningDirectionType))
                    {
                        var enumValue = (OpeningDirectionType)prop.GetValue(obj);
                        var enumMember = enumValue.GetType().GetField(enumValue.ToString());
                        var enumAttr = enumMember.GetCustomAttribute<ExportNameAttribute>();
                        value = enumAttr?.Name ?? value;
                    }

                    form1.ini.INIWrite(filePath, section, key, value);
                }
            }
        }

        private void tb_costumer_TextChanged(object sender, EventArgs e)
        {
            form1.orderHeader.Customer = tb_costumer.Text;
        }

        private void tb_description_TextChanged(object sender, EventArgs e)
        {
            form1.orderHeader.OrderDescription = tb_description.Text;

        }
    }
}
