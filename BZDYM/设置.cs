using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BZD
{
    public partial class 设置 : Form
    {
        public 设置()
        {
            InitializeComponent();
        }

        private void 设置_Load(object sender, EventArgs e)
        {//设置窗口启动时：
            domainUpDown1.Text = Settings1.Default.waizai窗口有焦点时透明度.ToString();//读取窗口透明度写入面板
            domainUpDown2.Text = Settings1.Default.waizai窗口无焦点时透明度.ToString();//读取窗口透明度写入面板
            
            checkBox2.Checked = Settings1.Default.窗口失去焦点是否自动缩放;//读取窗口失去焦点是否自动缩放配置数据
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings1.Default.waizai窗口有焦点时透明度 = Convert.ToSingle(domainUpDown1.Text);
            Settings1.Default.waizai窗口无焦点时透明度 = Convert.ToSingle(domainUpDown2.Text);
           
            Settings1.Default.窗口失去焦点是否自动缩放 = checkBox2.Checked;





            Settings1.Default.Save();//保存配置
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            #region 引用cmd执行命令
            /*
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";       //设定程序名
             p.StartInfo.UseShellExecute = false;        //关闭Shell的使用
            p.StartInfo.RedirectStandardInput = true;   //重定向标准输入
            p.StartInfo.RedirectStandardOutput = true;  //重定向标准输出
            p.StartInfo.RedirectStandardError = true;   //重定向错误输出
            p.StartInfo.CreateNoWindow = true;  //设置不显示窗口
            p.Start();  //启动进程
            p.StandardInput.WriteLine("cd c:\\");
          
            p.StandardInput.WriteLine("cd %%USERPROFILE%%\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup");//输入要执行的命令
        
            p.StandardInput.WriteLine("explorer %cd%");//cd进目录后用资源管理器打开
           
            p.StandardInput.WriteLine("exit");//退出
            */

            /*
            string output = null;
            Process p = new Process();//创建进程对象 
            p.StartInfo.FileName = "cmd.exe";//设定需要执行的命令 
            // startInfo.Arguments = "/C " + command;//“/C”表示执行完命令后马上退出  
            p.StartInfo.UseShellExecute = false;//不使用系统外壳程序启动 
            p.StartInfo.RedirectStandardInput = true;//可以重定向输入  
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = false;//不创建窗口 
            p.Start();
            // string comStr = comd1 + "&" + comd2 + "&" + comd3;
            p.StandardInput.WriteLine("c:");
            p.StandardInput.WriteLine("cd %%USERPROFILE%%\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup");
            p.StandardInput.WriteLine("explorer %cd%");
            //  output = p.StandardOutput.ReadToEnd();
            if (p != null)
            {
                p.Close();
            }
            // return output;
            */
            #endregion

            String text = "%USERPROFILE%\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup";
            Clipboard.SetDataObject(text);//复制到粘贴板


            MessageBox.Show("已复制到粘贴板，在资源管理器中复制进入");

            #region 引用打开资源管理器
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";       //设定程序名
            p.StartInfo.UseShellExecute = false;        //关闭Shell的使用
            p.StartInfo.RedirectStandardInput = true;   //重定向标准输入
            p.StartInfo.RedirectStandardOutput = true;  //重定向标准输出
            p.StartInfo.RedirectStandardError = true;   //重定向错误输出
            p.StartInfo.CreateNoWindow = true;  //设置不显示窗口
            p.Start();  //启动进程
            p.StandardInput.WriteLine("explorer.exe");//输入要执行的命令
            p.StandardInput.WriteLine("exit");//退出
            #endregion


        }

        
    }
}
