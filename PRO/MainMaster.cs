using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRO
{
    public partial class MainMaster : Form
    {
        public MainMaster()
        {
            InitializeComponent();
        }

       // HotKeys h = new HotKeys();

          private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            props.version vs = new props.version();
            vs.ShowDialog(this);
        }

        private void toolStripLabel6_Click(object sender, EventArgs e)
        {
            props.DbTest t = new props.DbTest();
            t.ShowDialog();
        }

        private void toolStripLabel8_Click(object sender, EventArgs e)
        {
            props.helpInfo h = new props.helpInfo();
            h.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Note n = new Note();
            n.ShowDialog(this);
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            main m = new main();
            m.ShowDialog(this);
            this.Close();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainMaster_Load(object sender, EventArgs e)
        {
          //  h.UnRegist(this.Handle, CallBack);
          //  h.Regist(this.Handle, 0, Keys.PageUp, CallBack);
        }

        protected override void WndProc(ref Message m)
        {
            //窗口消息处理函数
          //  h.ProcessHotKey(m);
            base.WndProc(ref m);
        }

        //按下快捷键时被调用的方法
        public void CallBack()
        {
            //MessageBox.Show("快捷键被调用！");
           // h.UnRegist(this.Handle, CallBack);
            Application.Exit();
            /**if (this.Visible == true)
            {
                this.Visible = false;
            }
            else
            {
                this.Visible = true;
            }
            **/
        }


        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            search s = new search();
            s.ShowDialog(this);
            this.Close();
        }
        

  
    }
}
