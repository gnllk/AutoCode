namespace AutoCode
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusDetail = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.menuItem_file = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_connectDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_help = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_manual = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_about = new System.Windows.Forms.ToolStripMenuItem();
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mainCheckBoxDbName = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mainChckListTable = new System.Windows.Forms.CheckedListBox();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.tabPage_Option = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.txt_Option_Namespace = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Option_SaveFilePath = new System.Windows.Forms.Button();
            this.txt_Option_SaveFilePath = new System.Windows.Forms.TextBox();
            this.btn_Option_SaveFilePath_Open = new System.Windows.Forms.Button();
            this.panel34 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.panel35 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.panel36 = new System.Windows.Forms.Panel();
            this.cbb_Option_CodeEncode = new System.Windows.Forms.ComboBox();
            this.panel37 = new System.Windows.Forms.Panel();
            this.cbb_Option_ProcedureEncode = new System.Windows.Forms.ComboBox();
            this.panel38 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.panel39 = new System.Windows.Forms.Panel();
            this.rbtnFirstLetterCaseLower = new System.Windows.Forms.RadioButton();
            this.rbtnFirstLetterCaseUpper = new System.Windows.Forms.RadioButton();
            this.rbtnFirstLetterCaseIgnore = new System.Windows.Forms.RadioButton();
            this.btn_Option_GenerateAll = new System.Windows.Forms.Button();
            this.tabPage_Entity = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txt_Entity_Suffix = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txt_Entity_Prefix = new System.Windows.Forms.TextBox();
            this.panel22 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.panel23 = new System.Windows.Forms.Panel();
            this.txt_Entity_SubNamespace = new System.Windows.Forms.TextBox();
            this.btn_Entity_Generate = new System.Windows.Forms.Button();
            this.tabPage_Interface = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.txt_Interface_Suffix = new System.Windows.Forms.TextBox();
            this.panel13 = new System.Windows.Forms.Panel();
            this.txt_Interface_Prefix = new System.Windows.Forms.TextBox();
            this.panel24 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel25 = new System.Windows.Forms.Panel();
            this.txt_Interface_SubNamespace = new System.Windows.Forms.TextBox();
            this.btn_Interface_Generate = new System.Windows.Forms.Button();
            this.tabPage_DAL = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.txt_DAL_Suffix = new System.Windows.Forms.TextBox();
            this.panel17 = new System.Windows.Forms.Panel();
            this.txt_DAL_Prefix = new System.Windows.Forms.TextBox();
            this.panel26 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.panel27 = new System.Windows.Forms.Panel();
            this.txt_DAL_SubNamespace = new System.Windows.Forms.TextBox();
            this.btn_DAL_Generate = new System.Windows.Forms.Button();
            this.tabPage_BLL = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.panel18 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel19 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.panel20 = new System.Windows.Forms.Panel();
            this.txt_BLL_Suffix = new System.Windows.Forms.TextBox();
            this.panel21 = new System.Windows.Forms.Panel();
            this.txt_BLL_Prefix = new System.Windows.Forms.TextBox();
            this.panel28 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.panel29 = new System.Windows.Forms.Panel();
            this.txt_BLL_SubNamespace = new System.Windows.Forms.TextBox();
            this.btn_BLL_Generate = new System.Windows.Forms.Button();
            this.tabPage_Procedure = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.panel30 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.panel31 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.panel32 = new System.Windows.Forms.Panel();
            this.txt_Procedure_Suffix = new System.Windows.Forms.TextBox();
            this.panel33 = new System.Windows.Forms.Panel();
            this.txt_Procedure_Prefix = new System.Windows.Forms.TextBox();
            this.btn_Procedure_Generate = new System.Windows.Forms.Button();
            this.mainStatusStrip.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.tabPage_Option.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.panel34.SuspendLayout();
            this.panel35.SuspendLayout();
            this.panel36.SuspendLayout();
            this.panel37.SuspendLayout();
            this.panel38.SuspendLayout();
            this.panel39.SuspendLayout();
            this.tabPage_Entity.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel22.SuspendLayout();
            this.panel23.SuspendLayout();
            this.tabPage_Interface.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panel25.SuspendLayout();
            this.tabPage_DAL.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel26.SuspendLayout();
            this.panel27.SuspendLayout();
            this.tabPage_BLL.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel19.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel21.SuspendLayout();
            this.panel28.SuspendLayout();
            this.panel29.SuspendLayout();
            this.tabPage_Procedure.SuspendLayout();
            this.tableLayoutPanel13.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            this.panel30.SuspendLayout();
            this.panel31.SuspendLayout();
            this.panel32.SuspendLayout();
            this.panel33.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusName,
            this.toolStripProgressBar,
            this.toolStripStatusDetail});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 600);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.mainStatusStrip.Size = new System.Drawing.Size(1095, 26);
            this.mainStatusStrip.TabIndex = 0;
            this.mainStatusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusName
            // 
            this.toolStripStatusName.Name = "toolStripStatusName";
            this.toolStripStatusName.Size = new System.Drawing.Size(39, 21);
            this.toolStripStatusName.Text = "进度";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(133, 20);
            // 
            // toolStripStatusDetail
            // 
            this.toolStripStatusDetail.Name = "toolStripStatusDetail";
            this.toolStripStatusDetail.Size = new System.Drawing.Size(39, 21);
            this.toolStripStatusDetail.Text = "信息";
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.BackColor = System.Drawing.SystemColors.ControlDark;
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_file,
            this.menuItem_help});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.mainMenuStrip.Size = new System.Drawing.Size(1095, 28);
            this.mainMenuStrip.TabIndex = 1;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // menuItem_file
            // 
            this.menuItem_file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_connectDatabase});
            this.menuItem_file.Name = "menuItem_file";
            this.menuItem_file.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.menuItem_file.Size = new System.Drawing.Size(69, 24);
            this.menuItem_file.Text = "文件(F)";
            // 
            // menuItem_connectDatabase
            // 
            this.menuItem_connectDatabase.Name = "menuItem_connectDatabase";
            this.menuItem_connectDatabase.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
            this.menuItem_connectDatabase.Size = new System.Drawing.Size(204, 24);
            this.menuItem_connectDatabase.Text = "链接数据库";
            this.menuItem_connectDatabase.Click += new System.EventHandler(this.menuItem_connectDatabase_Click);
            // 
            // menuItem_help
            // 
            this.menuItem_help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_manual,
            this.menuItem_about});
            this.menuItem_help.Name = "menuItem_help";
            this.menuItem_help.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.menuItem_help.Size = new System.Drawing.Size(73, 24);
            this.menuItem_help.Text = "帮助(H)";
            // 
            // menuItem_manual
            // 
            this.menuItem_manual.Name = "menuItem_manual";
            this.menuItem_manual.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.M)));
            this.menuItem_manual.Size = new System.Drawing.Size(194, 24);
            this.menuItem_manual.Text = "使用手册";
            // 
            // menuItem_about
            // 
            this.menuItem_about.Name = "menuItem_about";
            this.menuItem_about.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.menuItem_about.Size = new System.Drawing.Size(194, 24);
            this.menuItem_about.Text = "关于";
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 28);
            this.mainSplitContainer.Margin = new System.Windows.Forms.Padding(4);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.mainTabControl);
            this.mainSplitContainer.Size = new System.Drawing.Size(1095, 572);
            this.mainSplitContainer.SplitterDistance = 361;
            this.mainSplitContainer.SplitterWidth = 5;
            this.mainSplitContainer.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(361, 572);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mainCheckBoxDbName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(353, 32);
            this.panel1.TabIndex = 0;
            // 
            // mainCheckBoxDbName
            // 
            this.mainCheckBoxDbName.AutoSize = true;
            this.mainCheckBoxDbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainCheckBoxDbName.Location = new System.Drawing.Point(0, 0);
            this.mainCheckBoxDbName.Margin = new System.Windows.Forms.Padding(4);
            this.mainCheckBoxDbName.Name = "mainCheckBoxDbName";
            this.mainCheckBoxDbName.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.mainCheckBoxDbName.Size = new System.Drawing.Size(353, 32);
            this.mainCheckBoxDbName.TabIndex = 0;
            this.mainCheckBoxDbName.Text = "请先链接数据库";
            this.mainCheckBoxDbName.UseVisualStyleBackColor = true;
            this.mainCheckBoxDbName.CheckedChanged += new System.EventHandler(this.mainCheckBoxDbName_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.mainChckListTable);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 44);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(353, 524);
            this.panel2.TabIndex = 1;
            // 
            // mainChckListTable
            // 
            this.mainChckListTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainChckListTable.FormattingEnabled = true;
            this.mainChckListTable.Location = new System.Drawing.Point(0, 0);
            this.mainChckListTable.Margin = new System.Windows.Forms.Padding(4);
            this.mainChckListTable.Name = "mainChckListTable";
            this.mainChckListTable.Size = new System.Drawing.Size(353, 524);
            this.mainChckListTable.TabIndex = 1;
            this.mainChckListTable.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.mainChckListTable_ItemCheck);
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.tabPage_Option);
            this.mainTabControl.Controls.Add(this.tabPage_Entity);
            this.mainTabControl.Controls.Add(this.tabPage_Interface);
            this.mainTabControl.Controls.Add(this.tabPage_DAL);
            this.mainTabControl.Controls.Add(this.tabPage_BLL);
            this.mainTabControl.Controls.Add(this.tabPage_Procedure);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 0);
            this.mainTabControl.Margin = new System.Windows.Forms.Padding(4);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(729, 572);
            this.mainTabControl.TabIndex = 0;
            // 
            // tabPage_Option
            // 
            this.tabPage_Option.Controls.Add(this.tableLayoutPanel5);
            this.tabPage_Option.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Option.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage_Option.Name = "tabPage_Option";
            this.tabPage_Option.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage_Option.Size = new System.Drawing.Size(721, 543);
            this.tabPage_Option.TabIndex = 1;
            this.tabPage_Option.Text = "基本配置";
            this.tabPage_Option.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.btn_Option_GenerateAll, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 189F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(713, 535);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.panel8, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.panel9, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.panel10, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel7, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.panel34, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.panel35, 0, 3);
            this.tableLayoutPanel6.Controls.Add(this.panel36, 1, 2);
            this.tableLayoutPanel6.Controls.Add(this.panel37, 1, 3);
            this.tableLayoutPanel6.Controls.Add(this.panel38, 0, 4);
            this.tableLayoutPanel6.Controls.Add(this.panel39, 1, 4);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 5;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(705, 181);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label4);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(4, 4);
            this.panel8.Margin = new System.Windows.Forms.Padding(4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(125, 28);
            this.panel8.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 5);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "命名空间：";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label5);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(4, 40);
            this.panel9.Margin = new System.Windows.Forms.Padding(4);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(125, 28);
            this.panel9.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 5);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "保存路径：";
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.txt_Option_Namespace);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(137, 4);
            this.panel10.Margin = new System.Windows.Forms.Padding(4);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(564, 28);
            this.panel10.TabIndex = 2;
            // 
            // txt_Option_Namespace
            // 
            this.txt_Option_Namespace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Option_Namespace.Location = new System.Drawing.Point(0, 0);
            this.txt_Option_Namespace.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Option_Namespace.Name = "txt_Option_Namespace";
            this.txt_Option_Namespace.Size = new System.Drawing.Size(564, 25);
            this.txt_Option_Namespace.TabIndex = 0;
            this.txt_Option_Namespace.TextChanged += new System.EventHandler(this.txt_Option_Namespace_TextChanged);
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 3;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel7.Controls.Add(this.btn_Option_SaveFilePath, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.txt_Option_SaveFilePath, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.btn_Option_SaveFilePath_Open, 2, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(133, 36);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(572, 36);
            this.tableLayoutPanel7.TabIndex = 3;
            // 
            // btn_Option_SaveFilePath
            // 
            this.btn_Option_SaveFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Option_SaveFilePath.Location = new System.Drawing.Point(416, 4);
            this.btn_Option_SaveFilePath.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Option_SaveFilePath.Name = "btn_Option_SaveFilePath";
            this.btn_Option_SaveFilePath.Size = new System.Drawing.Size(72, 28);
            this.btn_Option_SaveFilePath.TabIndex = 0;
            this.btn_Option_SaveFilePath.Text = "浏览";
            this.btn_Option_SaveFilePath.UseVisualStyleBackColor = true;
            this.btn_Option_SaveFilePath.Click += new System.EventHandler(this.btn_Option_SaveFilePath_Click);
            // 
            // txt_Option_SaveFilePath
            // 
            this.txt_Option_SaveFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Option_SaveFilePath.Location = new System.Drawing.Point(4, 4);
            this.txt_Option_SaveFilePath.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Option_SaveFilePath.Name = "txt_Option_SaveFilePath";
            this.txt_Option_SaveFilePath.Size = new System.Drawing.Size(404, 25);
            this.txt_Option_SaveFilePath.TabIndex = 1;
            // 
            // btn_Option_SaveFilePath_Open
            // 
            this.btn_Option_SaveFilePath_Open.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Option_SaveFilePath_Open.Location = new System.Drawing.Point(496, 4);
            this.btn_Option_SaveFilePath_Open.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Option_SaveFilePath_Open.Name = "btn_Option_SaveFilePath_Open";
            this.btn_Option_SaveFilePath_Open.Size = new System.Drawing.Size(72, 28);
            this.btn_Option_SaveFilePath_Open.TabIndex = 2;
            this.btn_Option_SaveFilePath_Open.Text = "打开";
            this.btn_Option_SaveFilePath_Open.UseVisualStyleBackColor = true;
            this.btn_Option_SaveFilePath_Open.Click += new System.EventHandler(this.btn_Option_SaveFilePath_Open_Click);
            // 
            // panel34
            // 
            this.panel34.Controls.Add(this.label18);
            this.panel34.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel34.Location = new System.Drawing.Point(4, 76);
            this.panel34.Margin = new System.Windows.Forms.Padding(4);
            this.panel34.Name = "panel34";
            this.panel34.Size = new System.Drawing.Size(125, 28);
            this.panel34.TabIndex = 4;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(5, 5);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(112, 15);
            this.label18.TabIndex = 0;
            this.label18.Text = "代码编码方式：";
            // 
            // panel35
            // 
            this.panel35.Controls.Add(this.label19);
            this.panel35.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel35.Location = new System.Drawing.Point(4, 112);
            this.panel35.Margin = new System.Windows.Forms.Padding(4);
            this.panel35.Name = "panel35";
            this.panel35.Size = new System.Drawing.Size(125, 28);
            this.panel35.TabIndex = 5;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(5, 5);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(112, 15);
            this.label19.TabIndex = 0;
            this.label19.Text = "存储过程编码：";
            // 
            // panel36
            // 
            this.panel36.Controls.Add(this.cbb_Option_CodeEncode);
            this.panel36.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel36.Location = new System.Drawing.Point(137, 76);
            this.panel36.Margin = new System.Windows.Forms.Padding(4);
            this.panel36.Name = "panel36";
            this.panel36.Size = new System.Drawing.Size(564, 28);
            this.panel36.TabIndex = 6;
            // 
            // cbb_Option_CodeEncode
            // 
            this.cbb_Option_CodeEncode.AutoCompleteCustomSource.AddRange(new string[] {
            "GB2312",
            "ASCII",
            "UTF8"});
            this.cbb_Option_CodeEncode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbb_Option_CodeEncode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbb_Option_CodeEncode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbb_Option_CodeEncode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_Option_CodeEncode.FormattingEnabled = true;
            this.cbb_Option_CodeEncode.Items.AddRange(new object[] {
            "GB2312",
            "ASCII",
            "UTF8"});
            this.cbb_Option_CodeEncode.Location = new System.Drawing.Point(0, 0);
            this.cbb_Option_CodeEncode.Margin = new System.Windows.Forms.Padding(4);
            this.cbb_Option_CodeEncode.Name = "cbb_Option_CodeEncode";
            this.cbb_Option_CodeEncode.Size = new System.Drawing.Size(564, 23);
            this.cbb_Option_CodeEncode.TabIndex = 0;
            this.cbb_Option_CodeEncode.TextChanged += new System.EventHandler(this.cbb_Option_CodeEncode_TextChanged);
            // 
            // panel37
            // 
            this.panel37.Controls.Add(this.cbb_Option_ProcedureEncode);
            this.panel37.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel37.Location = new System.Drawing.Point(137, 112);
            this.panel37.Margin = new System.Windows.Forms.Padding(4);
            this.panel37.Name = "panel37";
            this.panel37.Size = new System.Drawing.Size(564, 28);
            this.panel37.TabIndex = 7;
            // 
            // cbb_Option_ProcedureEncode
            // 
            this.cbb_Option_ProcedureEncode.AutoCompleteCustomSource.AddRange(new string[] {
            "GB2312",
            "ASCII",
            "UTF8"});
            this.cbb_Option_ProcedureEncode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbb_Option_ProcedureEncode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbb_Option_ProcedureEncode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbb_Option_ProcedureEncode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_Option_ProcedureEncode.FormattingEnabled = true;
            this.cbb_Option_ProcedureEncode.Items.AddRange(new object[] {
            "GB2312",
            "ASCII",
            "UTF8"});
            this.cbb_Option_ProcedureEncode.Location = new System.Drawing.Point(0, 0);
            this.cbb_Option_ProcedureEncode.Margin = new System.Windows.Forms.Padding(4);
            this.cbb_Option_ProcedureEncode.Name = "cbb_Option_ProcedureEncode";
            this.cbb_Option_ProcedureEncode.Size = new System.Drawing.Size(564, 23);
            this.cbb_Option_ProcedureEncode.TabIndex = 0;
            this.cbb_Option_ProcedureEncode.TextChanged += new System.EventHandler(this.cbb_Option_ProcedureEncode_TextChanged);
            // 
            // panel38
            // 
            this.panel38.Controls.Add(this.label20);
            this.panel38.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel38.Location = new System.Drawing.Point(3, 147);
            this.panel38.Name = "panel38";
            this.panel38.Size = new System.Drawing.Size(127, 31);
            this.panel38.TabIndex = 8;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 8);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(67, 15);
            this.label20.TabIndex = 0;
            this.label20.Text = "首字母：";
            // 
            // panel39
            // 
            this.panel39.Controls.Add(this.rbtnFirstLetterCaseLower);
            this.panel39.Controls.Add(this.rbtnFirstLetterCaseUpper);
            this.panel39.Controls.Add(this.rbtnFirstLetterCaseIgnore);
            this.panel39.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel39.Location = new System.Drawing.Point(136, 147);
            this.panel39.Name = "panel39";
            this.panel39.Size = new System.Drawing.Size(566, 31);
            this.panel39.TabIndex = 9;
            // 
            // rbtnFirstLetterCaseLower
            // 
            this.rbtnFirstLetterCaseLower.AutoSize = true;
            this.rbtnFirstLetterCaseLower.Location = new System.Drawing.Point(163, 6);
            this.rbtnFirstLetterCaseLower.Name = "rbtnFirstLetterCaseLower";
            this.rbtnFirstLetterCaseLower.Size = new System.Drawing.Size(58, 19);
            this.rbtnFirstLetterCaseLower.TabIndex = 2;
            this.rbtnFirstLetterCaseLower.Text = "小写";
            this.rbtnFirstLetterCaseLower.UseVisualStyleBackColor = true;
            this.rbtnFirstLetterCaseLower.CheckedChanged += new System.EventHandler(this.rbtnFirstLetterCaseLower_CheckedChanged);
            // 
            // rbtnFirstLetterCaseUpper
            // 
            this.rbtnFirstLetterCaseUpper.AutoSize = true;
            this.rbtnFirstLetterCaseUpper.Location = new System.Drawing.Point(81, 6);
            this.rbtnFirstLetterCaseUpper.Name = "rbtnFirstLetterCaseUpper";
            this.rbtnFirstLetterCaseUpper.Size = new System.Drawing.Size(58, 19);
            this.rbtnFirstLetterCaseUpper.TabIndex = 1;
            this.rbtnFirstLetterCaseUpper.Text = "大写";
            this.rbtnFirstLetterCaseUpper.UseVisualStyleBackColor = true;
            this.rbtnFirstLetterCaseUpper.CheckedChanged += new System.EventHandler(this.rbtnFirstLetterCaseUpper_CheckedChanged);
            // 
            // rbtnFirstLetterCaseIgnore
            // 
            this.rbtnFirstLetterCaseIgnore.AutoSize = true;
            this.rbtnFirstLetterCaseIgnore.Checked = true;
            this.rbtnFirstLetterCaseIgnore.Location = new System.Drawing.Point(3, 6);
            this.rbtnFirstLetterCaseIgnore.Name = "rbtnFirstLetterCaseIgnore";
            this.rbtnFirstLetterCaseIgnore.Size = new System.Drawing.Size(58, 19);
            this.rbtnFirstLetterCaseIgnore.TabIndex = 0;
            this.rbtnFirstLetterCaseIgnore.TabStop = true;
            this.rbtnFirstLetterCaseIgnore.Text = "忽略";
            this.rbtnFirstLetterCaseIgnore.UseVisualStyleBackColor = true;
            this.rbtnFirstLetterCaseIgnore.CheckedChanged += new System.EventHandler(this.rbtnFirstLetterCaseIgnore_CheckedChanged);
            // 
            // btn_Option_GenerateAll
            // 
            this.btn_Option_GenerateAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Option_GenerateAll.Location = new System.Drawing.Point(4, 193);
            this.btn_Option_GenerateAll.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Option_GenerateAll.Name = "btn_Option_GenerateAll";
            this.btn_Option_GenerateAll.Size = new System.Drawing.Size(705, 41);
            this.btn_Option_GenerateAll.TabIndex = 1;
            this.btn_Option_GenerateAll.Text = "一键生成所有";
            this.btn_Option_GenerateAll.UseVisualStyleBackColor = true;
            this.btn_Option_GenerateAll.Click += new System.EventHandler(this.btn_Option_GenerateAll_Click);
            // 
            // tabPage_Entity
            // 
            this.tabPage_Entity.Controls.Add(this.tableLayoutPanel2);
            this.tabPage_Entity.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Entity.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage_Entity.Name = "tabPage_Entity";
            this.tabPage_Entity.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage_Entity.Size = new System.Drawing.Size(721, 543);
            this.tabPage_Entity.TabIndex = 0;
            this.tabPage_Entity.Text = "生成实体";
            this.tabPage_Entity.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_Entity_Generate, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(713, 535);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.panel6, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel4, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.panel5, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel22, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel23, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(705, 104);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(4, 72);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(125, 28);
            this.panel6.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "实体后缀：";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(4, 38);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(125, 26);
            this.panel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "实体前缀：";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txt_Entity_Suffix);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(137, 72);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(564, 28);
            this.panel4.TabIndex = 1;
            // 
            // txt_Entity_Suffix
            // 
            this.txt_Entity_Suffix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Entity_Suffix.Location = new System.Drawing.Point(0, 0);
            this.txt_Entity_Suffix.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Entity_Suffix.Name = "txt_Entity_Suffix";
            this.txt_Entity_Suffix.Size = new System.Drawing.Size(564, 25);
            this.txt_Entity_Suffix.TabIndex = 0;
            this.txt_Entity_Suffix.Text = "Entity";
            this.txt_Entity_Suffix.TextChanged += new System.EventHandler(this.txt_Entity_Suffix_TextChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txt_Entity_Prefix);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(137, 38);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(564, 26);
            this.panel5.TabIndex = 2;
            // 
            // txt_Entity_Prefix
            // 
            this.txt_Entity_Prefix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Entity_Prefix.Location = new System.Drawing.Point(0, 0);
            this.txt_Entity_Prefix.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Entity_Prefix.Name = "txt_Entity_Prefix";
            this.txt_Entity_Prefix.Size = new System.Drawing.Size(564, 25);
            this.txt_Entity_Prefix.TabIndex = 0;
            this.txt_Entity_Prefix.TextChanged += new System.EventHandler(this.txt_Entity_Prefix_TextChanged);
            // 
            // panel22
            // 
            this.panel22.Controls.Add(this.label11);
            this.panel22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel22.Location = new System.Drawing.Point(4, 4);
            this.panel22.Margin = new System.Windows.Forms.Padding(4);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(125, 26);
            this.panel22.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "子命名空间：";
            // 
            // panel23
            // 
            this.panel23.Controls.Add(this.txt_Entity_SubNamespace);
            this.panel23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel23.Location = new System.Drawing.Point(137, 4);
            this.panel23.Margin = new System.Windows.Forms.Padding(4);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(564, 26);
            this.panel23.TabIndex = 5;
            // 
            // txt_Entity_SubNamespace
            // 
            this.txt_Entity_SubNamespace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Entity_SubNamespace.Location = new System.Drawing.Point(0, 0);
            this.txt_Entity_SubNamespace.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Entity_SubNamespace.Name = "txt_Entity_SubNamespace";
            this.txt_Entity_SubNamespace.Size = new System.Drawing.Size(564, 25);
            this.txt_Entity_SubNamespace.TabIndex = 0;
            this.txt_Entity_SubNamespace.Text = "Entity";
            this.txt_Entity_SubNamespace.TextChanged += new System.EventHandler(this.txt_Entity_SubNamespace_TextChanged);
            // 
            // btn_Entity_Generate
            // 
            this.btn_Entity_Generate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Entity_Generate.Location = new System.Drawing.Point(4, 116);
            this.btn_Entity_Generate.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Entity_Generate.Name = "btn_Entity_Generate";
            this.btn_Entity_Generate.Size = new System.Drawing.Size(705, 30);
            this.btn_Entity_Generate.TabIndex = 1;
            this.btn_Entity_Generate.Text = "生成实体";
            this.btn_Entity_Generate.UseVisualStyleBackColor = true;
            this.btn_Entity_Generate.Click += new System.EventHandler(this.btn_Entity_Generate_Click);
            // 
            // tabPage_Interface
            // 
            this.tabPage_Interface.Controls.Add(this.tableLayoutPanel4);
            this.tabPage_Interface.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Interface.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage_Interface.Name = "tabPage_Interface";
            this.tabPage_Interface.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage_Interface.Size = new System.Drawing.Size(721, 543);
            this.tabPage_Interface.TabIndex = 2;
            this.tabPage_Interface.Text = "生成接口";
            this.tabPage_Interface.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel8, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btn_Interface_Generate, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(713, 535);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.panel7, 0, 2);
            this.tableLayoutPanel8.Controls.Add(this.panel11, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.panel12, 0, 2);
            this.tableLayoutPanel8.Controls.Add(this.panel13, 1, 1);
            this.tableLayoutPanel8.Controls.Add(this.panel24, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.panel25, 1, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 3;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(705, 104);
            this.tableLayoutPanel8.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label3);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(4, 72);
            this.panel7.Margin = new System.Windows.Forms.Padding(4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(125, 28);
            this.panel7.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "接口后缀：";
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.label6);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(4, 38);
            this.panel11.Margin = new System.Windows.Forms.Padding(4);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(125, 26);
            this.panel11.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 5);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "接口前缀：";
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.txt_Interface_Suffix);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(137, 72);
            this.panel12.Margin = new System.Windows.Forms.Padding(4);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(564, 28);
            this.panel12.TabIndex = 1;
            // 
            // txt_Interface_Suffix
            // 
            this.txt_Interface_Suffix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Interface_Suffix.Location = new System.Drawing.Point(0, 0);
            this.txt_Interface_Suffix.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Interface_Suffix.Name = "txt_Interface_Suffix";
            this.txt_Interface_Suffix.Size = new System.Drawing.Size(564, 25);
            this.txt_Interface_Suffix.TabIndex = 0;
            this.txt_Interface_Suffix.TextChanged += new System.EventHandler(this.txt_Interface_Suffix_TextChanged);
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.txt_Interface_Prefix);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(137, 38);
            this.panel13.Margin = new System.Windows.Forms.Padding(4);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(564, 26);
            this.panel13.TabIndex = 2;
            // 
            // txt_Interface_Prefix
            // 
            this.txt_Interface_Prefix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Interface_Prefix.Location = new System.Drawing.Point(0, 0);
            this.txt_Interface_Prefix.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Interface_Prefix.Name = "txt_Interface_Prefix";
            this.txt_Interface_Prefix.Size = new System.Drawing.Size(564, 25);
            this.txt_Interface_Prefix.TabIndex = 0;
            this.txt_Interface_Prefix.Text = "I";
            this.txt_Interface_Prefix.TextChanged += new System.EventHandler(this.txt_Interface_Prefix_TextChanged);
            // 
            // panel24
            // 
            this.panel24.Controls.Add(this.label13);
            this.panel24.Controls.Add(this.label12);
            this.panel24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel24.Location = new System.Drawing.Point(4, 4);
            this.panel24.Margin = new System.Windows.Forms.Padding(4);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(125, 26);
            this.panel24.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 5);
            this.label13.Margin = new System.Windows.Forms.Padding(4);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(97, 15);
            this.label13.TabIndex = 1;
            this.label13.Text = "子命名空间：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 5);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 15);
            this.label12.TabIndex = 0;
            // 
            // panel25
            // 
            this.panel25.Controls.Add(this.txt_Interface_SubNamespace);
            this.panel25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel25.Location = new System.Drawing.Point(137, 4);
            this.panel25.Margin = new System.Windows.Forms.Padding(4);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(564, 26);
            this.panel25.TabIndex = 5;
            // 
            // txt_Interface_SubNamespace
            // 
            this.txt_Interface_SubNamespace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Interface_SubNamespace.Location = new System.Drawing.Point(0, 0);
            this.txt_Interface_SubNamespace.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Interface_SubNamespace.Name = "txt_Interface_SubNamespace";
            this.txt_Interface_SubNamespace.Size = new System.Drawing.Size(564, 25);
            this.txt_Interface_SubNamespace.TabIndex = 0;
            this.txt_Interface_SubNamespace.Text = "Interface";
            this.txt_Interface_SubNamespace.TextChanged += new System.EventHandler(this.txt_Interface_SubNamespace_TextChanged);
            // 
            // btn_Interface_Generate
            // 
            this.btn_Interface_Generate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Interface_Generate.Location = new System.Drawing.Point(4, 116);
            this.btn_Interface_Generate.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Interface_Generate.Name = "btn_Interface_Generate";
            this.btn_Interface_Generate.Size = new System.Drawing.Size(705, 30);
            this.btn_Interface_Generate.TabIndex = 1;
            this.btn_Interface_Generate.Text = "生成接口";
            this.btn_Interface_Generate.UseVisualStyleBackColor = true;
            this.btn_Interface_Generate.Click += new System.EventHandler(this.btn_Interface_Generate_Click);
            // 
            // tabPage_DAL
            // 
            this.tabPage_DAL.Controls.Add(this.tableLayoutPanel9);
            this.tabPage_DAL.Location = new System.Drawing.Point(4, 25);
            this.tabPage_DAL.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage_DAL.Name = "tabPage_DAL";
            this.tabPage_DAL.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage_DAL.Size = new System.Drawing.Size(721, 543);
            this.tabPage_DAL.TabIndex = 3;
            this.tabPage_DAL.Text = "生成DAL";
            this.tabPage_DAL.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel10, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.btn_DAL_Generate, 0, 1);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 3;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(713, 535);
            this.tableLayoutPanel9.TabIndex = 3;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Controls.Add(this.panel14, 0, 2);
            this.tableLayoutPanel10.Controls.Add(this.panel15, 0, 1);
            this.tableLayoutPanel10.Controls.Add(this.panel16, 0, 2);
            this.tableLayoutPanel10.Controls.Add(this.panel17, 1, 1);
            this.tableLayoutPanel10.Controls.Add(this.panel26, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.panel27, 1, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel10.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 3;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(705, 104);
            this.tableLayoutPanel10.TabIndex = 0;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.label7);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel14.Location = new System.Drawing.Point(4, 72);
            this.panel14.Margin = new System.Windows.Forms.Padding(4);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(125, 28);
            this.panel14.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 5);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "DAL后缀：";
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.label8);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel15.Location = new System.Drawing.Point(4, 38);
            this.panel15.Margin = new System.Windows.Forms.Padding(4);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(125, 26);
            this.panel15.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 5);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "DAL前缀：";
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.txt_DAL_Suffix);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel16.Location = new System.Drawing.Point(137, 72);
            this.panel16.Margin = new System.Windows.Forms.Padding(4);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(564, 28);
            this.panel16.TabIndex = 1;
            // 
            // txt_DAL_Suffix
            // 
            this.txt_DAL_Suffix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_DAL_Suffix.Location = new System.Drawing.Point(0, 0);
            this.txt_DAL_Suffix.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_DAL_Suffix.Name = "txt_DAL_Suffix";
            this.txt_DAL_Suffix.Size = new System.Drawing.Size(564, 25);
            this.txt_DAL_Suffix.TabIndex = 0;
            this.txt_DAL_Suffix.Text = "DAL : BaseDAL";
            this.txt_DAL_Suffix.TextChanged += new System.EventHandler(this.txt_DAL_Suffix_TextChanged);
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.txt_DAL_Prefix);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel17.Location = new System.Drawing.Point(137, 38);
            this.panel17.Margin = new System.Windows.Forms.Padding(4);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(564, 26);
            this.panel17.TabIndex = 2;
            // 
            // txt_DAL_Prefix
            // 
            this.txt_DAL_Prefix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_DAL_Prefix.Location = new System.Drawing.Point(0, 0);
            this.txt_DAL_Prefix.Margin = new System.Windows.Forms.Padding(4);
            this.txt_DAL_Prefix.Name = "txt_DAL_Prefix";
            this.txt_DAL_Prefix.Size = new System.Drawing.Size(564, 25);
            this.txt_DAL_Prefix.TabIndex = 0;
            this.txt_DAL_Prefix.TextChanged += new System.EventHandler(this.txt_DAL_Prefix_TextChanged);
            // 
            // panel26
            // 
            this.panel26.Controls.Add(this.label14);
            this.panel26.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel26.Location = new System.Drawing.Point(4, 4);
            this.panel26.Margin = new System.Windows.Forms.Padding(4);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(125, 26);
            this.panel26.TabIndex = 4;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(5, 5);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(97, 15);
            this.label14.TabIndex = 0;
            this.label14.Text = "子命名空间：";
            // 
            // panel27
            // 
            this.panel27.Controls.Add(this.txt_DAL_SubNamespace);
            this.panel27.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel27.Location = new System.Drawing.Point(137, 4);
            this.panel27.Margin = new System.Windows.Forms.Padding(4);
            this.panel27.Name = "panel27";
            this.panel27.Size = new System.Drawing.Size(564, 26);
            this.panel27.TabIndex = 5;
            // 
            // txt_DAL_SubNamespace
            // 
            this.txt_DAL_SubNamespace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_DAL_SubNamespace.Location = new System.Drawing.Point(0, 0);
            this.txt_DAL_SubNamespace.Margin = new System.Windows.Forms.Padding(4);
            this.txt_DAL_SubNamespace.Name = "txt_DAL_SubNamespace";
            this.txt_DAL_SubNamespace.Size = new System.Drawing.Size(564, 25);
            this.txt_DAL_SubNamespace.TabIndex = 0;
            this.txt_DAL_SubNamespace.Text = "DAL";
            this.txt_DAL_SubNamespace.TextChanged += new System.EventHandler(this.txt_DAL_SubNamespace_TextChanged);
            // 
            // btn_DAL_Generate
            // 
            this.btn_DAL_Generate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_DAL_Generate.Location = new System.Drawing.Point(4, 116);
            this.btn_DAL_Generate.Margin = new System.Windows.Forms.Padding(4);
            this.btn_DAL_Generate.Name = "btn_DAL_Generate";
            this.btn_DAL_Generate.Size = new System.Drawing.Size(705, 30);
            this.btn_DAL_Generate.TabIndex = 1;
            this.btn_DAL_Generate.Text = "生成DAL";
            this.btn_DAL_Generate.UseVisualStyleBackColor = true;
            this.btn_DAL_Generate.Click += new System.EventHandler(this.btn_DAL_Generate_Click);
            // 
            // tabPage_BLL
            // 
            this.tabPage_BLL.Controls.Add(this.tableLayoutPanel11);
            this.tabPage_BLL.Location = new System.Drawing.Point(4, 25);
            this.tabPage_BLL.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage_BLL.Name = "tabPage_BLL";
            this.tabPage_BLL.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage_BLL.Size = new System.Drawing.Size(721, 543);
            this.tabPage_BLL.TabIndex = 4;
            this.tabPage_BLL.Text = "生成BLL";
            this.tabPage_BLL.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 1;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.Controls.Add(this.tableLayoutPanel12, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.btn_BLL_Generate, 0, 1);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel11.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 3;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(713, 535);
            this.tableLayoutPanel11.TabIndex = 3;
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.ColumnCount = 2;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.Controls.Add(this.panel18, 0, 2);
            this.tableLayoutPanel12.Controls.Add(this.panel19, 0, 1);
            this.tableLayoutPanel12.Controls.Add(this.panel20, 0, 2);
            this.tableLayoutPanel12.Controls.Add(this.panel21, 1, 1);
            this.tableLayoutPanel12.Controls.Add(this.panel28, 0, 0);
            this.tableLayoutPanel12.Controls.Add(this.panel29, 1, 0);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel12.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 3;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(705, 104);
            this.tableLayoutPanel12.TabIndex = 0;
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.label9);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel18.Location = new System.Drawing.Point(4, 72);
            this.panel18.Margin = new System.Windows.Forms.Padding(4);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(125, 28);
            this.panel18.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 5);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "BLL后缀：";
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.label10);
            this.panel19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel19.Location = new System.Drawing.Point(4, 38);
            this.panel19.Margin = new System.Windows.Forms.Padding(4);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(125, 26);
            this.panel19.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 5);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "BLL前缀：";
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.txt_BLL_Suffix);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel20.Location = new System.Drawing.Point(137, 72);
            this.panel20.Margin = new System.Windows.Forms.Padding(4);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(564, 28);
            this.panel20.TabIndex = 1;
            // 
            // txt_BLL_Suffix
            // 
            this.txt_BLL_Suffix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_BLL_Suffix.Location = new System.Drawing.Point(0, 0);
            this.txt_BLL_Suffix.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_BLL_Suffix.Name = "txt_BLL_Suffix";
            this.txt_BLL_Suffix.Size = new System.Drawing.Size(564, 25);
            this.txt_BLL_Suffix.TabIndex = 0;
            this.txt_BLL_Suffix.Text = "BLL : BaseBLL";
            this.txt_BLL_Suffix.TextChanged += new System.EventHandler(this.txt_BLL_Suffix_TextChanged);
            // 
            // panel21
            // 
            this.panel21.Controls.Add(this.txt_BLL_Prefix);
            this.panel21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel21.Location = new System.Drawing.Point(137, 38);
            this.panel21.Margin = new System.Windows.Forms.Padding(4);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(564, 26);
            this.panel21.TabIndex = 2;
            // 
            // txt_BLL_Prefix
            // 
            this.txt_BLL_Prefix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_BLL_Prefix.Location = new System.Drawing.Point(0, 0);
            this.txt_BLL_Prefix.Margin = new System.Windows.Forms.Padding(4);
            this.txt_BLL_Prefix.Name = "txt_BLL_Prefix";
            this.txt_BLL_Prefix.Size = new System.Drawing.Size(564, 25);
            this.txt_BLL_Prefix.TabIndex = 0;
            this.txt_BLL_Prefix.TextChanged += new System.EventHandler(this.txt_BLL_Prefix_TextChanged);
            // 
            // panel28
            // 
            this.panel28.Controls.Add(this.label15);
            this.panel28.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel28.Location = new System.Drawing.Point(4, 4);
            this.panel28.Margin = new System.Windows.Forms.Padding(4);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(125, 26);
            this.panel28.TabIndex = 4;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(5, 5);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(97, 15);
            this.label15.TabIndex = 0;
            this.label15.Text = "子命名空间：";
            // 
            // panel29
            // 
            this.panel29.Controls.Add(this.txt_BLL_SubNamespace);
            this.panel29.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel29.Location = new System.Drawing.Point(137, 4);
            this.panel29.Margin = new System.Windows.Forms.Padding(4);
            this.panel29.Name = "panel29";
            this.panel29.Size = new System.Drawing.Size(564, 26);
            this.panel29.TabIndex = 5;
            // 
            // txt_BLL_SubNamespace
            // 
            this.txt_BLL_SubNamespace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_BLL_SubNamespace.Location = new System.Drawing.Point(0, 0);
            this.txt_BLL_SubNamespace.Margin = new System.Windows.Forms.Padding(4);
            this.txt_BLL_SubNamespace.Name = "txt_BLL_SubNamespace";
            this.txt_BLL_SubNamespace.Size = new System.Drawing.Size(564, 25);
            this.txt_BLL_SubNamespace.TabIndex = 0;
            this.txt_BLL_SubNamespace.Text = "BLL";
            this.txt_BLL_SubNamespace.TextChanged += new System.EventHandler(this.txt_BLL_SubNamespace_TextChanged);
            // 
            // btn_BLL_Generate
            // 
            this.btn_BLL_Generate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_BLL_Generate.Location = new System.Drawing.Point(4, 116);
            this.btn_BLL_Generate.Margin = new System.Windows.Forms.Padding(4);
            this.btn_BLL_Generate.Name = "btn_BLL_Generate";
            this.btn_BLL_Generate.Size = new System.Drawing.Size(705, 30);
            this.btn_BLL_Generate.TabIndex = 1;
            this.btn_BLL_Generate.Text = "生成BLL";
            this.btn_BLL_Generate.UseVisualStyleBackColor = true;
            this.btn_BLL_Generate.Click += new System.EventHandler(this.btn_BLL_Generate_Click);
            // 
            // tabPage_Procedure
            // 
            this.tabPage_Procedure.Controls.Add(this.tableLayoutPanel13);
            this.tabPage_Procedure.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Procedure.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage_Procedure.Name = "tabPage_Procedure";
            this.tabPage_Procedure.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage_Procedure.Size = new System.Drawing.Size(721, 543);
            this.tabPage_Procedure.TabIndex = 5;
            this.tabPage_Procedure.Text = "生成存储过程";
            this.tabPage_Procedure.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.ColumnCount = 1;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.Controls.Add(this.tableLayoutPanel14, 0, 0);
            this.tableLayoutPanel13.Controls.Add(this.btn_Procedure_Generate, 0, 1);
            this.tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel13.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel13.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 3;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(713, 535);
            this.tableLayoutPanel13.TabIndex = 4;
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.ColumnCount = 2;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel14.Controls.Add(this.panel30, 0, 1);
            this.tableLayoutPanel14.Controls.Add(this.panel31, 0, 0);
            this.tableLayoutPanel14.Controls.Add(this.panel32, 0, 1);
            this.tableLayoutPanel14.Controls.Add(this.panel33, 1, 0);
            this.tableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel14.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel14.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 2;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(705, 67);
            this.tableLayoutPanel14.TabIndex = 0;
            // 
            // panel30
            // 
            this.panel30.Controls.Add(this.label16);
            this.panel30.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel30.Location = new System.Drawing.Point(4, 37);
            this.panel30.Margin = new System.Windows.Forms.Padding(4);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(125, 26);
            this.panel30.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(5, 5);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(112, 15);
            this.label16.TabIndex = 0;
            this.label16.Text = "存储过程后缀：";
            // 
            // panel31
            // 
            this.panel31.Controls.Add(this.label17);
            this.panel31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel31.Location = new System.Drawing.Point(4, 4);
            this.panel31.Margin = new System.Windows.Forms.Padding(4);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(125, 25);
            this.panel31.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(5, 5);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(112, 15);
            this.label17.TabIndex = 0;
            this.label17.Text = "存储过程前缀：";
            // 
            // panel32
            // 
            this.panel32.Controls.Add(this.txt_Procedure_Suffix);
            this.panel32.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel32.Location = new System.Drawing.Point(137, 37);
            this.panel32.Margin = new System.Windows.Forms.Padding(4);
            this.panel32.Name = "panel32";
            this.panel32.Size = new System.Drawing.Size(564, 26);
            this.panel32.TabIndex = 1;
            // 
            // txt_Procedure_Suffix
            // 
            this.txt_Procedure_Suffix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Procedure_Suffix.Location = new System.Drawing.Point(0, 0);
            this.txt_Procedure_Suffix.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Procedure_Suffix.Name = "txt_Procedure_Suffix";
            this.txt_Procedure_Suffix.Size = new System.Drawing.Size(564, 25);
            this.txt_Procedure_Suffix.TabIndex = 0;
            this.txt_Procedure_Suffix.TextChanged += new System.EventHandler(this.txt_Procedure_Suffix_TextChanged);
            // 
            // panel33
            // 
            this.panel33.Controls.Add(this.txt_Procedure_Prefix);
            this.panel33.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel33.Location = new System.Drawing.Point(137, 4);
            this.panel33.Margin = new System.Windows.Forms.Padding(4);
            this.panel33.Name = "panel33";
            this.panel33.Size = new System.Drawing.Size(564, 25);
            this.panel33.TabIndex = 2;
            // 
            // txt_Procedure_Prefix
            // 
            this.txt_Procedure_Prefix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Procedure_Prefix.Location = new System.Drawing.Point(0, 0);
            this.txt_Procedure_Prefix.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Procedure_Prefix.Name = "txt_Procedure_Prefix";
            this.txt_Procedure_Prefix.Size = new System.Drawing.Size(564, 25);
            this.txt_Procedure_Prefix.TabIndex = 0;
            this.txt_Procedure_Prefix.Text = "AutoCode";
            this.txt_Procedure_Prefix.TextChanged += new System.EventHandler(this.txt_Procedure_Prefix_TextChanged);
            // 
            // btn_Procedure_Generate
            // 
            this.btn_Procedure_Generate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Procedure_Generate.Location = new System.Drawing.Point(4, 79);
            this.btn_Procedure_Generate.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Procedure_Generate.Name = "btn_Procedure_Generate";
            this.btn_Procedure_Generate.Size = new System.Drawing.Size(705, 30);
            this.btn_Procedure_Generate.TabIndex = 1;
            this.btn_Procedure_Generate.Text = "生成存储过程";
            this.btn_Procedure_Generate.UseVisualStyleBackColor = true;
            this.btn_Procedure_Generate.Click += new System.EventHandler(this.btn_Procedure_Generate_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 626);
            this.Controls.Add(this.mainSplitContainer);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.mainMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "AutoCode";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.mainTabControl.ResumeLayout(false);
            this.tabPage_Option.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.panel34.ResumeLayout(false);
            this.panel34.PerformLayout();
            this.panel35.ResumeLayout(false);
            this.panel35.PerformLayout();
            this.panel36.ResumeLayout(false);
            this.panel37.ResumeLayout(false);
            this.panel38.ResumeLayout(false);
            this.panel38.PerformLayout();
            this.panel39.ResumeLayout(false);
            this.panel39.PerformLayout();
            this.tabPage_Entity.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel22.ResumeLayout(false);
            this.panel22.PerformLayout();
            this.panel23.ResumeLayout(false);
            this.panel23.PerformLayout();
            this.tabPage_Interface.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel24.ResumeLayout(false);
            this.panel24.PerformLayout();
            this.panel25.ResumeLayout(false);
            this.panel25.PerformLayout();
            this.tabPage_DAL.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.panel26.ResumeLayout(false);
            this.panel26.PerformLayout();
            this.panel27.ResumeLayout(false);
            this.panel27.PerformLayout();
            this.tabPage_BLL.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel12.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            this.panel19.ResumeLayout(false);
            this.panel19.PerformLayout();
            this.panel20.ResumeLayout(false);
            this.panel20.PerformLayout();
            this.panel21.ResumeLayout(false);
            this.panel21.PerformLayout();
            this.panel28.ResumeLayout(false);
            this.panel28.PerformLayout();
            this.panel29.ResumeLayout(false);
            this.panel29.PerformLayout();
            this.tabPage_Procedure.ResumeLayout(false);
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel14.ResumeLayout(false);
            this.panel30.ResumeLayout(false);
            this.panel30.PerformLayout();
            this.panel31.ResumeLayout(false);
            this.panel31.PerformLayout();
            this.panel32.ResumeLayout(false);
            this.panel32.PerformLayout();
            this.panel33.ResumeLayout(false);
            this.panel33.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusName;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusDetail;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuItem_file;
        private System.Windows.Forms.ToolStripMenuItem menuItem_connectDatabase;
        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox mainCheckBoxDbName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage tabPage_Option;
        private System.Windows.Forms.TabPage tabPage_Entity;
        private System.Windows.Forms.TabPage tabPage_Interface;
        private System.Windows.Forms.TabPage tabPage_DAL;
        private System.Windows.Forms.TabPage tabPage_BLL;
        private System.Windows.Forms.TabPage tabPage_Procedure;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.TextBox txt_Option_Namespace;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Button btn_Option_SaveFilePath;
        private System.Windows.Forms.TextBox txt_Option_SaveFilePath;
        private System.Windows.Forms.Button btn_Option_GenerateAll;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txt_Entity_Suffix;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txt_Entity_Prefix;
        private System.Windows.Forms.Button btn_Entity_Generate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.TextBox txt_Interface_Suffix;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.TextBox txt_Interface_Prefix;
        private System.Windows.Forms.Button btn_Interface_Generate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.TextBox txt_DAL_Suffix;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.TextBox txt_DAL_Prefix;
        private System.Windows.Forms.Button btn_DAL_Generate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.TextBox txt_BLL_Suffix;
        private System.Windows.Forms.Panel panel21;
        private System.Windows.Forms.TextBox txt_BLL_Prefix;
        private System.Windows.Forms.Button btn_BLL_Generate;
        private System.Windows.Forms.Panel panel22;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel23;
        private System.Windows.Forms.TextBox txt_Entity_SubNamespace;
        private System.Windows.Forms.Panel panel24;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel25;
        private System.Windows.Forms.TextBox txt_Interface_SubNamespace;
        private System.Windows.Forms.Panel panel26;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel27;
        private System.Windows.Forms.TextBox txt_DAL_SubNamespace;
        private System.Windows.Forms.Panel panel28;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel29;
        private System.Windows.Forms.TextBox txt_BLL_SubNamespace;
        private System.Windows.Forms.CheckedListBox mainChckListTable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        private System.Windows.Forms.Panel panel30;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel31;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel32;
        private System.Windows.Forms.TextBox txt_Procedure_Suffix;
        private System.Windows.Forms.Panel panel33;
        private System.Windows.Forms.TextBox txt_Procedure_Prefix;
        private System.Windows.Forms.Button btn_Procedure_Generate;
        private System.Windows.Forms.ToolStripMenuItem menuItem_help;
        private System.Windows.Forms.ToolStripMenuItem menuItem_manual;
        private System.Windows.Forms.ToolStripMenuItem menuItem_about;
        private System.Windows.Forms.Panel panel34;
        private System.Windows.Forms.Panel panel35;
        private System.Windows.Forms.Panel panel36;
        private System.Windows.Forms.Panel panel37;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cbb_Option_CodeEncode;
        private System.Windows.Forms.ComboBox cbb_Option_ProcedureEncode;
        private System.Windows.Forms.Button btn_Option_SaveFilePath_Open;
        private System.Windows.Forms.Panel panel38;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel panel39;
        private System.Windows.Forms.RadioButton rbtnFirstLetterCaseLower;
        private System.Windows.Forms.RadioButton rbtnFirstLetterCaseUpper;
        private System.Windows.Forms.RadioButton rbtnFirstLetterCaseIgnore;
        
    }
}

