using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deurdata_beheer
{

    public partial class Form1 : Form
    {
        public Ini.handling ini = new Ini.handling();
        public OrderHeader orderHeader = new OrderHeader();

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            generalSettingPanel1.NewSash_Click += bt_newSash_Click;
            generalSettingPanel1.GenerateIniFile_Click += bt_generateIniFile_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            OrderHeader orderHeader = new OrderHeader
            {
                OrderNumber = -1,
                OrderDescription = "",
                Reference = "",
                NumberOfRows = 1,
            };

            Row row = new Row
            {
                Reference = "",
                RowDescription = "",
                Position = 1,
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

            orderHeader.Rows.Add(row);

            WriteToIni<OrderHeader>(
                orderHeader, 
                "TESTATA_COMMESSA", 
                "C:\\Temp\\Deurdata beheer\\INITest.ini");

            foreach (var orderRow in orderHeader.Rows)
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

                    ini.INIWrite(filePath, section, key, value);
                }
            }
        }

       

        public void handleCheckChange (UserControl panel, bool isChecked, CheckBox checkBox)
        {
            if (isChecked)
            {
                panel.Visible = isChecked;
                panel.Height = this.ClientSize.Height - 26;

                foreach (Control control in pan_Menu.Controls)
                {
                    if (control == checkBox ||
                        control == panel)
                    {
                        continue;
                    }
                    control.Visible = false;
                }
            } else
            {
                foreach (Control control in pan_Menu.Controls)
                {
                    if (control is CheckBox)
                    {
                        control.Visible = true;
                    } 
                    else if (control is UserControl)
                    {
                        control.Visible = false;
                    }
                    
                }
            }
            
        }

        private void bt_newSash_Click(object sender, EventArgs e)
        {
            AddSash();
        }

        public void AddSash()
        {
            if (orderHeader == null)
            {
                orderHeader = new OrderHeader {
                    OrderNumber = -1,
                };
            }

            Row row = new Row
            {
                Reference = "",
                RowDescription = "",
                Position = orderHeader.Rows.Count == 0 ? 1 : orderHeader.Rows.Count + 1,
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
            checkBox.Name = $"Deur {pan_Sashes.Controls.Count + 1}";
            checkBox.Text = checkBox.Name;
            checkBox.Tag = row;
            checkBox.Appearance = Appearance.Button;
            checkBox.Height = 45;
            checkBox.Width = pan_Sashes.Width;
            checkBox.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;
            checkBox.Top = (pan_Sashes.Controls.Count > 0) ? pan_Sashes.Controls.Count * (checkBox.Height + 5) : 0;


            orderHeader.Rows.Add(row);
            //row.Position = lb_Sashes.Items.Count + 1;

            pan_Sashes.Controls.Add(checkBox);
        }

        private void bt_generateIniFile_Click(object sender, EventArgs e)
        {
            GenerateIniFile();
        }

        public void GenerateIniFile()
        {
            WriteToIni<OrderHeader>(
                orderHeader,
                "TESTATA_COMMESSA",
                "C:\\Temp\\Deurdata beheer\\INITest.ini");

            foreach (var orderRow in orderHeader.Rows)
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

        private void tb_costumer_TextChanged(object sender, EventArgs e)
        {
            //orderHeader.OrderDescription = tb_costumer.Text;
        }
        private void cb_GeneralSettings_CheckedChanged(object sender, EventArgs e)
        {
            handleCheckChange(generalSettingPanel1, cb_GeneralSettings.Checked, (CheckBox)sender);
        }

        private void cb_MainRowSettings_CheckedChanged(object sender, EventArgs e)
        {
            //handleCheckChange(pan_MainRowSettings, cb_MainRowSettings.Checked, (CheckBox)sender);

        }
    }
}
