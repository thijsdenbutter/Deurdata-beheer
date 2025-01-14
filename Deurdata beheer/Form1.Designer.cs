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
            this.flp_menu = new System.Windows.Forms.FlowLayoutPanel();
            this.cb_generalSettingVisible = new System.Windows.Forms.CheckBox();
            this.pan_generalSettings = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flp_menu.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.flp_menu);
            this.splitContainer1.Size = new System.Drawing.Size(2093, 1040);
            this.splitContainer1.SplitterDistance = 1370;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // flp_menu
            // 
            this.flp_menu.AutoScroll = true;
            this.flp_menu.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.flp_menu.Controls.Add(this.cb_generalSettingVisible);
            this.flp_menu.Controls.Add(this.pan_generalSettings);
            this.flp_menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_menu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_menu.Location = new System.Drawing.Point(0, 0);
            this.flp_menu.Margin = new System.Windows.Forms.Padding(0);
            this.flp_menu.Name = "flp_menu";
            this.flp_menu.Padding = new System.Windows.Forms.Padding(10);
            this.flp_menu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flp_menu.Size = new System.Drawing.Size(720, 1040);
            this.flp_menu.TabIndex = 0;
            this.flp_menu.WrapContents = false;
            // 
            // cb_generalSettingVisible
            // 
            this.cb_generalSettingVisible.Appearance = System.Windows.Forms.Appearance.Button;
            this.cb_generalSettingVisible.BackColor = System.Drawing.SystemColors.ControlDark;
            this.cb_generalSettingVisible.Font = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_generalSettingVisible.Location = new System.Drawing.Point(50, 13);
            this.cb_generalSettingVisible.Name = "cb_generalSettingVisible";
            this.cb_generalSettingVisible.Size = new System.Drawing.Size(647, 55);
            this.cb_generalSettingVisible.TabIndex = 5;
            this.cb_generalSettingVisible.Text = "Project instellingen";
            this.cb_generalSettingVisible.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cb_generalSettingVisible.UseVisualStyleBackColor = false;
            this.cb_generalSettingVisible.CheckedChanged += new System.EventHandler(this.cb_generalSettingVisible_CheckedChanged);
            // 
            // pan_generalSettings
            // 
            this.pan_generalSettings.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pan_generalSettings.Location = new System.Drawing.Point(50, 74);
            this.pan_generalSettings.Name = "pan_generalSettings";
            this.pan_generalSettings.Size = new System.Drawing.Size(647, 408);
            this.pan_generalSettings.TabIndex = 6;
            this.pan_generalSettings.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2093, 1040);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flp_menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flp_menu;
        private System.Windows.Forms.CheckBox cb_generalSettingVisible;
        private System.Windows.Forms.Panel pan_generalSettings;
    }
}

