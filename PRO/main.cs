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
    public partial class main : PRO.MainMaster
    {
        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            //this.Owner.Hide();//隐藏Form1
            groupBox1.SendToBack();
            //Combobox.SelectedIndex = Combobox.Items.IndexOf(“默认选中文本”); 
            billType.SelectedIndex = billType.Items.IndexOf("保养");
            shipState.SelectedIndex = shipState.Items.IndexOf("未发货");
            billNeed.SelectedIndex = billNeed.Items.IndexOf("否");
            billState.SelectedIndex = billState.Items.IndexOf("未开具");
            area.SelectedIndex = area.Items.IndexOf("四川省");
            
            //隐藏页面上需要动态处理的组件
            label24.Hide();
            billState.Hide();
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
            
            //V0.2添加
            string debtT = billType.SelectedItem.ToString();//订单类型
            string areaV = area.SelectedItem.ToString();//地区信息
            string shipSt = shipState.SelectedItem.ToString();//发货状态
            string billN = billNeed.SelectedItem.ToString();//是否需要发票
            string billSt = billState.SelectedItem.ToString();//发票状态
            string debtV = debt.SelectedItem.ToString();//是否欠款
            string debtMV = debtM.Text.Trim();//具体钱款数额
            //TODO 是否需要提醒
            string remd = "是";

            MySqlConnection mycon = new MySqlConnection();
            mycon.ConnectionString = ConnectionUtil.connStr;
            mycon.Open();
            MySqlTransaction transaction = mycon.BeginTransaction();//事务必须在try外面赋值不然catch里的
            try
            {
                string sql = "INSERT INTO pro.t_pro ( idx, date, machine_num, company, client, type_num, goods, total, subcompany, receivables, address, book_date, send_date, arrival_date, ship_num, ship_state, logistics, freight, trans_num, tel, note, type, bill_need, bill_state, area, remind, debt, debtM) VALUES ('" 
                    + id + "', '" + dt + "', '" + machineNum + "', '" + companyValue + "', '" + ct +
                    "', '" + typeNum + "', '" + goodsValue + "', '" + totalValue + "', '" + subCompany + "', '" + receiVables + "', '" + addre + "', '"
                    + bookDate + "', '" + sendDate + "', '" + arrivalDate + "', '" + shipNum + "', '" + shipSt + "','" + logistic + "', '" + frei + "', '" + transNum + "', '"
                    + tele + "', '" + nt + "','" + debtT + "','" + billN + "','" + billSt + "','" + areaV + "','" + remd + "','" + debtV + "','" + debtMV + "')";
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
                shipState.Text = "";
                debtM.Text = "";

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

        private void billNeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bn = billNeed.SelectedItem.ToString();
            if (bn.Equals("是"))
            {
                label24.Show();
                billState.Show();
            }
            else {
                label24.Hide();
                billState.Hide();
            }
        }

        private void main_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void main_Load_1(object sender, EventArgs e)
        {
            this.Owner.Hide();//隐藏Form1
            groupBox1.SendToBack();
            //Combobox.SelectedIndex = Combobox.Items.IndexOf(“默认选中文本”); 
            billType.SelectedIndex = billType.Items.IndexOf("保养");
            shipState.SelectedIndex = shipState.Items.IndexOf("未发货");
            billNeed.SelectedIndex = billNeed.Items.IndexOf("否");
            billState.SelectedIndex = billState.Items.IndexOf("未开具");
            area.SelectedIndex = area.Items.IndexOf("四川省");
            debt.SelectedIndex = debt.Items.IndexOf("否");

            //隐藏页面上需要动态处理的组件
            label24.Hide();
            billState.Hide();
        }

        private void debt_SelectedIndexChanged(object sender, EventArgs e)
        {
            string debtStr = debt.SelectedItem.ToString();
            if (debtStr.Equals("是"))
            {
                debtM.Show();
                label26.Show();
            }
            else {
                debtM.Hide();
                label26.Hide();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
