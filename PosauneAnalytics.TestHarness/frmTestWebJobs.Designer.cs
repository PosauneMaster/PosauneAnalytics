namespace PosauneAnalytics.TestHarness
{
    partial class frmTestWebJobs
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
            this.btnCallJob = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQueuename = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFunctionName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCallJob
            // 
            this.btnCallJob.Location = new System.Drawing.Point(197, 227);
            this.btnCallJob.Name = "btnCallJob";
            this.btnCallJob.Size = new System.Drawing.Size(75, 23);
            this.btnCallJob.TabIndex = 0;
            this.btnCallJob.Text = "Run Job";
            this.btnCallJob.UseVisualStyleBackColor = true;
            this.btnCallJob.Click += new System.EventHandler(this.btnCallJob_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Queue Name:";
            // 
            // txtQueuename
            // 
            this.txtQueuename.Location = new System.Drawing.Point(12, 139);
            this.txtQueuename.Name = "txtQueuename";
            this.txtQueuename.Size = new System.Drawing.Size(260, 20);
            this.txtQueuename.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Function Name:";
            // 
            // txtFunctionName
            // 
            this.txtFunctionName.Location = new System.Drawing.Point(12, 182);
            this.txtFunctionName.Name = "txtFunctionName";
            this.txtFunctionName.Size = new System.Drawing.Size(260, 20);
            this.txtFunctionName.TabIndex = 4;
            // 
            // frmTestWebJobs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.txtFunctionName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtQueuename);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCallJob);
            this.Name = "frmTestWebJobs";
            this.Text = "frmTestWebJobs";
            this.Load += new System.EventHandler(this.frmTestWebJobs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCallJob;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQueuename;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFunctionName;
    }
}