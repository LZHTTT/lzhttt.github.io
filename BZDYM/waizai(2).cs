using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3;



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
                
                if (e.Clicks == 1 & this.listBox1.SelectedItems.Count>0)//输入鼠标点击次数为1此 那么就执行以下程序
                {
                    this.Text = listBox1.SelectedItem.ToString();

                }
                else if (e.Clicks == 2)//鼠标双击
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

                            #region 时间加密流 主程序
                            #region 获取时间相加和
                            System.DateTime currentTime = new System.DateTime();
                            currentTime = System.DateTime.Now;
                            Int64 bl年 = currentTime.Year;
                            Int64 bl月 = currentTime.Month;
                            Int64 bl日 = currentTime.Day;
                            Int64 bl时 = currentTime.Hour;
                            Int64 bl分 = currentTime.Minute;
                            Int64 bl秒 = currentTime.Second;

                            Int64 bl总 = (bl年 * 51536000 + bl月 * 2678400 + bl日 * 86400 + bl时 * 3600 + bl分 * 60 + bl秒) + 1;
                            #endregion

                            /*//有了相加和暂时不用这玩意
                            string BLshijian = DateTime.Now.ToLocalTime().ToString();//取系统时间
                            */

                            StreamWriter sW = new StreamWriter(@".\\JM.txt");//创建StreamWriter 类的实例,在软件所在目录创建文本 默认覆盖模式

                            sW.WriteLine(bl总.ToString());//向文件中写入拖放得到的地址
                            sW.Flush();     //刷新缓存          
                            sW.Close(); //关闭流
                            #endregion
                            #region 引用cmd执行命令
                            Process p = new Process();
                            p.StartInfo.FileName = "cmd.exe";       //设定程序名
                            p.StartInfo.UseShellExecute = false;        //关闭Shell的使用
                            p.StartInfo.RedirectStandardInput = true;   //重定向标准输入
                            p.StartInfo.RedirectStandardOutput = true;  //重定向标准输出
                            p.StartInfo.RedirectStandardError = true;   //重定向错误输出
                            p.StartInfo.CreateNoWindow = true;  //设置不显示窗口
                            p.Start();  //启动进程
                            p.StandardInput.WriteLine("start " + s);//输入要执行的命令
                            p.StandardInput.WriteLine("exit");//退出
                            #endregion

                           // this.Close();


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
            this.Close();
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
        #region 获取焦点失去焦点透明度设置

        private void waizai_Deactivate(object sender, EventArgs e)
        {
            this.Opacity = 0.3;
        }

        private void waizai_Activated(object sender, EventArgs e)
        {
            this.Opacity = 1;
        }
        #endregion

        private void waizai_FormClosed(object sender, FormClosedEventArgs e)
        {
            quanjubianlianghanshu.waizaichuangkoushifoudakai = 0;
        }
    }
}
