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
    public partial class login : Form
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
            String userName = textBox2.Text.Trim();
            String passWd = textBox1.Text.Trim();
            if (userName != "admin" && passWd != "123")
            {
                MessageBox.Show("请输入正确的用户名和密码", "提示");
                return;
            }else { 
                //TODO 用户名和密码正确，则登录主页面


            }
        }

        private void login_Load(object sender, EventArgs e)
        {
           // this.StartPosition = FormStartPosition.CenterScreen; 
            this.WindowState = FormWindowState.Maximized;    //最大化窗体
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
            // 通知所有消息泵必须终止，并且在处理了消息以后关闭所有应用程序窗口。
            //  由 .NET Compact Framework 支持。

            //关闭窗口(主程序还没有退去)
        }
    }
}
