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
    public partial class Note : Form
    {
        public Note()
        {
            InitializeComponent();
        }

        private void Note_Load(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Owner.Hide();
        }

        private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            props.version vs = new props.version();
            vs.ShowDialog(this);
        }

        private void toolStrip3_Click(object sender, EventArgs e)
        {
           
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

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            main m = new main();
            m.ShowDialog(this);
            
        }
    }
}
