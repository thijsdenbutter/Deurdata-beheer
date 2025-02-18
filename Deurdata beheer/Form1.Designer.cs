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
            this.pan_Menu = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.pan_GeneralSettings = new System.Windows.Forms.Panel();
            this.cb_GeneralSettings = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.pan_Menu);
            this.splitContainer1.Size = new System.Drawing.Size(2952, 1622);
            this.splitContainer1.SplitterDistance = 1932;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // pan_Menu
            // 
            this.pan_Menu.Controls.Add(this.checkBox1);
            this.pan_Menu.Controls.Add(this.pan_GeneralSettings);
            this.pan_Menu.Controls.Add(this.cb_GeneralSettings);
            this.pan_Menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_Menu.Location = new System.Drawing.Point(0, 0);
            this.pan_Menu.Name = "pan_Menu";
            this.pan_Menu.Size = new System.Drawing.Size(1017, 1622);
            this.pan_Menu.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBox1.Location = new System.Drawing.Point(0, 1221);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(1017, 27);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Algemene instellingen";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // pan_GeneralSettings
            // 
            this.pan_GeneralSettings.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pan_GeneralSettings.Controls.Add(this.button1);
            this.pan_GeneralSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.pan_GeneralSettings.Location = new System.Drawing.Point(0, 27);
            this.pan_GeneralSettings.Name = "pan_GeneralSettings";
            this.pan_GeneralSettings.Size = new System.Drawing.Size(1017, 1194);
            this.pan_GeneralSettings.TabIndex = 1;
            // 
            // cb_GeneralSettings
            // 
            this.cb_GeneralSettings.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_GeneralSettings.AutoSize = true;
            this.cb_GeneralSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.cb_GeneralSettings.Location = new System.Drawing.Point(0, 0);
            this.cb_GeneralSettings.Name = "cb_GeneralSettings";
            this.cb_GeneralSettings.Size = new System.Drawing.Size(1017, 27);
            this.cb_GeneralSettings.TabIndex = 0;
            this.cb_GeneralSettings.Text = "Algemene instellingen";
            this.cb_GeneralSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cb_GeneralSettings.UseVisualStyleBackColor = true;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2952, 1622);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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
    }
}

