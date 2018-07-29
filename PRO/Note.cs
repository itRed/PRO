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
    public partial class Note : PRO.MainMaster
    {
        public Note()
        {
            InitializeComponent();
        }

        private void Note_Load(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Owner.Hide();

            //发票提醒部分dataGridView1
            string P_Str_ConnectionStrs = string.Format("server={0};user id = {1};port = {2};password=123456;database=pro;pooling = false;", "localhost", "root", 3306);
            string sql = "SELECT  idx AS 订单编号,type AS 订单类型, DATE AS 订单日期, company AS 公司, CLIENT AS 客户名称, note AS 备注 FROM pro.t_pro WHERE  bill_need = '是' AND bill_state = '未开具'";

            MySqlDataAdapter adapter = null;
            adapter = new MySqlDataAdapter(string.Format(sql), P_Str_ConnectionStrs);
            DataTable P_dts = new DataTable();
            adapter.Fill(P_dts);
            this.dataGridView1.DataSource = P_dts;
            

        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[e.RowIndex].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                }
            }

        }

        private void 订单详情ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowNo = dataGridView1.CurrentRow.Index;
            string idx = dataGridView1.Rows[rowNo].Cells[0].Value.ToString();

            Detail d = new Detail(idx);
            d.ShowDialog();

           // MessageBox.Show("订单ID："+ idx,"订单ID");

            return;
        }

        private void 设置已开具发票ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowNo = dataGridView1.CurrentRow.Index;
            string idx = dataGridView1.Rows[rowNo].Cells[0].Value.ToString();
            //MessageBox.Show
            string sql = "UPDATE pro.t_pro SET bill_state = '已开具' WHERE idx = '" + idx + "' ";

            //把得到的数据写入到数据库就行了，
            MySqlConnection mycon = new MySqlConnection();
            mycon.ConnectionString = ConnectionUtil.connStr;

            try
            {
                mycon.Open();
                MySqlCommand cmd = new MySqlCommand(sql, mycon);
                int num = cmd.ExecuteNonQuery();
                if (num > 0)
                {
                    MessageBox.Show("订单号为" + idx + "的订单已经开具发票", "提示");
                }
                else if (num == 0)
                {
                    MessageBox.Show("未对订单进行发票开具", "提示");
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
