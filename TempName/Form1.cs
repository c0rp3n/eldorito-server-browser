using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

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
            Settings.IsUsingLog = Boolean.Parse(Settings.GetSetting("LogEnabled"));
            Settings.Log = String.Format("{0}\\{1}", Directory.GetCurrentDirectory(), Settings.GetSetting("LogName"));
            Settings.TimeOut = Int32.Parse(Settings.GetSetting("TimeOut"));
            Settings.IsUsingName_Server = Boolean.Parse(Settings.GetSetting("LookForServerEnabled"));
            Settings.ServerName = Settings.GetSetting("ServerName");
            Settings.IsPassworded = false;
        }

        private void CheckServers_Click(object sender, EventArgs e)
        {
            UpdateSettings();

            var text = new StringBuilder();

            try
            {
                dynamic ServerList = JsonConvert.DeserializeObject(Settings.wc.DownloadString(Settings.MasterServer));

                foreach (string Host in ServerList.result.servers)
                {
                    try
                    {
                        dynamic HostJSON = JsonConvert.DeserializeObject(Settings.wc.DownloadString(String.Format("http://{0}", Host)));
                        string ServerName = HostJSON.name;
                        int numPlayers = HostJSON.numPlayers;
                        dynamic PlayerList = HostJSON.players;

                        foreach (dynamic prop in HostJSON)
                        {
                            if (prop.Name.Equals("passworded"))
                            {
                                Settings.IsPassworded = true;
                            }
                        }

                        if (Settings.IsUsingName_Server.Equals(true))
                        {
                            if (ServerName.Contains(Settings.ServerName))
                            {
                                IP_Address.Items.Add(Host);
                                Server_Name.Items.Add(ServerName);

                                if (numPlayers.Equals(0))
                                {
                                    label2.Text = (Errors.NoPlayersFoundMessage);
                                    text.AppendLine(Errors.NoPlayersFoundMessage);
                                }
                                else if (Settings.IsPassworded.Equals(true))
                                {
                                    label2.Text = (Errors.PasswordServerMessage);
                                    text.AppendLine(Errors.PasswordServerMessage);

                                    Settings.IsPassworded = false;
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
                                            Player_Name.Items.Add(Player.name);
                                            UUID.Items.Add(Player.uid);
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
                            {
                                label2.Text = (Errors.NoPlayersFoundMessage);
                            }
                            else if (Settings.IsPassworded.Equals(true))
                            {
                                label2.Text = (Errors.PasswordServerMessage);

                                Settings.IsPassworded = false;
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
                                        Player_Name.Items.Add(Player.name);
                                        UUID.Items.Add(Player.uid);
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        switch (Settings.IsDEBUG.Equals(true))
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
            catch (Exception ex)
            {
                switch (Settings.IsDEBUG.Equals(true))
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
    }
}
