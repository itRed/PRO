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

namespace PRO
{
    public partial class login : PRO.Master
    {
        public login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {
           // this.WindowState = FormWindowState.Maximized;    //最大化窗体
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
            // 通知所有消息泵必须终止，并且在处理了消息以后关闭所有应用程序窗口。
            //  由 .NET Compact Framework 支持。

            //关闭窗口(主程序还没有退去)
        }

        private void login_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            String userName = textBox2.Text.Trim();
            String passWd = textBox1.Text.Trim();

            if ("".Equals(userName) || "".Equals(passWd))
            {
                MessageBox.Show("请输入正确的用户名和密码", "提示");
                return;
            }
            else
            {
                MySqlConnection mycon = new MySqlConnection();
                mycon.ConnectionString = ConnectionUtil.connStr;
                try
                {
                    mycon.Open();
                    string sql = "SELECT * FROM t_user WHERE user_name = '" + userName + "' AND user_pass = '" + passWd + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, mycon);
                    MySqlDataReader read = cmd.ExecuteReader();
                    InfoUser u = null;
                    while (read.Read())
                    {
                        u = new InfoUser();
                        u.setUserId(Convert.ToInt32(read.GetValue(0).ToString()));
                        u.setUserName(read.GetValue(1).ToString());
                        u.setUserPass(read.GetValue(2).ToString());
                        break;
                    }
                    if (u != null)
                    {
                        MessageBox.Show("登录成功", "提示");
                        //跳转到主页面
                        Note n = new Note();
                        n.ShowDialog(this);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("用户名或密码不正确，请确认后输入", "提示");
                        return;
                    }


                }
                catch (Exception ex1) {
                    MessageBox.Show(ex1.Message);
                }

            }
        }
    }
}
