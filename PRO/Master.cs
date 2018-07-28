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
    public partial class Master : Form
    {
        public Master()
        {
            InitializeComponent();
        }

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

        private void toolStripLabel7_Click(object sender, EventArgs e)
        {
            props.userInfo u = new props.userInfo();
            u.ShowDialog();
        }

        private void toolStripLabel8_Click(object sender, EventArgs e)
        {
            props.helpInfo h = new props.helpInfo();
            h.ShowDialog();
        }

        private void Master_Load(object sender, EventArgs e)
        {
            /**
             * 隐藏“用户”控件的有效性
            if (Glob.idLogin)
            {
                toolStripLabel7.Enabled = true;
            }
            else 
            {
                toolStripLabel7.Enabled = false;
            }**/
        }
    }
}
