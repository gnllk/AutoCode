using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Data.Common;
using AutoCode.Entity;
using AutoCode.Utils;
using AutoCode.SqlCreator;
using AutoCode.CodeCreator.Factory;

namespace AutoCode
{
    public partial class MainForm : Form
    {
        #region 窗口操作

        public MainForm()
        {
            InitializeComponent();
            AppInit();
        }

        public void AppInit()
        {
            try
            {
                mainTabControl.Enabled = false;
                toolStripProgressBar.Maximum = 100;
                toolStripProgressBar.Minimum = 0;
                toolStripProgressBar.Style = ProgressBarStyle.Continuous;
                ConfigManager.LoadConfig();

                txt_Option_Namespace.Text = ConfigManager.Config.Namespace;
                txt_Option_SaveFilePath.Text = ConfigManager.Config.SaveFilePath;
                cbb_Option_CodeEncode.SelectedIndex = ConfigManager.Config.CodeEncodeSelectIndex;
                cbb_Option_ProcedureEncode.SelectedIndex = ConfigManager.Config.ProcedureEncodeSelectIndex;

                txt_Entity_SubNamespace.Text = ConfigManager.Config.EntitySubNamespace;
                txt_Entity_Prefix.Text = ConfigManager.Config.EntityPrefix;
                txt_Entity_Suffix.Text = ConfigManager.Config.EntitySuffix;

                txt_Interface_SubNamespace.Text = ConfigManager.Config.InterfaceSubNamespace;
                txt_Interface_Prefix.Text = ConfigManager.Config.InterfacePrefix;
                txt_Interface_Suffix.Text = ConfigManager.Config.InterfaceSuffix;

                txt_DAL_SubNamespace.Text = ConfigManager.Config.DALSubNamespace;
                txt_DAL_Prefix.Text = ConfigManager.Config.DALPrefix;
                txt_DAL_Suffix.Text = ConfigManager.Config.DALSuffix;

                txt_BLL_SubNamespace.Text = ConfigManager.Config.BLLSubNamespace;
                txt_BLL_Prefix.Text = ConfigManager.Config.BLLPrefix;
                txt_BLL_Suffix.Text = ConfigManager.Config.BLLSuffix;

                txt_Procedure_Prefix.Text = ConfigManager.Config.ProcedurePrefix;
                txt_Procedure_Suffix.Text = ConfigManager.Config.ProcedureSuffix;

                SelectFirstLetter(ConfigManager.Config.FirstLetterSelectIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public const int BttSleepTime = 1000;

        public const int SttSleepTime = 500;

        public bool IsOneKey { get; set; }

        public void SetProgressBar(int step)
        {
            if (step > -1 && step < 101)
                toolStripProgressBar.Value = step;
        }

        public void SetProgressBarByThread(int step)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<int>(SetProgressBar), step);
            }
            else
            {
                SetProgressBar(step);
            }
        }

        public void SetStatusMessage(string msg)
        {
            if (null != msg)
                toolStripStatusDetail.Text = msg;
        }

