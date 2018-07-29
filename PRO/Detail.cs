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
    public partial class Detail : Form
    {
        public static string ids = "";

        public Detail()
        {
            InitializeComponent();
        }

        public Detail(string idx)
        {
            InitializeComponent();
            ids = idx;
        }

        private void Detail_Load(object sender, EventArgs e)
        {
            dataGridView1.ForeColor = Color.Black;
           
            string constr = ConnectionUtil.connStr; //"server=.;database=School;uid=123;pwd=123;";
            string P_Str_SqlStr = string.Format("SELECT  idx AS 订单编号,type AS 订单类型,area AS 区域, DATE AS 订单日期, machine_num AS 机器编码, company AS 公司, CLIENT AS 客户名称, type_num AS 型号, goods AS 发出货物, total AS 总金额, subcompany AS 分公司金额, receivables AS 收款情况, address AS 客户地址, book_date AS 接单日期, send_date AS 发货日期, arrival_date AS 到货日期, ship_num AS 发货件数, logistics AS 物流, freight AS 运费, trans_num AS 运输单号, tel AS 查询电话, note AS 备注, ship_state AS 运输状态,bill_need AS 需要发票,bill_state AS 发票状态,debt AS 是否欠款,debtM AS 欠款金额 FROM pro.t_pro WHERE idx = '" + ids + "'");
            
            DataTable P_dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(P_Str_SqlStr, constr);
            adapter.Fill(P_dt);
            this.dataGridView1.DataSource = P_dt;
        }
    }
}
