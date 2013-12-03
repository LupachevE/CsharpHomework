using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForm
{
    public partial class Form1 : Form
    {
        private ImageQuadrangle quadrangle;

        public Form1()
        {
            InitializeComponent();
            quadrangle = new ImageQuadrangle();
            textBox1.Text = "Let's start";
        }

        private void button_click(object sender, EventArgs e)
        {
            quadrangle.checkQuadrangle(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Refresh();
            textBox1.Text = quadrangle.controlMessage;
        }

        private void pictureBox1_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.Clear(Color.White);

            quadrangle.drawQuadrangle(e.Graphics);
        }
    }

    class ImageQuadrangle
    {
        private Point point1;
        private Point point2;
        private Point point3;
        private Point point4;
        private Random rand;

        //public String controlMessage;

        public String controlMessage = "";

        public void checkQuadrangle(int width, int height)
        {
            rand = new Random();
            point1 = new Point(rand.Next(width), rand.Next(height));
            point2 = new Point(rand.Next(width), rand.Next(height));
            point3 = new Point(rand.Next(width), rand.Next(height));
            point4 = new Point(rand.Next(width), rand.Next(height));
            controlMessage = Library.Geometry.IsParallelogramm(point1, point2, point3, point4) ? "It is parallelogramm" : "It is not parallelogramm";
        }

        public void drawQuadrangle(System.Drawing.Graphics gr)
        {
            Pen p = new Pen(Color.Black, 5);
            gr.DrawLine(p, point1, point2);
            gr.DrawLine(p, point2, point3);
            gr.DrawLine(p, point3, point4);
            gr.DrawLine(p, point4, point1);
            //gr.Dispose();
        }
    }
}
