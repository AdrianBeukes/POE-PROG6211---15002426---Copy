namespace Final
{
    partial class frmSplash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSplash));
            this.lblLoading = new System.Windows.Forms.Label();
            this.progBarLoad = new System.Windows.Forms.ProgressBar();
            this.timerLoad = new System.Windows.Forms.Timer(this.components);
            this.lblPercentage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.BackColor = System.Drawing.Color.Transparent;
            this.lblLoading.Font = new System.Drawing.Font("Palatino Linotype", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoading.Location = new System.Drawing.Point(267, 24);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(240, 63);
            this.lblLoading.TabIndex = 2;
            this.lblLoading.Text = "Loading...";
            // 
            // progBarLoad
            // 
            this.progBarLoad.Location = new System.Drawing.Point(170, 354);
            this.progBarLoad.Name = "progBarLoad";
            this.progBarLoad.Size = new System.Drawing.Size(397, 25);
            this.progBarLoad.TabIndex = 3;
            // 
            // timerLoad
            // 
            this.timerLoad.Enabled = true;
            this.timerLoad.Tick += new System.EventHandler(this.timerLoad_Tick_1);
            // 
            // lblPercentage
            // 
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.BackColor = System.Drawing.Color.Transparent;
            this.lblPercentage.Font = new System.Drawing.Font("Palatino Linotype", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentage.Location = new System.Drawing.Point(349, 382);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(53, 35);
            this.lblPercentage.TabIndex = 4;
            this.lblPercentage.Text = "0%";
            // 
            // frmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(750, 439);
            this.Controls.Add(this.lblPercentage);
            this.Controls.Add(this.progBarLoad);
            this.Controls.Add(this.lblLoading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splash";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.ProgressBar progBarLoad;
        private System.Windows.Forms.Timer timerLoad;
        private System.Windows.Forms.Label lblPercentage;
    }
}