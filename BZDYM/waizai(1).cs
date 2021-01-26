using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BZD
{
    public partial class waizai : Form
    {

        public waizai()
        {
            InitializeComponent();
        }
        #region 窗口载入时
        private void waizai_Load(object sender, EventArgs e)
        {
            #region 确定程序出现位置
            int pingmukuandu = Screen.PrimaryScreen.Bounds.Width;//获取屏幕宽度
            int pingmugaodu = Screen.PrimaryScreen.Bounds.Height;
            Control.CheckForIllegalCrossThreadCalls = false;
            //timerl.Start();
           if(MousePosition.X>pingmukuandu/2)
            {
                if(MousePosition.Y>pingmugaodu/2)
                {
                    this.SetDesktopLocation(MousePosition.X - 218, MousePosition.Y - 517);

                }
                else
                {
                    this.SetDesktopLocation(MousePosition.X - 218, MousePosition.Y );
                }
                
            }
           else
            {
                if (MousePosition.Y > pingmugaodu / 2)
                {
                    this.SetDesktopLocation(MousePosition.X, MousePosition.Y - 517);
                }
                else
                {
                    this.SetDesktopLocation(MousePosition.X , MousePosition.Y);
                }

            }
           
            #endregion 确定程序首次出现位置
            #region 载入文件中的内容到listbox
            if (File.Exists(@".\waizai.txt"))//判断文件是否存在
            {//如果文件存在
                StreamReader file = new StreamReader(@"waizai.txt", Encoding.GetEncoding("utf-8"));
                string s = "";

                while (s != null)
                {
                    s = file.ReadLine();//从当前流中读取一行字符串

                    if (s != null )
                    {
                        string[] ss = s.Split('\\');//把路径按\拆分为数组
                        listBox1.Items.Add(ss[ss.Length - 1]);
                    }

                }
                file.Close();
            }
            else 
            {
                StreamWriter waizai = new StreamWriter(@"waizai.txt");
                waizai.Flush();
                waizai.Close();

            }
            #endregion

        }
        #endregion
        #region 拖放程序
        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            #region 获得拖放，写入框子
            string BLneirong = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString(); //把获得到的拖放路径装入变量

            //检查添加值是否添加过
            if (this.listBox1.Items.Contains(BLneirong))
            {
                MessageBox.Show("集合成员已添加过！");
            }
            else
            {
                //对用于显示的文本进行切割
                string[] SZneirong = BLneirong.Split('\\');//把路径按\拆分为数组
                this.listBox1.Items.Add(SZneirong[SZneirong.Length - 1]);//把切割后的字符串 最后一个内容添加到listbox中，也就没有前面的一大行路径了
                StreamWriter writer = new StreamWriter(@"waizai.txt", true);// 写文件，(@"kuaijie.dll", true)续写(@"kuaijie.dll")表示覆盖                
                writer.Write(BLneirong + "\n");//将每一个item写进文件
                writer.Close();//记得最后要关闭哦！释放资源 祝你成功哈
            }
            #endregion


        }
        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            #region 重要代码：表明是所有类型的数据，比如文件路径 
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
            #endregion
        }
        #endregion
        #region 鼠标点击判断
        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) //判断是否右键点击
            {
                this.contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);//弹出contextMenuStrip1（菜单）位置就在MousePosition（鼠标点击位置的xy)
            }
            //如果是左键点击那么
            else if (e.Button == MouseButtons.Left & this.WindowState == FormWindowState.Normal)
            {
                
                if (e.Clicks == 1)//输入鼠标点击次数为1此 那么就执行以下程序
                {
                    this.Text = listBox1.SelectedItem.ToString();

                }
                else if (e.Clicks == 2)
                {

                    //判断所有选中项集合大于0
                    if (this.listBox1.SelectedItems.Count > 0)
                    {
                        int xuanzhongdedijixiang = listBox1.SelectedIndex;//判断选中的是listbox中的第几项
                        
                        StreamReader file = new StreamReader(@"waizai.txt", Encoding.GetEncoding("utf-8"));//读取文本
                        string s = "";


                        for (int i = -1;i<xuanzhongdedijixiang;i++)
                        {
                            s = file.ReadLine();//从当前流中读取一行字符串
                        }                        
                       if(s.Equals(""))
                        {
                            MessageBox.Show("选中为空项");
                        }
                       else
                        {
                            System.Diagnostics.Process.Start(s);//运行 BLxuanzhong 中的地址
                            
                        }

                        file.Close();
                    }
                    else
                    {
                        MessageBox.Show("未选中listbox集合的值");
                    }


                }
                else
                {

                }

            }
        }
        #endregion
        #region 关闭
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region 编辑按钮被点击
        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@".\waizai.txt");
        }
        #endregion
        #region 是否固定最前设置
        private void 取消固定最前ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (取消固定最前ToolStripMenuItem.Text == "取消固定最前")//判断标签是否为取消固定在前
            {
                this.TopMost = false;
                this.取消固定最前ToolStripMenuItem.Text = "固定在最前";//判断为真运行此  
            }
            else
            {
                this.TopMost = true;
                this.取消固定最前ToolStripMenuItem.Text = "取消固定最前";//判断为假，运行此
                /* 如果布尔表达式为假将执行的语句 */
            }
        }
        #endregion

      

        private void waizai_Deactivate(object sender, EventArgs e)
        {
            this.Opacity = 0.2;
        }

        private void waizai_Activated(object sender, EventArgs e)
        {
            this.Opacity = 1;
        }
    }
}
