using System;
using System.Drawing;
using System.Windows.Forms;

namespace FormsPictureBox
{
    public partial class Form1 : Form
    {
        private bool leftMove, upMove;
        private int ball_x, ball_y;
        private int rad = 50;
        private Pen p = new Pen(Color.Lime);
        private SolidBrush fon = new SolidBrush(Color.Black); // фон для анимации
        private SolidBrush fig = new SolidBrush(Color.Aquamarine);
        private Graphics gr;
        private Random rand = new Random();
        private Timer animationTimer;


        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true; // включаем двойную буферизацию

            // инициализация таймера для анимации
            animationTimer = new Timer();
            animationTimer.Interval = 50; // интервал обновления
            animationTimer.Tick += Timer3_Tick;

            ball_x = pictureBox1.Width / 2;
            ball_y = pictureBox1.Height / 2;
        }

        // кнопка "Полетаем" для запуска анимации шарика
        private void button3_Click(object sender, EventArgs e)
        {
            // остановка других таймеров
            timer1.Stop();
            timer2.Stop();

            gr = pictureBox1.CreateGraphics();
            leftMove = true;
            upMove = true;
            fig = new SolidBrush(RandomColor());
            // запуск анимации
            animationTimer.Start();
        }

        // таймер для анимации шарика
        private void Timer3_Tick(object sender, EventArgs e)
        {
            // очистка предыдущего положения
            gr.Clear(Color.Black);

            // обновление координат
            if (leftMove)
            {
                ball_x += 10;
            }
            else
            {
                ball_x -= 10;
            }

            if (upMove)
            {
                ball_y += 10;
            }
            else
            {
                ball_y -= 10;
            }

            // проверка столкновений с границами
            if (ball_x <= rad) leftMove = true;
            if (ball_x >= pictureBox1.Width - rad) leftMove = false;
            if (ball_y <= rad) upMove = true;
            if (ball_y >= pictureBox1.Height - rad) upMove = false;

            // отрисовка шарика
            gr.FillEllipse(fig, ball_x - rad, ball_y - rad, 2 * rad, 2 * rad);
            gr.DrawEllipse(p, ball_x - rad, ball_y - rad, 2 * rad, 2 * rad);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gr = pictureBox1.CreateGraphics();
            timer1.Start();
            timer2.Stop();
            animationTimer.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //черный фон
            gr.Clear(Color.Black);

            for (int i = 0; i < 15; i++)
            {
                int rad = 40;
                int x = rand.Next(pictureBox1.Width - 2 * rad);
                int y = rand.Next(pictureBox1.Height - 2 * rad);

                using (var brush = new SolidBrush(RandomColor()))
                using (var pen = new Pen(Color.White)) // цвет обводки
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
            animationTimer.Stop();

            // черный фон
            gr.Clear(Color.Black);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int rad = rand.Next(10, 50);
            int x = rand.Next(pictureBox1.Width - 2 * rad);
            int y = rand.Next(pictureBox1.Height - 2 * rad);

            using (var brush = new SolidBrush(RandomColor()))
            using (var pen = new Pen(Color.White)) // цвет обводки
            {
                gr.FillEllipse(brush, x, y, 2 * rad, 2 * rad);
                gr.DrawEllipse(pen, x, y, 2 * rad, 2 * rad);
            }
        }
    }
}
