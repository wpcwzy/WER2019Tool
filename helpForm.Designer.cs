namespace WER2019Tool
{
    partial class helpForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.release = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.issue = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.mail1 = new System.Windows.Forms.LinkLabel();
            this.mail2 = new System.Windows.Forms.LinkLabel();
            this.notice = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(685, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "如果您在使用过程中发现了一些bug，请在以下地址下载最新版本。我们会定期修复一些已知bug";
            // 
            // release
            // 
            this.release.AutoSize = true;
            this.release.Location = new System.Drawing.Point(29, 28);
            this.release.Name = "release";
            this.release.Size = new System.Drawing.Size(375, 15);
            this.release.TabIndex = 1;
            this.release.TabStop = true;
            this.release.Text = "https://github.com/wpcwzy/WER2019Tool/releases";
            this.release.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.release_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(2, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(599, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "如果最新版本仍然存在问题，请在以下链接反馈您所遇到的问题，以便我们进行修复";
            // 
            // issue
            // 
            this.issue.AutoSize = true;
            this.issue.Location = new System.Drawing.Point(29, 67);
            this.issue.Name = "issue";
            this.issue.Size = new System.Drawing.Size(391, 15);
            this.issue.TabIndex = 3;
            this.issue.TabStop = true;
            this.issue.Text = "https://github.com/wpcwzy/WER2019Tool/issues/new";
            this.issue.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.issue_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(2, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(487, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "如果您还有其他问题或不便访问上列链接，欢迎用邮件方式联系作者";
            // 
            // mail1
            // 
            this.mail1.AutoSize = true;
            this.mail1.Location = new System.Drawing.Point(29, 107);
            this.mail1.Name = "mail1";
            this.mail1.Size = new System.Drawing.Size(175, 15);
            this.mail1.TabIndex = 5;
            this.mail1.TabStop = true;
            this.mail1.Text = "wpc.369623245@live.cn";
            this.mail1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.mail1_LinkClicked);
            // 
            // mail2
            // 
            this.mail2.AutoSize = true;
            this.mail2.Location = new System.Drawing.Point(29, 122);
            this.mail2.Name = "mail2";
            this.mail2.Size = new System.Drawing.Size(135, 15);
            this.mail2.TabIndex = 6;
            this.mail2.TabStop = true;
            this.mail2.Text = "wpcwzy@gmail.com";
            this.mail2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.mail2_LinkClicked);
            // 
            // notice
            // 
            this.notice.AutoSize = true;
            this.notice.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.notice.Location = new System.Drawing.Point(2, 144);
            this.notice.Name = "notice";
            this.notice.Size = new System.Drawing.Size(631, 15);
            this.notice.TabIndex = 7;
            this.notice.Text = "因本工具为学生自发开发，所以问题只能在周末予以集中处理。给您带来不便敬请谅解！";
            // 
            // helpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 204);
            this.Controls.Add(this.notice);
            this.Controls.Add(this.mail2);
            this.Controls.Add(this.mail1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.issue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.release);
            this.Controls.Add(this.label1);
            this.Name = "helpForm";
            this.Text = "helpForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel release;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel issue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel mail1;
        private System.Windows.Forms.LinkLabel mail2;
        private System.Windows.Forms.Label notice;
    }
}