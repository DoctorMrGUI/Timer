using System;
using System.Drawing;
using System.Windows.Forms;

namespace Timer
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }
        //点击确定关闭关于窗体
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        //鼠标悬空按钮，改变UI图片
        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            pictureBox5.BackgroundImage = Properties.Resources.enter2;
        }
        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox5.BackgroundImage = Properties.Resources.enter2;
        }
        //鼠标离开按钮，改变UI图片
        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.BackgroundImage = Properties.Resources.enter1;
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
        //鼠标移动，窗体移动
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - StartX;
                this.Top += e.Y - StartY;
            }
        }
    }
}
