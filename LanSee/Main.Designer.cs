namespace LanSee
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabcompute = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgComputeList = new System.Windows.Forms.DataGridView();
            this.select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.online = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnDelCompute = new System.Windows.Forms.Button();
            this.chkAppStartWriteLog = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtComputeName = new System.Windows.Forms.TextBox();
            this.computename = new System.Windows.Forms.Label();
            this.btnAddCompute = new System.Windows.Forms.Button();
            this.tabnetwork = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnDelNetwork = new System.Windows.Forms.Button();
            this.btnAddNetwork = new System.Windows.Forms.Button();
            this.txtEndIp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStartIp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabApp = new System.Windows.Forms.TabPage();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dgApplicationList = new System.Windows.Forms.DataGridView();
            this.columnSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.columnAppName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnAppAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnprocessname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel7 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.textAppAddress = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnDelApp = new System.Windows.Forms.Button();
            this.textAppName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAddApp = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabcompute.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgComputeList)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabnetwork.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel5.SuspendLayout();
            this.tabApp.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgApplicationList)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel4.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabcompute);
            this.tabControl1.Controls.Add(this.tabnetwork);
            this.tabControl1.Controls.Add(this.tabApp);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(582, 559);
            this.tabControl1.TabIndex = 0;
            // 
            // tabcompute
            // 
            this.tabcompute.Controls.Add(this.panel2);
            this.tabcompute.Controls.Add(this.panel1);
            this.tabcompute.Location = new System.Drawing.Point(4, 22);
            this.tabcompute.Name = "tabcompute";
            this.tabcompute.Padding = new System.Windows.Forms.Padding(3);
            this.tabcompute.Size = new System.Drawing.Size(574, 533);
            this.tabcompute.TabIndex = 0;
            this.tabcompute.Text = "计算机管理";
            this.tabcompute.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgComputeList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 89);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(568, 441);
            this.panel2.TabIndex = 1;
            // 
            // dgComputeList
            // 
            this.dgComputeList.AllowUserToAddRows = false;
            this.dgComputeList.AllowUserToDeleteRows = false;
            this.dgComputeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgComputeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.select,
            this.online,
            this.name,
            this.ip,
            this.remark});
            this.dgComputeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgComputeList.Location = new System.Drawing.Point(0, 0);
            this.dgComputeList.Name = "dgComputeList";
            this.dgComputeList.RowTemplate.Height = 23;
            this.dgComputeList.Size = new System.Drawing.Size(568, 441);
            this.dgComputeList.TabIndex = 0;
            this.dgComputeList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgComputeList_CellEndEdit);
            // 
            // select
            // 
            this.select.FalseValue = "";
            this.select.HeaderText = "选中";
            this.select.Name = "select";
            // 
            // online
            // 
            this.online.HeaderText = "是否在线";
            this.online.Name = "online";
            this.online.ReadOnly = true;
            // 
            // name
            // 
            this.name.HeaderText = "计算机名称";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // ip
            // 
            this.ip.HeaderText = "IP地址";
            this.ip.Name = "ip";
            this.ip.ReadOnly = true;
            // 
            // remark
            // 
            this.remark.HeaderText = "备注";
            this.remark.Name = "remark";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtRemark);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btnDelCompute);
            this.panel1.Controls.Add(this.chkAppStartWriteLog);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.txtComputeName);
            this.panel1.Controls.Add(this.computename);
            this.panel1.Controls.Add(this.btnAddCompute);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(568, 86);
            this.panel1.TabIndex = 0;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(110, 49);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(129, 21);
            this.txtRemark.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(43, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 12;
            this.label9.Text = "备注：";
            // 
            // btnDelCompute
            // 
            this.btnDelCompute.Location = new System.Drawing.Point(245, 47);
            this.btnDelCompute.Name = "btnDelCompute";
            this.btnDelCompute.Size = new System.Drawing.Size(75, 23);
            this.btnDelCompute.TabIndex = 11;
            this.btnDelCompute.Text = "删除计算机";
            this.btnDelCompute.UseVisualStyleBackColor = true;
            this.btnDelCompute.Click += new System.EventHandler(this.btnDelCompute_Click);
            // 
            // chkAppStartWriteLog
            // 
            this.chkAppStartWriteLog.AutoSize = true;
            this.chkAppStartWriteLog.Checked = true;
            this.chkAppStartWriteLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAppStartWriteLog.Location = new System.Drawing.Point(329, 51);
            this.chkAppStartWriteLog.Name = "chkAppStartWriteLog";
            this.chkAppStartWriteLog.Size = new System.Drawing.Size(72, 16);
            this.chkAppStartWriteLog.TabIndex = 10;
            this.chkAppStartWriteLog.Text = "自动计时";
            this.chkAppStartWriteLog.UseVisualStyleBackColor = true;
            this.chkAppStartWriteLog.CheckedChanged += new System.EventHandler(this.chkAppStartWriteLog_CheckedChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(326, 16);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtComputeName
            // 
            this.txtComputeName.Location = new System.Drawing.Point(110, 18);
            this.txtComputeName.Name = "txtComputeName";
            this.txtComputeName.Size = new System.Drawing.Size(129, 21);
            this.txtComputeName.TabIndex = 2;
            // 
            // computename
            // 
            this.computename.AutoSize = true;
            this.computename.Location = new System.Drawing.Point(27, 21);
            this.computename.Name = "computename";
            this.computename.Size = new System.Drawing.Size(77, 12);
            this.computename.TabIndex = 1;
            this.computename.Text = "计算机名称：";
            // 
            // btnAddCompute
            // 
            this.btnAddCompute.Location = new System.Drawing.Point(245, 16);
            this.btnAddCompute.Name = "btnAddCompute";
            this.btnAddCompute.Size = new System.Drawing.Size(75, 23);
            this.btnAddCompute.TabIndex = 0;
            this.btnAddCompute.Text = "添加计算机";
            this.btnAddCompute.UseVisualStyleBackColor = true;
            this.btnAddCompute.Click += new System.EventHandler(this.btnAddCompute_Click);
            // 
            // tabnetwork
            // 
            this.tabnetwork.Controls.Add(this.panel6);
            this.tabnetwork.Controls.Add(this.panel5);
            this.tabnetwork.Location = new System.Drawing.Point(4, 22);
            this.tabnetwork.Name = "tabnetwork";
            this.tabnetwork.Padding = new System.Windows.Forms.Padding(3);
            this.tabnetwork.Size = new System.Drawing.Size(574, 533);
            this.tabnetwork.TabIndex = 1;
            this.tabnetwork.Text = "网段设置";
            this.tabnetwork.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dataGridView1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 55);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(568, 475);
            this.panel6.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(568, 475);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnDelNetwork);
            this.panel5.Controls.Add(this.btnAddNetwork);
            this.panel5.Controls.Add(this.txtEndIp);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.txtStartIp);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(568, 52);
            this.panel5.TabIndex = 0;
            // 
            // btnDelNetwork
            // 
            this.btnDelNetwork.Location = new System.Drawing.Point(482, 10);
            this.btnDelNetwork.Name = "btnDelNetwork";
            this.btnDelNetwork.Size = new System.Drawing.Size(75, 23);
            this.btnDelNetwork.TabIndex = 15;
            this.btnDelNetwork.Text = "删除网段";
            this.btnDelNetwork.UseVisualStyleBackColor = true;
            this.btnDelNetwork.Click += new System.EventHandler(this.btnDelNetwork_Click);
            // 
            // btnAddNetwork
            // 
            this.btnAddNetwork.Location = new System.Drawing.Point(401, 10);
            this.btnAddNetwork.Name = "btnAddNetwork";
            this.btnAddNetwork.Size = new System.Drawing.Size(75, 23);
            this.btnAddNetwork.TabIndex = 14;
            this.btnAddNetwork.Text = "添加网段";
            this.btnAddNetwork.UseVisualStyleBackColor = true;
            this.btnAddNetwork.Click += new System.EventHandler(this.btnAddNetwork_Click);
            // 
            // txtEndIp
            // 
            this.txtEndIp.Location = new System.Drawing.Point(293, 12);
            this.txtEndIp.Name = "txtEndIp";
            this.txtEndIp.Size = new System.Drawing.Size(102, 21);
            this.txtEndIp.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(247, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "结束IP：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "起始IP：";
            // 
            // txtStartIp
            // 
            this.txtStartIp.Location = new System.Drawing.Point(139, 12);
            this.txtStartIp.Name = "txtStartIp";
            this.txtStartIp.Size = new System.Drawing.Size(102, 21);
            this.txtStartIp.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "网段扫描：";
            // 
            // tabApp
            // 
            this.tabApp.Controls.Add(this.panel8);
            this.tabApp.Controls.Add(this.panel7);
            this.tabApp.Location = new System.Drawing.Point(4, 22);
            this.tabApp.Name = "tabApp";
            this.tabApp.Padding = new System.Windows.Forms.Padding(3);
            this.tabApp.Size = new System.Drawing.Size(574, 533);
            this.tabApp.TabIndex = 2;
            this.tabApp.Text = "应用程序设置";
            this.tabApp.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.dgApplicationList);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(3, 87);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(568, 443);
            this.panel8.TabIndex = 1;
            // 
            // dgApplicationList
            // 
            this.dgApplicationList.AllowUserToAddRows = false;
            this.dgApplicationList.AllowUserToDeleteRows = false;
            this.dgApplicationList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgApplicationList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnSelect,
            this.columnAppName,
            this.columnAppAddress,
            this.columnprocessname});
            this.dgApplicationList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgApplicationList.Location = new System.Drawing.Point(0, 0);
            this.dgApplicationList.Name = "dgApplicationList";
            this.dgApplicationList.RowTemplate.Height = 23;
            this.dgApplicationList.Size = new System.Drawing.Size(568, 443);
            this.dgApplicationList.TabIndex = 1;
            // 
            // columnSelect
            // 
            this.columnSelect.DataPropertyName = "select";
            this.columnSelect.HeaderText = "启动";
            this.columnSelect.Name = "columnSelect";
            // 
            // columnAppName
            // 
            this.columnAppName.DataPropertyName = "name";
            this.columnAppName.HeaderText = "应用程序名称";
            this.columnAppName.Name = "columnAppName";
            // 
            // columnAppAddress
            // 
            this.columnAppAddress.DataPropertyName = "address";
            this.columnAppAddress.HeaderText = "应用程序地址";
            this.columnAppAddress.Name = "columnAppAddress";
            // 
            // columnprocessname
            // 
            this.columnprocessname.DataPropertyName = "processname";
            this.columnprocessname.HeaderText = "进程名";
            this.columnprocessname.Name = "columnprocessname";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.button2);
            this.panel7.Controls.Add(this.textAppAddress);
            this.panel7.Controls.Add(this.label10);
            this.panel7.Controls.Add(this.btnDelApp);
            this.panel7.Controls.Add(this.textAppName);
            this.panel7.Controls.Add(this.label8);
            this.panel7.Controls.Add(this.btnAddApp);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(3, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(568, 84);
            this.panel7.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(237, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(12, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "..";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textAppAddress
            // 
            this.textAppAddress.Location = new System.Drawing.Point(102, 19);
            this.textAppAddress.Name = "textAppAddress";
            this.textAppAddress.Size = new System.Drawing.Size(129, 21);
            this.textAppAddress.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 12);
            this.label10.TabIndex = 16;
            this.label10.Text = "应用程序地址：";
            // 
            // btnDelApp
            // 
            this.btnDelApp.Location = new System.Drawing.Point(254, 44);
            this.btnDelApp.Name = "btnDelApp";
            this.btnDelApp.Size = new System.Drawing.Size(85, 23);
            this.btnDelApp.TabIndex = 15;
            this.btnDelApp.Text = "删除应用程序";
            this.btnDelApp.UseVisualStyleBackColor = true;
            // 
            // textAppName
            // 
            this.textAppName.Location = new System.Drawing.Point(102, 46);
            this.textAppName.Name = "textAppName";
            this.textAppName.Size = new System.Drawing.Size(129, 21);
            this.textAppName.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "应用程序名称：";
            // 
            // btnAddApp
            // 
            this.btnAddApp.Location = new System.Drawing.Point(254, 17);
            this.btnAddApp.Name = "btnAddApp";
            this.btnAddApp.Size = new System.Drawing.Size(85, 23);
            this.btnAddApp.TabIndex = 12;
            this.btnAddApp.Text = "添加应用程序";
            this.btnAddApp.UseVisualStyleBackColor = true;
            this.btnAddApp.Click += new System.EventHandler(this.btnAddApp_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 103);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(568, 304);
            this.panel3.TabIndex = 1;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewCheckBoxColumn2});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(568, 304);
            this.dataGridView2.TabIndex = 0;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "选中";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "计算机名称";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "IP地址";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.HeaderText = "是否在线";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.textBox1);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.textBox4);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.textBox5);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.button3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(568, 100);
            this.panel4.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(399, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "添加网段";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(291, 59);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(102, 21);
            this.textBox1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "结束IP：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "起始IP：";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(137, 59);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(102, 21);
            this.textBox4.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "网段扫描：";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(110, 18);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(129, 21);
            this.textBox5.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "计算机名称：";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(399, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "添加计算机";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "局域网监控";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 559);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "局域网监控";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Main_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabcompute.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgComputeList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabnetwork.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tabApp.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgApplicationList)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabcompute;
        private System.Windows.Forms.TabPage tabnetwork;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgComputeList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddCompute;
        private System.Windows.Forms.TextBox txtComputeName;
        private System.Windows.Forms.Label computename;
        private System.Windows.Forms.TabPage tabApp;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnAddNetwork;
        private System.Windows.Forms.TextBox txtEndIp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStartIp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelNetwork;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.CheckBox chkAppStartWriteLog;
        private System.Windows.Forms.Button btnDelCompute;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.DataGridView dgApplicationList;
        private System.Windows.Forms.Button btnDelApp;
        private System.Windows.Forms.TextBox textAppName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAddApp;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textAppAddress;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnAppName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnAppAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnprocessname;
        private System.Windows.Forms.DataGridViewCheckBoxColumn select;
        private System.Windows.Forms.DataGridViewCheckBoxColumn online;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn ip;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;

    }
}