namespace Deurdata_beheer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pan_Sashes = new System.Windows.Forms.Panel();
            this.pan_Menu = new System.Windows.Forms.Panel();
            this.cb_MainRowSettings = new System.Windows.Forms.CheckBox();
            this.cb_GeneralSettings = new System.Windows.Forms.CheckBox();
            this.generalSettingPanel1 = new Deurdata_beheer.generalSettingPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.pan_Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.pan_Menu);
            this.splitContainer1.Size = new System.Drawing.Size(1477, 1055);
            this.splitContainer1.SplitterDistance = 962;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pan_Sashes);
            this.splitContainer2.Size = new System.Drawing.Size(962, 1055);
            this.splitContainer2.SplitterDistance = 136;
            this.splitContainer2.TabIndex = 0;
            // 
            // pan_Sashes
            // 
            this.pan_Sashes.AutoScroll = true;
            this.pan_Sashes.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pan_Sashes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_Sashes.Location = new System.Drawing.Point(0, 0);
            this.pan_Sashes.Name = "pan_Sashes";
            this.pan_Sashes.Padding = new System.Windows.Forms.Padding(5);
            this.pan_Sashes.Size = new System.Drawing.Size(136, 1055);
            this.pan_Sashes.TabIndex = 0;
            // 
            // pan_Menu
            // 
            this.pan_Menu.Controls.Add(this.cb_MainRowSettings);
            this.pan_Menu.Controls.Add(this.generalSettingPanel1);
            this.pan_Menu.Controls.Add(this.cb_GeneralSettings);
            this.pan_Menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_Menu.Location = new System.Drawing.Point(0, 0);
            this.pan_Menu.Name = "pan_Menu";
            this.pan_Menu.Size = new System.Drawing.Size(512, 1055);
            this.pan_Menu.TabIndex = 0;
            // 
            // cb_MainRowSettings
            // 
            this.cb_MainRowSettings.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_MainRowSettings.AutoSize = true;
            this.cb_MainRowSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.cb_MainRowSettings.Location = new System.Drawing.Point(0, 144);
            this.cb_MainRowSettings.Name = "cb_MainRowSettings";
            this.cb_MainRowSettings.Size = new System.Drawing.Size(512, 26);
            this.cb_MainRowSettings.TabIndex = 2;
            this.cb_MainRowSettings.Text = "configuratie instellingen";
            this.cb_MainRowSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cb_MainRowSettings.UseVisualStyleBackColor = true;
            this.cb_MainRowSettings.CheckedChanged += new System.EventHandler(this.cb_MainRowSettings_CheckedChanged);
            // 
            // cb_GeneralSettings
            // 
            this.cb_GeneralSettings.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_GeneralSettings.AutoSize = true;
            this.cb_GeneralSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.cb_GeneralSettings.Location = new System.Drawing.Point(0, 0);
            this.cb_GeneralSettings.Name = "cb_GeneralSettings";
            this.cb_GeneralSettings.Size = new System.Drawing.Size(512, 26);
            this.cb_GeneralSettings.TabIndex = 0;
            this.cb_GeneralSettings.Tag = "pan_GeneralSettings";
            this.cb_GeneralSettings.Text = "Algemene instellingen";
            this.cb_GeneralSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cb_GeneralSettings.UseVisualStyleBackColor = true;
            this.cb_GeneralSettings.CheckedChanged += new System.EventHandler(this.cb_GeneralSettings_CheckedChanged);
            // 
            // generalSettingPanel1
            // 
            this.generalSettingPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.generalSettingPanel1.Location = new System.Drawing.Point(0, 26);
            this.generalSettingPanel1.Name = "generalSettingPanel1";
            this.generalSettingPanel1.Size = new System.Drawing.Size(512, 118);
            this.generalSettingPanel1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1477, 1055);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.pan_Menu.ResumeLayout(false);
            this.pan_Menu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pan_Menu;
        private System.Windows.Forms.CheckBox cb_GeneralSettings;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel pan_Sashes;
        private generalSettingPanel generalSettingPanel1;
        private System.Windows.Forms.CheckBox cb_MainRowSettings;
    }
}

