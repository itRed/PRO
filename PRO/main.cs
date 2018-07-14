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
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 测试数据库的链接
            //string M_str_sqlcon = "server=10.99.19.121;user id=root;password=root;database=haha"; //根据自己的设置
            // ConnectionUtil.connStr;
            string M_str_sqlcon = "server=127.0.0.1;user id=root;password=123456;database=pro";
            MySqlConnection mycon = new MySqlConnection();
            mycon.ConnectionString = ConnectionUtil.connStr;
            try
            {
                mycon.Open();

                MessageBox.Show("数据库已经连接了！");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            mycon.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //获取页面窗体订单信息
            string dt = date.Text.Trim();
            string machineNum = machine_num.Text.Trim();
            string companyValue = company.Text.Trim();
            string ct = client.Text.Trim();
            string typeNum = type_num.Text.Trim();
            string goodsValue = goods.Text.Trim();
            string totalValue = total.Text.Trim();
            string subCompany = subcompany.Text.Trim();
            string receiVables = receivables.Text.Trim();
            string addre = address.Text.Trim();
            string bookDate = book_date.Text.Trim();
            string sendDate = send_date.Text.Trim();
            string arrivalDate = arrival_date.Text.Trim();
            string shipNum = ship_num.Text.Trim();
            string logistic = logistics.Text.Trim();
            string frei = freight.Text.Trim();
            string tele = tel.Text.Trim();
            string transNum = trans_num.Text.Trim();
            string nt = note.Text.Trim();

            string id = Date.GetTimeStamp();

            MySqlConnection mycon = new MySqlConnection();
            mycon.ConnectionString = ConnectionUtil.connStr;
            mycon.Open();
            MySqlTransaction transaction = mycon.BeginTransaction();//事务必须在try外面赋值不然catch里的
            try
            {

                string sql = "INSERT INTO pro.t_pro (idx, date, machine_num, company, client, type_num, goods, total, subcompany, receivables, address, book_date, send_date, arrival_date, ship_num, logistics, freight, trans_num, tel, note) VALUES ('" + id + "', '" + dt + "', '" + machineNum + "', '" + companyValue + "', '" + ct +
                    "', '" + typeNum + "', '" + goodsValue + "', '" + totalValue + "', '" + subCompany + "', '" + receiVables + "', '" + addre + "', '" + bookDate + "', '" + sendDate + "', '" + arrivalDate + "', '" + shipNum + "', '" + logistic + "', '" + frei + "', '" + transNum + "', '" + tele + "', '" + nt + "')";
                MySqlCommand cmd1 = new MySqlCommand(sql, mycon);
                cmd1.ExecuteNonQuery();
                transaction.Commit();
                MessageBox.Show("订单信息保存成功", "提示");
                // date.Text = "";
                machine_num.Text = "";
                company.Text = "";
                client.Text = "";
                type_num.Text = "";
                goods.Text = "";
                total.Text = "";
                subcompany.Text = "";
                receivables.Text = "";
                address.Text = "";
                ship_num.Text = "";
                logistics.Text = "";
                freight.Text = "";
                tel.Text = "";
                trans_num.Text = "";
                note.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                transaction.Rollback();//事务ExecuteNonQuery()执行失败报错，username被设置unique
                mycon.Close();
            }
            finally
            {
                if (mycon.State != ConnectionState.Closed)
                {
                    //transaction.Commit();//事务要么回滚要么提交，即Rollback()与Commit()只能执行一个
                    mycon.Close();
                }
            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
