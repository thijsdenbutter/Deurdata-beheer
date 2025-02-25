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
            this.pan_Menu = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.pan_GeneralSettings = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.cb_GeneralSettings = new System.Windows.Forms.CheckBox();
            this.bt_newSash = new System.Windows.Forms.Button();
            this.pan_Sashes = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.pan_Menu.SuspendLayout();
            this.pan_GeneralSettings.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(2121, 1466);
            this.splitContainer1.SplitterDistance = 1388;
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
            this.splitContainer2.Size = new System.Drawing.Size(1388, 1466);
            this.splitContainer2.SplitterDistance = 202;
            this.splitContainer2.TabIndex = 0;
            // 
            // pan_Menu
            // 
            this.pan_Menu.Controls.Add(this.checkBox1);
            this.pan_Menu.Controls.Add(this.pan_GeneralSettings);
            this.pan_Menu.Controls.Add(this.cb_GeneralSettings);
            this.pan_Menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_Menu.Location = new System.Drawing.Point(0, 0);
            this.pan_Menu.Name = "pan_Menu";
            this.pan_Menu.Size = new System.Drawing.Size(730, 1466);
            this.pan_Menu.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBox1.Location = new System.Drawing.Point(0, 1221);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(730, 27);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Algemene instellingen";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // pan_GeneralSettings
            // 
            this.pan_GeneralSettings.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pan_GeneralSettings.Controls.Add(this.bt_newSash);
            this.pan_GeneralSettings.Controls.Add(this.button1);
            this.pan_GeneralSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.pan_GeneralSettings.Location = new System.Drawing.Point(0, 27);
            this.pan_GeneralSettings.Name = "pan_GeneralSettings";
            this.pan_GeneralSettings.Size = new System.Drawing.Size(730, 1194);
            this.pan_GeneralSettings.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(235, 319);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cb_GeneralSettings
            // 
            this.cb_GeneralSettings.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_GeneralSettings.AutoSize = true;
            this.cb_GeneralSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.cb_GeneralSettings.Location = new System.Drawing.Point(0, 0);
            this.cb_GeneralSettings.Name = "cb_GeneralSettings";
            this.cb_GeneralSettings.Size = new System.Drawing.Size(730, 27);
            this.cb_GeneralSettings.TabIndex = 0;
            this.cb_GeneralSettings.Text = "Algemene instellingen";
            this.cb_GeneralSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cb_GeneralSettings.UseVisualStyleBackColor = true;
            this.cb_GeneralSettings.CheckedChanged += new System.EventHandler(this.cb_GeneralSettings_CheckedChanged);
            // 
            // bt_newSash
            // 
            this.bt_newSash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_newSash.Location = new System.Drawing.Point(3, 1133);
            this.bt_newSash.Name = "bt_newSash";
            this.bt_newSash.Size = new System.Drawing.Size(275, 55);
            this.bt_newSash.TabIndex = 1;
            this.bt_newSash.Text = "Nieuwe deur";
            this.bt_newSash.UseVisualStyleBackColor = true;
            this.bt_newSash.Click += new System.EventHandler(this.bt_newSash_Click);
            // 
            // pan_Sashes
            // 
            this.pan_Sashes.AutoScroll = true;
            this.pan_Sashes.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pan_Sashes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_Sashes.Location = new System.Drawing.Point(0, 0);
            this.pan_Sashes.Name = "pan_Sashes";
            this.pan_Sashes.Padding = new System.Windows.Forms.Padding(5);
            this.pan_Sashes.Size = new System.Drawing.Size(202, 1466);
            this.pan_Sashes.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2121, 1466);
            this.Controls.Add(this.splitContainer1);
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
            this.pan_GeneralSettings.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pan_Menu;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel pan_GeneralSettings;
        private System.Windows.Forms.CheckBox cb_GeneralSettings;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button bt_newSash;
        private System.Windows.Forms.Panel pan_Sashes;
    }
}

