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
            generalSettingPanel1.SetMainForm(this);
            this.WindowState = FormWindowState.Maximized;
        }

        public void HandleCheckChange (UserControl panel, bool isChecked, CheckBox checkBox)
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

        private void Cb_GeneralSettings_CheckedChanged(object sender, EventArgs e)
        {
            HandleCheckChange(generalSettingPanel1, cb_GeneralSettings.Checked, (CheckBox)sender);
        }

        private void Cb_MainRowSettings_CheckedChanged(object sender, EventArgs e)
        {
            //handleCheckChange(pan_MainRowSettings, cb_MainRowSettings.Checked, (CheckBox)sender);

        }

    }
}
