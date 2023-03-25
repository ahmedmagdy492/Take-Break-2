﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Take_Break_2.SettingLoader;

namespace Take_Break_2
{
    public partial class SettingsForm : Form
    {
        private SettingModel _globalSettings;
        private readonly SettingsLoader _settingsLoader;

        public SettingsForm()
        {
            InitializeComponent();
            _settingsLoader = new SettingsLoader();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            _globalSettings = _settingsLoader.LoadSettings();
            nmTotalMins.Value = (decimal)_globalSettings.TotalSeconds / 60;
            nmWaitingTime.Value = (decimal)_globalSettings.WaitingTimeInSeconds / 60;
            chkBoxEnableSilentMode.Checked = _globalSettings.SilentMode ?? false;
            for(int i =0; i < _globalSettings.ListOfProgramsToRunSilentFor.Count; i++)
            {
                if(i < _globalSettings.ListOfProgramsToRunSilentFor.Count-1)
                {
                    txtProgramsNames.Text += _globalSettings.ListOfProgramsToRunSilentFor[i] + ",";
                }
                else
                {
                    txtProgramsNames.Text += _globalSettings.ListOfProgramsToRunSilentFor[i];
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (nmTotalMins.Value != 0 && nmWaitingTime.Value != 0)
            {
                _globalSettings.TotalSeconds = (long)nmTotalMins.Value * 60;
                _globalSettings.WaitingTimeInSeconds = (long)nmWaitingTime.Value * 60;
                _globalSettings.SilentMode = chkBoxEnableSilentMode.Checked;

                if (!string.IsNullOrWhiteSpace(txtProgramsNames.Text))
                {
                    var programsNames = txtProgramsNames.Text.Split(",");
                    foreach(var programName in programsNames)
                    {
                        if(!string.IsNullOrWhiteSpace(programName))
                        {
                            _globalSettings.ListOfProgramsToRunSilentFor.Add(programName);
                        }
                    }
                }
                else
                {
                    _globalSettings.ListOfProgramsToRunSilentFor.Clear();
                }

                _settingsLoader.SaveSettings(_globalSettings);
                MessageBox.Show("Changes Saved Successfully and will be applied next time the application runs");
                this.Close();
            }
        }
    }
}
