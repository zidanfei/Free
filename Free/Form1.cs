using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace Free
{
    public partial class Form1 : DevComponents.DotNetBar.Office2007Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private bool stop = false;

        public bool Stop
        {
            get { return stop; }
            set { stop = value; }
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            stop = true;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            stop = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (stop)
            {
                textBox1.Text = string.Empty;
                stop = false;
            }
            string timenow = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
            textBox1.Text += timenow + "\r\n";
            if (chkWriteLog.Checked)
            {
                File.AppendAllText(DateTime.Now.ToLongDateString() + ".txt", timenow + "\r\n");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            try
            {
                chkAppStartWriteLog.Checked = Convert.ToBoolean(GetAppSettings("autowritelog"));
            }
            catch
            { 
             
            }
            if (chkAppStartWriteLog.Checked)
            {
                timer1.Start();
            }
        }

        private void 恢复窗体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
            this.Visible = true;
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
            this.Visible = true;
        }

        private void chkAppStartWriteLog_CheckedChanged(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Free.exe.config");
            XmlNode n1 = xmlDoc.DocumentElement.SelectSingleNode("appSettings").SelectSingleNode("add");

            XmlNodeList nl = xmlDoc.DocumentElement.SelectSingleNode("appSettings").SelectNodes("add[@key=\"autowritelog\"]");
            if (nl.Count > 0)
            {
                //更新状态
                foreach (XmlNode node in nl)
                {
                    ((XmlElement)node).SetAttribute("value", chkAppStartWriteLog.Checked.ToString());
                }
            }
            xmlDoc.Save("Free.exe.config");
        }
        private string GetAppSettings(string name)
        {
            string value = string.Empty;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Free.exe.config");
            XmlNode n1 = xmlDoc.DocumentElement.SelectSingleNode("appSettings").SelectSingleNode("add");

            XmlNodeList nl = xmlDoc.DocumentElement.SelectSingleNode("appSettings").SelectNodes("add[@key=\"" + name + "\"]");
            if (nl.Count > 0)
            {
                //更新状态
                foreach (XmlNode node in nl)
                {
                    value = ((XmlElement)node).GetAttribute("value");
                }
            }
            return value;
        }

    }
}
