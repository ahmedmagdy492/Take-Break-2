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
            settingsForm.ShowDialog();
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
        }

        private bool IsOneOfTheseProcessesAreRunning()
        {
            var runningProcesses = Process.GetProcesses();
            var execptionProcesses = globalSettings.ListOfProgramsToRunSilentFor;

            foreach (var process in runningProcesses )
            {
                if(execptionProcesses.Contains(process.ProcessName))
                {
                    return true;
                }
            }

            return false;
        }

        private void CountDownTimer_TimeFinish()
        {
            if(globalSettings.SilentMode == null || globalSettings.SilentMode == false)
            {
                if(IsOneOfTheseProcessesAreRunning())
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
            else 
            {
                //SilentModeForm silentModeForm = new SilentModeForm();
                //silentModeForm.Show();
                //silentModeForm.FormClosed += (sender, e) =>
                //{
                //    countDownTimer.Start();
                //};
                var memStream = new MemoryStream();
                Properties.Resources.takebreak2.CopyTo(memStream);
                var soundBuffer = new SFML.Audio.SoundBuffer(memStream);
                var sound = new SFML.Audio.Sound(soundBuffer);
                sound.Play();
                countDownTimer.Start();
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