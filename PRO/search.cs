using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRO
{
    public partial class search : PRO.MainMaster
    {
        public search()
        {
            InitializeComponent();
        }

        private void search_Load(object sender, EventArgs e)
        {
          /**
            MySqlConnection mycon = new MySqlConnection();
            mycon.ConnectionString = ConnectionUtil.connStr;
            SqlConnection conn = new SqlConnection(ConnectionUtil.connStr.ToString());
           // mycon.Open();
            //MySqlTransaction transaction = mycon.BeginTransaction();//事务必须在try外面赋值不然catch里的
            try
            {
                string sql = "SELECT * FROM t_pro";

                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                DataSet Ds = new DataSet();
                sda.Fill(Ds, "t_pro");

                //使用DataSet绑定时，必须同时指明DateMember 
                this.dataGridView1.DataSource = Ds;
                this.dataGridView1.DataMember = "t_pro";

                //也可以直接用DataTable来绑定 
                this.dataGridView1.DataSource = Ds.Tables["t_pro"]; 

                //cmd1.ExecuteNonQuery();
              //  transaction.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               // transaction.Rollback();//事务ExecuteNonQuery()执行失败报错，username被设置unique
                mycon.Close();
            }
            finally
            {
                if (mycon.State != ConnectionState.Closed)
                {
                    mycon.Close();
                }
            }
            **/

            string constr = ConnectionUtil.connStr; //"server=.;database=School;uid=123;pwd=123;";
            string P_Str_ConnectionStr = string.Format("server={0};user id = {1};port = {2};password=123456;database=pro;pooling = false;", "localhost", "root", 3306);
            string P_Str_SqlStr = string.Format("SELECT  idx AS 订单编号, date AS 订单日期, machine_num AS 机器编码, company AS 公司, client AS 客户名称, type_num AS 型号, goods AS 发出货物, total AS 总金额, subcompany AS 分公司金额, receivables AS 收款情况, address AS 客户地址, book_date AS 接单日期, send_date AS 发货日期, arrival_date AS 到货日期, ship_num AS 发货件数, logistics AS 物流, freight AS 运费, trans_num AS 运输单号, tel AS 查询电话, note AS 备注 FROM pro.t_pro ");
            MySqlDataAdapter adapter = new MySqlDataAdapter(P_Str_SqlStr, P_Str_ConnectionStr);
            DataTable P_dt = new DataTable();
            adapter.Fill(P_dt);
            this.dataGridView1.DataSource = P_dt;

            // 列表样式
            // this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

        }
    }
}
