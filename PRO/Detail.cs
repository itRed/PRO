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

        private void button1_Click(object sender, EventArgs e)
        {

            /** 方案2 **/
            StringBuilder sb = new StringBuilder();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string ids = row.Cells["订单编号"].Value.ToString();
                string billTypeV = row.Cells["订单类型"].Value.ToString();
                string areaV = row.Cells["区域"].Value.ToString();
                string dateV = row.Cells["订单日期"].Value.ToString();
                string machineNumV = row.Cells["机器编码"].Value.ToString();
                string companyV = row.Cells["公司"].Value.ToString();
                string clientV = row.Cells["客户名称"].Value.ToString();
                string typeNumV = row.Cells["型号"].Value.ToString();
                string goodsV = row.Cells["发出货物"].Value.ToString();
                string totalV = row.Cells["总金额"].Value.ToString();
                string subCompanyV = row.Cells["分公司金额"].Value.ToString();
                string receivablesV = row.Cells["收款情况"].Value.ToString();
                string addressV = row.Cells["客户地址"].Value.ToString();
                string bookDateV = row.Cells["接单日期"].Value.ToString();
                string sendDateV = row.Cells["发货日期"].Value.ToString();
                string arrivalDateV = row.Cells["到货日期"].Value.ToString();
                string shipNumV = row.Cells["发货件数"].Value.ToString();
                string logisticsV = row.Cells["物流"].Value.ToString();
                string freightV = row.Cells["运费"].Value.ToString();
                string transNumV = row.Cells["运输单号"].Value.ToString();
                string telV = row.Cells["查询电话"].Value.ToString();
                string noteV = row.Cells["备注"].Value.ToString();
                string shipStateV = row.Cells["运输状态"].Value.ToString();
                string billNeedV = row.Cells["需要发票"].Value.ToString();
                string billStateV = row.Cells["发票状态"].Value.ToString();
                string debtV = row.Cells["是否欠款"].Value.ToString();
                string debtMV = row.Cells["欠款金额"].Value.ToString();
                //TODO 提醒标识
                string remingV = "是";

                // string dt = row.Cells[""].Value.ToString();
                string sql = "UPDATE pro.t_pro SET date = '" + dateV + "', machine_num = '" + machineNumV + "', company = '" + companyV + "', client = '" + clientV + "', type_num = '" + typeNumV + "', goods = '" + goodsV
                    + "', total = '" + totalV + "', subcompany ='" + subCompanyV + "', receivables = '" + receivablesV + "', address ='" + addressV + "', book_date = '" + bookDateV + "', send_date = '" + sendDateV + "', arrival_date = '" + arrivalDateV + "', ship_num = '" + shipNumV
                    + "', ship_state = '" + shipStateV + "', logistics = '" + logisticsV + "', freight = '" + freightV + "', trans_num = '" + transNumV + "', tel = '" + telV + "', note = '" + noteV + "', type = '" + typeNumV + "', bill_need = '" + billNeedV + "', bill_state = '" + billStateV
                    + "', area = '" + areaV + "', remind ='" + remingV + "', debt = '" + debtV + "', debtM = '" + debtMV + "' WHERE idx = '" + ids + "';";
                sb.Append(sql);
            }
            //把得到的数据写入到数据库就行了，
            MySqlConnection mycon = new MySqlConnection();
            mycon.ConnectionString = ConnectionUtil.connStr;

            try
            {
                mycon.Open();
                string sqlStr = sb.ToString();
                MySqlCommand cmd = new MySqlCommand(sqlStr, mycon);
                int num = cmd.ExecuteNonQuery();
                if (num > 0)
                {
                    MessageBox.Show("本次操作一共保存" + num + "条数据", "提示");
                }
                else if (num == 0)
                {
                    MessageBox.Show("未对数据进行更新操作", "提示");
                }
                else
                {
                    MessageBox.Show("操作异常，请稍后重新操作", "提示");
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                mycon.Close();
            }
        }
    }
}
