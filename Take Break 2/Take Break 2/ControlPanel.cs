using System.Diagnostics;
using System.Runtime.InteropServices;
using Take_Break_2.Helpers;
using Take_Break_2.SettingLoader;

namespace Take_Break_2;

enum QueryUserNotificationState
{
    QUNS_NOT_PRESENT = 1,
    QUNS_BUSY = 2,
    QUNS_RUNNING_D3D_FULL_SCREEN = 3,
    QUNS_PRESENTATION_MODE = 4,
    QUNS_ACCEPTS_NOTIFICATIONS = 5,
    QUNS_QUIET_TIME = 6,
    QUNS_APP = 7
}

public partial class ControlPanel : Form
{
    private SettingModel globalSettings;
    private CountDownTimer countDownTimer;
    private bool isHidden = false;

    [DllImport("shell32.dll", SetLastError = true)]
    private static extern int SHQueryUserNotificationState(out QueryUserNotificationState pquns);

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
        settingsForm.FormClosed += (sender, e) =>
        {
            SettingsForm_FormClosed(sender, e);
        };
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
        lblTimeLeft.Location = new Point((Width - lblTimeLeft.Width)/2, flowLayoutPanel1.Height + 30);
        btnToggleTimer.Location = new Point((Width - btnToggleTimer.Width)/2, lblTimeLeft.Location.Y + lblTimeLeft.Height + 10);
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
        //var autoIt = new AutoItX3();
        //int windowWidth = autoIt.WinGetPosWidth("[ACTIVE]");
        //int windowHeight = autoIt.WinGetPosHeight("[ACTIVE]");

        //if (windowWidth == Screen.PrimaryScreen.Bounds.Width && windowHeight == Screen.PrimaryScreen.Bounds.Height)
        //{
        //    return true;
        //}

        //return false;
        QueryUserNotificationState state;

        var result = SHQueryUserNotificationState(out state);
        if (result == 0)
        {
            if(state == QueryUserNotificationState.QUNS_NOT_PRESENT || state == QueryUserNotificationState.QUNS_BUSY || state == QueryUserNotificationState.QUNS_RUNNING_D3D_FULL_SCREEN || state == QueryUserNotificationState.QUNS_PRESENTATION_MODE)
            {
                return true;
            }
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
        if(WindowsApiHelper.CheckIfProgramInstalledOnTheSystem("AutoIt"))
        {
            var memStream = new MemoryStream();
            Properties.Resources.takebreak2.CopyTo(memStream);
            var soundBuffer = new SFML.Audio.SoundBuffer(memStream);
            var sound = new SFML.Audio.Sound(soundBuffer);
            sound.Play();
            countDownTimer.Start();

            PopupScreen popupScreen = new PopupScreen(globalSettings.WaitingTimeInSeconds ?? 900);
            popupScreen.Show();
            popupScreen.FormClosed += (sender, e) =>
            {
                countDownTimer.Start();
            };
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
        if(!isHidden)
        {
            lblTimeLeft.Text = TimeConverter.ConvertSecondsToReadableFormat(elapsedSeconds);
            AlignControls();
        }
    }

    private void ControlPanel_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
        notifyIcon1.Text = "Take break";
        notifyIcon1.Icon = this.Icon;
        notifyIcon1.ShowBalloonTip(1000, "Take break", "Take break is working in the background", ToolTipIcon.Info);
        isHidden = true;
        this.SuspendLayout();
        this.Hide();
    }

    private void showWindowToolStripMenuItem_Click(object sender, EventArgs e)
    {
        isHidden = false;
        this.ResumeLayout();
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
        this.isHidden = false;
        this.ResumeLayout();
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