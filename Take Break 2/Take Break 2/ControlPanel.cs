using AutoItX3Lib;
using System.Diagnostics;
using Take_Break_2.Helpers;
using Take_Break_2.SettingLoader;

namespace Take_Break_2
{
    public partial class ControlPanel : Form
    {
        private SettingModel globalSettings;
        private CountDownTimer countDownTimer;

        public ControlPanel()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            countDownTimer.Dispose();
            Environment.Exit(0);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.FormClosed += SettingsForm_FormClosed;
            settingsForm.ShowDialog();
        }

        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SettingsLoader settingsLoader = new SettingsLoader();
            globalSettings = settingsLoader.LoadSettings();

            countDownTimer.SetTotalSeconds(globalSettings.TotalSeconds ?? 1800);
            btnToggleTimer.Text = "Stop";
        }

        private void AlignControls()
        {
            panel1.Location = new Point((this.Width - panel1.Width) / 2, (this.Height - panel1.Height) / 2);
        }

        private void ControlPanel_Load(object sender, EventArgs e)
        {
            // load settings
            SettingsLoader settingsLoader = new SettingsLoader();
            globalSettings = settingsLoader.LoadSettings();

            // start the countdown timer
            countDownTimer = new CountDownTimer(globalSettings.TotalSeconds ?? 1800);
            countDownTimer.TimeTick += CountDownTimer_TimeTick;
            countDownTimer.TimeFinish += CountDownTimer_TimeFinish;
            countDownTimer.Start();
            btnToggleTimer.Text = "Stop";

            AlignControls();
        }

        private bool IsThereAWindowInFullScreen()
        {
            var autoIt = new AutoItX3();
            int windowWidth = autoIt.WinGetPosWidth("[ACTIVE]");
            int windowHeight = autoIt.WinGetPosHeight("[ACTIVE]");

            if (windowWidth == Screen.PrimaryScreen.Bounds.Width && windowHeight == Screen.PrimaryScreen.Bounds.Height)
            {
                return true;
            }

            return false;
        }

        private bool IsOneOfTheseProcessesAreRunning()
        {
            var runningProcesses = Process.GetProcesses();
            var execptionProcesses = globalSettings.ListOfProgramsToRunSilentFor;

            execptionProcesses.ForEach(i =>
            {
                i = i.ToLower();
            });

            foreach (var process in runningProcesses)
            {
                if (execptionProcesses.Contains(process.ProcessName.ToLower()))
                {
                    return true;
                }
            }

            return false;
        }

        private void CountDownTimer_TimeFinish()
        {
            if (IsThereAWindowInFullScreen())
            {
                var memStream = new MemoryStream();
                Properties.Resources.takebreak2.CopyTo(memStream);
                var soundBuffer = new SFML.Audio.SoundBuffer(memStream);
                var sound = new SFML.Audio.Sound(soundBuffer);
                sound.Play();
                countDownTimer.Start();
            }
            else
            {
                PopupScreen popupScreen = new PopupScreen(globalSettings.WaitingTimeInSeconds ?? 900);
                popupScreen.Show();
                popupScreen.FormClosed += (sender, e) =>
                {
                    countDownTimer.Start();
                };
            }
        }

        private void CountDownTimer_TimeTick(long elapsedSeconds)
        {
            lblTimeLeft.Text = TimeConverter.ConvertSecondsToReadableFormat(elapsedSeconds);
        }

        private void ControlPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            notifyIcon1.Text = "Take break 2";
            notifyIcon1.Icon = this.Icon;
            notifyIcon1.ShowBalloonTip(1000, "Take break 2", "Take break 2 is working in the background", ToolTipIcon.Info);
            this.Hide();
        }

        private void showWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            countDownTimer.Dispose();
            Environment.Exit(0);
        }

        private void btnCloseWindow_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void btnControlPanel_Click(object sender, EventArgs e)
        {
            WindowsApiHelper.CreateShortcutOnDesktop(Environment.ProcessPath);
        }

        private void btnToggleTimer_Click_1(object sender, EventArgs e)
        {
            if (countDownTimer.IsStarted)
            {
                countDownTimer.Stop();
                btnToggleTimer.Text = "Start";
            }
            else
            {
                countDownTimer.Start();
                btnToggleTimer.Text = "Stop";
            }
        }
    }
}