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
            label1 = new Label();
            nmTotalMins = new NumericUpDown();
            nmWaitingTime = new NumericUpDown();
            label2 = new Label();
            btnSave = new Button();
            label3 = new Label();
            label4 = new Label();
            chkBoxEnableSilentMode = new CheckBox();
            txtProgramsNames = new TextBox();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)nmTotalMins).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nmWaitingTime).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(56, 68);
            label1.Name = "label1";
            label1.Size = new Size(146, 28);
            label1.TabIndex = 0;
            label1.Text = "Alarm Period";
            // 
            // nmTotalMins
            // 
            nmTotalMins.Location = new Point(225, 68);
            nmTotalMins.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            nmTotalMins.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            nmTotalMins.Name = "nmTotalMins";
            nmTotalMins.Size = new Size(184, 34);
            nmTotalMins.TabIndex = 1;
            nmTotalMins.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // nmWaitingTime
            // 
            nmWaitingTime.Location = new Point(225, 153);
            nmWaitingTime.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            nmWaitingTime.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            nmWaitingTime.Name = "nmWaitingTime";
            nmWaitingTime.Size = new Size(184, 34);
            nmWaitingTime.TabIndex = 3;
            nmWaitingTime.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(56, 153);
            label2.Name = "label2";
            label2.Size = new Size(142, 28);
            label2.TabIndex = 2;
            label2.Text = "Wating Time";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(338, 421);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(121, 51);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Trebuchet MS", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(425, 75);
            label3.Name = "label3";
            label3.Size = new Size(46, 23);
            label3.TabIndex = 6;
            label3.Text = "mins";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Trebuchet MS", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(425, 158);
            label4.Name = "label4";
            label4.Size = new Size(46, 23);
            label4.TabIndex = 7;
            label4.Text = "mins";
            // 
            // chkBoxEnableSilentMode
            // 
            chkBoxEnableSilentMode.AutoSize = true;
            chkBoxEnableSilentMode.Location = new Point(63, 355);
            chkBoxEnableSilentMode.Name = "chkBoxEnableSilentMode";
            chkBoxEnableSilentMode.Size = new Size(232, 32);
            chkBoxEnableSilentMode.TabIndex = 8;
            chkBoxEnableSilentMode.Text = "Enable Silent Mode";
            chkBoxEnableSilentMode.UseVisualStyleBackColor = true;
            // 
            // txtProgramsNames
            // 
            txtProgramsNames.Location = new Point(56, 244);
            txtProgramsNames.Multiline = true;
            txtProgramsNames.Name = "txtProgramsNames";
            txtProgramsNames.Size = new Size(403, 87);
            txtProgramsNames.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(60, 213);
            label5.Name = "label5";
            label5.Size = new Size(181, 28);
            label5.TabIndex = 10;
            label5.Text = "Programs Names";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Trebuchet MS", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(241, 217);
            label6.Name = "label6";
            label6.Size = new Size(248, 24);
            label6.TabIndex = 11;
            label6.Text = "names seperated by comma";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(13F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(531, 506);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txtProgramsNames);
            Controls.Add(chkBoxEnableSilentMode);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnSave);
            Controls.Add(nmWaitingTime);
            Controls.Add(label2);
            Controls.Add(nmTotalMins);
            Controls.Add(label1);
            Font = new Font("Trebuchet MS", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.SeaGreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 4, 5, 4);
            MaximizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            Load += SettingsForm_Load;
            ((System.ComponentModel.ISupportInitialize)nmTotalMins).EndInit();
            ((System.ComponentModel.ISupportInitialize)nmWaitingTime).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private TextBox txtProgramsNames;
        private Label label5;
        private Label label6;
    }
}