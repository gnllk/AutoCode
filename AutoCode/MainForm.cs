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

namespace AutoCode
{
    public partial class MainForm : Form
    {
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

        #region 按键事件

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
                string prefix = ConfigManager.Config.EntityPrefix;
                string suffix = ConfigManager.Config.EntitySuffix;
                string subNSP = ConfigManager.Config.EntitySubNamespace;
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
                if (subNSP.Length > 0 && subNSP.First() == '.')
                {
                    subNSP = subNSP.Substring(1);
                }
                if (mainChckListTable.CheckedItems.Count > 0)
                {
                    if (this.IsOneKey)
                    {
                        foreach (var item in mainChckListTable.CheckedItems)
                        {
                            string tableName = item.ToString();
                            string fileSuffix = suffix.Contains(':') ? suffix.Substring(0, suffix.IndexOf(':')).Trim() : suffix;
                            string fileName = Path.Combine(ConfigManager.Config.SaveFilePath, "Entity", string.Format("{0}.cs", GetObjectName(tableName, prefix, fileSuffix)));
                            string nameSp = string.IsNullOrEmpty(subNSP) ? ConfigManager.Config.Namespace : string.Format("{0}.{1}", ConfigManager.Config.Namespace, subNSP);
                            GenerateEntity(ConfigManager.Config, fileName, nameSp, tableName, prefix, suffix);
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
                                    string fileSuffix = suffix.Contains(':') ? suffix.Substring(0, suffix.IndexOf(':')).Trim() : suffix;
                                    string entityName = GetObjectName(tableName, prefix, fileSuffix);
                                    string fileName = Path.Combine(ConfigManager.Config.SaveFilePath, "Entity", string.Format("{0}.cs", entityName));
                                    string nameSp = string.IsNullOrEmpty(subNSP) ? ConfigManager.Config.Namespace : string.Format("{0}.{1}", ConfigManager.Config.Namespace, subNSP);
                                    //控制进度和消息
                                    SetProgressBarByThread((int)(rate * (i + 1)));
                                    SetStatusMessageByThread(string.Format("正在生成实体{0}...", entityName));
                                    Thread.Sleep(SttSleepTime);
                                    GenerateEntity(ConfigManager.Config, fileName, nameSp, tableName, prefix, suffix);
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
                string prefix = ConfigManager.Config.InterfacePrefix;
                string suffix = ConfigManager.Config.InterfaceSuffix;
                string subNSP = ConfigManager.Config.InterfaceSubNamespace;
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
                if (subNSP.Length > 0 && subNSP.First() == '.')
                {
                    subNSP = subNSP.Substring(1);
                }
                if (mainChckListTable.CheckedItems.Count > 0)
                {
                    if (this.IsOneKey)
                    {
                        foreach (var item in mainChckListTable.CheckedItems)
                        {
                            string tableName = item.ToString();
                            string fileSuffix = suffix.Contains(':') ? suffix.Substring(0, suffix.IndexOf(':')).Trim() : suffix;
                            string fileName = Path.Combine(ConfigManager.Config.SaveFilePath, "Interface", string.Format("{0}.cs", GetObjectName(tableName, prefix, fileSuffix)));
                            string nameSp = string.IsNullOrEmpty(subNSP) ? ConfigManager.Config.Namespace : string.Format("{0}.{1}", ConfigManager.Config.Namespace, subNSP);
                            GenerateInterface(ConfigManager.Config, fileName, nameSp, tableName, prefix, suffix);
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
                                    string fileSuffix = suffix.Contains(':') ? suffix.Substring(0, suffix.IndexOf(':')).Trim() : suffix;
                                    string interfaseName = GetObjectName(tableName, prefix, fileSuffix);
                                    string fileName = Path.Combine(ConfigManager.Config.SaveFilePath, "Interface", string.Format("{0}.cs", interfaseName));
                                    string nameSp = string.IsNullOrEmpty(subNSP) ? ConfigManager.Config.Namespace : string.Format("{0}.{1}", ConfigManager.Config.Namespace, subNSP);
                                    //控制进度和消息
                                    SetProgressBarByThread((int)(rate * (i + 1)));
                                    SetStatusMessageByThread(string.Format("正在生成接口{0}...", interfaseName));
                                    Thread.Sleep(SttSleepTime);
                                    GenerateInterface(ConfigManager.Config, fileName, nameSp, tableName, prefix, suffix);
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
                string prefix = ConfigManager.Config.DALPrefix;
                string suffix = ConfigManager.Config.DALSuffix;
                string subNSP = ConfigManager.Config.DALSubNamespace;
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
                if (subNSP.Length > 0 && subNSP.First() == '.')
                {
                    subNSP = subNSP.Substring(1);
                }
                if (mainChckListTable.CheckedItems.Count > 0)
                {
                    if (this.IsOneKey)
                    {
                        foreach (var item in mainChckListTable.CheckedItems)
                        {
                            string tableName = item.ToString();
                            string fileSuffix = suffix.Contains(':') ? suffix.Substring(0, suffix.IndexOf(':')).Trim() : suffix;
                            string fileName = Path.Combine(ConfigManager.Config.SaveFilePath, "DAL", string.Format("{0}.cs", GetObjectName(tableName, prefix, fileSuffix)));
                            string nameSp = string.IsNullOrEmpty(subNSP) ? ConfigManager.Config.Namespace : string.Format("{0}.{1}", ConfigManager.Config.Namespace, subNSP);
                            GenerateDAL(ConfigManager.Config, fileName, nameSp, tableName, prefix, suffix);
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
                                    string fileSuffix = suffix.Contains(':') ? suffix.Substring(0, suffix.IndexOf(':')).Trim() : suffix;
                                    string DALName = GetObjectName(tableName, prefix, fileSuffix);
                                    string fileName = Path.Combine(ConfigManager.Config.SaveFilePath, "DAL", string.Format("{0}.cs", DALName));
                                    string nameSp = string.IsNullOrEmpty(subNSP) ? ConfigManager.Config.Namespace : string.Format("{0}.{1}", ConfigManager.Config.Namespace, subNSP);
                                    //控制进度和消息
                                    SetProgressBarByThread((int)(rate * (i + 1)));
                                    SetStatusMessageByThread(string.Format("正在生成DAL{0}...", DALName));
                                    Thread.Sleep(SttSleepTime);
                                    GenerateDAL(ConfigManager.Config, fileName, nameSp, tableName, prefix, suffix);
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
                string prefix = ConfigManager.Config.BLLPrefix;
                string suffix = ConfigManager.Config.BLLSuffix;
                string subNSP = ConfigManager.Config.BLLSubNamespace;
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
                if (subNSP.Length > 0 && subNSP.First() == '.')
                {
                    subNSP = subNSP.Substring(1);
                }
                if (mainChckListTable.CheckedItems.Count > 0)
                {
                    if (this.IsOneKey)
                    {
                        foreach (var item in mainChckListTable.CheckedItems)
                        {
                            string tableName = item.ToString();
                            string fileSuffix = suffix.Contains(':') ? suffix.Substring(0, suffix.IndexOf(':')).Trim() : suffix;
                            string fileName = Path.Combine(ConfigManager.Config.SaveFilePath, "BLL", string.Format("{0}.cs", GetObjectName(tableName, prefix, fileSuffix)));
                            string nameSp = string.IsNullOrEmpty(subNSP) ? ConfigManager.Config.Namespace : string.Format("{0}.{1}", ConfigManager.Config.Namespace, subNSP);
                            GenerateBLL(ConfigManager.Config, fileName, nameSp, tableName, prefix, suffix);
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
                                    string fileSuffix = suffix.Contains(':') ? suffix.Substring(0, suffix.IndexOf(':')).Trim() : suffix;
                                    string BLLName = GetObjectName(tableName, prefix, fileSuffix);
                                    string fileName = Path.Combine(ConfigManager.Config.SaveFilePath, "BLL", string.Format("{0}.cs", BLLName));
                                    string nameSp = string.IsNullOrEmpty(subNSP) ? ConfigManager.Config.Namespace : string.Format("{0}.{1}", ConfigManager.Config.Namespace, subNSP);
                                    //控制进度和消息
                                    SetProgressBarByThread((int)(rate * (i + 1)));
                                    SetStatusMessageByThread(string.Format("正在生成BLL{0}...", BLLName));
                                    Thread.Sleep(SttSleepTime);
                                    GenerateBLL(ConfigManager.Config, fileName, nameSp, tableName, prefix, suffix);
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

        #endregion 按键事件

        #region 辅助函数

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
                case "ASCII": return Encoding.ASCII;
                default: return Encoding.Default;
            }
        }

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

        private string GetObjectName(string tableName, string prefix, string suffix)
        {
            Regex reg = new Regex("[a-z0-9A-Z]+", RegexOptions.RightToLeft);
            Match match = reg.Match(tableName);
            return match.Success ? (prefix + FirstLetterCase(match.Value) + suffix)
                : (prefix + FirstLetterCase(tableName) + suffix);
        }

        private TableNameEntity GetTableDataRow(string tableName)
        {
            if (null != ConfigManager.DatabaseTable && ConfigManager.DatabaseTable.Count > 0)
            {
                return ConfigManager.DatabaseTable.Find(e => e.Name == tableName);
            }
            return null;
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

        private string InheritInterface(string className, string _interface)
        {
            if (!string.IsNullOrEmpty(className) && !string.IsNullOrEmpty(_interface))
            {
                if (className.Contains(':'))
                {
                    return className + ", " + _interface;
                }
                else
                {
                    return className + " : " + _interface;
                }
            }
            return className;
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

        private void GenerateEntity(Config config, string fileName, string nameSpace, string tableName, string prefix, string suffix)
        {
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
                string filePath = Path.GetDirectoryName(fileName);
                if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    StreamWriter writer = new StreamWriter(fs, GetCodeEncoding(config));
                    writer.WriteLine("using System;");
                    writer.WriteLine("using System.Collections.Generic;");
                    writer.WriteLine("using System.Linq;");
                    writer.WriteLine("using System.Text;");
                    writer.WriteLine();
                    writer.WriteLine("namespace {0}", nameSpace);
                    writer.WriteLine("{");
                    //start of class
                    writer.WriteLine("\t/// <summary>");
                    writer.WriteLine("{0}", AddFixPerLine((GetTableDescription(tableName, "其他") + "实体"), "\t/// ", string.Empty));
                    writer.WriteLine("\t/// </summary>");
                    writer.WriteLine("\tpublic class {0}", GetObjectName(tableName, prefix, suffix));
                    writer.WriteLine("\t{");
                    writer.WriteLine("\t\t#region 公共属性");
                    writer.WriteLine();
                    foreach (ColumnNameEntity item in list)
                    {
                        string attr = string.Format("\t\tpublic {0} {1} ", ConfigManager.DataTypeConvertor.ConvertToDataType(item), item.Name);
                        writer.WriteLine("\t\t/// <summary>");
                        writer.WriteLine("\t\t/// {0}", item.Description);
                        writer.WriteLine("\t\t/// </summary>");
                        writer.WriteLine(attr + "{ get; set; }");
                        writer.WriteLine();
                    }
                    writer.WriteLine("\t\t#endregion");
                    writer.WriteLine("\t}");
                    //end of class
                    writer.WriteLine("}");
                    writer.Close();
                }
            }
        }

        private void GenerateInterface(Config config, string fileName, string nameSpace, string tableName, string prefix, string suffix)
        {
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
                string filePath = Path.GetDirectoryName(fileName);
                if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    StreamWriter writer = new StreamWriter(fs, GetCodeEncoding(config));
                    writer.WriteLine("using System;");
                    writer.WriteLine("using System.Collections.Generic;");
                    writer.WriteLine("using System.Linq;");
                    writer.WriteLine("using System.Text;");
                    //实体命名空间
                    string entitySubNSP = config.EntitySubNamespace;
                    if (entitySubNSP.Length > 0 && entitySubNSP.First() == '.') entitySubNSP = entitySubNSP.Substring(1);
                    string enttiyNameSp = string.IsNullOrEmpty(entitySubNSP) ? config.Namespace : string.Format("{0}.{1}", config.Namespace, entitySubNSP);
                    writer.WriteLine("using {0};", enttiyNameSp);
                    writer.WriteLine();

                    writer.WriteLine("namespace {0}", nameSpace);
                    writer.WriteLine("{");
                    //start of class
                    writer.WriteLine("\t/// <summary>");
                    writer.WriteLine("{0}", AddFixPerLine((GetTableDescription(tableName, "其他") + "接口"), "\t/// ", string.Empty));
                    writer.WriteLine("\t/// </summary>");
                    writer.WriteLine("\tpublic interface {0}", GetObjectName(tableName, prefix, suffix));
                    writer.WriteLine("\t{");
                    writer.WriteLine("\t\t#region 接口");
                    writer.WriteLine();

                    string entityClass = GetObjectName(tableName, config.EntityPrefix, config.EntitySuffix);
                    //Get
                    writer.WriteLine("\t\t/// <summary>");
                    writer.WriteLine("\t\t/// 获取一个实体数据");
                    writer.WriteLine("\t\t/// </summary>");
                    List<ColumnNameEntity> primaryColumn = list.FindAll(e => e.IsPrimary);
                    if (null != primaryColumn && primaryColumn.Count > 0)
                    {
                        string args = string.Empty;
                        int count = primaryColumn.Count;
                        int mcount = count - 1;
                        for (int i = 0; i < count; i++)
                        {
                            var item = primaryColumn[i];
                            writer.WriteLine("\t\t/// <param name=\"{0}\">{1}</param>", item.Name, item.Description);
                            if (i < mcount)
                                args += string.Format("{0} {1}, ", ConfigManager.DataTypeConvertor.ConvertToDataType(item), item.Name);
                            else
                                args += string.Format("{0} {1}", ConfigManager.DataTypeConvertor.ConvertToDataType(item), item.Name);
                        }
                        writer.WriteLine("\t\t/// <returns>返回实体，否则返回NULL</returns>");
                        writer.WriteLine("\t\t{0} Get({1});", entityClass, args);
                    }
                    else
                    {
                        writer.WriteLine("\t\t/// <param name=\"{0}\">{1}</param>", "id", "ID");//default
                        writer.WriteLine("\t\t/// <returns>返回实体，否则返回NULL</returns>");
                        writer.WriteLine("\t\t{0} Get({1});", entityClass, "int id");
                    }
                    writer.WriteLine();
                    //Delete
                    writer.WriteLine("\t\t/// <summary>");
                    writer.WriteLine("\t\t/// 删除一个实体数据");
                    writer.WriteLine("\t\t/// </summary>");
                    if (null != primaryColumn && primaryColumn.Count > 0)
                    {
                        string args = string.Empty;
                        int count = primaryColumn.Count;
                        int mcount = count - 1;
                        for (int i = 0; i < count; i++)
                        {
                            var item = primaryColumn[i];
                            writer.WriteLine("\t\t/// <param name=\"{0}\">{1}</param>", item.Name, item.Description);
                            if (i < mcount)
                                args += string.Format("{0} {1}, ", ConfigManager.DataTypeConvertor.ConvertToDataType(item), item.Name);
                            else
                                args += string.Format("{0} {1}", ConfigManager.DataTypeConvertor.ConvertToDataType(item), item.Name);
                        }
                        writer.WriteLine("\t\t/// <returns>0失败，1成功</returns>");
                        writer.WriteLine("\t\tint Delete({0});", args);
                    }
                    else
                    {
                        writer.WriteLine("\t\t/// <param name=\"{0}\">{1}</param>", "id", "ID");
                        writer.WriteLine("\t\t/// <returns>0失败，1成功</returns>");
                        writer.WriteLine("\t\tint Delete({0});", "int id");
                    }

                    writer.WriteLine();
                    //Edit
                    writer.WriteLine("\t\t/// <summary>");
                    writer.WriteLine("\t\t/// 编辑一个实体数据");
                    writer.WriteLine("\t\t/// </summary>");
                    writer.WriteLine("\t\t/// <param name=\"item\">实体</param>");
                    writer.WriteLine("\t\t/// <returns>0失败，1成功</returns>");
                    writer.WriteLine("\t\tint Edit({0} item);", entityClass);
                    writer.WriteLine();
                    //Add
                    writer.WriteLine("\t\t/// <summary>");
                    writer.WriteLine("\t\t/// 增加一个实体数据，并更新实体的ID为新增ID");
                    writer.WriteLine("\t\t/// </summary>");
                    writer.WriteLine("\t\t/// <param name=\"item\">实体</param>");
                    writer.WriteLine("\t\t/// <returns>0失败，1成功，2已存在</returns>");
                    writer.WriteLine("\t\tint Add(ref {0} item);", entityClass);
                    writer.WriteLine();
                    //GetList
                    writer.WriteLine("\t\t/// <summary>");
                    writer.WriteLine("\t\t/// 获取数据列表");
                    writer.WriteLine("\t\t/// </summary>");
                    writer.WriteLine("\t\t/// <returns>返回非NULL列表</returns>");
                    writer.WriteLine("\t\tList<{0}> GetList();", entityClass);
                    writer.WriteLine();

                    writer.WriteLine("\t\t#endregion");
                    writer.WriteLine("\t}");
                    //end of class
                    writer.WriteLine("}");
                    writer.Close();
                }
            }
        }

        private void GenerateDAL(Config config, string fileName, string nameSpace, string tableName, string prefix, string suffix)
        {
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
                string filePath = Path.GetDirectoryName(fileName);
                if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    StreamWriter writer = new StreamWriter(fs, GetCodeEncoding(config));
                    writer.WriteLine("using System;");
                    writer.WriteLine("using System.Collections.Generic;");
                    writer.WriteLine("using System.Linq;");
                    writer.WriteLine("using System.Text;");
                    writer.WriteLine("using Microsoft.Practices.EnterpriseLibrary.Data;");
                    writer.WriteLine("using System.Data.Common;");
                    writer.WriteLine("using System.Data;");
                    //实体命名空间
                    string entitySubNSP = config.EntitySubNamespace;
                    if (entitySubNSP.Length > 0 && entitySubNSP.First() == '.') entitySubNSP = entitySubNSP.Substring(1);
                    string enttiyNameSp = string.IsNullOrEmpty(entitySubNSP) ? config.Namespace : string.Format("{0}.{1}", config.Namespace, entitySubNSP);
                    writer.WriteLine("using {0};", enttiyNameSp);
                    //接口命名空间
                    string interfSubNSP = config.InterfaceSubNamespace;
                    if (!string.IsNullOrEmpty(interfSubNSP) && interfSubNSP != entitySubNSP)
                    {
                        if (interfSubNSP.Length > 0 && interfSubNSP.First() == '.') interfSubNSP = interfSubNSP.Substring(1);
                        string interfNameSp = string.IsNullOrEmpty(interfSubNSP) ? config.Namespace : string.Format("{0}.{1}", config.Namespace, interfSubNSP);
                        writer.WriteLine("using {0};", interfNameSp);
                    }
                    writer.WriteLine();

                    writer.WriteLine("namespace {0}", nameSpace);
                    writer.WriteLine("{");
                    //start of class
                    writer.WriteLine("\t/// <summary>");
                    writer.WriteLine("{0}", AddFixPerLine((GetTableDescription(tableName, "其他") + "DAL实现"), "\t/// ", string.Empty));
                    writer.WriteLine("\t/// </summary>");
                    string className = GetObjectName(tableName, prefix, suffix);
                    string interfaceName = GetObjectName(tableName, config.InterfacePrefix, config.InterfaceSuffix);
                    writer.WriteLine("\tpublic class {0}", InheritInterface(className, interfaceName));
                    writer.WriteLine("\t{");
                    writer.WriteLine("\t\t#region DAL实现");
                    writer.WriteLine();

                    string entityClass = GetObjectName(tableName, config.EntityPrefix, config.EntitySuffix);
                    string procedurePrefix = config.ProcedurePrefix;
                    string procedurePrefix_ = string.IsNullOrEmpty(procedurePrefix) ? string.Empty : procedurePrefix + "_";
                    string procedureSuffix = config.ProcedureSuffix;
                    string procedureSuffix_ = string.IsNullOrEmpty(procedureSuffix) ? string.Empty : "_" + procedureSuffix;
                    //Get
                    writer.WriteLine("\t\t/// <summary>");
                    writer.WriteLine("\t\t/// 获取一个实体数据");
                    writer.WriteLine("\t\t/// </summary>");
                    List<ColumnNameEntity> primaryColumn = list.FindAll(e => e.IsPrimary);
                    if (null != primaryColumn && primaryColumn.Count > 0)
                    {
                        string args = string.Empty;
                        int count = primaryColumn.Count;
                        int mcount = count - 1;
                        for (int i = 0; i < count; i++)
                        {
                            var item = primaryColumn[i];
                            writer.WriteLine("\t\t/// <param name=\"{0}\">{1}</param>", item.Name, item.Description);
                            if (i < mcount)
                                args += string.Format("{0} {1}, ", ConfigManager.DataTypeConvertor.ConvertToDataType(item), item.Name);
                            else
                                args += string.Format("{0} {1}", ConfigManager.DataTypeConvertor.ConvertToDataType(item), item.Name);
                        }
                        writer.WriteLine("\t\t/// <returns>返回实体，否则返回NULL</returns>");
                        writer.WriteLine("\t\tpublic {0} Get({1})", entityClass, args);
                        writer.WriteLine("\t\t{");
                        writer.WriteLine("\t\t\tDatabase db = GetDB();");
                        writer.WriteLine("\t\t\tDbCommand cmd = db.GetStoredProcCommand(\"{0}\");", string.Format("{0}{1}{2}_Get", procedurePrefix_, tableName, procedureSuffix_));
                        for (int i = 0; i < count; i++)
                        {
                            var item = primaryColumn[i];
                            writer.WriteLine("\t\t\tdb.AddInParameter(cmd, \"{0}\", DbType.{1}, {0});", item.Name, ConfigManager.DataTypeConvertor.ConvertToDbType(item));
                        }
                    }
                    else
                    {
                        writer.WriteLine("\t\t/// <param name=\"{0}\">{1}</param>", "id", "ID");
                        writer.WriteLine("\t\t/// <returns>返回实体，否则返回NULL</returns>");
                        writer.WriteLine("\t\tpublic {0} Get({1})", entityClass, "int id");
                        writer.WriteLine("\t\t{");
                        writer.WriteLine("\t\t\tDatabase db = GetDB();");
                        writer.WriteLine("\t\t\tDbCommand cmd = db.GetStoredProcCommand(\"{0}\");", string.Format("{0}{1}{2}_Get", procedurePrefix_, tableName, procedureSuffix_));
                        writer.WriteLine("\t\t\tdb.AddInParameter(cmd, \"{0}\", DbType.{1}, {0});", "id", "Int32");
                    }
                    writer.WriteLine("\t\t\t{0} entity = null;", entityClass);
                    writer.WriteLine("\t\t\tusing (IDataReader reader = db.ExecuteReader(cmd))");
                    writer.WriteLine("\t\t\t{");
                    writer.WriteLine("\t\t\t\tif (reader.Read())");
                    writer.WriteLine("\t\t\t\t{");
                    writer.WriteLine("\t\t\t\t\tentity = ConvertToEntity<{0}>(reader);", entityClass);
                    writer.WriteLine("\t\t\t\t}");
                    writer.WriteLine("\t\t\t}");
                    writer.WriteLine("\t\t\treturn entity;");
                    writer.WriteLine("\t\t}");
                    writer.WriteLine();
                    //Delete
                    writer.WriteLine("\t\t/// <summary>");
                    writer.WriteLine("\t\t/// 删除一个实体数据");
                    writer.WriteLine("\t\t/// </summary>");
                    if (null != primaryColumn && primaryColumn.Count > 0)
                    {
                        string args = string.Empty;
                        int count = primaryColumn.Count;
                        int mcount = count - 1;
                        for (int i = 0; i < count; i++)
                        {
                            var item = primaryColumn[i];
                            writer.WriteLine("\t\t/// <param name=\"{0}\">{1}</param>", item.Name, item.Description);
                            if (i < mcount)
                                args += string.Format("{0} {1}, ", ConfigManager.DataTypeConvertor.ConvertToDataType(item), item.Name);
                            else
                                args += string.Format("{0} {1}", ConfigManager.DataTypeConvertor.ConvertToDataType(item), item.Name);
                        }
                        writer.WriteLine("\t\t/// <returns>0失败，1成功</returns>");
                        writer.WriteLine("\t\tpublic int Delete({0})", args);
                        writer.WriteLine("\t\t{");
                        writer.WriteLine("\t\t\tDatabase db = GetDB();");
                        writer.WriteLine("\t\t\tDbCommand cmd = db.GetStoredProcCommand(\"{0}\");", string.Format("{0}{1}{2}_Delete", procedurePrefix_, tableName, procedureSuffix_));
                        for (int i = 0; i < count; i++)
                        {
                            var item = primaryColumn[i];
                            writer.WriteLine("\t\t\tdb.AddInParameter(cmd, \"{0}\", DbType.{1}, {0});", item.Name, ConfigManager.DataTypeConvertor.ConvertToDbType(item));
                        }
                    }
                    else
                    {
                        writer.WriteLine("\t\t/// <param name=\"{0}\">{1}</param>", "id", "ID");
                        writer.WriteLine("\t\t/// <returns>0失败，1成功</returns>");
                        writer.WriteLine("\t\tpublic int Delete({0})", "int id");
                        writer.WriteLine("\t\t{");
                        writer.WriteLine("\t\t\tDatabase db = GetDB();");
                        writer.WriteLine("\t\t\tDbCommand cmd = db.GetStoredProcCommand(\"{0}\");", string.Format("{0}{1}{2}_Get", procedurePrefix_, tableName, procedureSuffix_));
                        writer.WriteLine("\t\t\tdb.AddInParameter(cmd, \"{0}\", DbType.{1}, {0});", "id", "Int32");
                    }
                    writer.WriteLine("\t\t\tdb.AddOutParameter(cmd, \"{0}\", DbType.{1}, 32);", "ReturnValue", "Int32");
                    writer.WriteLine("\t\t\tdb.ExecuteNonQuery(cmd);");
                    writer.WriteLine("\t\t\treturn Convert.ToInt32(db.GetParameterValue(cmd, \"ReturnValue\"));");
                    writer.WriteLine("\t\t}");
                    writer.WriteLine();
                    //Edit
                    writer.WriteLine("\t\t/// <summary>");
                    writer.WriteLine("\t\t/// 编辑一个实体数据");
                    writer.WriteLine("\t\t/// </summary>");
                    writer.WriteLine("\t\t/// <param name=\"item\">实体</param>");
                    writer.WriteLine("\t\t/// <returns>0失败，1成功</returns>");
                    writer.WriteLine("\t\tpublic int Edit({0} item)", entityClass);
                    writer.WriteLine("\t\t{");
                    writer.WriteLine("\t\t\tDatabase db = GetDB();");
                    writer.WriteLine("\t\t\tDbCommand cmd = db.GetStoredProcCommand(\"{0}\");", string.Format("{0}{1}{2}_Edit", procedurePrefix_, tableName, procedureSuffix_));
                    List<ColumnNameEntity> editList = list.FindAll(e => e.IsIdentity == false || (e.IsIdentity && e.IsPrimary));
                    if (null != editList && editList.Count > 0)
                    {
                        foreach (var item in editList)
                        {
                            writer.WriteLine("\t\t\tdb.AddInParameter(cmd, \"{0}\", DbType.{1}, item.{0});", item.Name, ConfigManager.DataTypeConvertor.ConvertToDbType(item));
                        }
                    }
                    writer.WriteLine("\t\t\tdb.AddOutParameter(cmd, \"{0}\", DbType.{1}, 32);", "ReturnValue", "Int32");
                    writer.WriteLine("\t\t\tdb.ExecuteNonQuery(cmd);");
                    writer.WriteLine("\t\t\treturn Convert.ToInt32(db.GetParameterValue(cmd, \"ReturnValue\"));");
                    writer.WriteLine("\t\t}");
                    writer.WriteLine();
                    //Add
                    writer.WriteLine("\t\t/// <summary>");
                    writer.WriteLine("\t\t/// 增加一个实体数据，并更新实体的ID为新增ID");
                    writer.WriteLine("\t\t/// </summary>");
                    writer.WriteLine("\t\t/// <param name=\"item\">实体</param>");
                    writer.WriteLine("\t\t/// <returns>0失败，1成功，2已存在</returns>");
                    writer.WriteLine("\t\tpublic int Add(ref {0} item)", entityClass);
                    writer.WriteLine("\t\t{");
                    writer.WriteLine("\t\t\tDatabase db = GetDB();");
                    writer.WriteLine("\t\t\tDbCommand cmd = db.GetStoredProcCommand(\"{0}\");", string.Format("{0}{1}{2}_Add", procedurePrefix_, tableName, procedureSuffix_));
                    List<ColumnNameEntity> addList = list.FindAll(e => e.IsIdentity == false);
                    if (null != addList && addList.Count > 0)
                    {
                        foreach (var item in addList)
                        {
                            writer.WriteLine("\t\t\tdb.AddInParameter(cmd, \"{0}\", DbType.{1}, item.{0});", item.Name, ConfigManager.DataTypeConvertor.ConvertToDbType(item));
                        }
                    }
                    writer.WriteLine("\t\t\tdb.AddOutParameter(cmd, \"{0}\", DbType.{1}, 32);", "ReturnValue", "Int32");
                    ColumnNameEntity identity = list.Find(e => e.IsIdentity);
                    if (identity != null)
                    {
                        writer.WriteLine("\t\t\tdb.AddOutParameter(cmd, \"{0}\", DbType.{1}, 32);", "OutID", ConfigManager.DataTypeConvertor.ConvertToDbType(identity));
                    }
                    writer.WriteLine("\t\t\tdb.ExecuteNonQuery(cmd);");
                    if (identity != null)
                    {
                        writer.WriteLine("\t\t\titem.{0} = Convert.To{1}(db.GetParameterValue(cmd, \"OutID\"));",
                            identity.Name, ConfigManager.DataTypeConvertor.ConvertToDbType(identity));
                    }
                    writer.WriteLine("\t\t\treturn Convert.ToInt32(db.GetParameterValue(cmd, \"ReturnValue\"));");
                    writer.WriteLine("\t\t}");
                    writer.WriteLine();
                    //GetList
                    writer.WriteLine("\t\t/// <summary>");
                    writer.WriteLine("\t\t/// 获取数据列表");
                    writer.WriteLine("\t\t/// </summary>");
                    writer.WriteLine("\t\t/// <returns>返回非NULL列表</returns>");
                    writer.WriteLine("\t\tpublic List<{0}> GetList()", entityClass);
                    writer.WriteLine("\t\t{");
                    writer.WriteLine("\t\t\tDatabase db = GetDB();");
                    writer.WriteLine("\t\t\tDbCommand cmd = db.GetStoredProcCommand(\"{0}\");", string.Format("{0}{1}{2}_GetList", procedurePrefix_, tableName, procedureSuffix_));
                    writer.WriteLine("\t\t\tList<{0}> list = new List<{0}>();", entityClass);
                    writer.WriteLine("\t\t\tusing (IDataReader reader = db.ExecuteReader(cmd))");
                    writer.WriteLine("\t\t\t{");
                    writer.WriteLine("\t\t\t\twhile (reader.Read())");
                    writer.WriteLine("\t\t\t\t{");
                    writer.WriteLine("\t\t\t\t\tvar entity = ConvertToEntity<{0}>(reader);", entityClass);
                    writer.WriteLine("\t\t\t\t\tif(null != entity) list.Add(entity);");
                    writer.WriteLine("\t\t\t\t}");
                    writer.WriteLine("\t\t\t}");
                    writer.WriteLine("\t\t\treturn list;");
                    writer.WriteLine("\t\t}");
                    writer.WriteLine();

                    writer.WriteLine("\t\t#endregion");
                    writer.WriteLine("\t}");
                    //end of class
                    writer.WriteLine("}");
                    writer.Close();
                }
            }
        }

        private void GenerateBLL(Config config, string fileName, string nameSpace, string tableName, string prefix, string suffix)
        {
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
                string filePath = Path.GetDirectoryName(fileName);
                if (!Directory.Exists(filePath)) Directory.CreateDirectory(filePath);
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    StreamWriter writer = new StreamWriter(fs, GetCodeEncoding(config));
                    writer.WriteLine("using System;");
                    writer.WriteLine("using System.Collections.Generic;");
                    writer.WriteLine("using System.Linq;");
                    writer.WriteLine("using System.Text;");
                    //实体命名空间
                    string entitySubNSP = config.EntitySubNamespace;
                    if (entitySubNSP.Length > 0 && entitySubNSP.First() == '.') entitySubNSP = entitySubNSP.Substring(1);
                    string enttiyNameSp = string.IsNullOrEmpty(entitySubNSP) ? config.Namespace : string.Format("{0}.{1}", config.Namespace, entitySubNSP);
                    writer.WriteLine("using {0};", enttiyNameSp);
                    //接口命名空间
                    string interfSubNSP = config.InterfaceSubNamespace;
                    if (!string.IsNullOrEmpty(interfSubNSP) && interfSubNSP != entitySubNSP)
                    {
                        if (interfSubNSP.Length > 0 && interfSubNSP.First() == '.') interfSubNSP = interfSubNSP.Substring(1);
                        string interfNameSp = string.IsNullOrEmpty(interfSubNSP) ? config.Namespace : string.Format("{0}.{1}", config.Namespace, interfSubNSP);
                        writer.WriteLine("using {0};", interfNameSp);
                    }
                    //DAL命名空间
                    string dalSubNSP = config.DALSubNamespace;
                    if (!string.IsNullOrEmpty(dalSubNSP) && dalSubNSP != entitySubNSP && dalSubNSP != interfSubNSP)
                    {
                        if (dalSubNSP.Length > 0 && dalSubNSP.First() == '.') dalSubNSP = dalSubNSP.Substring(1);
                        string dalNameSp = string.IsNullOrEmpty(dalSubNSP) ? config.Namespace : string.Format("{0}.{1}", config.Namespace, dalSubNSP);
                        writer.WriteLine("using {0};", dalNameSp);
                    }
                    writer.WriteLine();

                    writer.WriteLine("namespace {0}", nameSpace);
                    writer.WriteLine("{");
                    //start of class
                    writer.WriteLine("\t/// <summary>");
                    writer.WriteLine("{0}", AddFixPerLine((GetTableDescription(tableName, "其他") + "BLL实现"), "\t/// ", string.Empty));
                    writer.WriteLine("\t/// </summary>");
                    string className = GetObjectName(tableName, prefix, suffix);
                    writer.WriteLine("\tpublic class {0}", className);
                    writer.WriteLine("\t{");
                    writer.WriteLine("\t\t#region BLL实现");
                    writer.WriteLine();

                    string entityClass = GetObjectName(tableName, config.EntityPrefix, config.EntitySuffix);
                    //属性
                    string interfacePrefix = config.InterfacePrefix;
                    string interfaceSuffix = config.InterfaceSuffix;
                    string fileSuffix = interfaceSuffix.Contains(':') ? interfaceSuffix.Substring(0, interfaceSuffix.IndexOf(':')).Trim() : interfaceSuffix;
                    string clearInterfaceName = GetObjectName(tableName, interfacePrefix, fileSuffix);
                    string dalPrefix = config.DALPrefix;
                    string dalSuffix = config.DALSuffix;
                    string dalFileSuffix = dalSuffix.Contains(':') ? dalSuffix.Substring(0, dalSuffix.IndexOf(':')).Trim() : dalSuffix;
                    string clearDALName = GetObjectName(tableName, dalPrefix, dalFileSuffix);
                    writer.WriteLine("\t\tprivate {0} m_DAL = null;", clearInterfaceName);
                    writer.WriteLine();
                    writer.WriteLine("\t\t/// <summary>");
                    writer.WriteLine("\t\t/// 数据访问层");
                    writer.WriteLine("\t\t/// </summary>");
                    writer.WriteLine("\t\tpublic {0} DAL", clearInterfaceName);
                    writer.WriteLine("\t\t{");
                    writer.WriteLine("\t\t\tget");
                    writer.WriteLine("\t\t\t{");
                    writer.WriteLine("\t\t\t\tif(null == m_DAL)");
                    writer.WriteLine("\t\t\t\t{");
                    writer.WriteLine("\t\t\t\t\tm_DAL = new {0}();", clearDALName);
                    writer.WriteLine("\t\t\t\t}");
                    writer.WriteLine("\t\t\t\treturn m_DAL;");
                    writer.WriteLine("\t\t\t}");
                    writer.WriteLine("\t\t}");
                    writer.WriteLine();
                    //Get
                    writer.WriteLine("\t\t/// <summary>");
                    writer.WriteLine("\t\t/// 获取一个实体数据");
                    writer.WriteLine("\t\t/// </summary>");
                    List<ColumnNameEntity> primaryColumn = list.FindAll(e => e.IsPrimary == true);
                    if (null != primaryColumn && primaryColumn.Count > 0)
                    {
                        string args = string.Empty;
                        string realArgs = string.Empty;
                        int count = primaryColumn.Count;
                        int mcount = count - 1;
                        for (int i = 0; i < count; i++)
                        {
                            var item = primaryColumn[i];
                            writer.WriteLine("\t\t/// <param name=\"{0}\">{1}</param>", item.Name, item.Description);
                            if (i < mcount)
                            {
                                args += string.Format("{0} {1}, ", ConfigManager.DataTypeConvertor.ConvertToDataType(item), item.Name);
                                realArgs += string.Format("{0}, ", item.Name);
                            }
                            else
                            {
                                args += string.Format("{0} {1}", ConfigManager.DataTypeConvertor.ConvertToDataType(item), item.Name);
                                realArgs += string.Format("{0}", item.Name);
                            }
                        }
                        writer.WriteLine("\t\t/// <returns>返回实体，否则返回NULL</returns>");
                        writer.WriteLine("\t\tpublic {0} Get({1})", entityClass, args);
                        writer.WriteLine("\t\t{");
                        writer.WriteLine("\t\t\treturn this.DAL.Get({0});", realArgs);
                    }
                    else
                    {
                        writer.WriteLine("\t\t/// <param name=\"{0}\">{1}</param>", "id", "ID");
                        writer.WriteLine("\t\t/// <returns>返回实体，否则返回NULL</returns>");
                        writer.WriteLine("\t\tpublic {0} Get({1})", entityClass, "int id");
                        writer.WriteLine("\t\t{");
                        writer.WriteLine("\t\t\treturn this.DAL.Get({0});", "id");
                    }
                    writer.WriteLine("\t\t}");
                    writer.WriteLine();
                    //Delete
                    writer.WriteLine("\t\t/// <summary>");
                    writer.WriteLine("\t\t/// 删除一个实体数据");
                    writer.WriteLine("\t\t/// </summary>");
                    if (null != primaryColumn && primaryColumn.Count > 0)
                    {
                        string args = string.Empty;
                        string realArgs = string.Empty;
                        int count = primaryColumn.Count;
                        int mcount = count - 1;
                        for (int i = 0; i < count; i++)
                        {
                            var item = primaryColumn[i];
                            writer.WriteLine("\t\t/// <param name=\"{0}\">{1}</param>", item.Name, item.Description);
                            if (i < mcount)
                            {
                                args += string.Format("{0} {1}, ", ConfigManager.DataTypeConvertor.ConvertToDataType(item), item.Name);
                                realArgs += string.Format("{0}, ", item.Name);
                            }
                            else
                            {
                                args += string.Format("{0} {1}", ConfigManager.DataTypeConvertor.ConvertToDataType(item), item.Name);
                                realArgs += string.Format("{0}", item.Name);
                            }
                        }
                        writer.WriteLine("\t\t/// <returns>0失败，1成功</returns>");
                        writer.WriteLine("\t\tpublic int Delete({0})", args);
                        writer.WriteLine("\t\t{");
                        writer.WriteLine("\t\t\treturn this.DAL.Delete({0});", realArgs);
                    }
                    else
                    {
                        writer.WriteLine("\t\t/// <param name=\"{0}\">{1}</param>", "id", "ID");
                        writer.WriteLine("\t\t/// <returns>0失败，1成功</returns>");
                        writer.WriteLine("\t\tpublic int Delete({0})", "int id");
                        writer.WriteLine("\t\t{");
                        writer.WriteLine("\t\t\treturn this.DAL.Delete({0});", "id");
                    }
                    writer.WriteLine("\t\t}");
                    writer.WriteLine();
                    //Edit
                    writer.WriteLine("\t\t/// <summary>");
                    writer.WriteLine("\t\t/// 编辑一个实体数据");
                    writer.WriteLine("\t\t/// </summary>");
                    writer.WriteLine("\t\t/// <param name=\"item\">实体</param>");
                    writer.WriteLine("\t\t/// <returns>0失败，1成功</returns>");
                    writer.WriteLine("\t\tpublic int Edit({0} item)", entityClass);
                    writer.WriteLine("\t\t{");
                    writer.WriteLine("\t\t\treturn this.DAL.Edit(item);");
                    writer.WriteLine("\t\t}");
                    writer.WriteLine();
                    //Add
                    writer.WriteLine("\t\t/// <summary>");
                    writer.WriteLine("\t\t/// 增加一个实体数据，并更新实体的ID为新增ID");
                    writer.WriteLine("\t\t/// </summary>");
                    writer.WriteLine("\t\t/// <param name=\"item\">实体</param>");
                    writer.WriteLine("\t\t/// <returns>0失败，1成功，2已存在</returns>");
                    writer.WriteLine("\t\tpublic int Add(ref {0} item)", entityClass);
                    writer.WriteLine("\t\t{");
                    writer.WriteLine("\t\t\treturn this.DAL.Add(ref item);");
                    writer.WriteLine("\t\t}");
                    writer.WriteLine();
                    //GetList
                    writer.WriteLine("\t\t/// <summary>");
                    writer.WriteLine("\t\t/// 获取数据列表");
                    writer.WriteLine("\t\t/// </summary>");
                    writer.WriteLine("\t\t/// <returns>返回非NULL列表</returns>");
                    writer.WriteLine("\t\tpublic List<{0}> GetList()", entityClass);
                    writer.WriteLine("\t\t{");
                    writer.WriteLine("\t\t\treturn this.DAL.GetList();");
                    writer.WriteLine("\t\t}");
                    writer.WriteLine();

                    writer.WriteLine("\t\t#endregion");
                    writer.WriteLine("\t}");
                    //end of class
                    writer.WriteLine("}");
                    writer.Close();
                }
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
                    SqlCreatorBase creator = SqlCreatorFactory.GetSqlCreator(config.DbType);
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

        #region 首字母大小写

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

        #endregion 首字母大小写
    }
}
