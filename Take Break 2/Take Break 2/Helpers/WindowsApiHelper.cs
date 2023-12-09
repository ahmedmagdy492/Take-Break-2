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
        private const string APP_NAME = "TakeBreak2";

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

            //string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), Path.GetFileName(executablePath));
            //if (!File.Exists(fileName))
            //{
            //    File.CreateSymbolicLink(fileName, executablePath);
            //}

            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                    ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            rk.SetValue(APP_NAME, executablePath);
        }

        public static void CreateShortcutOnDesktop(string executablePath)
        {
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), Path.GetFileName(executablePath));
            if (!File.Exists(fileName))
            {
                File.CreateSymbolicLink(fileName, executablePath);
            }
        }

        public static void RemoveMeFromStartup(string executablePath)
        {
            //string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), Path.GetFileName(executablePath));
            //if (File.Exists(fileName))
            //{
            //    File.Delete(fileName);
            //}

            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                    ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            rk.DeleteValue(APP_NAME, false);
        }

        public static bool CheckIfProgramInstalledOnTheSystem(string programName)
        {
            string registry_key = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
            {
                foreach (string subkey_name in key.GetSubKeyNames())
                {
                    using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                    {
                        if (subkey.GetValue("DisplayName") != null)
                        {
                            if (subkey.GetValue("DisplayName").ToString().ToLower().Contains(programName.ToLower()))
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }
    }
}
