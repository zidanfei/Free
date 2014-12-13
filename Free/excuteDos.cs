using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Free
{
    public partial class excuteDos : Form
    {
        public excuteDos()
        {
            InitializeComponent();
        }
        public void excute()
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            //true表示不显示黑框，false表示显示dos界面
            p.Start();

            p.StandardInput.WriteLine("shutdown -s -t " + textBox1.Text);
            p.StandardInput.WriteLine("shutdown -a");

            p.StandardInput.WriteLine("exit");

            //MessageBox.Show("ok!!!");
            p.Close(); 
        }

        private void excuteDos_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            excute();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(textBox1.Text);
            }
            catch
            {
                textBox1.Text = string.Empty;
            }
        }
    }
}
