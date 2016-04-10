using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

using Newtonsoft.Json;

namespace TempName
{
    class Program
    {
        static void Main()
        {
            var text = new StringBuilder();

            if (IsUsingLog.Equals(false))
            {
                if (IsUsingName.Equals(false))
                {
                    while (true)
                    {
                        Using_NoLog();
                        Sleep();
                    }
                }
                else
                {
                    while (true)
                    {
                        UsingName_NoLog();
                        Sleep();
                    }
                }
            }
            else
            {
                if (IsUsingName.Equals(false))
                {
                    while (true)
                    {
                        Using_Log(text);
                        Sleep();
                    }
                }
                else
                {
                    while (true)
                    {
                        UsingName_Log(text);
                        Sleep();
                    }
                }
            }
        }

        #region Variable Declaration
        static WebClient wc = new WebClient();

        static bool IsUsingName { get; } = Properties.Settings.Default.IsUsingName;

        static bool IsUsingLog { get; } = Properties.Settings.Default.IsUsingLog;

        static int RefreshRate { get; } = Properties.Settings.Default.RefreshRate;

        static string MasterServer { get; } = SetMasterServer();

        static dynamic ServerList = JsonConvert.DeserializeObject(wc.DownloadString(SetMasterServer()));

        static string NameContains { get; } = Properties.Settings.Default.ServerNameContainsThis;

        static string Log { get; } = String.Format("{0}\\{1}", Directory.GetCurrentDirectory(), Properties.Settings.Default.LogFilePathAndName);

        static string _PlayerName { get; } = Properties.Settings.Default.PlayerName;

        static string _PlayerUID { get; } = Properties.Settings.Default.PlayerUID;
        #endregion
        #region Error Messages
        static string MasterServerNotConnetMessage { get; } = String.Format("Cannot reach master server");

        static string HostNotConnetMessage { get; } = String.Format("Cannot reach host!");

        static string NoPlayersFoundMessage { get; } = String.Format("======== No players found! =======");

        static string PlayerHasNoNameMessage { get; } = String.Format("======= Player has no name!=======");

        static string PlayerHasNoUIDMessage { get; } = String.Format("======= Player has no uid!=======");
        #endregion
        #region Helper Functions
        private static void Sleep()
        {
            Console.Clear();
            for (int i = Properties.Settings.Default.RefreshRate * 1; i > 0; i--)
            {
                Console.WriteLine("Waiting {0} seconds!", i);
                Thread.Sleep(1000);
                Console.Clear();
            }
        }

        private static string SetMasterServer()
        {
            dynamic DewritoJSON = JsonConvert.DeserializeObject(wc.DownloadString("https://raw.githubusercontent.com/ElDewrito/ElDorito/master/dewrito.json"));

            foreach (dynamic masterServer in DewritoJSON.masterServers)
            {
                return masterServer.list;
            }
            return "";
        }

