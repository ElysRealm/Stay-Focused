namespace Stay_Focused
{
    partial class StayFocused
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
            this.aboutLabel = new System.Windows.Forms.Label();
            this.explainTimeUntil = new System.Windows.Forms.Label();
            this.timeUntil = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // aboutLabel
            // 
            this.aboutLabel.AutoSize = true;
            this.aboutLabel.Location = new System.Drawing.Point(3, 9);
            this.aboutLabel.Name = "aboutLabel";
            this.aboutLabel.Size = new System.Drawing.Size(573, 15);
            this.aboutLabel.TabIndex = 0;
            this.aboutLabel.Text = "Welcome to Stay Focused! Leave this open in the background, and it will check tha" +
    "t you are staying on task.";
            // 
            // explainTimeUntil
            // 
            this.explainTimeUntil.AutoSize = true;
            this.explainTimeUntil.Location = new System.Drawing.Point(3, 36);
            this.explainTimeUntil.Name = "explainTimeUntil";
            this.explainTimeUntil.Size = new System.Drawing.Size(162, 15);
            this.explainTimeUntil.TabIndex = 1;
            this.explainTimeUntil.Text = "Time Unitl Next Focus Check:";
            // 
            // timeUntil
            // 
            this.timeUntil.AutoSize = true;
            this.timeUntil.Location = new System.Drawing.Point(171, 36);
            this.timeUntil.Name = "timeUntil";
            this.timeUntil.Size = new System.Drawing.Size(158, 15);
            this.timeUntil.TabIndex = 2;
            this.timeUntil.Text = "(time until next focus check)";
            // 
            // StayFocused
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 450);
            this.Controls.Add(this.timeUntil);
            this.Controls.Add(this.explainTimeUntil);
            this.Controls.Add(this.aboutLabel);
            this.Name = "StayFocused";
            this.Text = "Stay Focused";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label aboutLabel;
        private Label explainTimeUntil;
        public Label timeUntil;
    }
}