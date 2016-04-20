namespace TempName
{
    partial class Settings_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings_Form));
            this.Exit = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.serverAndPlayerCheckerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IsUsingLog = new System.Windows.Forms.CheckBox();
            this.IsUsingName_Server = new System.Windows.Forms.CheckBox();
            this.IsDEBUG = new System.Windows.Forms.CheckBox();
            this.LogName_textBox = new System.Windows.Forms.TextBox();
            this.ServerName_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TimeOut_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(133)))), ((int)(((byte)(181)))));
            this.Exit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Exit.BackgroundImage")));
            this.Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Exit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(133)))), ((int)(((byte)(181)))));
            this.Exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(174)))), ((int)(((byte)(206)))));
            this.Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(174)))), ((int)(((byte)(206)))));
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.Location = new System.Drawing.Point(367, 8);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(23, 23);
            this.Exit.TabIndex = 16;
            this.Exit.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(133)))), ((int)(((byte)(181)))));
            this.menuStrip1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverAndPlayerCheckerToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(397, 36);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.move_MouseDown);
            // 
            // serverAndPlayerCheckerToolStripMenuItem
            // 
            this.serverAndPlayerCheckerToolStripMenuItem.Name = "serverAndPlayerCheckerToolStripMenuItem";
            this.serverAndPlayerCheckerToolStripMenuItem.Size = new System.Drawing.Size(64, 32);
            this.serverAndPlayerCheckerToolStripMenuItem.Text = "Settings";
            // 
            // IsUsingLog
            // 
            this.IsUsingLog.AutoSize = true;
            this.IsUsingLog.Location = new System.Drawing.Point(12, 76);
            this.IsUsingLog.Name = "IsUsingLog";
            this.IsUsingLog.Size = new System.Drawing.Size(85, 18);
            this.IsUsingLog.TabIndex = 17;
            this.IsUsingLog.Text = "Log Enabled";
            this.IsUsingLog.UseVisualStyleBackColor = true;
            this.IsUsingLog.CheckedChanged += new System.EventHandler(this.IsUsingLog_CheckedChanged);
            // 
            // IsUsingName_Server
            // 
            this.IsUsingName_Server.AutoSize = true;
            this.IsUsingName_Server.Location = new System.Drawing.Point(12, 102);
            this.IsUsingName_Server.Name = "IsUsingName_Server";
            this.IsUsingName_Server.Size = new System.Drawing.Size(145, 18);
            this.IsUsingName_Server.TabIndex = 17;
            this.IsUsingName_Server.Text = "Look For Server Enabled";
            this.IsUsingName_Server.UseVisualStyleBackColor = true;
            this.IsUsingName_Server.CheckedChanged += new System.EventHandler(this.IsUsingName_Server_CheckedChanged);
            // 
            // IsDEBUG
            // 
            this.IsDEBUG.AutoSize = true;
            this.IsDEBUG.Location = new System.Drawing.Point(12, 50);
            this.IsDEBUG.Name = "IsDEBUG";
            this.IsDEBUG.Size = new System.Drawing.Size(102, 18);
            this.IsDEBUG.TabIndex = 17;
            this.IsDEBUG.Text = "DEBUG Enabled";
            this.IsDEBUG.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.IsDEBUG.UseVisualStyleBackColor = true;
            this.IsDEBUG.CheckedChanged += new System.EventHandler(this.IsDEBUG_CheckedChanged);
            // 
            // LogName_textBox
            // 
            this.LogName_textBox.Location = new System.Drawing.Point(285, 74);
            this.LogName_textBox.Name = "LogName_textBox";
            this.LogName_textBox.Size = new System.Drawing.Size(100, 20);
            this.LogName_textBox.TabIndex = 18;
            this.LogName_textBox.TextChanged += new System.EventHandler(this.LogName_textBox_TextChanged);
            this.LogName_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LogName_textBox_KeyDown);
            // 
            // ServerName_textBox
            // 
            this.ServerName_textBox.Location = new System.Drawing.Point(285, 100);
            this.ServerName_textBox.Name = "ServerName_textBox";
            this.ServerName_textBox.Size = new System.Drawing.Size(100, 20);
            this.ServerName_textBox.TabIndex = 18;
            this.ServerName_textBox.TextChanged += new System.EventHandler(this.ServerName_textBox_TextChanged);
            this.ServerName_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ServerName_textBox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(224, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 19;
            this.label1.Text = "Log Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 19;
            this.label2.Text = "Server Name";
            // 
            // TimeOut_textBox
            // 
            this.TimeOut_textBox.Location = new System.Drawing.Point(285, 48);
            this.TimeOut_textBox.Name = "TimeOut_textBox";
            this.TimeOut_textBox.Size = new System.Drawing.Size(100, 20);
            this.TimeOut_textBox.TabIndex = 18;
            this.TimeOut_textBox.TextChanged += new System.EventHandler(this.TimeOut_textBox_TextChanged);
            this.TimeOut_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TimeOut_textBox_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(235, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 14);
            this.label3.TabIndex = 19;
            this.label3.Text = "Timeout";
            // 
            // Settings_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(397, 129);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TimeOut_textBox);
            this.Controls.Add(this.ServerName_textBox);
            this.Controls.Add(this.LogName_textBox);
            this.Controls.Add(this.IsDEBUG);
            this.Controls.Add(this.IsUsingName_Server);
            this.Controls.Add(this.IsUsingLog);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Arial", 8.25F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Settings_Form";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Form_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem serverAndPlayerCheckerToolStripMenuItem;
        private System.Windows.Forms.CheckBox IsUsingLog;
        private System.Windows.Forms.CheckBox IsUsingName_Server;
        private System.Windows.Forms.CheckBox IsDEBUG;
        private System.Windows.Forms.TextBox LogName_textBox;
        private System.Windows.Forms.TextBox ServerName_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TimeOut_textBox;
        private System.Windows.Forms.Label label3;
    }
}