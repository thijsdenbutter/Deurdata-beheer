using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deurdata_beheer
{

    public partial class Form1 : Form
    {
        public static Color color_midnightPurple  = Color.FromArgb(24, 7, 58);
        public static Color color_aquaGreen = Color.FromArgb(60, 178, 142);
        public static Color color_icyGreen = Color.FromArgb(219, 237, 228);

        public static Font font_buttons = new Font("Roboto", 25, FontStyle.Regular);

        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
