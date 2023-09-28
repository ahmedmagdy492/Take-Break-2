using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Take_Break_2
{
    public class CountDownTimer : IDisposable
    {
        private long totalSeconds;
        private long elapsedSeconds;
        private bool isStarted = false;
        private System.Windows.Forms.Timer timer;
        public event Action<long> TimeTick;
        public event Action TimeFinish;

        public CountDownTimer(long totalSeconds)
        {
            if (totalSeconds <= 0)
                throw new ArgumentException($"{nameof(totalSeconds)} should be greater than 0");
            this.totalSeconds = this.elapsedSeconds = totalSeconds;
            InitTimer();
        }

        public void SetTotalSeconds(long totalSeconds)
        {
            this.totalSeconds = totalSeconds;
            this.elapsedSeconds = this.totalSeconds;
        }

        public bool IsStarted { get { return isStarted; } }

        private void InitTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Tick += (sender, e) => Update();
        }

        public void Start()
        {
            isStarted = true;
        }

        private void Update()
        {
            if(isStarted)
            {
                if(elapsedSeconds > 0)
                {
                    TimeTick(--elapsedSeconds);
                }
                else
                {
                    isStarted = false;
                    elapsedSeconds = totalSeconds;
                    TimeFinish();
                }
            }
        }

        public void Stop()
        {
            isStarted = false;
        }

        public void Resume()
        {
            isStarted = true;
        }

        public void Dispose()
        {
            isStarted = false;
            timer.Stop();
            timer.Enabled = false;
            timer.Dispose();
        }
    }
}
