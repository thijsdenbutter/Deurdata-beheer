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
            resizeMenuItems();
        }

        public void resizeMenuItems()
        {
            double panelPadding = 30;
            double panelWidth = flp_menu.Width;

            if (flp_menu.VerticalScroll.Visible == true)
            {
                panelWidth = flp_menu.Width - SystemInformation.VerticalScrollBarWidth;
            }

            Size size = new Size(Convert.ToInt32(panelWidth - panelPadding), 50);

            cb_generalSettingVisible.Size = size;
            pan_generalSettings.Width = size.Width;
        }


        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            resizeMenuItems();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            resizeMenuItems();
        }


        private void cb_generalSettingVisible_CheckedChanged(object sender, EventArgs e)
        {
            pan_generalSettings.Visible = cb_generalSettingVisible.Checked ? true : false;
        }
    }
}
