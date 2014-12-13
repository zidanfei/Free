using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Xml;
using System.Threading;
using System.IO;

namespace Free
{
    public partial class AppControl : DevComponents.DotNetBar.Office2007Form
    {


        Time startTime = Time.Parse("6:00");
        Time endTime = Time.Parse("8:00");
        DayOfWeek[] weekdays = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };
        public AppControl()
        {
            InitializeComponent();
            AppControl.CheckForIllegalCrossThreadCalls = false;
        }
        /// <summary>
        /// 添加计算机事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddCompute_Click(object sender, EventArgs e)
        {
            AddCompute(txtComputeName.Text.Trim(), txtRemark.Text.Trim());
            bandComputeList();
           
        }
        /// <summary>
        /// 初始化加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppControl_Load(object sender, EventArgs e)
        {
            //绑定应用程序列表
            bandApplicationList();
            //绑定计算机列表
            //RefreshComputeList();
            Thread refreshListThread = new Thread(new ThreadStart(refreshList));
            refreshListThread.IsBackground = true;
            refreshListThread.Start();
            Thread startAppli = new Thread(new ThreadStart(startApplication));
            startAppli.IsBackground = true;
            startAppli.Start();
        }

        /// <summary>
        /// 刷新计算机列表事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Thread refreshListThread = new Thread(new ThreadStart(RefreshComputeList));
            refreshListThread.Start();
        }

        private void btnAddNetwork_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 删除计算机信息事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelNetwork_Click(object sender, EventArgs e)
        {

        }

        private void btnDelCompute_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 添加应用程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddApp_Click(object sender, EventArgs e)
        {
            AddApplication(textAppName.Text, textAppAddress.Text);
            bandApplicationList();
        }

        /// <summary>
        /// 单元格编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgComputeList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string value = string.Empty;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("computelist.xml");
            try
            {
                XmlNodeList nl = xmlDoc.SelectSingleNode("computelist").ChildNodes;
                if (nl.Count > 0)
                {
                    //更新状态
                    foreach (XmlNode node in nl)
                    {
                        XmlNode xmlname = node.SelectSingleNode("name");
                        if (e.ColumnIndex == dgComputeList.Rows[e.RowIndex].Cells["select"].ColumnIndex && dgComputeList.Rows[e.RowIndex].Cells["name"].Value.ToString() == xmlname.InnerText)
                        {
                            XmlNode xmlselect = node.SelectSingleNode("select");
                            if (string.IsNullOrEmpty(dgComputeList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                            {
                                xmlselect.InnerText = "false";
                            }
                            else
                            {
                                xmlselect.InnerText = "True";
                            }
                        }
                        if (e.ColumnIndex == dgComputeList.Rows[e.RowIndex].Cells["remark"].ColumnIndex && dgComputeList.Rows[e.RowIndex].Cells["name"].Value.ToString() == xmlname.InnerText)
                        {
                            XmlNode xmlremark = node.SelectSingleNode("remark");
                            xmlremark.InnerText = dgComputeList.Rows[e.RowIndex].Cells["remark"].Value.ToString();

                        }
                    }
                    xmlDoc.Save("computelist.xml");
                }

            }
            catch
            {

            }
        }


        /// <summary>
        /// 自动计时配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        void startApplication()
        {
            while (true)
            {
                //StartApp();
                Thread.Sleep(60000);
            }
        }
        void refreshList()
        {
            while (true)
            {
                lock (dgComputeList)
                {
                    RefreshComputeList();
                    Thread.Sleep(60000);
                }
            }
        }

        /// <summary>
        /// 刷新计算机列表
        /// </summary>
        protected void RefreshComputeList()
        {
            string value = string.Empty;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("computelist.xml");
            try
            {
                XmlNodeList nl = xmlDoc.SelectSingleNode("computelist").ChildNodes;
                if (nl.Count > 0)
                {
                    //更新状态
                    foreach (XmlNode node in nl)
                    {
                        XmlNode xmlselect = node.SelectSingleNode("select");
                        //选中计算机刷新
                        //if (bool.Parse(xmlselect.InnerText))
                        //{
                        XmlNode xmlname = node.SelectSingleNode("name");
                        XmlNode xmlonline = node.SelectSingleNode("online");
                        XmlNode xmlremark = node.SelectSingleNode("remark");
                        IPHostEntry host = GetHostByName(xmlname.InnerText);
                        XmlNode xmlip = node.SelectSingleNode("ip");
                        //计算机是否在线
                        if (host == null)
                        {
                            if (bool.Parse(xmlonline.InnerText))
                            {
                                xmlonline.InnerText = false.ToString();
                            }
                        }
                        else
                        {
                            if (!bool.Parse(xmlonline.InnerText))
                            {
                                xmlonline.InnerText = true.ToString();
                            }

                            for (int i = 0; i < host.AddressList.Length; i++)
                            {
                                if (host.AddressList[i].ToString().Substring(0, 3).Equals("192"))
                                {
                                    xmlip.InnerText = host.AddressList[i].ToString();
                                    break;
                                }
                            }
                            WriteLog(host.HostName, xmlip.InnerText, xmlremark.InnerText);
                        }
                        bandCompute(bool.Parse(xmlselect.InnerText), bool.Parse(xmlonline.InnerText), xmlname.InnerText, xmlip.InnerText, xmlremark.InnerText);
                    }
                    xmlDoc.Save("computelist.xml");
                    //bandComputeList();
                }

            }
            catch (Exception ex)
            {

            }
        }
        void bandCompute(bool select, bool online, string computeName, string ipAddress, string remark)
        {
            dgComputeList.Rows.Add(select, online, computeName, ipAddress, remark);
        }
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="ip"></param>
        /// <param name="remark"></param>
        private void WriteLog(string hostname, string ip, string remark)
        {
            if (chkAppStartWriteLog.Checked)
            {
                if (!Directory.Exists("log"))
                {
                    Directory.CreateDirectory("log");
                }
                if (!Directory.Exists("log\\" + DateTime.Now.ToLongDateString()))
                {
                    Directory.CreateDirectory("log\\" + DateTime.Now.ToLongDateString());
                }

                string timenow = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
                File.AppendAllText("log\\" + DateTime.Now.ToLongDateString() + "\\" + hostname + " " + remark + " " + DateTime.Now.ToLongDateString() + ".txt", ip + " " + timenow + "\r\n");
            }
        }
        /// <summary>
        /// 通过计算机名称获取计算机信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected IPHostEntry GetHostByName(string name)
        {
            try
            {
                return Dns.GetHostByName(name);
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 绑定计算机列表
        /// </summary>
        protected void bandComputeList()
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml("computelist.xml");
                dgComputeList.DataSource = ds;
                dgComputeList.DataMember = "compute";
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 绑定应用程序列表
        /// </summary>
        protected void bandApplicationList()
        {
            try
            {
                DataSet ds = new DataSet();
                ds.ReadXml("applicationlist.xml");
                dgApplicationList.DataSource = ds;
                if (ds.Tables.Count > 0)
                {
                    dgApplicationList.DataMember = "application";
                }
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 添加计算机
        /// </summary>
        /// <param name="name">计算机名称</param>
        protected void AddCompute(string name, string remark)
        {
            IPHostEntry host = GetHostByName(name);
            if (host != null && string.IsNullOrEmpty(GetAppComputeByName(name)))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("computelist.xml");

                XmlElement xmlEl = xmlDoc.CreateElement("compute");
                XmlElement xmlselect = xmlDoc.CreateElement("select");
                xmlselect.InnerText = true.ToString();
                xmlEl.AppendChild(xmlselect);
                XmlElement xmlonline = xmlDoc.CreateElement("online");
                xmlonline.InnerText = true.ToString();
                xmlEl.AppendChild(xmlonline);
                XmlElement xmlname = xmlDoc.CreateElement("name");
                xmlname.InnerText = name;
                xmlEl.AppendChild(xmlname);
                XmlElement xmlip = xmlDoc.CreateElement("ip");
                for (int i = 0; i < host.AddressList.Length; i++)
                {
                    if (host.AddressList[i].ToString().Substring(0, 3).Equals("192"))
                    {
                        xmlip.InnerText = host.AddressList[i].ToString();
                        break;
                    }
                }
                xmlEl.AppendChild(xmlip);

                XmlElement xmlremark = xmlDoc.CreateElement("remark");
                xmlremark.InnerText = remark;
                xmlEl.AppendChild(xmlremark);
                xmlDoc.SelectSingleNode("computelist").AppendChild(xmlEl);
                xmlDoc.Save("computelist.xml");

            }
            else
            {
                MessageBox.Show("此计算机不存在！");
            }
        }
        /// <summary>
        /// 添加应用程序
        /// </summary>
        /// <param name="name">应用程序名称</param>
        protected void AddApplication(string name, string address)
        {
            if (!string.IsNullOrEmpty(address))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("applicationlist.xml");

                XmlElement xmlEl = xmlDoc.CreateElement("application");
                XmlElement xmlselect = xmlDoc.CreateElement("select");
                xmlselect.InnerText = true.ToString();
                xmlEl.AppendChild(xmlselect);
                XmlElement xmlname = xmlDoc.CreateElement("name");
                if (!string.IsNullOrEmpty(name))
                {
                    xmlname.InnerText = name;
                }
                else
                {
                    xmlname.InnerText = address.Substring(address.LastIndexOf('\\') + 1);
                }
                xmlEl.AppendChild(xmlname);
                XmlElement xmladdress = xmlDoc.CreateElement("address");
                xmladdress.InnerText = address;
                xmlEl.AppendChild(xmladdress);
                XmlElement xmlprocessname = xmlDoc.CreateElement("processname");
                xmlprocessname.InnerText = string.Empty;
                xmlEl.AppendChild(xmlprocessname);
                xmlDoc.SelectSingleNode("applicationlist").AppendChild(xmlEl);
                xmlDoc.Save("applicationlist.xml");

            }
            else
            {
                MessageBox.Show("请选择应用程序！");
            }
        }
        /// <summary>
        /// 更新应用程序进程名
        /// </summary>
        /// <param name="name"></param>
        private void updateAppProcessNameByName(string name, string processname)
        {
            string value = string.Empty;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("applicationlist.xml");
            try
            {

                XmlNodeList nl = xmlDoc.SelectSingleNode("applicationlist").ChildNodes;
                if (nl.Count > 0)
                {
                    //更新状态
                    foreach (XmlNode node in nl)
                    {
                        if (node.SelectSingleNode("name").InnerText == name)
                        {
                            node.SelectSingleNode("processname").InnerText = processname;
                            xmlDoc.Save("applicationlist.xml");
                            break;
                        }
                    }
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// 获得计算机信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string GetAppComputeByName(string name)
        {
            string value = string.Empty;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("computelist.xml");
            try
            {

                XmlNodeList nl = xmlDoc.SelectSingleNode("computelist").ChildNodes;
                if (nl.Count > 0)
                {
                    //更新状态
                    foreach (XmlNode node in nl)
                    {
                        if (node.ChildNodes[1].InnerText == name)
                        {
                            return node.ChildNodes[2].InnerText;
                        }
                    }
                }
            }
            catch
            {

            }
            return value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog findappfile = new OpenFileDialog();
            findappfile.Multiselect = false;
            if (findappfile.ShowDialog() == DialogResult.OK)
            {
                textAppAddress.Text = findappfile.FileName;
            }
        }

        /// <summary>
        /// 在线计算机个数
        /// </summary>
        /// <returns></returns>
        public int GetOnlineCompute()
        {
            int count = 0;
            for (int i = 0; i < dgComputeList.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgComputeList.Rows[i].Cells["online"].Value) && Convert.ToBoolean(dgComputeList.Rows[i].Cells["select"].Value))
                {
                    count++;
                }
            }
            return count;
        }
        /// <summary>
        /// 是否有在线计算机
        /// </summary>
        /// <returns></returns>
        public bool HasOnlineCompute()
        {
            for (int i = 0; i < dgComputeList.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgComputeList.Rows[i].Cells["online"].Value) && Convert.ToBoolean(dgComputeList.Rows[i].Cells["select"].Value))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 是否在规定的时间内
        /// </summary>
        /// <returns></returns>
        public bool InTime()
        {
            //不在限制日期内
            if (!InLimitDay(DateTime.Now))
            {
                return true;
            }
            //开始时间小于结束时间
            if (startTime.Compare(endTime) == 1)
            {
                //开始时间小于当前时间且结束时间大于当前时间
                if (startTime.Compare(DateTime.Now) == 1 && endTime.Compare(DateTime.Now) == -1)
                {
                    return false;
                }
            }
            else
            {
                //开始时间大于当前时间且结束时间小于当前时间
                if (startTime.Compare(DateTime.Now) == -1 && endTime.Compare(DateTime.Now) == 1)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 限制的日期
        /// </summary>
        /// <param name="date">要分析的日期</param>
        /// <returns></returns>
        public bool InLimitDay(DateTime date)
        {
            for (int i = 0; i < weekdays.Length; i++)
            {
                if (date.DayOfWeek == weekdays[i])
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 启动程序
        /// </summary>
        public void StartApp()
        {
            try
            {
                if (InTime())
                {
                    for (int i = 0; i < dgApplicationList.Rows.Count; i++)
                    {
                        if (string.IsNullOrEmpty(dgApplicationList.Rows[i].Cells["columnprocessname"].Value.ToString()))
                        {
                            dgApplicationList.CurrentCell = dgApplicationList.Rows[i].Cells["columnprocessname"];
                            dgApplicationList.BeginEdit(false);
                            dgApplicationList.Rows[i].Cells["columnprocessname"].Value = Process.Start(dgApplicationList.Rows[i].Cells["columnAppAddress"].Value.ToString()).ProcessName;
                            //dgApplicationList.EndEdit();
                            updateAppProcessNameByName(dgApplicationList.Rows[i].Cells["columnAppName"].Value.ToString(), dgApplicationList.Rows[i].Cells["columnprocessname"].Value.ToString());

                        }
                        Process[] a = Process.GetProcessesByName(dgApplicationList.Rows[i].Cells["columnprocessname"].Value.ToString());
                        if (Convert.ToBoolean(dgApplicationList.Rows[i].Cells["columnSelect"].Value) && a.Length == 0)
                        {
                            Process.Start(dgApplicationList.Rows[i].Cells["columnAppAddress"].Value.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
    }
}
