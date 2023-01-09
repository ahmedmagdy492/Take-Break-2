namespace Take_Break_2
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.nmTotalMins = new System.Windows.Forms.NumericUpDown();
            this.nmWaitingTime = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkBoxEnableSilentMode = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nmTotalMins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmWaitingTime)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Alarm Period";
            // 
            // nmTotalMins
            // 
            this.nmTotalMins.Location = new System.Drawing.Point(225, 68);
            this.nmTotalMins.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nmTotalMins.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nmTotalMins.Name = "nmTotalMins";
            this.nmTotalMins.Size = new System.Drawing.Size(184, 40);
            this.nmTotalMins.TabIndex = 1;
            this.nmTotalMins.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // nmWaitingTime
            // 
            this.nmWaitingTime.Location = new System.Drawing.Point(225, 153);
            this.nmWaitingTime.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nmWaitingTime.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nmWaitingTime.Name = "nmWaitingTime";
            this.nmWaitingTime.Size = new System.Drawing.Size(184, 40);
            this.nmWaitingTime.TabIndex = 3;
            this.nmWaitingTime.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 36);
            this.label2.TabIndex = 2;
            this.label2.Text = "Wating Time";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(344, 314);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 51);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(425, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "mins";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(425, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "mins";
            // 
            // chkBoxEnableSilentMode
            // 
            this.chkBoxEnableSilentMode.AutoSize = true;
            this.chkBoxEnableSilentMode.Location = new System.Drawing.Point(56, 248);
            this.chkBoxEnableSilentMode.Name = "chkBoxEnableSilentMode";
            this.chkBoxEnableSilentMode.Size = new System.Drawing.Size(278, 40);
            this.chkBoxEnableSilentMode.TabIndex = 8;
            this.chkBoxEnableSilentMode.Text = "Enable Silent Mode";
            this.chkBoxEnableSilentMode.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Black", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(295, 236);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 58);
            this.button1.TabIndex = 9;
            this.button1.Text = "New";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 36F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(531, 408);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkBoxEnableSilentMode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.nmWaitingTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nmTotalMins);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.SeaGreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmTotalMins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmWaitingTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private NumericUpDown nmTotalMins;
        private NumericUpDown nmWaitingTime;
        private Label label2;
        private Button btnSave;
        private Label label3;
        private Label label4;
        private CheckBox chkBoxEnableSilentMode;
        private Button button1;
    }
}