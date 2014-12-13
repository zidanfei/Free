using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Xml;
using System.Threading;
using System.IO;

namespace LanSee
{
    public partial class Main : DevComponents.DotNetBar.Office2007Form
    {
        readonly Time _startTime = Time.Parse("6:00");
        readonly Time _endTime = Time.Parse("8:00");
        readonly DayOfWeek[] _weekdays = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };
        private readonly string _computeDataBase = ConfigHelper.GetConfigString("ComputeDataBase");
        private readonly string _applicationDataBase = ConfigHelper.GetConfigString("ApplicationDataBase");
        private readonly string _netWorkDataBase = ConfigHelper.GetConfigString("NetWorkDataBase");
        Hook m_hook = new Hook();

        public Main()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        /// <summary>
        /// 添加计算机事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddCompute_Click(object sender, EventArgs e)
        {
            IPHostEntry host = GetHostByName(txtComputeName.Text.Trim());


            for (int i = 0; i < host.AddressList.Length; i++)
            {
                if (host.AddressList[i].ToString().Substring(0, 3).Equals("192"))
                {
                    Compute compute = new Compute();
                    compute.Name = txtComputeName.Text.Trim();
                    compute.Remark = txtRemark.Text.Trim();
                    compute.Select = true;
                    compute.Online = true;
                    compute.Ip = host.AddressList[i].ToString();
                    if (GetCompute(compute) == null)
                    {
                        bandCompute(compute);
                        //添加计算机
                        AddCompute(compute, _computeDataBase);
                    }

                }
            }

            BandComputeList(_computeDataBase);

        }
        /// <summary>
        /// 初始化加载，程序主入口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Load(object sender, EventArgs e)
        {
            //绑定应用程序列表
            BandApplicationList();

            //刷新计算机列表
            var refreshListThread = new Thread(refreshList);
            refreshListThread.IsBackground = true;
            refreshListThread.Start();

            //加载启动应用程序列表
            var startAppli = new Thread(startApplication);
            startAppli.IsBackground = true;
            startAppli.Start();

            //刷新域添加新上线的计算机
            var selectCompute = new Thread(SelectComputes);
            selectCompute.IsBackground = true;
            selectCompute.Start();
            //是否写入日志
            chkAppStartWriteLog.Checked = ConfigHelper.GetConfigBool("autowritelog");



            //ActiveHook.SetWindowPos(this.Handle, IntPtr.Zero, 0, 0, 800, 600, ActiveHook.SWP_NOACTIVATE);
            //m_hook.OnKeyDown += new Hook.KeyboardDelegate(OnHookKeyDown);

        }
        void OnHookKeyDown(KeyEventArgs e)
        {
            OnKeyDown(e);
            if (e.Handled)
            {
                return;
            }
            if (((Control.ModifierKeys & Keys.Shift) == Keys.Shift) && ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                    && ((Control.ModifierKeys & Keys.Alt) == Keys.Alt))
            {

                if (!this.Visible)
                {
                    this.Show();
                }
            }
            if (e.KeyCode == Keys.F10)
            {
                this.Hide();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            m_hook.SetHook(true);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_hook.SetHook(false);
        }

        void EnumComputersByDirectoryEntry()
        {
            using (var root = new DirectoryEntry("WinNT:"))
            {
                //查询所有域
                foreach (DirectoryEntry domain in root.Children)
                {
                    //textBox1.Text += "Domain | WorkGroup:\t" + domain.Name + "\r\n";
                    //查询域中所有计算机
                    foreach (DirectoryEntry computer in domain.Children)
                    {
                        try
                        {
                            IPHostEntry host = Dns.GetHostByName(computer.Name);

                            for (int i = 0; i < host.AddressList.Length; i++)
                            {
                                if (host.AddressList[i].ToString().Substring(0, 3).Equals("192"))
                                {
                                    Compute compute = new Compute();
                                    compute.Name = computer.Name;
                                    compute.Remark = computer.Name;
                                    compute.Select = true;
                                    compute.Online = true;
                                    compute.Ip = host.AddressList[i].ToString();

                                    //绑定计算机
                                    bandCompute(compute);
                                    //添加计算机
                                    AddCompute(compute, _computeDataBase);

                                }
                            }
                            //BandComputeList(_computeDataBase);
                        }
                        catch { }
                        //textBox1.Text += "Computer:\t" + computer.Name + "\t" + ip + "\t" + computer.AuthenticationType + "\r\n";
                    }
                }
            }
        }

        /// <summary>
        /// 刷新计算机列表事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Thread refreshListThread = new Thread(RefreshComputeList);
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
            AddApplication(textAppName.Text, textAppAddress.Text, _applicationDataBase);
            BandApplicationList();
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
            xmlDoc.Load(_computeDataBase);
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
                    xmlDoc.Save(_computeDataBase);
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
            ConfigHelper.SetAppConfig("autowritelog", chkAppStartWriteLog.Checked.ToString());
        }
        void startApplication()
        {
            while (true)
            {
                StartApp();
                Thread.Sleep(60000);
            }
        }

