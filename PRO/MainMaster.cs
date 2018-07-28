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
    public partial class MainMaster : Form
    {
        public MainMaster()
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

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            search s = new search();
            s.ShowDialog(this);
            this.Close();
        }
    }
}
