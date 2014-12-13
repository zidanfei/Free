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
using System.Web.UI.WebControls;
using System.Xml;
using System.Collections;

namespace ShutDown
{
    public partial class Main : Form
    {
        public Main()
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

            p.StandardInput.WriteLine("shutdown -s -t 1");
            p.StandardInput.WriteLine("shutdown -a");

            p.StandardInput.WriteLine("exit");

            //MessageBox.Show("ok!!!");
            p.Close();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            excute();
        }



        private void cmbHours_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonSetting_Click(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {

        }

        private void buttonexecute_Click(object sender, EventArgs e)
        {
            //opreate op = opers[cmbType.SelectedValue];

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }

        void bandCombox(ComboBox cmb, int start, int end)
        {
            if (start < end)
            {
                for (int i = start; i <= end; i++)
                {
                    cmb.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
            }
            else
            {
                for (int i = start; i >= end; i++)
                {
                    cmb.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
            }
            cmb.SelectedIndex = 0;
        }
        void bandCombox(ComboBox cmb, ListItem[] arr)
        {
            cmb.Items.AddRange(arr);
            if (arr.Length > 0)
            {
                cmb.SelectedIndex = 0;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            bandCombox(cmbCycleHours, 0, 23);
            bandCombox(cmbCycleMinutes, 0, 59);
            bandCombox(cmbEverydayHours, 0, 23);
            bandCombox(cmbEverydayMinute, 0, 59);
            bandCombox(cmbCountDownHours, 0, 23);
            bandCombox(cmbCountDownMinutes, 0, 59);
            bandCombox(cmbSystemRunTimeHours, 0, 23);
            bandCombox(cmbSystemRunTimeMinutes, 0, 59);
            bandCombox(cmbMouseStopHours, 0, 23);
            bandCombox(cmbMouseStopMinutes, 0, 59);
            bandCombox(cmbCycle, new ListItem[7] { new ListItem("星期一", DayOfWeek.Monday.ToString()), 
                new ListItem("星期二", DayOfWeek.Tuesday.ToString()),new ListItem("星期三", DayOfWeek.Wednesday.ToString()),
                new ListItem("星期四", DayOfWeek.Thursday.ToString()),new ListItem("星期五", DayOfWeek.Friday.ToString()),
                new ListItem("星期六", DayOfWeek.Saturday.ToString()),new ListItem("星期日", DayOfWeek.Sunday.ToString()) });
            opers = ReadOperationList();
            ListItem[] opl=new ListItem[opers.Count];
            int i=0;
            foreach(string op in opers.Keys)
            {
                opl[i] = new ListItem(opers[op].name, opers[op].value);
                i++;
            }
            bandCombox(cmbType, opl);
        }
        Dictionary<string, opreate> opers;
        Dictionary<string, opreate>  ReadOperationList()
        {
            Dictionary<string, opreate> opers = new Dictionary<string, opreate>();
            //opreate[] oper = new opreate[0];
            string value = string.Empty;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("operation.xml");
            try
            {
                XmlNodeList nl = xmlDoc.SelectSingleNode("operationList").ChildNodes;

                if (nl.Count > 0)
                {
                    //oper = new opreate[nl.Count];
                    //int i=0;
                    //更新状态
                    foreach (XmlNode node in nl)
                    {
                        opreate op = new opreate();
                        XmlNode xmlname = node.SelectSingleNode("name");
                        op.name = xmlname.InnerText;
                        XmlNode xmlvalue = node.SelectSingleNode("value");
                        op.value = xmlvalue.InnerText;
                        XmlNode xmliscommand = node.SelectSingleNode("iscommand");
                        op.iscommand = Convert.ToBoolean(xmliscommand.InnerText);
                        XmlNode xmlcommand = node.SelectSingleNode("command");
                        op.command = xmlcommand.InnerText;
                        XmlNode xmlparameter = node.SelectSingleNode("parameter");
                        op.parameter = xmlparameter.InnerText;
                        //oper[i] = op;
                        opers.Add(op.value, op);
                        //i++;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return opers;
        }
        class opreate
        {
            internal string name;
            internal string value;
            internal bool iscommand;
            internal string command;
            internal string parameter;
        }
    }
}
