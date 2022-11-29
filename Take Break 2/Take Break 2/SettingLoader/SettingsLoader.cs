using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Text.Json.Nodes;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace Take_Break_2.SettingLoader
{
    public class SettingsLoader
    {
        private readonly string FILE_NAME;

        public SettingsLoader()
        {
            FILE_NAME = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "settings.json");
        }

        private void CreateFile()
        {
            using (var streamWriter = new StreamWriter(FILE_NAME))
            {
                streamWriter.WriteLine("{\"Startup\": true, \"TotalSeconds\": 1800, \"WaitingTimeInSeconds\": 900}");
            }
        }

        private void EnsureSettingFileExists()
        {
            if (!File.Exists(FILE_NAME))
                CreateFile();
        }

        public SettingModel LoadSettings()
        {
            EnsureSettingFileExists();
            using (StreamReader sr = new StreamReader(FILE_NAME))
            {
                string settingsFileContent = sr.ReadToEnd();
                var settings = JsonConvert.DeserializeObject<SettingModel>(settingsFileContent);
                return settings;
            }
        }

        public void SaveSettingItem(SettingModel settings)
        {
            EnsureSettingFileExists();
            using (StreamWriter sw = new StreamWriter(FILE_NAME))
            {
                var settingsStr = JsonConvert.SerializeObject(settings);
                sw.WriteLine(settingsStr);
            }
        }
    }
}
