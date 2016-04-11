using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Text;

using Newtonsoft.Json;

namespace TempName
{
    class Program
    {
        static void Main()
        {
            var text = new StringBuilder();

            while (true)
            {
                CheckServers(text);
                Helpers.Sleep();
            }
        }

        private static void CheckServers(StringBuilder text)
        {
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
                                Settings.IsPassword = true;
                            }
                        }

                        if (Settings.IsUsingName_Server.Equals(true))
                        {
                            if (ServerName.Contains(Settings.ServerName))
                            {
                                Console.WriteLine("IP: {0} Host: {1}", Host, ServerName);
                                text.AppendLine(String.Format("IP: {0} Host: {1}", Host, ServerName));

                                if (numPlayers.Equals(0))
                                {
                                    Console.WriteLine(Errors.NoPlayersFoundMessage);
                                    text.AppendLine(Errors.NoPlayersFoundMessage);
                                }
                                else if (Settings.IsPassword.Equals(true))
                                {
                                    Console.WriteLine(Errors.PasswordServerMessage);
                                    text.AppendLine(Errors.PasswordServerMessage);
                                }
                                else
                                {
                                    for (int i = 0; i < numPlayers; i++)
                                    {
                                        dynamic Player = PlayerList[i];
                                        
                                        if (Player.name == null && Player.uid == null)
                                        {
                                            Console.WriteLine("{0} or {1}", Errors.PlayerHasNoNameMessage, Errors.PlayerHasNoUIDMessage);
                                            text.AppendLine(String.Format("{0} or {1}", Errors.PlayerHasNoNameMessage, Errors.PlayerHasNoUIDMessage));
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
                        else
                        {
                            Console.WriteLine("IP: {0} Host: {1}", Host, ServerName);
                            text.AppendLine(String.Format("IP: {0} Host: {1}", Host, ServerName));

                            if (numPlayers.Equals(0))
                            {
                                Console.WriteLine(Errors.NoPlayersFoundMessage);
                                text.AppendLine(Errors.NoPlayersFoundMessage);
                            }
                            else if (Settings.IsPassword.Equals(true))
                            {
                                Console.WriteLine(Errors.PasswordServerMessage);
                                text.AppendLine(Errors.PasswordServerMessage);
                            }
                            else
                            {
                                for (int i = 0; i < numPlayers; i++)
                                {
                                    dynamic Player = PlayerList[i];

                                    if (Player.name == null && Player.uid == null)
                                    {
                                        Console.WriteLine("{0} or {1}", Errors.PlayerHasNoNameMessage, Errors.PlayerHasNoUIDMessage);
                                        text.AppendLine(String.Format("{0} or {1}", Errors.PlayerHasNoNameMessage, Errors.PlayerHasNoUIDMessage));
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
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        Console.Read();
                        /*Console.WriteLine(Errors.HostNotConnetMessage + Environment.NewLine);
                        text.AppendLine(Errors.HostNotConnetMessage + Environment.NewLine);*/
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine(Errors.MasterServerNotConnetMessage);
                text.AppendLine(Errors.MasterServerNotConnetMessage);
            }
            finally
            {
                Logger.Log(text.ToString());
                text.Clear();
            }
        }
    }
}
