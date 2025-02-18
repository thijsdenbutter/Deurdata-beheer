﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deurdata_beheer
{

    public partial class Form1 : Form
    {
        public Ini.handling ini = new Ini.handling();

        public Form1()
        {
            InitializeComponent();

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



    }
}
