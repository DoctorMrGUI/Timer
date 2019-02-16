using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Timer
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public int StartX;//窗体预设坐标X
        public int StartY;//窗体预设坐标Y    
        //鼠标按下左键拖动窗体，获取鼠标坐标
        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                StartX = e.X;
                StartY = e.Y;
            }
        }
        //鼠标移动，窗体移动
        private void Form3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - StartX;
                this.Top += e.Y - StartY;
            }
        }
        //鼠标按下左键拖动窗体，获取鼠标坐标
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                StartX = e.X;
                StartY = e.Y;
            }
        }
        //鼠标移动，窗体移动
        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - StartX;
                this.Top += e.Y - StartY;
            } 
        }
        //鼠标按下左键拖动窗体，获取鼠标坐标
        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                StartX = e.X;
                StartY = e.Y;
            }
        }
        //鼠标移动，窗体移动
        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - StartX;
                this.Top += e.Y - StartY;
            }           
        }
        //通过数据设置窗体位置
        private void Form3_Load(object sender, EventArgs e)
        {
            //背景透明
            this.BackgroundImage = null;
            //查找数据
            FileInfo finfo = new FileInfo("D:\\Timerdata.xml");
            //如果数据存在
            if (finfo.Exists)
            {
                using (FileStream fs = new FileStream("D:\\Timerdata.xml", FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        //设置窗体坐标
                        string[] str = File.ReadAllLines(@"D:\\Timerdata.xml", Encoding.Default);
                        if (str.Length == 0)
                        {
                            label1.Text = "数据丢失！" + "\n" + "请重新设置！";
                            sr.Close();
                            fs.Close();
                            File.Delete("D:\\Timerdata.xml");
                        }
                        else {
                            int X1; int Y1; X1 = int.Parse(str[4]); Y1 = int.Parse(str[5]);
                            this.Location = new Point(X1, Y1);
                            sr.Close();
                            fs.Close();
                        }
                    }
                }
            }
            //否则报错
            else 
            {
                label1.Text = "数据不存在！"  + "\n" + "请重新设置！" ;
            }
            int a = label1.Width;
            this.Width = a - 10;
        }
        //通过数据设置倒计时天数
        private void timer1_Tick(object sender, EventArgs e)
        {
            //查找数据
            FileInfo finfo = new FileInfo("D:\\Timerdata.xml");
            //如果数据存在
            if (finfo.Exists)
            {
                using (FileStream fs = new FileStream("D:\\Timerdata.xml", FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string[] str = File.ReadAllLines(@"D:\\Timerdata.xml", Encoding.Default);
                        int s1 = 0;
                        int s2 = 0;
                        int s3 = 0;
                        s1 = int.Parse(str[1]);
                        s2 = int.Parse(str[2]);
                        s3 = int.Parse(str[3]);
                        //日期做差
                        DateTime d2 = new DateTime(s1, s2, s3, 0, 0, 0);
                        DateTime d1 = DateTime.Now;
                        TimeSpan d3 = d2.Subtract(d1);
                        //如果计时小于0,结束倒计时
                        if ((int.Parse(d3.Days.ToString()) <= 0) && ((int.Parse(d3.Hours.ToString()) < 0) || (int.Parse(d3.Hours.ToString()) < 0) || (int.Parse(d3.Seconds.ToString()) < 0)))
                        {
                            label1.Text = "倒计时结束" + "\n" + "请重新设置！";
                        }
                        //如果计时大于等于0,继续倒计时
                        else
                        {
                            label1.Text = "距离" + sr.ReadLine() + "还有：" + "\n"
                            + d3.Days.ToString() + "天"
                            + d3.Hours.ToString() + "时"
                            + d3.Minutes.ToString() + "分"
                            + d3.Seconds.ToString() + "秒";
                        }
                        sr.Close();
                        fs.Close();
                    }
                }
            }
            //否则报错
            else 
            {
                label1.Text = "数据不存在！" +"\n" + "请重新设置！";
            }
            int a = label1.Width;
            this.Width = a-10;
        }
        //保存窗体位置
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            //查找数据
            FileInfo finfo = new FileInfo("D:\\Timerdata.xml");
            //如果数据存在
            if (finfo.Exists)
            {
                using (FileStream fs = new FileStream("D:\\Timerdata.xml", FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        //保存窗体坐标
                        string[] str = File.ReadAllLines(@"D:\\Timerdata.xml", Encoding.Default);
                        int X1; int Y1;
                        X1 = this.Location.X;
                        Y1 = this.Location.Y;
                        string[] Timerdata = new string[] { sr.ReadLine(), str[1], str[2], str[3], "" + X1, "" + Y1, };
                        sr.Close();
                        fs.Close();
                        //把源文件取消隐藏
                        finfo.Attributes = FileAttributes.Normal;
                        //保存
                        System.IO.File.WriteAllLines("D:\\Timerdata.xml", Timerdata);
                        //把文件隐藏
                        FileInfo finfo2 = new FileInfo("D:\\Timerdata.xml");
                        if (finfo.Exists)
                        {
                            finfo2.Attributes = FileAttributes.Hidden;
                        }
                    }                        
                }
            }
        }
        //点击右键菜单退出程序选项
        private void 退出程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //点击右键菜单重新设置选项，打开Mainmenu窗体
        private void 重新设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mainmenu a = new Mainmenu();
            a.Show();
            this.Visible = false;
        }
        //点击右键菜单关于选项，打开About窗体
        private void 关于ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            About b = new About();
            b.ShowDialog();
        }
        //帮助选项打开
        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("（1）选择事件，时间，点击启动。" + "\n" + "（2）长按显示的文字可拖动窗体。" + "\n" + "（3）选中显示文字可打开右键菜单。" + "\n" + "（4）请勿随便点击“开机自启”按钮。" + "\n" + "（5）清除开机自启动请按“开机自启”按钮。");
        }
        //辅助按钮
        //private void word打不开ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    string path = ("C:\\Users\\Administrator\\AppData\\Roaming\\Microsoft\\Templates");
        //    if (Directory.Exists(path))
        //    {
        //        System.IO.Directory.Delete("C:\\Users\\Administrator\\AppData\\Roaming\\Microsoft\\Templates",true);
        //        MessageBox.Show("相关文件夹（文件）已删除，Word文档可以正常启动！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    else
        //    {
        //        MessageBox.Show("找不到路径！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //} 
    }
}
