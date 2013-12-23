using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Controls;

namespace MainForm
{
    public partial class MyForm : Form
    {
        private ImageQuadrangle quadrangle;


        public MyForm()
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            InitializeComponent();
            quadrangle = new ImageQuadrangle();

            ToolTip toolTip1 = new ToolTip();
            
            textBox1.Text = "Let's start";
            textBox2.Text = "First point";
            toolTip1.SetToolTip(textBox2, "Input X and Y of first point seperated with ',' and '.'");
            textBox3.Text = "Second point";
            toolTip1.SetToolTip(textBox3, "Input X and Y of second point seperated with ',' and '.'");            
            textBox4.Text = "Third point";
            toolTip1.SetToolTip(textBox4, "Input X and Y of third point seperated with ',' and '.'");
            textBox5.Text = "Fourth point";
            toolTip1.SetToolTip(textBox5, "Input X and Y of fourth point seperated with ',' and '.'");
            
        }
        private void button_click(object sender, EventArgs e)
        {
            quadrangle.checkQuadrangle(textBox2, textBox3, textBox4, textBox5);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

    class ImageQuadrangle
    {
        private Point point1;
        private Point point2;
        private Point point3;
        private Point point4;
        public String controlMessage = "";

        public int toIntFirst(string somestring)
        {
            return int.Parse(somestring.Split(',', '.')[0].Trim());
        }

        public int toIntSecond(string somestring)
        {
            return int.Parse(somestring.Split(',', '.')[1].Trim());
        }

        public void checkQuadrangle(TextBox textBox2, TextBox textBox3, TextBox textBox4, TextBox textBox5)
        {

            point1 = new Point((textBox2.Text.Equals("First point")) ? 0 : toIntFirst(textBox2.Text), (textBox2.Text.Equals("First point")) ? 0 : toIntSecond(textBox2.Text));
            point2 = new Point((textBox3.Text.Equals("Second point")) ? 0 : toIntFirst(textBox3.Text), (textBox3.Text.Equals("Second point")) ? 0 : toIntSecond(textBox3.Text));
            point3 = new Point((textBox4.Text.Equals("Third point")) ? 0 : toIntFirst(textBox4.Text), (textBox4.Text.Equals("Third point")) ? 0 : toIntSecond(textBox4.Text));
            point4 = new Point((textBox5.Text.Equals("Fourth point")) ? 0 : toIntFirst(textBox5.Text), (textBox5.Text.Equals("Fourth point")) ? 0 : toIntSecond(textBox5.Text));
            
            /*point1 = new Point(10, 10);
            point2 = new Point(50, 10);
            point3 = new Point(40, 40);
            point4 = new Point(0, 40);*/
            controlMessage = GeomLibrary.Geometry.IsParallelogramm(point1, point2, point3, point4) ? "It is parallelogramm" : "It is not parallelogramm";
        }

        public void drawQuadrangle(System.Drawing.Graphics gr)
        {
            Pen p = new Pen(Color.Black, 5);
            gr.DrawLine(p, point1, point2);
            gr.DrawLine(p, point2, point4);
            gr.DrawLine(p, point4, point3);
            gr.DrawLine(p, point3, point1);
            //gr.Dispose();
        }
    }
}
