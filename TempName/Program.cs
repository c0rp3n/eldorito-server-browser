using System;
using System.IO;
using System.Text;

using Newtonsoft.Json;
using System.Windows.Forms;

namespace TempName
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var frm = new MainForm();
            frm.Show();
            Application.Run();
        }
    }
}