        public void SetStatusMessageByThread(string mag)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(SetStatusMessage), mag);
            }
            else
            {
                SetStatusMessage(mag);
            }
        }

        public void Enable()
        {
            menuItem_file.Enabled = true;
            mainSplitContainer.Enabled = true;
        }

        public void EnableByThread()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(Enable));
            }
            else
            {
                Enable();
            }
        }

        public void Unable()
        {
            menuItem_file.Enabled = false;
            mainSplitContainer.Enabled = false;
        }

        public void UnableByThread()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(Unable));
            }
            else
            {
                Unable();
            }
        }

        #endregion 窗口操作

        #region 按钮事件

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ConfigManager.SaveConfig();
            }
            catch { }
        }

        private void mainChckListTable_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                int checkedCount = mainChckListTable.CheckedItems.Count;
                if (checkedCount < 0) checkedCount = 0;
                if (e.NewValue == CheckState.Checked)
                {
                    toolStripStatusDetail.Text = string.Format("总共{0}张表，选中{1}张表", mainChckListTable.Items.Count, checkedCount + 1);
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    toolStripStatusDetail.Text = string.Format("总共{0}张表，选中{1}张表", mainChckListTable.Items.Count, checkedCount - 1);
                }
            }
            catch { }
        }

        private void mainCheckBoxDbName_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox obj = sender as CheckBox;
                if (null != obj && null != mainChckListTable.Items)
                {
                    int count = mainChckListTable.Items.Count;
                    for (int i = 0; i < count; i++)
                    {
                        mainChckListTable.SetItemChecked(i, obj.Checked);
                    }
                    toolStripStatusDetail.Text = string.Format("总共{0}张表，选中{1}张表", count, obj.Checked ? count : 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void menuItem_connectDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem obj = sender as ToolStripMenuItem;
                if (null != obj)
                {
                    ConnToDbForm form = new ConnToDbForm();
                    form.FormClosed += new FormClosedEventHandler(ConnToDbFormClosed);
                    form.TopLevel = true;
                    form.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void ConnToDbFormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (ConfigManager.LoginSuccess)
                {
                    mainTabControl.Enabled = true;
                    mainCheckBoxDbName.Text = ConfigManager.Config.DbName;
                    List<TableNameEntity> tblist = null;
                    string conStr = ConfigManager.DbFactory.CreateConnStr(
                        ConfigManager.Config.DbServerName, ConfigManager.Config.DbName,
                        ConfigManager.Config.DbLoginName, ConfigManager.Config.DbLoginPwd);
                    using (DbConnection conn = ConfigManager.DbFactory.GetConnection(conStr))
                    {
                        DbCommand cmd = ConfigManager.DbFactory.GetCommand(conn,
                            ConfigManager.SpecificSql.GetTableNameSql(ConfigManager.Config.DbName));
                        tblist = DbHelper.GetList<TableNameEntity>(cmd);
                    }
                    ConfigManager.DatabaseTable = tblist;
                    if (null != tblist && tblist.Count > 0)
                    {
                        //初始化链表
                        mainChckListTable.Items.Clear();
                        foreach (TableNameEntity item in tblist)
                        {
                            mainChckListTable.Items.Add(item.Name);
                        }
                        //全选中
                        mainCheckBoxDbName.Checked = true;
                        mainCheckBoxDbName_CheckedChanged(mainCheckBoxDbName, new EventArgs());
                    }
                    else
                    {
                        mainTabControl.Enabled = false;
                        mainChckListTable.Items.Clear();
                        MessageBox.Show(string.Format("数据库{0}没有任何表", ConfigManager.Config.DbName));
                    }
                }
                else if (ConfigManager.ClickLogin)
                {
                    mainTabControl.Enabled = false;
                    MessageBox.Show("请链接数据库");
                }
            }
            catch (Exception ex)
            {
                mainTabControl.Enabled = true;
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Option_SaveFilePath_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.ShowNewFolderButton = true;
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ConfigManager.Config.SaveFilePath = dialog.SelectedPath;
                    txt_Option_SaveFilePath.Text = dialog.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Option_SaveFilePath_Open_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_Option_SaveFilePath.Text.Trim()))
                {
                    System.Diagnostics.Process.Start("explorer.exe", txt_Option_SaveFilePath.Text.Trim());
                }
                else
                {
                    MessageBox.Show("请先点击“浏览”按键选择路径");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //单击生成

        private void btn_Option_GenerateAll_Click(object sender, EventArgs e)
        {
            IsOneKey = true;
            if (mainChckListTable.CheckedItems.Count > 0)
            {
                System.Threading.Tasks.Task.Factory.StartNew(new Action(delegate()
                {
                    try
                    {
                        UnableByThread();
                        SetProgressBarByThread(1);
                        SetStatusMessageByThread("正在生成实体...");
                        btn_Entity_Generate_Click(btn_Entity_Generate, null);
                        SetProgressBarByThread(20);
                        Thread.Sleep(BttSleepTime);
                        SetStatusMessageByThread("正在生成接口...");
                        btn_Interface_Generate_Click(btn_Interface_Generate, null);
                        SetProgressBarByThread(40);
                        Thread.Sleep(BttSleepTime);
                        SetStatusMessageByThread("正在生成DAL...");
                        btn_DAL_Generate_Click(btn_DAL_Generate, null);
                        SetProgressBarByThread(60);
                        Thread.Sleep(BttSleepTime);
                        SetStatusMessageByThread("正在生成BLL...");
                        btn_BLL_Generate_Click(btn_BLL_Generate, null);
                        SetProgressBarByThread(80);
                        Thread.Sleep(BttSleepTime);
                        SetStatusMessageByThread("正在生成存储过程脚本...");
                        btn_Procedure_Generate_Click(btn_Procedure_Generate, null);
                        SetProgressBarByThread(100);
                        Thread.Sleep(BttSleepTime);
                        SetStatusMessageByThread("一键生成所有已完成");
                    }
                    catch (Exception ex)
                    {
                        SetStatusMessageByThread(ex.Message);
                    }
                    finally
                    {
                        EnableByThread();
                    }
                }));
            }
            else
            {
                MessageBox.Show("请选择表");
            }
        }

        private void btn_Entity_Generate_Click(object sender, EventArgs e)
        {
            try
            {
                if (e != null) IsOneKey = false;

                Config config = ConfigManager.Config;
                if (string.IsNullOrEmpty(config.Namespace))
                {
                    MessageBox.Show("请填写命名空间");
                    return;
                }
                if (string.IsNullOrEmpty(config.SaveFilePath))
                {
                    MessageBox.Show("请选择文件保存路径");
                    return;
                }
                if (mainChckListTable.CheckedItems.Count > 0)
                {
                    if (this.IsOneKey)
                    {
                        foreach (var item in mainChckListTable.CheckedItems)
                        {
                            var names = GetEntityNames(config, item.ToString());
                            GenerateEntity(ConfigManager.Config, names);
                        }
                    }
                    else
                    {
                        System.Threading.Tasks.Task.Factory.StartNew(new Action(delegate()
                        {
                            try
                            {
                                UnableByThread();
                                int count = mainChckListTable.CheckedItems.Count;
                                double rate = 100.0 / count;
                                for (int i = 0; i < count; i++)
                                {
                                    string tableName = mainChckListTable.CheckedItems[i].ToString();
                                    var names = GetEntityNames(config, tableName);
                                    SetProgressBarByThread((int)(rate * (i + 1)));
                                    SetStatusMessageByThread(string.Format("正在生成实体{0}...", names.EntityClassName));
                                    Thread.Sleep(SttSleepTime);
                                    GenerateEntity(ConfigManager.Config, names);
                                }
                                SetProgressBarByThread(100);
                                SetStatusMessageByThread(string.Format("生成实体完成"));
                            }
                            catch (Exception ex)
                            {
                                SetStatusMessageByThread(ex.Message);
                            }
                            finally
                            {
                                EnableByThread();
                            }
                        }));
                    }
                }
                else
                {
                    MessageBox.Show("请选择表");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Interface_Generate_Click(object sender, EventArgs e)
        {
            try
            {
                if (e != null) IsOneKey = false;

                var config = ConfigManager.Config;
                if (string.IsNullOrEmpty(config.Namespace))
                {
                    MessageBox.Show("请填写命名空间");
                    return;
                }
                if (string.IsNullOrEmpty(config.SaveFilePath))
                {
                    MessageBox.Show("请选择文件保存路径");
                    return;
                }

                if (mainChckListTable.CheckedItems.Count > 0)
                {
                    if (this.IsOneKey)
                    {
                        foreach (var item in mainChckListTable.CheckedItems)
                        {
                            string tableName = item.ToString();
                            var names = GetInterfaceNames(config, tableName);
                            GenerateInterface(config, names);
                        }
                    }
                    else
                    {
                        System.Threading.Tasks.Task.Factory.StartNew(new Action(delegate()
                        {
                            try
                            {
                                UnableByThread();
                                int count = mainChckListTable.CheckedItems.Count;
                                double rate = 100.0 / count;
                                for (int i = 0; i < count; i++)
                                {
                                    string tableName = mainChckListTable.CheckedItems[i].ToString();
                                    var names = GetInterfaceNames(config, tableName);
                                    SetProgressBarByThread((int)(rate * (i + 1)));
                                    SetStatusMessageByThread(string.Format("正在生成接口{0}...", names.InterfaceClassName));
                                    Thread.Sleep(SttSleepTime);
                                    GenerateInterface(config, names);
                                }
                                SetProgressBarByThread(100);
                                SetStatusMessageByThread(string.Format("生成接口完成"));
                            }
                            catch (Exception ex)
                            {
                                SetStatusMessageByThread(ex.Message);
                            }
                            finally
                            {
                                EnableByThread();
                            }
                        }));
                    }
                }
                else
                {
                    MessageBox.Show("请选择表");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_DAL_Generate_Click(object sender, EventArgs e)
        {
            try
            {
                if (e != null) IsOneKey = false;
                var config = ConfigManager.Config;
                if (string.IsNullOrEmpty(ConfigManager.Config.Namespace))
                {
                    MessageBox.Show("请填写命名空间");
                    return;
                }
                if (string.IsNullOrEmpty(ConfigManager.Config.SaveFilePath))
                {
                    MessageBox.Show("请选择文件保存路径");
                    return;
                }

                if (mainChckListTable.CheckedItems.Count > 0)
                {
                    if (this.IsOneKey)
                    {
                        foreach (var item in mainChckListTable.CheckedItems)
                        {
                            string tableName = item.ToString();
                            var names = GetDALNames(config, tableName);
                            GenerateDAL(config, names);
                        }
                    }
                    else
                    {
                        System.Threading.Tasks.Task.Factory.StartNew(new Action(delegate()
                        {
                            try
                            {
                                UnableByThread();
                                int count = mainChckListTable.CheckedItems.Count;
                                double rate = 100.0 / count;
                                for (int i = 0; i < count; i++)
                                {
                                    string tableName = mainChckListTable.CheckedItems[i].ToString();
                                    var names = GetDALNames(config, tableName);
                                    SetProgressBarByThread((int)(rate * (i + 1)));
                                    SetStatusMessageByThread(string.Format("正在生成DAL{0}...", names.DALClassName));
                                    Thread.Sleep(SttSleepTime);
                                    GenerateDAL(config, names);
                                }
                                SetProgressBarByThread(100);
                                SetStatusMessageByThread(string.Format("生成DAL完成"));
                            }
                            catch (Exception ex)
                            {
                                SetStatusMessageByThread(ex.Message);
                            }
                            finally
                            {
                                EnableByThread();
                            }
                        }));
                    }
                }
                else
                {
                    MessageBox.Show("请选择表");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_BLL_Generate_Click(object sender, EventArgs e)
        {
            try
            {
                if (e != null) IsOneKey = false;
                var config = ConfigManager.Config;
                if (string.IsNullOrEmpty(ConfigManager.Config.Namespace))
                {
                    MessageBox.Show("请填写命名空间");
                    return;
                }
                if (string.IsNullOrEmpty(ConfigManager.Config.SaveFilePath))
                {
                    MessageBox.Show("请选择文件保存路径");
                    return;
                }

                if (mainChckListTable.CheckedItems.Count > 0)
                {
                    if (this.IsOneKey)
                    {
                        foreach (var item in mainChckListTable.CheckedItems)
                        {
                            string tableName = item.ToString();
                            var names = GetBLLNames(config, tableName);
                            GenerateBLL(config, names);
                        }
                    }
                    else
                    {
                        System.Threading.Tasks.Task.Factory.StartNew(new Action(delegate()
                        {
                            try
                            {
                                UnableByThread();
                                int count = mainChckListTable.CheckedItems.Count;
                                double rate = 100.0 / count;
                                for (int i = 0; i < count; i++)
                                {
                                    string tableName = mainChckListTable.CheckedItems[i].ToString();
                                    var names = GetBLLNames(config, tableName);
                                    SetProgressBarByThread((int)(rate * (i + 1)));
                                    SetStatusMessageByThread(string.Format("正在生成BLL{0}...", names.BLLClassName));
                                    Thread.Sleep(SttSleepTime);
                                    GenerateBLL(config, names);
                                }
                                SetProgressBarByThread(100);
                                SetStatusMessageByThread(string.Format("生成BLL完成"));
                            }
                            catch (Exception ex)
                            {
                                SetStatusMessageByThread(ex.Message);
                            }
                            finally
                            {
                                EnableByThread();
                            }
                        }));
                    }
                }
                else
                {
                    MessageBox.Show("请选择表");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Procedure_Generate_Click(object sender, EventArgs e)
        {
            try
            {
                if (e != null) IsOneKey = false;
                string prefix = ConfigManager.Config.ProcedurePrefix;
                string suffix = ConfigManager.Config.ProcedureSuffix;
                if (mainChckListTable.CheckedItems.Count > 0)
                {
                    if (this.IsOneKey)
                    {
                        string filePath = Path.Combine(ConfigManager.Config.SaveFilePath, "SQL");
                        string fileName = Path.Combine(filePath, "Procedures.sql");
                        if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
                        using (FileStream fs = new FileStream(fileName, FileMode.Create))
                        {
                            StreamWriter writer = new StreamWriter(fs, GetProcedureEncoding(ConfigManager.Config));
                            writer.Write("-- ================================================\r\n"
                                + "-- 生成时间：{0}\r\n"
                                + "-- 创建存储过程执行脚本\r\n"
                                + "-- 该脚本由AutoCodo自动生成\r\n"
                                + "-- ================================================\r\n\r\n", DateTime.Now);
                            foreach (var item in mainChckListTable.CheckedItems)
                            {
                                string tableName = item.ToString();
                                GenerateProcedure(ConfigManager.Config, writer, tableName, prefix, suffix);
                            }
                            writer.Close();
                        }
                    }
                    else
                    {
                        System.Threading.Tasks.Task.Factory.StartNew(new Action(delegate()
                        {
                            try
                            {
                                UnableByThread();
                                string filePath = Path.Combine(ConfigManager.Config.SaveFilePath, "SQL");
                                string fileName = Path.Combine(filePath, "Procedures.sql");
                                if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
                                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                                {
                                    StreamWriter writer = new StreamWriter(fs, GetProcedureEncoding(ConfigManager.Config));
                                    writer.Write("-- ================================================\r\n"
                                        + "-- 生成时间：{0}\r\n"
                                        + "-- 创建存储过程执行脚本\r\n"
                                        + "-- 该脚本由AutoCodo自动生成\r\n"
                                        + "-- ================================================\r\n\r\n", DateTime.Now);
                                    int count = mainChckListTable.CheckedItems.Count;
                                    double rate = 100.0 / count;
                                    for (int i = 0; i < count; i++)
                                    {
                                        string tableName = mainChckListTable.CheckedItems[i].ToString();
                                        SetProgressBarByThread((int)(rate * (i + 1)));
                                        SetStatusMessageByThread(string.Format("正在生成表{0}的存储过程...", tableName));
                                        Thread.Sleep(SttSleepTime);
                                        GenerateProcedure(ConfigManager.Config, writer, tableName, prefix, suffix);
                                    }
                                    SetProgressBarByThread(100);
                                    SetStatusMessageByThread(string.Format("生成存储过程完成"));
                                    writer.Close();
                                }
                            }
                            catch (Exception ex)
                            {
                                SetStatusMessageByThread(ex.Message);
                            }
                            finally
                            {
                                EnableByThread();
                            }
                        }));
                    }
                }
                else
                {
                    MessageBox.Show("请选择表");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion 按钮事件

        #region 文本编码

        private Encoding GetCodeEncoding(Config config)
        {
            string encodingStr = config.CodeEncode.Trim();
            return GetEncoding(encodingStr);
        }

        private Encoding GetProcedureEncoding(Config config)
        {
            string encodingStr = config.ProcedureEncode.Trim();
            return GetEncoding(encodingStr);
        }

        private Encoding GetEncoding(string encodingStr)
        {
            switch (encodingStr)
            {
                case "GB2312": return Encoding.GetEncoding("GB2312");
                case "UTF8": return Encoding.UTF8;
                case "UTF8(NO BOM)": return new UTF8Encoding(false);
                case "ASCII": return Encoding.ASCII;
                default: return Encoding.Default;
            }
        }

        #endregion 文本编码

        #region 生成对象

        private void GenerateEntity(Config config, GenNames names)
        {
            string fileName = BuildPath(config, names, CodeGenType.Entity, CodeLanType.CSharp);
            CreateDirIfNotExist(fileName);
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                StreamWriter writer = new StreamWriter(fs, GetCodeEncoding(config));

                var creator = new EntityCreatorFactory(writer, names, config, GetTableDataRow(names.TableName)).GetCodeCreator(CodeLanType.CSharp);
                creator.Generate();
            }
        }

        private void GenerateInterface(Config config, GenNames names)
        {
            string fileName = BuildPath(config, names, CodeGenType.Interface, CodeLanType.CSharp);
            CreateDirIfNotExist(fileName);
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                StreamWriter writer = new StreamWriter(fs, GetCodeEncoding(config));

                var creator = new InterfaceCreatorFactory(writer, names, config, GetTableDataRow(names.TableName)).GetCodeCreator(CodeLanType.CSharp);
                creator.Generate();
            }
        }

        private void GenerateDAL(Config config, GenNames names)
        {
            string fileName = BuildPath(config, names, CodeGenType.DAL, CodeLanType.CSharp);
            CreateDirIfNotExist(fileName);
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                StreamWriter writer = new StreamWriter(fs, GetCodeEncoding(config));

                var creator = new DALCreatorFactory(writer, names, config, GetTableDataRow(names.TableName)).GetCodeCreator(CodeLanType.CSharp);
                creator.Generate();
            }
        }

        private void GenerateBLL(Config config, GenNames names)
        {
            string fileName = BuildPath(config, names, CodeGenType.BLL, CodeLanType.CSharp);
            CreateDirIfNotExist(fileName);
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                StreamWriter writer = new StreamWriter(fs, GetCodeEncoding(config));

                var creator = new BLLCreatorFactory(writer, names, config, GetTableDataRow(names.TableName)).GetCodeCreator(CodeLanType.CSharp);
                creator.Generate();
            }
        }

        private void GenerateProcedure(Config config, StreamWriter writer, string tableName, string prefix, string suffix)
        {
            if (!string.IsNullOrEmpty(tableName))
            {
                //table columns
                string conStr = ConfigManager.DbFactory.CreateConnStr(ConfigManager.Config.DbServerName,
                ConfigManager.Config.DbName, ConfigManager.Config.DbLoginName, ConfigManager.Config.DbLoginPwd);
                List<ColumnNameEntity> list = null;
                using (DbConnection conn = ConfigManager.DbFactory.GetConnection(conStr))
                {
                    DbCommand cmd = ConfigManager.DbFactory.GetCommand(conn,
                        ConfigManager.SpecificSql.GetColumnNameSql(ConfigManager.Config.DbName, tableName));
                    list = DbHelper.GetList<ColumnNameEntity>(cmd);
                }
                if (null != list && list.Count > 0)
                {
                    string procedure = tableName;
                    if (!string.IsNullOrEmpty(prefix)) procedure = prefix + "_" + procedure;
                    if (!string.IsNullOrEmpty(suffix)) procedure = procedure + "_" + suffix;
                    ISqlCreator creator = SqlCreatorFactory.GetSqlCreator(config.DbType);
                    //drop
                    creator.DropProcesure(writer, config.DbName, procedure + "_Get");
                    writer.WriteLine();
                    creator.DropProcesure(writer, config.DbName, procedure + "_Add");
                    writer.WriteLine();
                    creator.DropProcesure(writer, config.DbName, procedure + "_Edit");
                    writer.WriteLine();
                    creator.DropProcesure(writer, config.DbName, procedure + "_Delete");
                    writer.WriteLine();
                    creator.DropProcesure(writer, config.DbName, procedure + "_GetList");
                    writer.WriteLine();
                    //create
                    creator.CreateGetProcedure(writer, list, config.DbName, tableName, procedure + "_Get");
                    writer.WriteLine();
                    creator.CreateAddProcedure(writer, list, config.DbName, tableName, procedure + "_Add");
                    writer.WriteLine();
                    creator.CreateEditProcedure(writer, list, config.DbName, tableName, procedure + "_Edit");
                    writer.WriteLine();
                    creator.CreateDeleteProcedure(writer, list, config.DbName, tableName, procedure + "_Delete");
                    writer.WriteLine();
                    creator.CreateGetListProcedure(writer, list, config.DbName, tableName, procedure + "_GetList");
                    writer.WriteLine();
                }
            }
        }

        #endregion 生成对象

        #region 辅助函数

        private GenNames GetEntityNames(Config config, string tableName)
        {
            var names = new GenNames();
            string prefix = ConfigManager.Config.EntityPrefix;
            string suffix = ConfigManager.Config.EntitySuffix;
            string nameSP = ConfigManager.Config.Namespace;
            string subNSP = ConfigManager.Config.EntitySubNamespace.ReplaceStart(",", string.Empty);

            string classFullName = GetObjectName(tableName, prefix, suffix);

            names.EntityClassName = GetObjectName(classFullName, string.Empty, string.Empty, RegexOptions.None);
            names.EntityInheritanceName = classFullName.ReplaceStart(names.EntityClassName, string.Empty);
            names.EntityNameSpace = string.IsNullOrWhiteSpace(subNSP) ? nameSP : string.Format("{0}.{1}", nameSP, subNSP);

            names.TableName = tableName;
            names.Prefix = prefix;
            names.Suffix = suffix;

            return names;
        }

        private GenNames GetInterfaceNames(Config config, string tableName)
        {
            GenNames names = GetEntityNames(config, tableName);
            string prefix = ConfigManager.Config.InterfacePrefix;
            string suffix = ConfigManager.Config.InterfaceSuffix;
            string nameSP = ConfigManager.Config.Namespace;
            string subNSP = ConfigManager.Config.InterfaceSubNamespace.ReplaceStart(",", string.Empty);

            string classFullName = GetObjectName(tableName, prefix, suffix);

            names.InterfaceClassName = GetObjectName(classFullName, string.Empty, string.Empty, RegexOptions.None);
            names.InterfaceInheritanceName = classFullName.ReplaceStart(names.InterfaceClassName, string.Empty);
            names.InterfaceNameSpace = string.IsNullOrWhiteSpace(subNSP) ? nameSP : string.Format("{0}.{1}", nameSP, subNSP);

            names.TableName = tableName;
            names.Prefix = prefix;
            names.Suffix = suffix;

            return names;
        }

        private GenNames GetDALNames(Config config, string tableName)
        {
            GenNames names = GetInterfaceNames(config, tableName);
            string prefix = ConfigManager.Config.DALPrefix;
            string suffix = ConfigManager.Config.DALSuffix;
            string nameSP = ConfigManager.Config.Namespace;
            string subNSP = ConfigManager.Config.DALSubNamespace.ReplaceStart(",", string.Empty);

            string classFullName = GetObjectName(tableName, prefix, suffix);

            names.DALClassName = GetObjectName(classFullName, string.Empty, string.Empty, RegexOptions.None);
            names.DALInheritanceName = classFullName.ReplaceStart(names.DALClassName, string.Empty);
            names.DALNameSpace = string.IsNullOrWhiteSpace(subNSP) ? nameSP : string.Format("{0}.{1}", nameSP, subNSP);

            names.TableName = tableName;
            names.Prefix = prefix;
            names.Suffix = suffix;

            return names;
        }

        private GenNames GetBLLNames(Config config, string tableName)
        {
            GenNames names = GetDALNames(config, tableName);
            string prefix = ConfigManager.Config.BLLPrefix;
            string suffix = ConfigManager.Config.BLLSuffix;
            string nameSP = ConfigManager.Config.Namespace;
            string subNSP = ConfigManager.Config.BLLSubNamespace.ReplaceStart(",", string.Empty);

            string classFullName = GetObjectName(tableName, prefix, suffix);

            names.BLLClassName = GetObjectName(classFullName, string.Empty, string.Empty, RegexOptions.None);
            names.BLLInheritanceName = classFullName.ReplaceStart(names.BLLClassName, string.Empty);
            names.BLLNameSpace = string.IsNullOrWhiteSpace(subNSP) ? nameSP : string.Format("{0}.{1}", nameSP, subNSP);

            names.TableName = tableName;
            names.Prefix = prefix;
            names.Suffix = suffix;

            return names;
        }

        private string GetObjectName(string tableName, string prefix, string suffix, RegexOptions option = RegexOptions.RightToLeft)
        {
            Regex reg = new Regex("[a-z0-9A-Z]+", option);
            Match match = reg.Match(tableName);
            return match.Success ? (prefix + FirstLetterCase(match.Value) + suffix)
                : (prefix + FirstLetterCase(tableName) + suffix);
        }

        private string GetTableDescription(string tableName, string _default)
        {
            TableNameEntity row = GetTableDataRow(tableName);
            if (null != row)
            {
                return string.IsNullOrEmpty(row.Description) ? _default : row.Description;
            }
            return _default;
        }

        private string AddFixPerLine(string str, string prefix, string suffix)
        {
            if (!string.IsNullOrEmpty(str))
            {
                StringBuilder writer = new StringBuilder();
                StringReader reader = new StringReader(str);
                string line = reader.ReadLine();
                string next = null;
                while (!string.IsNullOrEmpty(line))
                {
                    next = reader.ReadLine();
                    if (!string.IsNullOrEmpty(next))
                        writer.AppendLine(prefix + line + suffix);
                    else
                        writer.Append(prefix + line + suffix);
                    line = next;
                }
                writer.Replace('\r', ' ', writer.Length - 2, 2);
                writer.Replace('\n', ' ', writer.Length - 2, 2);
                return writer.ToString();
            }
            return string.Empty;
        }

        private TableNameEntity GetTableDataRow(string tableName)
        {
            if (null != ConfigManager.DatabaseTable && ConfigManager.DatabaseTable.Count > 0)
            {
                return ConfigManager.DatabaseTable.Find(e => e.Name == tableName);
            }
            return null;
        }

        private List<ColumnNameEntity> ConvertToColumnNameEntityListFrom(DataTable columnTable)
        {
            List<ColumnNameEntity> list = new List<ColumnNameEntity>();
            if (null != columnTable && null != columnTable.Rows && columnTable.Rows.Count > 0)
            {
                foreach (DataRow row in columnTable.Rows)
                {
                    ColumnNameEntity entity = new ColumnNameEntity();
                    entity.Name = row["name"].ToNotNullString();
                    entity.Description = row["MS_Description"].ToNotNullString();
                    entity.ColumnMaxLength = row["max_length"].ToNotNullString().ToInt32(0);
                    entity.ColumnUserTypeID = row["user_type_id"].ToNotNullString().ToInt32(0);
                    entity.IsIdentity = row["is_identity"].ToNotNullString().ToBoolean(false);
                    entity.IsNullable = row["is_nullable"].ToNotNullString().ToBoolean(false);
                    entity.IsPrimary = row["is_primary_key"].ToNotNullString().ToBoolean(false);
                    entity.IsUnique = row["is_unique"].ToNotNullString().ToBoolean(false);
                    list.Add(entity);
                }
            }
            return list;
        }

        private static string BuildPath(Config config, GenNames names, CodeGenType genType, CodeLanType lanType)
        {
            return Path.Combine(config.SaveFilePath,
                GetSubPath(genType),
                string.Format("{0}.{1}",
                    GetClassName(names, genType),
                    GetFileExtentionName(lanType)));
        }

        private static string GetSubPath(CodeGenType type)
        {
            switch (type)
            {
                case CodeGenType.Entity: return "Entity";
                case CodeGenType.Interface: return "Interface";
                case CodeGenType.DAL: return "DAL";
                case CodeGenType.BLL: return "BLL";
            }
            throw new Exception(string.Format("Not support this generator type {0}", type)); ;
        }

        private static string GetClassName(GenNames names, CodeGenType type)
        {
            switch (type)
            {
                case CodeGenType.Entity: return names.EntityClassName;
                case CodeGenType.Interface: return names.InterfaceClassName;
                case CodeGenType.DAL: return names.DALClassName;
                case CodeGenType.BLL: return names.BLLClassName;
            }
            throw new Exception(string.Format("Not support this generator type {0}", type)); ;
        }

        private static string GetFileExtentionName(CodeLanType lanType)
        {
            switch (lanType)
            {
                case CodeLanType.CSharp: return "cs";
                case CodeLanType.Java: return "java";
            }
            throw new Exception(string.Format("Not support this language type {0}", lanType));
        }

        private static void CreateDirIfNotExist(string fileName)
        {
            string filePath = Path.GetDirectoryName(fileName);
            if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
        }

        #endregion 辅助函数

        #region 修改配置

        private void txt_Option_Namespace_TextChanged(object sender, EventArgs e)
        {
            ConfigManager.Config.Namespace = txt_Option_Namespace.Text.Trim();
        }

        private void cbb_Option_CodeEncode_TextChanged(object sender, EventArgs e)
        {
            ConfigManager.Config.CodeEncode = cbb_Option_CodeEncode.Text.Trim();
            ConfigManager.Config.CodeEncodeSelectIndex = cbb_Option_CodeEncode.SelectedIndex;
        }

        private void cbb_Option_ProcedureEncode_TextChanged(object sender, EventArgs e)
        {
            ConfigManager.Config.ProcedureEncode = cbb_Option_ProcedureEncode.Text.Trim();
            ConfigManager.Config.ProcedureEncodeSelectIndex = cbb_Option_ProcedureEncode.SelectedIndex;
        }

        private void txt_Entity_SubNamespace_TextChanged(object sender, EventArgs e)
        {
            ConfigManager.Config.EntitySubNamespace = txt_Entity_SubNamespace.Text.Trim();
        }

        private void txt_Entity_Prefix_TextChanged(object sender, EventArgs e)
        {
            ConfigManager.Config.EntityPrefix = txt_Entity_Prefix.Text.Trim();
        }

        private void txt_Entity_Suffix_TextChanged(object sender, EventArgs e)
        {
            ConfigManager.Config.EntitySuffix = txt_Entity_Suffix.Text.Trim();
        }

        private void txt_Interface_SubNamespace_TextChanged(object sender, EventArgs e)
        {
            ConfigManager.Config.InterfaceSubNamespace = txt_Interface_SubNamespace.Text.Trim();
        }

        private void txt_Interface_Prefix_TextChanged(object sender, EventArgs e)
        {
            ConfigManager.Config.InterfacePrefix = txt_Interface_Prefix.Text.Trim();
        }

        private void txt_Interface_Suffix_TextChanged(object sender, EventArgs e)
        {
            ConfigManager.Config.InterfaceSuffix = txt_Interface_Suffix.Text.Trim();
        }

        private void txt_DAL_SubNamespace_TextChanged(object sender, EventArgs e)
        {
            ConfigManager.Config.DALSubNamespace = txt_DAL_SubNamespace.Text.Trim();
        }

        private void txt_DAL_Prefix_TextChanged(object sender, EventArgs e)
        {
            ConfigManager.Config.DALPrefix = txt_DAL_Prefix.Text.Trim();
        }

        private void txt_DAL_Suffix_TextChanged(object sender, EventArgs e)
        {
            ConfigManager.Config.DALSuffix = txt_DAL_Suffix.Text.Trim();
        }

        private void txt_BLL_SubNamespace_TextChanged(object sender, EventArgs e)
        {
            ConfigManager.Config.BLLSubNamespace = txt_BLL_SubNamespace.Text.Trim();
        }

        private void txt_BLL_Prefix_TextChanged(object sender, EventArgs e)
        {
            ConfigManager.Config.BLLPrefix = txt_BLL_Prefix.Text.Trim();
        }

        private void txt_BLL_Suffix_TextChanged(object sender, EventArgs e)
        {
            ConfigManager.Config.BLLSuffix = txt_BLL_Suffix.Text.Trim();
        }

        private void txt_Procedure_Prefix_TextChanged(object sender, EventArgs e)
        {
            ConfigManager.Config.ProcedurePrefix = txt_Procedure_Prefix.Text.Trim();
        }

        private void txt_Procedure_Suffix_TextChanged(object sender, EventArgs e)
        {
            ConfigManager.Config.ProcedureSuffix = txt_Procedure_Suffix.Text.Trim();
        }

        #endregion 修改配置

        #region 字母大小写

        private string FirstLetterCase(string str)
        {
            if (rbtnFirstLetterCaseLower.Checked)
            {
                return Tools.FirstLetterToLower(str);
            }
            else if (rbtnFirstLetterCaseUpper.Checked)
            {
                return Tools.FirstLetterToUpper(str);
            }
            else
            {
                return str;
            }
        }

        private void rbtnFirstLetterCaseIgnore_CheckedChanged(object sender, EventArgs e)
        {
            ConfigManager.Config.FirstLetterSelectIndex = 0;
        }

        private void rbtnFirstLetterCaseUpper_CheckedChanged(object sender, EventArgs e)
        {
            ConfigManager.Config.FirstLetterSelectIndex = 1;
        }

        private void rbtnFirstLetterCaseLower_CheckedChanged(object sender, EventArgs e)
        {
            ConfigManager.Config.FirstLetterSelectIndex = 2;
        }

        public void SelectFirstLetter(int index)
        {
            switch (index)
            {
                case 1: rbtnFirstLetterCaseUpper.Checked = true; break;
                case 2: rbtnFirstLetterCaseLower.Checked = true; break;
                default: rbtnFirstLetterCaseIgnore.Checked = true; break;
            }
        }

        #endregion 字母大小写
    }
}
