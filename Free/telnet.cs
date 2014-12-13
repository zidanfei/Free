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
    public partial class telnet : Form
    {
        public telnet()
        {
            InitializeComponent();
        }

        private void telnet_Load(object sender, EventArgs e)
        {
            Process telnet = new Process();
            telnet.StartInfo.CreateNoWindow = true;
            telnet.StartInfo.FileName = "cmd.exe";
            //telnet.StandardInput.NewLine=
            telnet.StartInfo.RedirectStandardInput = true;

            //telnet.StandardInput = "mstsc /v: www.lcghj.gov.cn /console";
            telnet.StartInfo.UserName = "pc";
            System.Security.SecureString pwdSecure = new System.Security.SecureString();
            string pwd = "wuqin@2009";
            for (int i = 0; i < pwd.Length; i++)
            {
                pwdSecure.AppendChar(pwd[i]);
            }
            telnet.StartInfo.Password = pwdSecure;
            telnet.StartInfo.UseShellExecute = false;
            telnet.Start();
          

            telnet.WaitForExit();
            telnet.Close();
         

        }

    }
}
