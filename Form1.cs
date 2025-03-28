using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace FormsPictureBox
{
    public partial class Form1 : Form
    {
        //Инициализация переменных и ресурсов
        private Graphics gr;
        private Random rand = new Random();
        private SolidBrush fonBrush = new SolidBrush(Color.BlanchedAlmond);

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //gr.Clear(fonBrush.Color);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            gr = pictureBox1.CreateGraphics();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gr.Clear(fonBrush.Color);

            for (int i = 0; i < 15; i++)
            {
                int rad = 40;
                int x = rand.Next(pictureBox1.Width - 2 * rad);
                int y = rand.Next(pictureBox1.Height - 2 * rad);

                using (var brush = new SolidBrush(RandomColor()))
                using (var pen = new Pen(fonBrush.Color)) //new Pen(RandomColor()))
                {
                    gr.FillEllipse(brush, x, y, 2 * rad, 2 * rad);
                    gr.DrawEllipse(pen, x, y, 2 * rad, 2 * rad);
                }
            }
        }

        private Color RandomColor()
        {
            return Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            gr = pictureBox1.CreateGraphics();
            timer2.Start();

            gr.Clear(fonBrush.Color);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            int rad = rand.Next(10, 50);
            int x = rand.Next(pictureBox1.Width - 2 * rad);
            int y = rand.Next(pictureBox1.Height - 2 * rad);

            using (var brush = new SolidBrush(RandomColor()))
            using (var pen = new Pen(RandomColor()))
            {
                gr.FillEllipse(brush, x, y, 2 * rad, 2 * rad);
                gr.DrawEllipse(pen, x, y, 2 * rad, 2 * rad);
            }
        }

    }   
}
