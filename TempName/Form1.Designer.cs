using System;
using System.Drawing;

namespace TempName
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.CheckServers = new System.Windows.Forms.Button();
            this.IP_Address = new System.Windows.Forms.ListBox();
            this.Server_Name = new System.Windows.Forms.ListBox();
            this.UUID = new System.Windows.Forms.ListBox();
            this.Player_Name = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.serverAndPlayerCheckerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.Button();
            this.Minimise = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CheckServers
            // 
            this.CheckServers.BackColor = System.Drawing.SystemColors.Control;
            this.CheckServers.Location = new System.Drawing.Point(801, 429);
            this.CheckServers.Name = "CheckServers";
            this.CheckServers.Size = new System.Drawing.Size(121, 25);
            this.CheckServers.TabIndex = 1;
            this.CheckServers.Text = "Check Servers";
            this.CheckServers.UseVisualStyleBackColor = false;
            this.CheckServers.Click += new System.EventHandler(this.CheckServers_Click);
            // 
            // IP_Address
            // 
            this.IP_Address.FormattingEnabled = true;
            this.IP_Address.ItemHeight = 14;
            this.IP_Address.Location = new System.Drawing.Point(453, 72);
            this.IP_Address.Name = "IP_Address";
            this.IP_Address.Size = new System.Drawing.Size(144, 340);
            this.IP_Address.TabIndex = 2;
            this.IP_Address.SelectedIndexChanged += new System.EventHandler(this.IP_Address_SelectedIndexChanged);
            // 
            // Server_Name
            // 
            this.Server_Name.FormattingEnabled = true;
            this.Server_Name.ItemHeight = 14;
            this.Server_Name.Location = new System.Drawing.Point(12, 72);
            this.Server_Name.Name = "Server_Name";
            this.Server_Name.Size = new System.Drawing.Size(435, 340);
            this.Server_Name.TabIndex = 3;
            this.Server_Name.SelectedIndexChanged += new System.EventHandler(this.Server_Name_SelectedIndexChanged);
            // 
            // UUID
            // 
            this.UUID.FormattingEnabled = true;
            this.UUID.ItemHeight = 14;
            this.UUID.Location = new System.Drawing.Point(768, 73);
            this.UUID.Name = "UUID";
            this.UUID.Size = new System.Drawing.Size(154, 340);
            this.UUID.TabIndex = 4;
            this.UUID.SelectedIndexChanged += new System.EventHandler(this.UUID_SelectedIndexChanged);
            // 
            // Player_Name
            // 
            this.Player_Name.FormattingEnabled = true;
            this.Player_Name.ItemHeight = 14;
            this.Player_Name.Location = new System.Drawing.Point(603, 72);
            this.Player_Name.Name = "Player_Name";
            this.Player_Name.Size = new System.Drawing.Size(159, 340);
            this.Player_Name.TabIndex = 5;
            this.Player_Name.SelectedIndexChanged += new System.EventHandler(this.Player_Name_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 421);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Log:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 439);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "Null";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Sever Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(453, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "IP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(603, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 14);
            this.label5.TabIndex = 10;
            this.label5.Text = "Player name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(768, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 14);
            this.label6.TabIndex = 11;
            this.label6.Text = "Player UID";
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuStrip1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverAndPlayerCheckerToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(943, 36);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.move_MouseDown);
            // 
            // serverAndPlayerCheckerToolStripMenuItem
            // 
            this.serverAndPlayerCheckerToolStripMenuItem.Name = "serverAndPlayerCheckerToolStripMenuItem";
            this.serverAndPlayerCheckerToolStripMenuItem.Size = new System.Drawing.Size(164, 32);
            this.serverAndPlayerCheckerToolStripMenuItem.Text = "Server and Player Checker";
            // 
            // Exit
            // 
            this.Exit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Exit.BackgroundImage")));
            this.Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Exit.Location = new System.Drawing.Point(908, 8);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(23, 23);
            this.Exit.TabIndex = 13;
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Minimise
            // 
            this.Minimise.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Minimise.BackgroundImage")));
            this.Minimise.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Minimise.Location = new System.Drawing.Point(879, 8);
            this.Minimise.Name = "Minimise";
            this.Minimise.Size = new System.Drawing.Size(23, 23);
            this.Minimise.TabIndex = 14;
            this.Minimise.UseVisualStyleBackColor = true;
            this.Minimise.Click += new System.EventHandler(this.Minimise_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 469);
            this.Controls.Add(this.Minimise);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Player_Name);
            this.Controls.Add(this.UUID);
            this.Controls.Add(this.Server_Name);
            this.Controls.Add(this.IP_Address);
            this.Controls.Add(this.CheckServers);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server Checker";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Exit_MouseDown(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.Button CheckServers;
        private System.Windows.Forms.ListBox IP_Address;
        private System.Windows.Forms.ListBox Server_Name;
        private System.Windows.Forms.ListBox UUID;
        private System.Windows.Forms.ListBox Player_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem serverAndPlayerCheckerToolStripMenuItem;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button Minimise;
    }
}