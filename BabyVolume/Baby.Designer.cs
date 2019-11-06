namespace BabyVolume
{
    partial class Baby
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pollTimer = new System.Windows.Forms.Timer(this.components);
            this.VolText = new System.Windows.Forms.Label();
            this.TextTimeoutTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BabyVolume.Properties.Resources._00;
            this.pictureBox1.Location = new System.Drawing.Point(-2, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(335, 338);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // pollTimer
            // 
            this.pollTimer.Enabled = true;
            this.pollTimer.Interval = 1;
            this.pollTimer.Tick += new System.EventHandler(this.pollTimer_Tick);
            // 
            // VolText
            // 
            this.VolText.AutoSize = true;
            this.VolText.BackColor = System.Drawing.Color.White;
            this.VolText.Location = new System.Drawing.Point(12, 316);
            this.VolText.Name = "VolText";
            this.VolText.Size = new System.Drawing.Size(86, 13);
            this.VolText.TabIndex = 1;
            this.VolText.Text = "Sensitivity: 100%";
            this.VolText.Visible = false;
            // 
            // TextTimeoutTimer
            // 
            this.TextTimeoutTimer.Interval = 3000;
            this.TextTimeoutTimer.Tick += new System.EventHandler(this.TextTimeoutTimer_Tick);
            // 
            // Baby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lime;
            this.ClientSize = new System.Drawing.Size(335, 338);
            this.Controls.Add(this.VolText);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = global::BabyVolume.Properties.Resources.baby;
            this.Name = "Baby";
            this.Text = "Baby";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Lime;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Baby_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer pollTimer;
        private System.Windows.Forms.Label VolText;
        private System.Windows.Forms.Timer TextTimeoutTimer;
    }
}

