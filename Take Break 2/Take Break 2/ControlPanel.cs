using Take_Break_2.Helpers;
using Take_Break_2.SettingLoader;

namespace Take_Break_2
{
    public partial class ControlPanel : Form
    {
        private SettingModel globalSetting;
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

        private void btnToggleTimer_Click(object sender, EventArgs e)
        {
            if(countDownTimer.IsStarted)
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

        private void btnSettings_Click(object sender, EventArgs e)
        {

        }

        private void ControlPanel_Load(object sender, EventArgs e)
        {
            // load settings
            SettingsLoader settingsLoader = new SettingsLoader();
            globalSetting = settingsLoader.LoadSettings();

            // start the countdown timer
            countDownTimer = new CountDownTimer(globalSetting.TotalSeconds ?? 1800);
            countDownTimer.TimeTick += CountDownTimer_TimeTick;
            countDownTimer.TimeFinish += CountDownTimer_TimeFinish;
            countDownTimer.Start();
            btnToggleTimer.Text = "Stop";
        }

        private void CountDownTimer_TimeFinish()
        {
            PopupScreen popupScreen = new PopupScreen(globalSetting.WaitingTimeInSeconds ?? 900);
            popupScreen.Show();
            popupScreen.FormClosed += (sender, e) =>
            {
                countDownTimer.Start();
            };
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
    }
}