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

        private const int WM_HOTKEY = 0x312; //窗口消息：热键
        private const int WM_CREATE = 0x1; //窗口消息：创建
        private const int WM_DESTROY = 0x2; //窗口消息：销毁
        private const int HotKeyID = 1; //热键ID（自定义）
        public class SystemHotKey
        {

            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, Keys vk);
            [DllImport("user32.dll", SetLastError = true)]
            public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
            [Flags()]
            public enum KeyModifiers { None = 0, Alt = 1, Ctrl = 2, Shift = 4, WindowsKey = 8 }

            /// <param name="hwnd">窗口句柄</param>
            /// <param name="hotKey_id">热键ID</param>
            /// <param name="keyModifiers">组合键</param>
            /// <param name="key">热键</param>
            public static void RegHotKey(IntPtr hwnd, int hotKeyId, KeyModifiers keyModifiers, Keys key)
            {
                if (!RegisterHotKey(hwnd, hotKeyId, keyModifiers, key))
                {
                    int errorCode = Marshal.GetLastWin32Error();
                    if (errorCode == 1409)
                    {
                        MessageBox.Show("PageUp 隐藏热键被占用 ！请检查！");
                    }
                    else
                    {
                        MessageBox.Show("注册热键失败！错误代码：" + errorCode + "  请联系工程师！");
                    }
                }
            }


            /// <param name="hwnd">窗口句柄</param>
            /// <param name="hotKey_id">热键ID</param>
            public static void UnRegHotKey(IntPtr hwnd, int hotKeyId)
            {
                //注销指定的热键
                UnregisterHotKey(hwnd, hotKeyId);
            }

        }

        protected override void WndProc(ref Message msg)
        {
            base.WndProc(ref msg);
            switch (msg.Msg)
            {
                case WM_HOTKEY: //窗口消息：热键
                    int tmpWParam = msg.WParam.ToInt32();
                    if (tmpWParam == HotKeyID)
                    {

                        //     if (this.Visible == false  )
                        //   {
                        //     this.Visible  =true ;
                        //    }
                        //    else 
                        //{
                        //  	this.Visible  =false  ;
                        //    }
                        //此处判断窗口可视属性并修改,不知道怎么修改其他窗口了，直接关闭好了。
                        // Application .Exit ();
                        if (this.Visible == false)
                        {
                            this.Visible = true;
                        }
                        else
                        {
                            this.Visible = false;
                        }

                    }
                    break;
                case WM_CREATE: //窗口消息：创建
                    SystemHotKey.RegHotKey(this.Handle, HotKeyID, SystemHotKey.KeyModifiers.None, Keys.PageUp);//此处指定热键为PageUp
                    break;
                case WM_DESTROY: //窗口消息：销毁
                    SystemHotKey.UnRegHotKey(this.Handle, HotKeyID); //销毁热键
                    break;
                default:
                    break;
            }
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