        private static void LogFile(string Input)
        {
            var text = new StringBuilder();

            if (File.Exists(Log))
            {
                foreach (string s in File.ReadAllLines(Log))
                {
                    text.AppendLine(s.ToString());
                }

                text.AppendLine(DateTime.Now.ToString());
                text.AppendLine(Environment.NewLine);
                text.AppendLine(Input);
            }
            else
            {
                text.AppendLine(DateTime.Now.ToString());
                text.AppendLine(Environment.NewLine);
                text.AppendLine(Input);
            }

            using (var file = new StreamWriter(File.Create(Log)))
            {
                file.Write(text.ToString());
            }
        }
        #endregion
        #region Main Functions
        private static void Using_Log(StringBuilder text)
        {
            try
            {
                dynamic ServerList = JsonConvert.DeserializeObject(wc.DownloadString(MasterServer));

                foreach (string Host in ServerList.result.servers)
                {
                    try
                    {
                        dynamic HostJSON = JsonConvert.DeserializeObject(wc.DownloadString(String.Format("http://{0}", Host)));
                        string ServerName = HostJSON.name;
                        int numPlayers = HostJSON.numPlayers;
                        dynamic PlayerList = HostJSON.players;


                        Console.WriteLine("IP: {0} Host: {1}", Host, ServerName);
                        text.AppendLine(String.Format("IP: {0} Host: {1}", Host, ServerName));

                        if (numPlayers.Equals(0))
                        {
                            Console.WriteLine(NoPlayersFoundMessage);
                            text.AppendLine(NoPlayersFoundMessage);
                        }
                        else
                        {
                            for (int i = 0; i < numPlayers; i++)
                            {
                                dynamic Player = PlayerList[i];

                                if (Player.name.Equals(null) && Player.uid.Equals(null).Equals(true))
                                {
                                    Console.WriteLine("{0} or {1}", PlayerHasNoNameMessage, PlayerHasNoUIDMessage);
                                    text.AppendLine(String.Format("{0} or {1}", PlayerHasNoNameMessage, PlayerHasNoUIDMessage));
                                }
                                else
                                {
                                    Console.WriteLine("UID: {1} Name: {0}", Player.name, Player.uid);
                                    text.AppendLine(String.Format("UID: {1} Name: {0}", Player.name, Player.uid));
                                }
                            }
                        }
                        Console.WriteLine(Environment.NewLine);
                        text.AppendLine(Environment.NewLine);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(HostNotConnetMessage + Environment.NewLine);
                        text.AppendLine(HostNotConnetMessage + Environment.NewLine);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine(MasterServerNotConnetMessage + Environment.NewLine);
                text.AppendLine(MasterServerNotConnetMessage + Environment.NewLine);
            }
            finally
            {
                LogFile(text.ToString());
                text.Clear();
            }
        }

        private static void Using_NoLog()
        {
            try
            {
                dynamic ServerList = JsonConvert.DeserializeObject(wc.DownloadString(MasterServer));

                foreach (string Host in ServerList.result.servers)
                {
                    try
                    {
                        dynamic HostJSON = JsonConvert.DeserializeObject(wc.DownloadString(String.Format("http://{0}", Host)));
                        string ServerName = HostJSON.name;
                        int numPlayers = HostJSON.numPlayers;
                        dynamic PlayerList = HostJSON.players;


                        Console.WriteLine("IP: {0} Host: {1}", Host, ServerName);

                        if (numPlayers.Equals(0))
                        {
                            Console.WriteLine(NoPlayersFoundMessage);
                        }
                        else
                        {
                            for (int i = 0; i < numPlayers; i++)
                            {
                                dynamic Player = PlayerList[i];

                                if (Player.name.Equals(null) && Player.uid.Equals(null).Equals(true))
                                {
                                    Console.WriteLine("{0} or {1}", PlayerHasNoNameMessage, PlayerHasNoUIDMessage);
                                }
                                else
                                {
                                    Console.WriteLine("UID: {1} Name: {0}", Player.name, Player.uid);
                                }
                            }
                        }
                        Console.WriteLine(Environment.NewLine);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(HostNotConnetMessage + Environment.NewLine);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine(MasterServerNotConnetMessage + Environment.NewLine);
            }
        }

        private static void UsingName_Log(StringBuilder text)
        {
            try
            {
                dynamic ServerList = JsonConvert.DeserializeObject(wc.DownloadString(MasterServer));

                foreach (string Host in ServerList.result.servers)
                {
                    try
                    {
                        dynamic HostJSON = JsonConvert.DeserializeObject(wc.DownloadString(String.Format("http://{0}", Host)));
                        string ServerName = HostJSON.name; int numPlayers = HostJSON.numPlayers; dynamic PlayerList = HostJSON.players;

                        if (ServerName.Contains(NameContains))
                        {
                            Console.WriteLine("IP: {0} Host: {1}", Host, ServerName);
                            text.AppendLine(String.Format("IP: {0} Host: {1}", Host, ServerName));

                            if (numPlayers.Equals(0))
                            {
                                Console.WriteLine(NoPlayersFoundMessage);
                                text.AppendLine(NoPlayersFoundMessage);
                            }
                            else
                            {
                                for (int i = 0; i < numPlayers; i++)
                                {
                                    dynamic Player = PlayerList[i];

                                    if (Player.name.Equals(_PlayerName))
                                    {
                                        Console.WriteLine("IsSpecified UID: {1} Name: {0}", Player.name, Player.uid);
                                        text.AppendLine(String.Format("UID: {1} Name: {0}", Player.name, Player.uid));
                                    }
                                    else if (Player.uid.Equals(_PlayerUID))
                                    {
                                        Console.WriteLine("IsSpecified UID: {1} Name: {0}", Player.name, Player.uid);
                                        text.AppendLine(String.Format("IsSpecified UID: {1} Name: {0}", Player.name, Player.uid));
                                    }
                                    else
                                    {
                                        Console.WriteLine("UID: {1} Name: {0}", Player.name, Player.uid);
                                        text.AppendLine(String.Format("UID: {1} Name: {0}", Player.name, Player.uid));
                                    }
                                }
                            }
                            Console.WriteLine(Environment.NewLine);
                            text.AppendLine(Environment.NewLine);
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(HostNotConnetMessage + Environment.NewLine);
                        text.AppendLine(HostNotConnetMessage + Environment.NewLine);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine(MasterServerNotConnetMessage);
                text.AppendLine(MasterServerNotConnetMessage);
            }
            finally
            {
                LogFile(text.ToString());
                text.Clear();
            }
        }

        private static void UsingName_NoLog()
        {
            try
            {
                dynamic ServerList = JsonConvert.DeserializeObject(wc.DownloadString(MasterServer));

                foreach (string Host in ServerList.result.servers)
                {
                    try
                    {
                        dynamic HostJSON = JsonConvert.DeserializeObject(wc.DownloadString(String.Format("http://{0}", Host)));
                        string ServerName = HostJSON.name; int numPlayers = HostJSON.numPlayers; dynamic PlayerList = HostJSON.players;

                        if (ServerName.Contains(NameContains))
                        {
                            Console.WriteLine("IP: {0} Host: {1}", Host, ServerName);

                            if (numPlayers.Equals(0))
                            {
                                Console.WriteLine(NoPlayersFoundMessage);
                            }
                            else
                            {
                                for (int i = 0; i < numPlayers; i++)
                                {
                                    dynamic Player = PlayerList[i];

                                    if (Player.name.Equals(_PlayerName))
                                    {
                                        Console.WriteLine("IsSpecified UID: {1} Name: {0}", Player.name, Player.uid);
                                    }
                                    else if (Player.uid.Equals(_PlayerUID))
                                    {
                                        Console.WriteLine("IsSpecified UID: {1} Name: {0}", Player.name, Player.uid);
                                    }
                                    else
                                    {
                                        Console.WriteLine("UID: {1} Name: {0}", Player.name, Player.uid);
                                    }
                                }
                            }
                            Console.WriteLine(Environment.NewLine);
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(HostNotConnetMessage + Environment.NewLine);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine(MasterServerNotConnetMessage + Environment.NewLine);
            }
        }
        #endregion
    }
}
