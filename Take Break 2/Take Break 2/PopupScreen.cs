using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Take_Break_2.Helpers;

namespace Take_Break_2
{
    public partial class PopupScreen : Form
    {
        private readonly long _waitingTimeInSeconds;
        private CountDownTimer countDownTimer;

        public PopupScreen(long waitingTimeInSeconds)
        {
            InitializeComponent();
            _waitingTimeInSeconds = waitingTimeInSeconds;
        }

        private void PopupScreen_Load(object sender, EventArgs e)
        {
            lblMsg.Location = new Point((this.Width - lblMsg.Width) /2, (this.Height - lblMsg.Height) /2);

            countDownTimer = new CountDownTimer(_waitingTimeInSeconds);
            countDownTimer.TimeTick += CountDownTimer_TimeTick;
            countDownTimer.TimeFinish += CountDownTimer_TimeFinish;
            countDownTimer.Start();
        }

        private void CountDownTimer_TimeFinish()
        {
            countDownTimer.Stop();
            countDownTimer.Dispose();
            this.Close();
        }

        private void CountDownTimer_TimeTick(long timeLeft)
        {
            lblMsg.Text = $"Please Take break for {_waitingTimeInSeconds/60} mins, the control will get back to you after: " + TimeConverter.ConvertSecondsToReadableFormat(timeLeft);
            lblMsg.Location = new Point((this.Width - lblMsg.Width) / 2, (this.Height - lblMsg.Height) / 2);
        }
    }
}
