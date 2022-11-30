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
            Application.Exit();
        }

        private void btnControlPanel_Click(object sender, EventArgs e)
        {
            if(!controlPanelPanel.Visible)
            {
                controlPanelPanel.Visible = true;
            }
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
            // TODO:
            // 1.show the popup form
            // 2.start the waiting timer
            // 3.after it finishes start countdown timer again
            countDownTimer.Start();
        }

        private void CountDownTimer_TimeTick(long elapsedSeconds)
        {
            lblTimeLeft.Text = TimeConverter.ConvertSecondsToReadableFormat(elapsedSeconds);
        }
    }
}