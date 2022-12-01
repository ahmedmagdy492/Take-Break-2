using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Take_Break_2.Helpers
{
    public static class WindowsApiHelper
    {
        public static void AddMeToStartup(string executablePath)
        {
            #region NOT WORKING DUE TO LACK OF PERMISSION TO WRITE TO THIS KEY
            // HKEY_LOCAL_MACHINE/Microsoft/Windows/CurrentVersion/Run
            //RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Microsoft").OpenSubKey("Windows").OpenSubKey("CurrentVersion").OpenSubKey("Run");
            //if(registryKey != null)
            //{
            //    registryKey.SetValue("TakeBreak2", executablePath);
            //    registryKey.Close();
            //}
            #endregion

            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), Path.GetFileName(executablePath));
            if (!File.Exists(fileName))
            {
                File.Copy(executablePath, fileName);
            }
        }

        public static void RemoveMeFromStartup(string executablePath)
        {
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), Path.GetFileName(executablePath));
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }
    }
}
