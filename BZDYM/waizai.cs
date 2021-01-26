using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace BZD
{
    public partial class waizai : Form
    {
        #region 程序开始
        public waizai()
        {
            InitializeComponent();
        }
        #endregion
        #region 变量
        string CLzhixiangchangliang = @".\\Bridging.bat";
        string BLpanfu = "A";
        #endregion
        #region 窗口载入时
        private void waizai_Load(object sender, EventArgs e)
        {
            #region 防止多开
            bool isNotRunning;  //互斥体判断
            System.Threading.Mutex instance = new System.Threading.Mutex(true, "MutexName", out isNotRunning);   //同步基元变量
            if (!isNotRunning)  // 如果不是未运行状态
            {
                MessageBox.Show("程序已在运行");
                Environment.Exit(1);
            }
           
            #endregion
            #region 确定程序出现位置
            int pingmukuandu = Screen.PrimaryScreen.Bounds.Width;//获取屏幕宽度 写入变量中
            this.SetDesktopLocation(pingmukuandu -400, 0);

            #endregion 
            #region 载入文件中的内容到listbox
            if (File.Exists(@".\waizai.txt"))//判断文件是否存在
            {//如果文件存在
                StreamReader file = new StreamReader(@"waizai.txt", Encoding.GetEncoding("utf-8"));//把文件内容装入file
                string s = "";

                while (s != null)
                {
                    s = file.ReadLine();//从当前流中读取一行字符串

                    if (s != null )
                    {
                        if(s.Contains('|'))//判断是否包含|
                        {
                            string[] ss = s.Split('|');//把路径按\拆分为数组
                            listBox1.Items.Add(ss[ss.Length - 1]);
                        }
                        else
                        {
                            string[] ss = s.Split('\\');//把路径按\拆分为数组
                            listBox1.Items.Add(ss[ss.Length - 1]);

                        }
                     
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
                writer.Write("\n"+BLneirong );//将每一个item写进文件
                writer.Close();//记得最后要关闭释放资源
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
                            if (s.Contains('|'))//判断是否包含|
                            {
                                string[] ssdk = s.Split('|');//把路径按\拆分为数组
                                
                                s = ssdk[ssdk.Length - 2];
                            }
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
                            p.StandardInput.WriteLine("start "+"\"" + "\"" + " \"" + s + "\"");//输入要执行的命令
                            p.StandardInput.WriteLine("exit");//退出
                            #endregion
                           
                           


                        }

                        file.Close();//关闭文件读写占用
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
        #region 窗口被关闭时
        private void waizai_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Application.ExitThread();// 强制中止调用线程上的所有消息，同样面临其它线程无法正确退出的问题； 
            System.Environment.Exit(0);//最彻底关闭方法

            //  Application.Exit();//关闭整个程序
            // this.Close();//关闭当前窗口
        }
        #endregion
        #region 编辑按钮被点击
        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@".\waizai.txt");//打开链接记录文本所在文件waizai.txt
            
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
            this.Opacity = Settings1.Default.waizai窗口无焦点时透明度 ;
           if(Settings1.Default.窗口失去焦点是否自动缩放 == true)
            {
                this.Height = 0;
                this.Text = "✨✨✨✨✨✨";

            }
               
        }

        private void waizai_Activated(object sender, EventArgs e)
        {
            this.Opacity = Settings1.Default.waizai窗口有焦点时透明度;
            this.Height = 380;
            
        }

        #endregion
        #region 菜单项
        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new 设置().ShowDialog();
        }

        private void 更新程序到系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(File.Exists(@"C:\BZD\BZD.exe"))
            {
                File.Delete(@"C:\BZD\BZD.exe");
                Console.Read();
                System.IO.Directory.CreateDirectory(@"C:\BZD");//创建c盘bzd文件夹
                System.IO.File.Copy(Application.ExecutablePath, @"C:\BZD\BZD.exe");//复制自身到c盘bzd  
                File.Delete(@".\zck.txt");
                System.Diagnostics.Process.Start(@"C:\BZD");//打开文件夹          
                System.Environment.Exit(0);//然后结束自身

            }
            else
            {
                System.IO.Directory.CreateDirectory("C:\\BZD");//创建c盘bzd文件夹
                System.IO.File.Copy(Application.ExecutablePath, "C:\\BZD\\BZD.exe");//复制自身到c盘bzd    
                File.Delete(".\\zck.txt");
                Console.Read();
                System.Diagnostics.Process.Start("C:\\BZD");//打开文件夹          
                System.Environment.Exit(0);//然后结束自身
            }
           
        }


        private void 打开自身所在目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@".\");
        }


        private void 打开控制面板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region 引用cmd执行命令
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";       //设定程序名
            p.StartInfo.UseShellExecute = false;        //关闭Shell的使用
            p.StartInfo.RedirectStandardInput = true;   //重定向标准输入
            p.StartInfo.RedirectStandardOutput = true;  //重定向标准输出
            p.StartInfo.RedirectStandardError = true;   //重定向错误输出
            p.StartInfo.CreateNoWindow = true;  //设置不显示窗口
            p.Start();  //启动进程
            p.StandardInput.WriteLine("control.exe");//输入要执行的命令
            p.StandardInput.WriteLine("exit");//退出
            #endregion 
        }

        private void 打开磁盘管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region 引用cmd执行命令
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";       //设定程序名
            p.StartInfo.UseShellExecute = false;        //关闭Shell的使用
            p.StartInfo.RedirectStandardInput = true;   //重定向标准输入
            p.StartInfo.RedirectStandardOutput = true;  //重定向标准输出
            p.StartInfo.RedirectStandardError = true;   //重定向错误输出
            p.StartInfo.CreateNoWindow = true;  //设置不显示窗口
            p.Start();  //启动进程
            p.StandardInput.WriteLine("diskmgmt.msc");//输入要执行的命令
            p.StandardInput.WriteLine("exit");//退出
            #endregion 
        }

        private void 调用XToolStripMenuItem_Click(object sender, EventArgs e)
        {

            #region 盘符判断结构

            int panduan = 0;
            if (File.Exists("A:\\X\\Start\\Start.bat"))
            {
                BLpanfu = "A";
                panduan += 1;
            }
            if (File.Exists("B:\\X\\Start\\Start.bat"))
            {
                BLpanfu = "B";
                panduan += 1;
            }
            if (File.Exists("C:\\X\\Start\\Start.bat"))
            {
                BLpanfu = "C";
                panduan += 1;
            }
            if (File.Exists("D:\\X\\Start\\Start.bat"))
            {
                BLpanfu = "D";
                panduan += 1;
            }
            if (File.Exists("E:\\X\\Start\\Start.bat"))
            {
                BLpanfu = "E";
                panduan += 1;
            }
            if (File.Exists("F:\\X\\Start\\Start.bat"))
            {
                BLpanfu = "F";
                panduan += 1;
            }
            if (File.Exists("G:\\X\\Start\\Start.bat"))
            {
                BLpanfu = "G";
                panduan += 1;
            }
            if (File.Exists("H:\\X\\Start\\Start.bat"))
            {
                BLpanfu = "H";
                panduan += 1;
            }
            if (File.Exists("I:\\X\\Start\\Start.bat"))
            {
                BLpanfu = "I";
                panduan += 1;
            }
            if (File.Exists("J:\\X\\Start\\Start.bat"))
            {
                BLpanfu = "J";
                panduan += 1;
            }
            if (File.Exists("K:\\X\\Start\\Start.bat"))
            {
                BLpanfu = "K";
                panduan += 1;
            }
            if (File.Exists("L:\\X\\Start\\Start.bat"))
            {
                BLpanfu = "L";
                panduan += 1;
            }
            if (File.Exists("M:\\X\\Start\\Start.bat"))
            {
                BLpanfu = "M";
                panduan += 1;
            }
            if (File.Exists("N:\\X\\Start\\Start.bat"))
            {
                BLpanfu = "N";
                panduan += 1;
            }
            if (File.Exists("O:\\X\\Start\\Start.bat"))
            {
                BLpanfu = "O";
                panduan += 1;
            }
            if (File.Exists("P:\\X\\Start\\Start.bat"))
            {
                BLpanfu = "P";
                panduan += 1;
            }
            if (File.Exists("Q:\\X\\Start\\Start.bat"))
            {
                BLpanfu = "Q"; panduan += 1;
            }
            if (File.Exists("R:\\X\\Start\\Start.bat"))
            {
                BLpanfu = "R"; panduan += 1;
            }
            if (File.Exists("S:\\X\\Start\\Start.bat"))
            {
                BLpanfu = "S"; panduan += 1;
            }
            if (File.Exists("T:\\X\\Start\\Start.bat"))
            {
                BLpanfu = "T"; panduan += 1;
            }
            if (File.Exists("U:\\X\\Start\\Start.bat"))
            {
                BLpanfu = "U"; panduan += 1;
            }
            if (File.Exists("V:\\X\\Start\\Start.bat"))
            {
                BLpanfu = "V"; panduan += 1;
            }
            if (File.Exists("W:\\X\\Start\\Start.bat"))
            {
                BLpanfu = "W"; panduan += 1;
            }
            if (File.Exists("X:\\X\\Start\\Start.bat"))
            {
                BLpanfu = "X"; panduan += 1;
            }
            if (File.Exists("Y:\\X\\Start\\Start.bat"))
            {
                BLpanfu = "Y"; panduan += 1;
            }
            if (File.Exists("Z:\\X\\Start\\Start.bat"))
            {
                BLpanfu = "Z"; panduan += 1;
            }

            #endregion
            #region  写入查找到的文件位置后打开
            if (panduan == 1)
            {

                StreamWriter sW = new StreamWriter(CLzhixiangchangliang);//创建StreamWriter 类的实例,在软件所在目录创建文本 默认覆盖模式
                sW.WriteLine("@echo off " + "\n" + "start /max " + BLpanfu + ":\\X\\Start\\Start.bat");//向文件中写入cmd命令
                sW.Flush();     //刷新缓存          
                sW.Close(); //关闭流  
                System.Diagnostics.Process.Start(CLzhixiangchangliang);//打开入口链接




            }
            else if (panduan == 0)
            {
                MessageBox.Show("请联系开发者获取指向");


            }
            else
            {
                MessageBox.Show("目标重复，请联系管理员");
            }

            #endregion
        }

        private void 软件版本20210119ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://lzhttt.top");
        }

       

        private void 返回默认位置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region 确定程序出现位置
            int pingmukuandu = Screen.PrimaryScreen.Bounds.Width;//获取屏幕宽度 
            this.SetDesktopLocation(pingmukuandu - 400, 0);

            #endregion 
        }

        private void 编辑后重新载入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Application.Exit();
        }
        #endregion
       

       
        
    }
}