        /// <summary>
        /// 刷新计算机列表
        /// </summary>
        void refreshList()
        {
            while (true)
            {
                lock (dgComputeList)
                {
                    RefreshComputeList(_computeDataBase);
                    Thread.Sleep(ConfigHelper.GetConfigInt("RefreshComputesTime"));
                }
            }
        }
        /// <summary>
        /// 通过域方式查询计算机
        /// </summary>
        void SelectComputes()
        {
            while (true)
            {
                lock (dgComputeList)
                {
                    EnumComputersByDirectoryEntry();
                    Thread.Sleep(ConfigHelper.GetConfigInt("SelectComputesTime"));
                }
            }
        }
        /// <summary>
        /// 刷新计算机列表
        /// </summary>
        protected void RefreshComputeList()
        {
            lock (dgComputeList)
            {
                RefreshComputeList(_computeDataBase);
            }
        }
        /// <summary>
        /// 刷新计算机列表
        /// </summary>
        /// <param name="xmlPath"></param>
        protected void RefreshComputeList(string xmlPath)
        {
            string value = string.Empty;
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);
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
                                if (host.AddressList[i].ToString() == xmlip.InnerText)
                                {
                                    WriteLog(host.HostName, xmlip.InnerText, xmlremark.InnerText);
                                    break;
                                }
                            }
                            if (xmlname.InnerText != host.HostName)
                            {
                                xmlname.InnerText = host.HostName;
                            }
                        }
                        var compute = new Compute();
                        compute.Select = bool.Parse(xmlselect.InnerText);
                        compute.Online = bool.Parse(xmlonline.InnerText);
                        compute.Name = xmlname.InnerText;
                        compute.Ip = xmlip.InnerText;
                        compute.Remark = xmlremark.InnerText;
                        bandCompute(compute);
                    }
                    xmlDoc.Save(xmlPath);
                    //BandComputeList();
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
        /// 绑定计算机到DataGridView
        /// </summary>
        /// <param name="compute"></param>
        void bandCompute(Compute compute)
        {
            if (dgComputeList.Rows.Count == 0)
            {
                dgComputeList.Rows.Add(compute.Select, compute.Online, compute.Name, compute.Ip, compute.Remark);
                return;
            }
            bool isExist = false;
            for (int i = 0; i < dgComputeList.Rows.Count; i++)
            {
                if (compute.Name.ToLower() == dgComputeList.Rows[i].Cells[2].Value.ToString().ToLower() &&
                    compute.Ip.ToLower() == dgComputeList.Rows[i].Cells[3].Value.ToString().ToLower())
                {
                    dgComputeList.Rows[i].Cells[0].Value = compute.Select;
                    dgComputeList.Rows[i].Cells[1].Value = compute.Online;
                    dgComputeList.Rows[i].Cells[2].Value = compute.Name;
                    dgComputeList.Rows[i].Cells[3].Value = compute.Ip;
                    dgComputeList.Rows[i].Cells[4].Value = compute.Remark;
                    isExist = true;
                    break;
                }
            }
            if (!isExist)
            {
                dgComputeList.Rows.Add(compute.Select, compute.Online, compute.Name, compute.Ip, compute.Remark);
            }
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
        protected void BandComputeList(string xmlPath)
        {
            try
            {
                lock (dgComputeList)
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(xmlPath);
                    dgComputeList.DataSource = ds;
                    dgComputeList.DataMember = "compute";
                }
            }
            catch
            {
                //MessageBox.Show("绑定错误！");
                throw;
            }
        }
        /// <summary>
        /// 绑定应用程序列表
        /// </summary>
        protected void BandApplicationList()
        {
            try
            {
                var ds = new DataSet();
                ds.ReadXml(_applicationDataBase);
                dgApplicationList.DataSource = ds;
                if (ds.Tables.Count > 0)
                {
                    dgApplicationList.DataMember = "application";
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        /// <summary>
        /// 添加计算机
        /// </summary>
        /// <param name="name">计算机名称</param>
        /// <param name="remark"></param>
        /// <param name="xmlPath"></param>
        protected void AddCompute(Compute compute, string xmlPath)
        {
            // IPHostEntry host = GetHostByName(compute.Name);
            var temp = GetCompute(compute);
            if (temp == null)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlPath);//_computeDataBase

                XmlElement xmlEl = xmlDoc.CreateElement("compute");
                XmlElement xmlselect = xmlDoc.CreateElement("select");
                xmlselect.InnerText = compute.Select.ToString();
                xmlEl.AppendChild(xmlselect);

                XmlElement xmlonline = xmlDoc.CreateElement("online");
                xmlonline.InnerText = compute.Online.ToString();
                xmlEl.AppendChild(xmlonline);

                XmlElement xmlname = xmlDoc.CreateElement("name");
                xmlname.InnerText = compute.Name;
                xmlEl.AppendChild(xmlname);

                XmlElement xmlip = xmlDoc.CreateElement("ip");
                xmlip.InnerText = compute.Ip;
                xmlEl.AppendChild(xmlip);

                XmlElement xmlremark = xmlDoc.CreateElement("remark");
                xmlremark.InnerText = compute.Remark;
                xmlEl.AppendChild(xmlremark);
                xmlDoc.SelectSingleNode("computelist").AppendChild(xmlEl);
                xmlDoc.Save(xmlPath);

            }
            //else
            //{
            //    MessageBox.Show("此计算机不存在！");
            //}
        }
        /// <summary>
        /// 添加应用程序
        /// </summary>
        /// <param name="name">应用程序名称</param>
        protected void AddApplication(string name, string address, string xmlPath)
        {
            if (!string.IsNullOrEmpty(address))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlPath);

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
                xmlDoc.Save(xmlPath);

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
            xmlDoc.Load(_applicationDataBase);
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
                            xmlDoc.Save(_applicationDataBase);
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
        private Compute GetCompute(Compute compute)
        {
            string value = string.Empty;
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(_computeDataBase);
            try
            {

                XmlNodeList nl = xmlDoc.SelectSingleNode("computelist").ChildNodes;
                if (nl.Count > 0)
                {
                    //更新状态
                    foreach (XmlNode node in nl)
                    {
                        if (node.ChildNodes[1].InnerText.ToLower() == compute.Name.ToLower() && node.ChildNodes[2].InnerText.ToLower() == compute.Ip.ToLower())
                        {
                            return ConvertCompute(node);
                        }
                    }
                }
            }
            catch
            {

            }
            return null;
        }
        /// <summary>
        /// 把XmlNode转换为Compute对象
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        Compute ConvertCompute(XmlNode node)
        {
            try
            {
                var compute = new Compute();
                compute.Select = Convert.ToBoolean(node.ChildNodes[0].InnerText); ;
                compute.Name = node.ChildNodes[1].InnerText;
                compute.Ip = node.ChildNodes[2].InnerText;
                compute.Online = Convert.ToBoolean(node.ChildNodes[3].InnerText); ;
                compute.Remark = node.ChildNodes[4].InnerText;
                return compute;
            }
            catch
            {
                return null;
            }

        }
        ///// <summary>
        ///// 把XmlNode转换为Compute对象
        ///// </summary>
        ///// <param name="node"></param>
        ///// <returns></returns>
        //Compute ConvertXmlNode(Compute compute)
        //{
        //    try
        //    {
        //        var compute = new XmlNode();
        //        compute.Select = Convert.ToBoolean(node.ChildNodes[0].InnerText); ;
        //        compute.Name = node.ChildNodes[1].InnerText;
        //        compute.Ip = node.ChildNodes[2].InnerText;
        //        compute.Online = Convert.ToBoolean(node.ChildNodes[3].InnerText); ;
        //        compute.Remark = node.ChildNodes[4].InnerText;
        //        return compute;
        //    }
        //    catch
        //    {
        //        return null;
        //    }

        //}
        /// <summary>
        /// 获得计算机信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string GetAppComputeByName(string name)
        {
            string value = string.Empty;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(_computeDataBase);
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
            if (_startTime.Compare(_endTime) == 1)
            {
                //开始时间小于当前时间且结束时间大于当前时间
                if (_startTime.Compare(DateTime.Now) == 1 && _endTime.Compare(DateTime.Now) == -1)
                {
                    return false;
                }
            }
            else
            {
                //开始时间大于当前时间且结束时间小于当前时间
                if (_startTime.Compare(DateTime.Now) == -1 && _endTime.Compare(DateTime.Now) == 1)
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
            for (int i = 0; i < _weekdays.Length; i++)
            {
                if (date.DayOfWeek == _weekdays[i])
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




        /// <summary>
        /// 关闭窗口事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
            this.Visible = true;
        }
        /// <summary>
        /// 鼠标双击任务栏通知区域图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
            this.Visible = true;
        }
        /// <summary>
        /// 退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Dispose();
            //Application.Exit(); //好像只在主线程可以起作用，而且当有线程，或是阻塞方法的情况下，很容易失灵
            Environment.Exit(0); //无论在主线程和其它线程，只要执行了这句，都可以把程序结束干净
            //Close();
            //Application.ExitThread(); 
        }
    }
}
