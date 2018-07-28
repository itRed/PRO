using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRO.props
{
    public partial class DbTest : Form
    {
        public DbTest()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ipstr = ip.Text.Trim();
            string userStr = user.Text.Trim();
            string passwd = password.Text.Trim();
            string portStr = port.Text.Trim(); 

            if ("".Equals(ipstr) || ipstr == null) {
                MessageBox.Show("IP地址不能为空","提示");
                ip.Focus();
                return;
            }
            else if ("".Equals(userStr) || userStr == null) {
                MessageBox.Show("用户名不能为空","提示");
                user.Focus();
                return;
            }
            else if ("".Equals(passwd) || passwd == null) {
                MessageBox.Show("数据库密码不能为空","提示");
                password.Focus();
                return;
            }
            else if ("".Equals(portStr) || portStr == null)
            {
                MessageBox.Show("端口不能为空", "提示");
                port.Focus();
                return;
            }
            else {
                string M_str_sqlcon = "server=" + ipstr + ";user id=" + userStr + ";password=" + passwd + ";database=pro";
                MySqlConnection mycon = new MySqlConnection();
                mycon.ConnectionString = ConnectionUtil.connStr;
                try
                {
                    mycon.Open();
                    MessageBox.Show("数据库连接成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                mycon.Close();

            }

        }

        private void DbTest_Load(object sender, EventArgs e)
        {
            //设置当前窗体在所有窗体的最上层
            this.TopMost = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ipstr = ip.Text.Trim();
            string userStr = user.Text.Trim();
            string passwd = password.Text.Trim();
            string portStr = port.Text.Trim();

            if ("".Equals(ipstr) || ipstr == null)
            {
                MessageBox.Show("IP地址不能为空", "提示");
                ip.Focus();
                return;
            }
            else if ("".Equals(userStr) || userStr == null)
            {
                MessageBox.Show("用户名不能为空", "提示");
                user.Focus();
                return;
            }
            else if ("".Equals(passwd) || passwd == null)
            {
                MessageBox.Show("数据库密码不能为空", "提示");
                password.Focus();
                return;
            }
            else if ("".Equals(portStr) || portStr == null)
            {
                MessageBox.Show("端口不能为空", "提示");
                port.Focus();
                return;
            }
            else
            {
                string M_str_sqlcon = "server=" + ipstr + ";user id=" + userStr + ";password=" + passwd + ";database=pro";
                MySqlConnection mycon = new MySqlConnection();
                mycon.ConnectionString = ConnectionUtil.connStr;
                try
                {
                    mycon.Open();
                    string sql = "INSERT INTO pro.t_db ( db_ip, db_user, db_pass, db_port) VALUES ('" + ipstr + "', '" + userStr + "','" + passwd + "','" + portStr + "')";
                    MySqlCommand cmd1 = new MySqlCommand(sql, mycon);
                    cmd1.ExecuteNonQuery();
                    //transaction.Commit();
                    MessageBox.Show("数据库配置项保存成功", "提示");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    mycon.Close();
                }
                finally {
                    if (mycon.State != ConnectionState.Closed)
                    {
                        mycon.Close();
                    }
                }
            }
        }
    }
}
