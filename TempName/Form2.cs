using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;

namespace TempName
{
    public partial class Settings_Form : Form
    {
        public Settings_Form()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.FromArgb(21, 133, 181), ButtonBorderStyle.Solid);
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void Settings_Form_Load(object sender, EventArgs e)
        {
            UpdateSettings();
        }

        private void UpdateSettings()
        {
            IsDEBUG.Checked = bool.Parse(TempName.SettingsForm.GetSetting("IsDEBUG"));
            TimeOut_textBox.Text = TempName.SettingsForm.GetSetting("TimeOut");
            IsUsingLog.Checked = bool.Parse(TempName.SettingsForm.GetSetting("LogEnabled"));
            LogName_textBox.Text = TempName.SettingsForm.GetSetting("LogName");
            IsUsingName_Server.Checked = bool.Parse(TempName.SettingsForm.GetSetting("LookForServerEnabled"));
            ServerName_textBox.Text = TempName.SettingsForm.GetSetting("ServerName");
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IsDEBUG_CheckedChanged(object sender, EventArgs e)
        {
            CheckState state = IsDEBUG.CheckState;

            TempName.SettingsForm.SetSetting("IsDEBUG", IsDEBUG.Checked.ToString());
            TempName.SettingsForm.IsDEBUG = IsDEBUG.Checked;
        }

        private void TimeOut_textBox_TextChanged(object sender, EventArgs e)
        {
            this.Text = TimeOut_textBox.Text;
        }
        private void TimeOut_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TempName.SettingsForm.SetSetting("TimeOut", TimeOut_textBox.Text);
                TempName.SettingsForm.TimeOut = int.Parse(TimeOut_textBox.Text);
            }
        }

        private void IsUsingLog_CheckedChanged(object sender, EventArgs e)
        {
            CheckState state = IsUsingLog.CheckState;

            TempName.SettingsForm.SetSetting("LogEnabled", IsUsingLog.Checked.ToString());
            TempName.SettingsForm.IsUsingLog = IsUsingLog.Checked;
        }
        private void LogName_textBox_TextChanged(object sender, EventArgs e)
        {
            this.Text = LogName_textBox.Text;
        }
        private void LogName_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TempName.SettingsForm.SetSetting("LogName", LogName_textBox.Text);
                TempName.SettingsForm.Log = string.Format("{0}\\{1}", Directory.GetCurrentDirectory(), LogName_textBox.Text);
            }
        }

        private void IsUsingName_Server_CheckedChanged(object sender, EventArgs e)
        {
            CheckState state = this.IsUsingName_Server.CheckState;

            TempName.SettingsForm.SetSetting("LookForServerEnabled", IsUsingName_Server.Checked.ToString());
            TempName.SettingsForm.IsUsingName_Server = IsUsingName_Server.Checked;
        }
        private void ServerName_textBox_TextChanged(object sender, EventArgs e)
        {
            this.Text = ServerName_textBox.Text;
        }
        private void ServerName_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TempName.SettingsForm.SetSetting("ServerName", ServerName_textBox.Text);
                TempName.SettingsForm.ServerName = ServerName_textBox.Text;
            }
        }

        private void move_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
    }
}
