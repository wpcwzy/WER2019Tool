using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace WER2019Tool
{
    public partial class helpForm : Form
    {
        public helpForm()
        {
            InitializeComponent();
        }

        private void release_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            release.LinkVisited = true;
            Process.Start("https://github.com/wpcwzy/WER2019Tool/releases/latest");
        }

        private void issue_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            issue.LinkVisited = true;
            Process.Start("https://github.com/wpcwzy/WER2019Tool/issues/new");
        }

        private void mail1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mail1.LinkVisited = true;
            Process.Start("mailto:wpc.369623245@live.cn");
        }

        private void mail2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mail2.LinkVisited = true;
            Process.Start("mailto:wpcwzy@gmail.com");
        }
    }
}
