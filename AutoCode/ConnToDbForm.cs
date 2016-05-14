using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutoCode.Entity;
using System.Data.Common;
using AutoCode.Utils;
using AutoCode.DbFactory;
using AutoCode.SpecificSql;

namespace AutoCode
{
    public partial class ConnToDbForm : Form
    {
        public ConnToDbForm()
        {
            InitializeComponent();
            ConfigManager.ClickLogin = false;
            cbb_LoginType.SelectedIndex = ConfigManager.Config.DbLoginTypeSelectIndex;
            cbb_serverName.Text = ConfigManager.Config.DbServerName;
            txt_LoginPwd.Text = ConfigManager.Config.DbLoginPwd;
            cbb_LoginName.Text = ConfigManager.Config.DbLoginName;
            cbb_DbName.Text = ConfigManager.Config.DbName;
            cbb_DatabaseType.DataSource = Enum.GetNames(typeof(DatabaseType)); ;
            cbb_DatabaseType.Text = ConfigManager.Config.DbType.ToString();
        }

        private void btn_Conn_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigManager.ClickLogin = true;
                string dbName = cbb_DbName.Text.Trim();
                string server = cbb_serverName.Text.Trim();
                string loginName = cbb_LoginName.Text.Trim();
                string loginPwd = txt_LoginPwd.Text.Trim();
                if (string.IsNullOrEmpty(server))
                {
                    MessageBox.Show("请填写服务器名");
                    cbb_serverName.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(loginName))
                {
                    MessageBox.Show("请填写登陆名称");
                    cbb_LoginName.Focus();
                    return;
                }
                if (!SetDbType(cbb_DatabaseType.Text.Trim()))
                {
                    MessageBox.Show("请选择数据类型");
                    cbb_DatabaseType.Focus();
                    return;
                }
                string conStr = ConfigManager.DbFactory.CreateConnStr(server, "", loginName, loginPwd);
                using (DbConnection conn = ConfigManager.DbFactory.GetConnection(conStr))
                {
                    DbCommand cmd = ConfigManager.DbFactory.GetCommand(conn, ConfigManager.SpecificSql.GetDatabaseNameSql());
                    List<DatabaseNameEntity> dblist = DbHelper.GetList<DatabaseNameEntity>(cmd);
                    List<string> list = new List<string>();
                    foreach (DatabaseNameEntity item in dblist)
                    {
                        list.Add(item.Name);
                    }
                    cbb_DbName.DataSource = list;
                    cbb_DbName.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            try
            {
                string dbName = cbb_DbName.Text.Trim();
                string server = cbb_serverName.Text.Trim();
                string loginName = cbb_LoginName.Text.Trim();
                string loginPwd = txt_LoginPwd.Text.Trim();
                if (string.IsNullOrEmpty(server))
                {
                    MessageBox.Show("请填写服务器名");
                    cbb_serverName.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(loginName))
                {
                    MessageBox.Show("请填写登陆名称");
                    cbb_LoginName.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(dbName))
                {
                    MessageBox.Show("请填写数据库名");
                    cbb_DbName.Focus();
                    return;
                }
                if (!SetDbType(cbb_DatabaseType.Text.Trim()))
                {
                    MessageBox.Show("请选择数据类型");
                    cbb_DatabaseType.Focus();
                    return;
                }
                string conStr = ConfigManager.DbFactory.CreateConnStr(server, dbName, loginName, loginPwd);
                using (DbConnection conn = ConfigManager.DbFactory.GetConnection(conStr))
                {
                    if (DbHelper.IsAvailable(conn))
                    {
                        SaveConfig();
                        ConfigManager.LoginSuccess = true;
                        this.Close();
                    }
                    else
                    {
                        ConfigManager.LoginSuccess = false;
                        MessageBox.Show("登陆失败");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveConfig()
        {
            ConfigManager.Config.DbLoginTypeSelectIndex = cbb_LoginType.SelectedIndex;
            ConfigManager.Config.DbServerName = cbb_serverName.Text.Trim();
            ConfigManager.Config.DbLoginName = cbb_LoginName.Text.Trim();
            ConfigManager.Config.DbLoginPwd = txt_LoginPwd.Text.Trim();
            ConfigManager.Config.DbName = cbb_DbName.Text.Trim();
            ConfigManager.Config.DbType = (DatabaseType)Enum.Parse(typeof(DatabaseType), cbb_DatabaseType.Text.Trim());
        }

        private bool SetDbType(string dbType)
        {
            if (string.IsNullOrWhiteSpace(dbType)) throw new ArgumentNullException("dbType", "数据类型不能为空或null");
            DatabaseType type = (DatabaseType)Enum.Parse(typeof(DatabaseType), dbType);
            switch (type)
            {
                case DatabaseType.MsSqlClient:
                    ConfigManager.DbFactory = new MsDbFactory();
                    ConfigManager.SpecificSql = new MsSpecificSql();
                    SqlCreatorFactory.Clear();
                    return true;
                case DatabaseType.MySqlClient:
                    ConfigManager.DbFactory = new MySqlDbFactory();
                    ConfigManager.SpecificSql = new MySqlSpecificSql();
                    SqlCreatorFactory.Clear();
                    return true;
                default:
                    return false;
            }
        }
    }
}
