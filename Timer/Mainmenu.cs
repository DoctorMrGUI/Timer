using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace Timer
{
    public partial class Mainmenu : Form
    {
        public Mainmenu()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) 
        {
            //加载UI图片资源
            string Path = Application.StartupPath.Substring(0, Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));
            Path += @"\close.png";//关闭默认按钮
            string Path2 = Application.StartupPath.Substring(0, Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));
            Path2 += @"\close2.png";//关闭鼠标悬空按钮
            string Path3 = Application.StartupPath.Substring(0, Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));
            Path3 += @"\small.png";//最小化默认按钮
            string Path4 = Application.StartupPath.Substring(0, Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));
            Path4 += @"\small2.png";//最小化鼠标悬空按钮
            string Path5 = Application.StartupPath.Substring(0, Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));
            Path4 += @"\cancel1.png";//取消鼠标悬空按钮
            string Path6 = Application.StartupPath.Substring(0, Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));
            Path4 += @"\cancel2.png";//取消默认按钮
            string Path7 = Application.StartupPath.Substring(0, Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));
            Path4 += @"\ok1.png";//启动鼠标悬空按钮
            string Path8 = Application.StartupPath.Substring(0, Application.StartupPath.Substring(0, Application.StartupPath.LastIndexOf("\\")).LastIndexOf("\\"));
            Path4 += @"\ok12.png";//启动默认按钮
            //使用UI图片
            Image Mimg = Image.FromFile(Path, true);
            imageList1.Images.Add(Mimg);
            Image Mimg2 = Image.FromFile(Path, true);
            imageList1.Images.Add(Mimg);
            Image Mimg3 = Image.FromFile(Path, true);
            imageList1.Images.Add(Mimg);
            Image Mimg4 = Image.FromFile(Path, true);
            imageList1.Images.Add(Mimg);
            Image Mimg5 = Image.FromFile(Path, true);
            imageList2.Images.Add(Mimg);
            Image Mimg6 = Image.FromFile(Path, true);
            imageList2.Images.Add(Mimg);
            Image Mimg7 = Image.FromFile(Path, true);
            imageList2.Images.Add(Mimg);
            Image Mimg8 = Image.FromFile(Path, true);
            imageList2.Images.Add(Mimg);
        }
        //关闭按钮点击关闭程序
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Application.Exit();
        }
        //鼠标悬空按钮，改变UI图片
        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = imageList1.Images[1];
        }
        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox2.BackgroundImage = imageList1.Images[1];
        }
        //鼠标悬空按钮，改变UI图片
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = imageList1.Images[0];
        }
        //最小化按钮点击
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        //鼠标悬空按钮，改变UI图片
        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.BackgroundImage = imageList1.Images[3];
        }
        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox3.BackgroundImage = imageList1.Images[3];
        }
        //鼠标离开按钮，改变UI图片
        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackgroundImage = imageList1.Images[2];
        }
        //鼠标悬空按钮，改变UI图片
        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.BackgroundImage = imageList2.Images[2];
        }
        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox4.BackgroundImage = imageList2.Images[2];
        }
        //鼠标悬空按钮，改变UI图片
        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            pictureBox5.BackgroundImage = imageList2.Images[0];
        }
        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox5.BackgroundImage = imageList2.Images[0];
        }
        //鼠标离开按钮，改变UI图片
        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.BackgroundImage = imageList2.Images[3];
        }
        //鼠标离开按钮，改变UI图片
        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.BackgroundImage = imageList2.Images[1];
        }

        public int StartX;//窗体预设坐标X
        public int StartY;//窗体预设坐标Y

        //鼠标按下左键拖动窗体，获取鼠标坐标
        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                StartX = e.X;
                StartY = e.Y;
            }
        }
        //鼠标按下左键拖动窗体，获取鼠标坐标
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                StartX = e.X;
                StartY = e.Y;
            }
        }
        //鼠标按下左键拖动窗体，获取鼠标坐标
        private void panel1_MouseDown(object sender, MouseEventArgs e)
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
        //鼠标移动，窗体移动
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - StartX;
                this.Top += e.Y - StartY;
            }
        }
        //鼠标移动，窗体移动
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - StartX;
                this.Top += e.Y - StartY;
            }
        }
        //帮助选项打开
        private void 如何使用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("（1）选择事件，时间，点击启动。" + "\n" + "（2）长按显示的文字可拖动窗体。" + "\n" + "（3）选中显示文字可打开右键菜单。" + "\n" + "（4）请勿随便点击“开机自启”按钮。" + "\n" + "（5）清除开机自启动请按“开机自启”按钮。");
        }
        //打开关于框
        private void 关于ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            About b = new About();
            b.ShowDialog();
        }
        //日期选中后显示选择的日期
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label7.Text = dateTimePicker1.Text;
        }
        //点击启动按钮
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //如果输入框有一个以上没有内容
            if ((textBox1.Text == string.Empty) || (label7.Text == string.Empty))
            {
                //提示输入
                MessageBox.Show("请选择时间并填写事件", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //否则，添加数据，关闭窗体
            else
            {
                string[] Timerdata = new string[] 
                { 
                    textBox1.Text.ToString(),//目标
                    dateTimePicker1.Value.Year.ToString(), //年
                    dateTimePicker1.Value.Month.ToString(),//月
                    dateTimePicker1.Value.Day.ToString(), //日
                    "300" , "0",//Timer窗口初始位置
                };
                //查找数据
                FileInfo finfo = new FileInfo("D:\\Timerdata.xml");
                //如果数据存在
                if (finfo.Exists)
                {
                    using (FileStream fs = new FileStream("D:\\Timerdata.xml", FileMode.Open, FileAccess.Read))
                    {
                        using (StreamReader sr = new StreamReader(fs))
                        {
                            sr.Close();
                            fs.Close();
                            File.Delete("D:\\Timerdata.xml");
                            System.IO.File.WriteAllLines("D:\\Timerdata.xml", Timerdata);
                            FileInfo finfo1 = new FileInfo("D:\\Timerdata.xml");
                            //把文件保存为隐藏
                            if (finfo.Exists)
                            {
                                finfo1.Attributes = FileAttributes.Hidden;
                            }
                            Form3 b = new Form3();
                            b.Show();
                            this.Visible = false;
                        }
                    }
                }
                else {
                    System.IO.File.WriteAllLines("D:\\Timerdata.xml", Timerdata);
                    FileInfo finfo2 = new FileInfo("D:\\Timerdata.xml");
                    //把文件保存为隐藏
                    if (finfo.Exists)
                    {
                        finfo2.Attributes = FileAttributes.Hidden;
                    }
                    Form3 b = new Form3();
                    b.Show();
                    this.Visible = false;
                }
            }
        }
        //返回Timer窗体
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form3 b = new Form3();
            b.Show();
            this.Visible = false;
        }
        //定义软件自启动名称
        public string KeyName = "Timer计时器";
        //自启动显示
        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (label7.Text == ""))
            {
                checkBox1.Visible = false;
            }
            else
            {
                checkBox1.Visible = true;
            }
        }
        //设置软件开机自启
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string strName = Application.ExecutablePath;
                if (checkBox1.Checked) //设置开机自启动  
                {
                    this.checkBox1.Checked = true;
                    if (!File.Exists(strName))//指定文件是否存在  
                        return;
                    Microsoft.Win32.RegistryKey Rkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    if (Rkey == null)
                    {
                        Rkey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                    }
                    Rkey.SetValue(KeyName, strName + " -s");//修改注册表，使程序开机时自动执行。
                }
                else
                {
                    //修改注册表，使程序开机时不自动执行。  
                    this.checkBox1.Checked = false;
                    RegistryKey Rkey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                    if (Rkey == null)
                    {
                        Rkey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                    }
                    Rkey.DeleteValue(KeyName, false);
                }
            }
            catch//没有权限会异常            
            {
                MessageBox.Show("请您使用管理员权限打开应用程序！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}