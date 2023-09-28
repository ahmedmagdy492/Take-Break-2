namespace Take_Break_2
{
    partial class ControlPanel
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlPanel));
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            showWindowToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            label2 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnSettings = new Button();
            btnExit = new Button();
            panel1 = new Panel();
            lblTimerLabel = new Label();
            lblTimeLeft = new Label();
            btnToggleTimer = new Button();
            contextMenuStrip1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipText = "Take Break 3 is working in the background";
            notifyIcon1.BalloonTipTitle = "Take Break 3";
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Text = "Take break 3";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { showWindowToolStripMenuItem, exitToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(211, 68);
            // 
            // showWindowToolStripMenuItem
            // 
            showWindowToolStripMenuItem.Name = "showWindowToolStripMenuItem";
            showWindowToolStripMenuItem.Size = new Size(210, 32);
            showWindowToolStripMenuItem.Text = "Show Window";
            showWindowToolStripMenuItem.Click += showWindowToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(210, 32);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(15, 111);
            label2.Margin = new Padding(69, 65, 69, 65);
            label2.Name = "label2";
            label2.Size = new Size(282, 31);
            label2.TabIndex = 11;
            label2.Text = "Created By Ahmed Magdy";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.Controls.Add(btnSettings);
            flowLayoutPanel1.Controls.Add(btnExit);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(714, 77);
            flowLayoutPanel1.TabIndex = 12;
            // 
            // btnSettings
            // 
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnSettings.ForeColor = Color.Black;
            btnSettings.Location = new Point(4, 4);
            btnSettings.Margin = new Padding(4);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(115, 58);
            btnSettings.TabIndex = 4;
            btnSettings.Text = "Settings";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(0, 123, 255);
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(127, 4);
            btnExit.Margin = new Padding(4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(120, 58);
            btnExit.TabIndex = 6;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblTimerLabel);
            panel1.Controls.Add(lblTimeLeft);
            panel1.Controls.Add(btnToggleTimer);
            panel1.Location = new Point(174, 260);
            panel1.Name = "panel1";
            panel1.Size = new Size(351, 276);
            panel1.TabIndex = 13;
            // 
            // lblTimerLabel
            // 
            lblTimerLabel.AutoSize = true;
            lblTimerLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblTimerLabel.ForeColor = Color.Black;
            lblTimerLabel.Location = new Point(121, 12);
            lblTimerLabel.Margin = new Padding(69, 65, 69, 65);
            lblTimerLabel.Name = "lblTimerLabel";
            lblTimerLabel.Size = new Size(115, 31);
            lblTimerLabel.TabIndex = 10;
            lblTimerLabel.Text = "Time Left";
            // 
            // lblTimeLeft
            // 
            lblTimeLeft.AutoSize = true;
            lblTimeLeft.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblTimeLeft.ForeColor = Color.Black;
            lblTimeLeft.Location = new Point(132, 87);
            lblTimeLeft.Margin = new Padding(69, 65, 69, 65);
            lblTimeLeft.Name = "lblTimeLeft";
            lblTimeLeft.Size = new Size(104, 31);
            lblTimeLeft.TabIndex = 11;
            lblTimeLeft.Text = "00:00:00";
            // 
            // btnToggleTimer
            // 
            btnToggleTimer.BackColor = Color.FromArgb(0, 123, 255);
            btnToggleTimer.FlatStyle = FlatStyle.Flat;
            btnToggleTimer.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnToggleTimer.ForeColor = Color.White;
            btnToggleTimer.Location = new Point(10, 155);
            btnToggleTimer.Margin = new Padding(34, 32, 34, 32);
            btnToggleTimer.Name = "btnToggleTimer";
            btnToggleTimer.Size = new Size(330, 103);
            btnToggleTimer.TabIndex = 12;
            btnToggleTimer.Text = "Start";
            btnToggleTimer.UseVisualStyleBackColor = false;
            btnToggleTimer.Click += btnToggleTimer_Click_1;
            // 
            // ControlPanel
            // 
            AutoScaleDimensions = new SizeF(11F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(714, 576);
            Controls.Add(panel1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(label2);
            DoubleBuffered = true;
            Font = new Font("Trebuchet MS", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.RosyBrown;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "ControlPanel";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Take Break 3 - Control Panel";
            FormClosing += ControlPanel_FormClosing;
            Load += ControlPanel_Load;
            contextMenuStrip1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem showWindowToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Label label2;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnExit;
        private Button btnSettings;
        private Panel panel1;
        private Label lblTimerLabel;
        private Label lblTimeLeft;
        private Button btnToggleTimer;
    }
}