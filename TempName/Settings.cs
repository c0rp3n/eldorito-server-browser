using System;
using System.IO;
using System.Net;

using Newtonsoft.Json;

namespace TempName
{
    class SettingsForm
    {
        public static WebClient wc = new WebClient();

        public static string GetSetting(string Setting)
        {
            var IniFile = new IniFile.IniFile(SettingsForm.IniFile);

            switch (Setting)
            {
                case "TimeOut":
                    if (!IniFile.KeyExists(Setting, "Settings"))
                        IniFile.Write(Setting, "20", "Settings");
                    return IniFile.Read(Setting, "Settings");

                case "IsDEBUG":
                case "LogEnabled":
                case "LookForServerEnabled":
                    if (!IniFile.KeyExists(Setting, "Settings"))
                        IniFile.Write(Setting, "false", "Settings");
                    return IniFile.Read(Setting, "Settings");

                case "ServerName":
                case "LogName":
                    if (!IniFile.KeyExists(Setting, "Settings"))
                        if (Setting.Equals("ServerName"))
                            IniFile.Write(Setting, "G-Money", "Settings");
                        else if (Setting.Equals("LogName"))
                            IniFile.Write(Setting, "Log.txt", "Settings");
                    return IniFile.Read(Setting, "Settings");
            }
            return null;
        }

        public static void SetSetting(string Setting, string setting_)
        {
            var IniFile = new IniFile.IniFile(SettingsForm.IniFile);

            switch (Setting)
            {
                case "TimeOut":
                case "IsDEBUG":
                case "LogEnabled":
                case "LookForServerEnabled":
                case "ServerName":
                case "LogName":
                    IniFile.Write(Setting, setting_, "Settings");
                    break;
            }
        }

        public static string IniFile { get; } = "Settings.ini";


        public static bool IsDEBUG { get; set; } = Boolean.Parse(GetSetting("IsDEBUG"));
        
        public static int TimeOut { get; set; } = Int32.Parse(GetSetting("TimeOut"));


        public static bool IsUsingLog { get; set; } = Boolean.Parse(GetSetting("LogEnabled"));

        public static string Log { get; set; } = String.Format("{0}\\{1}", Directory.GetCurrentDirectory(), GetSetting("LogName"));


        public static bool IsUsingName_Server { get; set; } = Boolean.Parse(GetSetting("LookForServerEnabled"));

        public static string ServerName { get; set; } = GetSetting("ServerName");
        

        public static string MasterServer { get; set; } = Helpers.GetMasterServer();

        public static dynamic ServerList = JsonConvert.DeserializeObject(wc.DownloadString(MasterServer));
    }
}
