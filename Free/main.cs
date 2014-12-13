using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.DirectoryServices;
using System.Threading;
using System.Net;

namespace Free
{
    public partial class main : DevComponents.DotNetBar.Office2007Form
    {
        public main()
        {
            InitializeComponent();
            main.CheckForIllegalCrossThreadCalls = false;
        }
        //LDAP: (Lightweight Directory Access Protocol)
        //IIS: (提供IIS元数据来读及配置Internet Infomation Server)
        //WinNT: (提供在非常有限的性能下对Windows NT域的访问)
        //NDS: (提供对Novell Directory Service的访问)

        private void main_Load(object sender, EventArgs e)
        {
            string a = Application.ProductName;
            EnumComputers();
            Thread startAppli = new Thread(new ThreadStart(EnumComputers1));
            startAppli.IsBackground = true;
            startAppli.Start();
        }

        void EnumComputers1()
        {
            using (DirectoryEntry root = new DirectoryEntry("WinNT:"))
            {
                foreach (DirectoryEntry domain in root.Children)
                {
                    textBox1.Text += "Domain | WorkGroup:\t" + domain.Name + "\r\n";
                    foreach (DirectoryEntry computer in domain.Children)
                    {
                        string ip = "";
                        try
                        {
                            IPHostEntry host = Dns.GetHostByName(computer.Name);

                            for (int i = 0; i < host.AddressList.Length; i++)
                            {
                                if (host.AddressList[i].ToString().Substring(0, 3).Equals("192"))
                                {
                                    ip = host.AddressList[i].ToString();
                                    break;
                                }
                            }
                        }
                        catch { }
                        textBox1.Text += "Computer:\t" + computer.Name + "\t" + ip + "\t" + computer.AuthenticationType + "\r\n";
                    }
                }
            }
        }
        private void EnumComputers()
        {
            try
            {
                for (int i = 1; i <= 255; i++)
                {

                    System.Net.NetworkInformation.Ping myPing;
                    myPing = new System.Net.NetworkInformation.Ping();
                    myPing.PingCompleted += new System.Net.NetworkInformation.PingCompletedEventHandler(_myPing_PingCompleted);

                    string pingIP = "192.168.1." + i.ToString();
                    myPing.SendAsync(pingIP, 1000, null);
                }
            }
            catch
            {
            }
        }

        private void _myPing_PingCompleted(object sender, System.Net.NetworkInformation.PingCompletedEventArgs e)
        {
            if (e.Reply.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                textBox1.Text += e.Reply.Address.ToString() + "|" + Dns.GetHostByAddress(IPAddress.Parse(e.Reply.Address.ToString())).HostName + "\r\n";
            }

        }

    }
}
