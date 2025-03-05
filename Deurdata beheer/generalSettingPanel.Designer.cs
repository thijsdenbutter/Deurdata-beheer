namespace Deurdata_beheer
{
    partial class generalSettingPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pan_GeneralSettings = new System.Windows.Forms.Panel();
            this.bt_generateIniFile = new System.Windows.Forms.Button();
            this.tb_costumer = new System.Windows.Forms.TextBox();
            this.lb_costumer = new System.Windows.Forms.Label();
            this.bt_newSash = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pan_GeneralSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // pan_GeneralSettings
            // 
            this.pan_GeneralSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pan_GeneralSettings.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pan_GeneralSettings.Controls.Add(this.bt_generateIniFile);
            this.pan_GeneralSettings.Controls.Add(this.tb_costumer);
            this.pan_GeneralSettings.Controls.Add(this.lb_costumer);
            this.pan_GeneralSettings.Controls.Add(this.bt_newSash);
            this.pan_GeneralSettings.Controls.Add(this.button1);
            this.pan_GeneralSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_GeneralSettings.Location = new System.Drawing.Point(0, 0);
            this.pan_GeneralSettings.Name = "pan_GeneralSettings";
            this.pan_GeneralSettings.Size = new System.Drawing.Size(396, 579);
            this.pan_GeneralSettings.TabIndex = 2;
            // 
            // bt_generateIniFile
            // 
            this.bt_generateIniFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_generateIniFile.Location = new System.Drawing.Point(196, 518);
            this.bt_generateIniFile.Name = "bt_generateIniFile";
            this.bt_generateIniFile.Size = new System.Drawing.Size(188, 55);
            this.bt_generateIniFile.TabIndex = 4;
            this.bt_generateIniFile.Text = "Genereeer inibestand";
            this.bt_generateIniFile.UseVisualStyleBackColor = true;
            // 
            // tb_costumer
            // 
            this.tb_costumer.Location = new System.Drawing.Point(108, 17);
            this.tb_costumer.Margin = new System.Windows.Forms.Padding(2);
            this.tb_costumer.Name = "tb_costumer";
            this.tb_costumer.Size = new System.Drawing.Size(74, 22);
            this.tb_costumer.TabIndex = 3;
            // 
            // lb_costumer
            // 
            this.lb_costumer.AutoSize = true;
            this.lb_costumer.Location = new System.Drawing.Point(23, 19);
            this.lb_costumer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_costumer.Name = "lb_costumer";
            this.lb_costumer.Size = new System.Drawing.Size(35, 16);
            this.lb_costumer.TabIndex = 2;
            this.lb_costumer.Text = "klant";
            // 
            // bt_newSash
            // 
            this.bt_newSash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_newSash.Location = new System.Drawing.Point(3, 518);
            this.bt_newSash.Name = "bt_newSash";
            this.bt_newSash.Size = new System.Drawing.Size(179, 55);
            this.bt_newSash.TabIndex = 1;
            this.bt_newSash.Text = "Nieuwe deur";
            this.bt_newSash.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(235, 319);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // generalSettingPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pan_GeneralSettings);
            this.Name = "generalSettingPanel";
            this.Size = new System.Drawing.Size(396, 579);
            this.pan_GeneralSettings.ResumeLayout(false);
            this.pan_GeneralSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pan_GeneralSettings;
        private System.Windows.Forms.Button bt_generateIniFile;
        private System.Windows.Forms.TextBox tb_costumer;
        private System.Windows.Forms.Label lb_costumer;
        private System.Windows.Forms.Button bt_newSash;
        private System.Windows.Forms.Button button1;
    }
}
