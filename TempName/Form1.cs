using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

using Newtonsoft.Json;

namespace TempName
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void UUID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Player_Name.SelectedIndex = UUID.SelectedIndex;
        }

        private void Player_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            UUID.SelectedIndex = Player_Name.SelectedIndex;
        }

        private void IP_Address_SelectedIndexChanged(object sender, EventArgs e)
        {
            Server_Name.SelectedIndex = IP_Address.SelectedIndex;
        }

        private void Server_Name_SelectedIndexChanged(object sender, EventArgs e)
        {
            IP_Address.SelectedIndex = Server_Name.SelectedIndex;
        }

        private static void UpdateSettings()
        {
            TempName.SettingsForm.IsDEBUG = bool.Parse(TempName.SettingsForm.GetSetting("IsDEBUG"));
            TempName.SettingsForm.TimeOut = int.Parse(TempName.SettingsForm.GetSetting("TimeOut"));
            TempName.SettingsForm.IsUsingLog = bool.Parse(TempName.SettingsForm.GetSetting("LogEnabled"));
            TempName.SettingsForm.Log = string.Format("{0}\\{1}", Directory.GetCurrentDirectory(), TempName.SettingsForm.GetSetting("LogName"));
            TempName.SettingsForm.IsUsingName_Server = bool.Parse(TempName.SettingsForm.GetSetting("LookForServerEnabled"));
            TempName.SettingsForm.ServerName = TempName.SettingsForm.GetSetting("ServerName");
        }

        private void CheckServers_Click(object sender, EventArgs e)
        {
            UpdateSettings();

            var text = new StringBuilder();

            try
            {
                string ServerList_ = TempName.SettingsForm.wc.DownloadString(TempName.SettingsForm.MasterServer);
                dynamic ServerList = JsonConvert.DeserializeObject(ServerList_);
                
                foreach (string Host in ServerList.result.servers)
                {
                    try
                    {
                        string HostJSON_ = TempName.SettingsForm.wc.DownloadString(String.Format("http://{0}", Host));
                        dynamic HostJSON = JsonConvert.DeserializeObject(HostJSON_);
                        string ServerName = HostJSON.name;
                        int numPlayers = HostJSON.numPlayers;
                        int maxPlayers = HostJSON.maxPlayers;
                        dynamic PlayerList = HostJSON.players;

                        if (TempName.SettingsForm.IsUsingName_Server.Equals(true))
                        {
                            if (ServerName.Contains(TempName.SettingsForm.ServerName))
                            {
                                IP_Address.Items.Add(Host);
                                Server_Name.Items.Add(ServerName);

                                if (numPlayers.Equals(0))
                                {
                                    label2.Text = (Errors.NoPlayersFoundMessage);
                                    text.AppendLine(Errors.NoPlayersFoundMessage);
                                }
                                else if (HostJSON_.Contains("passworded"))
                                {
                                    label2.Text = (Errors.PasswordServerMessage);
                                    text.AppendLine(Errors.PasswordServerMessage);
                                }
                                else
                                {
                                    if (numPlayers.Equals(maxPlayers))
                                    {
                                        label2.Text = (Errors.FullServerMessage);
                                        text.AppendLine(Errors.FullServerMessage);
                                    }
                                    else
                                    {
                                        for (int i = 0; i < numPlayers; i++)
                                        {
                                            dynamic Player = PlayerList[i];

                                            if (Player.name == null && Player.uid == null)
                                            {
                                                Player_Name.Items.Add(Errors.PlayerHasNoNameMessage);
                                                UUID.Items.Add(Errors.PlayerHasNoUIDMessage);
                                            }
                                            else
                                            {
                                                this.Player_Name.Items.Add(Player.name);
                                                this.UUID.Items.Add(Player.uid);
                                            }
                                        }
                                    }
                                }
                                text.AppendLine(Environment.NewLine);
                            }
                        }
                        else
                        {
                            IP_Address.Items.Add(Host);
                            Server_Name.Items.Add(ServerName);

                            if (numPlayers.Equals(0))
                                label2.Text = (Errors.NoPlayersFoundMessage);
                            else if (HostJSON_.Contains("passworded"))
                                label2.Text = (Errors.PasswordServerMessage);
                            else
                            {
                                if (numPlayers.Equals(maxPlayers))
                                {
                                    label2.Text = (Errors.FullServerMessage);
                                    text.AppendLine(Errors.FullServerMessage);
                                }
                                else
                                {
                                    for (int i = 0; i < numPlayers; i++)
                                    {
                                        dynamic Player = PlayerList[i];

                                        if (Player.name == null && Player.uid == null)
                                        {
                                            Player_Name.Items.Add(Errors.PlayerHasNoNameMessage);
                                            UUID.Items.Add(Errors.PlayerHasNoUIDMessage);
                                        }
                                        else
                                        {
                                            this.Player_Name.Items.Add(Player.name);
                                            this.UUID.Items.Add(Player.uid);
                                        }
                                    }
                                }
                            }
                        }
                        text.AppendLine(Environment.NewLine);
                    }
                    catch (Exception) // ex)
                    {
                        switch (TempName.SettingsForm.IsDEBUG.Equals(true))
                        {
                            case true:
                                break;

                            case false:
                                label2.Text = (Errors.HostNotConnetMessage + Environment.NewLine);
                                break;
                        }
                    }
                }
            }
            catch (Exception) // ex)
            {
                switch (TempName.SettingsForm.IsDEBUG.Equals(true))
                {
                    case true:
                        break;

                    case false:
                        label2.Text = (Errors.MasterServerNotConnetMessage);
                        break;
                }
            }
            label2.Text = ("Complete");
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Minimise_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void move_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            var form = Application.OpenForms.OfType<Settings_Form>().FirstOrDefault();
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                Settings_Form Form_Settings = new Settings_Form();
                Form_Settings.StartPosition = FormStartPosition.Manual;
                Form_Settings.Location = new Point(Location.X, Location.Y - (Form_Settings.Size.Height + 5));
                Form_Settings.Show();
            }
        }
    }
}
