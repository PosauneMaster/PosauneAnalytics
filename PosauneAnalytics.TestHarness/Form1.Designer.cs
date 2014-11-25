namespace PosauneAnalytics.TestHarness
{
    partial class Form1
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
            this.btnDownload = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnListBlob = new System.Windows.Forms.Button();
            this.btnDownloadBlob = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(180, 227);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 0;
            this.btnDownload.Text = "Downloader";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(55, 190);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // btnListBlob
            // 
            this.btnListBlob.Location = new System.Drawing.Point(32, 52);
            this.btnListBlob.Name = "btnListBlob";
            this.btnListBlob.Size = new System.Drawing.Size(110, 23);
            this.btnListBlob.TabIndex = 3;
            this.btnListBlob.Text = "List Blob";
            this.btnListBlob.UseVisualStyleBackColor = true;
            this.btnListBlob.Click += new System.EventHandler(this.btnListBlob_Click);
            // 
            // btnDownloadBlob
            // 
            this.btnDownloadBlob.Location = new System.Drawing.Point(32, 81);
            this.btnDownloadBlob.Name = "btnDownloadBlob";
            this.btnDownloadBlob.Size = new System.Drawing.Size(110, 23);
            this.btnDownloadBlob.TabIndex = 4;
            this.btnDownloadBlob.Text = "Download Blob";
            this.btnDownloadBlob.UseVisualStyleBackColor = true;
            this.btnDownloadBlob.Click += new System.EventHandler(this.btnDownloadBlob_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnDownloadBlob);
            this.Controls.Add(this.btnListBlob);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnDownload);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnListBlob;
        private System.Windows.Forms.Button btnDownloadBlob;
    }
}

