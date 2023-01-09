using Microsoft.Win32;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Take_Break_2_Installer
{
    public partial class Form2 : Form
    {
        private string fullPath;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string parentPath = Path.Combine(Environment.GetEnvironmentVariable("SystemDrive"), "Users", Environment.GetEnvironmentVariable("ProgramFiles"));
            fullPath = Path.Combine(parentPath, "Take Break 2");

            Directory.CreateDirectory(fullPath);

            lblPath.Text = fullPath;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            btnNext.Enabled = false;
            btnNext.Text = "Installing...";
            bool createShortcut = chkboxShortcut.Checked;
            bool startup = chkStartup.Checked;

            // uncompress the files into the specifed path
            byte[] zipFile = Properties.Resources.Take_Break_2;
            string tempFolder = Environment.GetEnvironmentVariable("TEMP");
            string fileName = $"{Guid.NewGuid().ToString("N")}.zip";

            File.WriteAllBytes(Path.Combine(tempFolder, fileName), zipFile);

            ZipFile.ExtractToDirectory(Path.Combine(tempFolder, fileName), fullPath);

            if(createShortcut)
            {
                File.CreateSymbolicLink(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Take Break 2"), Path.Combine(fullPath, "Take Break 2.exe"));
            }

            if(startup)
            {
                RegistryKey rk = Registry.CurrentUser.OpenSubKey
                    ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                rk.SetValue("TakeBreak2", Path.Combine(fullPath, "Take Break 2.exe"));
            }
            this.Hide();
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }
    }
}
