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
            this.tb_description = new System.Windows.Forms.TextBox();
            this.lb_descriction = new System.Windows.Forms.Label();
            this.pan_GeneralSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // pan_GeneralSettings
            // 
            this.pan_GeneralSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pan_GeneralSettings.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pan_GeneralSettings.Controls.Add(this.tb_description);
            this.pan_GeneralSettings.Controls.Add(this.lb_descriction);
            this.pan_GeneralSettings.Controls.Add(this.bt_generateIniFile);
            this.pan_GeneralSettings.Controls.Add(this.tb_costumer);
            this.pan_GeneralSettings.Controls.Add(this.lb_costumer);
            this.pan_GeneralSettings.Controls.Add(this.bt_newSash);
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
            this.bt_generateIniFile.Click += new System.EventHandler(this.bt_generateIniFile_Click);
            // 
            // tb_costumer
            // 
            this.tb_costumer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_costumer.Location = new System.Drawing.Point(108, 17);
            this.tb_costumer.Margin = new System.Windows.Forms.Padding(2);
            this.tb_costumer.Name = "tb_costumer";
            this.tb_costumer.Size = new System.Drawing.Size(276, 22);
            this.tb_costumer.TabIndex = 3;
            this.tb_costumer.TextChanged += new System.EventHandler(this.tb_costumer_TextChanged);
            // 
            // lb_costumer
            // 
            this.lb_costumer.AutoSize = true;
            this.lb_costumer.Location = new System.Drawing.Point(11, 20);
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
            this.bt_newSash.Click += new System.EventHandler(this.bt_newSash_Click_1);
            // 
            // tb_description
            // 
            this.tb_description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_description.Location = new System.Drawing.Point(108, 43);
            this.tb_description.Margin = new System.Windows.Forms.Padding(2);
            this.tb_description.Name = "tb_description";
            this.tb_description.Size = new System.Drawing.Size(276, 22);
            this.tb_description.TabIndex = 6;
            this.tb_description.TextChanged += new System.EventHandler(this.tb_description_TextChanged);
            // 
            // lb_descriction
            // 
            this.lb_descriction.AutoSize = true;
            this.lb_descriction.Location = new System.Drawing.Point(11, 46);
            this.lb_descriction.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_descriction.Name = "lb_descriction";
            this.lb_descriction.Size = new System.Drawing.Size(82, 16);
            this.lb_descriction.TabIndex = 5;
            this.lb_descriction.Text = "omschrijving";
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
        private System.Windows.Forms.TextBox tb_description;
        private System.Windows.Forms.Label lb_descriction;
    }
}
