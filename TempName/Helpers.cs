using System;
using System.IO;
using System.Text;
using System.Threading;

using Newtonsoft.Json;

namespace TempName
{
    class Helpers
    {
        public static void Sleep()
        {
            for (int i = 2; i > 0; i--)
            {
                Thread.Sleep(1000);
            }
            Console.Clear();
            for (int i = Settings.TimeOut * 1; i > 0; i--)
            {
                Console.WriteLine("Waiting {0} seconds!", i);
                Thread.Sleep(1000);
                Console.Clear();
            }
        }

        public static string GetMasterServer()
        {
            string DewritoTEXT = Settings.wc.DownloadString("https://raw.githubusercontent.com/ElDewrito/ElDorito/master/dewrito.json");
            dynamic DewritoJSON = JsonConvert.DeserializeObject(DewritoTEXT);

            foreach (dynamic masterServer in DewritoJSON.masterServers)
            {
                return masterServer.list;
            }
            return null;
        }

        public static string FindPlayerByName(string NameToFind, string playerToSearch)
        {
            if (playerToSearch.Contains(NameToFind))
            {
                return String.Format("(MATCH) Name: {0} in name from settings: {1} ", NameToFind, playerToSearch);
            }

            return null;
        }

        public static string FindPlayerByUID(string UIDToFind, string playerToSearch)
        {
            if (UIDToFind == playerToSearch)
            {
                return String.Format("(MATCH) UID: {0} in UID from settings: {1} ", UIDToFind, playerToSearch);
            }

            return null;
        }
    }

    class Logger
    {
        public static void Log(string Input)
        {
            if (Settings.IsUsingLog.Equals(true))
            {
                var text = new StringBuilder();

                if (File.Exists(Settings.Log))
                {
                    foreach (string s in File.ReadAllLines(Settings.Log))
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

                using (var file = new StreamWriter(File.Create(Settings.Log)))
                {
                    file.Write(text.ToString());
                }
            }
        }
    }
}
