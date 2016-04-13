using System;
using System.IO;
using System.Net;

using Newtonsoft.Json;

namespace TempName
{
    class Settings
    {
        public static WebClient wc = new WebClient();

        public static string GetSetting(string Setting)
        {
            var IniFile = new IniFile.IniFile(Settings.IniFile);

            switch (Setting)
            {
                case "TimeOut":
                    if (!IniFile.KeyExists(Setting, "Settings"))
                    {
                        IniFile.Write(Setting, "20", "Settings");
                        return IniFile.Read(Setting, "Settings");
                    }
                    else
                        return IniFile.Read(Setting, "Settings");

                case "IsDEBUG":
                case "LogEnabled":
                case "LookForServerEnabled":
                //case "LookForPlayerEnabled":
                    if (!IniFile.KeyExists(Setting, "Settings"))
                    {
                        IniFile.Write(Setting, "false", "Settings");
                        return IniFile.Read(Setting, "Settings");
                    }
                    else
                        return IniFile.Read(Setting, "Settings");

                case "ServerName":
                //case "PlayerName":
                //case "PlayerUID":
                case "LogName":
                    if (!IniFile.KeyExists(Setting, "Settings"))
                    {
                        if (Setting.Equals("ServerName"))
                            IniFile.Write(Setting, "G-Money", "Settings");
                        /*else if (Setting.Equals("PlayerName"))
                            IniFile.Write(Setting, "HatedPlayer", "Settings");
                        else if (Setting.Equals("PlayerUID"))
                            IniFile.Write(Setting, "1a2b3c4d5e6f7g8h", "Settings");*/
                        else if (Setting.Equals("LogName"))
                            IniFile.Write(Setting, "Log.txt", "Settings");
                        return IniFile.Read(Setting, "Settings");
                    }
                    else
                        return IniFile.Read(Setting, "Settings");
            }
            return null;
        }

        public static string IniFile { get; } = "Settings.ini";


        public static bool IsDEBUG { get; } = Boolean.Parse(GetSetting("IsDEBUG"));


        public static bool IsUsingLog { get; set; } = Boolean.Parse(GetSetting("LogEnabled"));

        public static string Log { get; set; } = String.Format("{0}\\{1}", Directory.GetCurrentDirectory(), GetSetting("LogName"));


        public static int TimeOut { get; set; } = Int32.Parse(GetSetting("TimeOut"));
        

        public static bool IsPassworded { get; set; } = false;


        public static bool IsUsingName_Server { get; set; } = Boolean.Parse(GetSetting("LookForServerEnabled"));

        public static string ServerName { get; set; } = GetSetting("ServerName");


        /*public static bool IsUsingName_Player { get; } = Boolean.Parse(GetSetting("LookForPlayerEnabled"));

        public static string Playername { get; } = GetSetting("PlayerName");

        public static string Playeruid { get; } = GetSetting("PlayerUID");*/


        public static string MasterServer { get; set; } = Helpers.GetMasterServer();

        public static dynamic ServerList = JsonConvert.DeserializeObject(wc.DownloadString(MasterServer));
    }
}
