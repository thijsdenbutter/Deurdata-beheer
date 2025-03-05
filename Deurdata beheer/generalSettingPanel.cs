using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deurdata_beheer
{
    public partial class generalSettingPanel : UserControl
    {
        public event EventHandler NewSash_Click;
        public event EventHandler GenerateIniFile_Click;

        public generalSettingPanel()
        {
            InitializeComponent();
            bt_newSash.Click += bt_newSash_Click;
            bt_generateIniFile.Click += bt_generateIniFile_Click;
        }

        private void bt_generateIniFile_Click(object sender, EventArgs e)
        {
            GenerateIniFile_Click?.Invoke(this, EventArgs.Empty);
        }

        private void bt_newSash_Click(object sender, EventArgs e)
        {
            NewSash_Click?.Invoke(this, EventArgs.Empty);
        }
    }
}
