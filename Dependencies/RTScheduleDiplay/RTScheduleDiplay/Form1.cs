using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTScheduleDiplay
{
    public partial class Form1 : Form
    {
        DrawSky.Easel easel = null;

        ToolTip _toolTip;

        Timer _animationTimer = new Timer();
        int _animationTimerStep;
        int _totalAnimationTimerSteps;

        public Form1()
        {
            InitializeComponent();
            _toolTip = new ToolTip();
            DrawSky();
            _animationTimer.Interval = 100;
            _animationTimer.Tick += new EventHandler(AnimationTick);
        }

        public void DrawSky()
        {
            try
            {
                easel = new DrawSky.Easel(pictureBox1.Size);
                easel.dt = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day, dateTimePicker2.Value.Hour, dateTimePicker2.Value.Minute, 0);

                int minutes = 0;
                if (int.TryParse(textBox6.Text, out minutes))
                {

                }
                int stepSize = 0;
                if (int.TryParse(textBox7.Text, out _totalAnimationTimerSteps))
                {
                    stepSize = minutes / _totalAnimationTimerSteps;
                }
                if (_animationTimerStep > 0 && stepSize > 0)
                {
                    easel.dt = easel.dt.AddMinutes(_animationTimerStep * stepSize);
                }
                easel.dt = easel.dt.ToUniversalTime();
                float f;
                if (float.TryParse(textBox1.Text, out f))
                {
                    easel.latitude = f;
                }
                if (float.TryParse(textBox2.Text, out f))
                {
                    easel.longitude = f;
                }
                int alt;
                if (int.TryParse(textBox3.Text, out alt))
                {
                    easel.altitude = alt;
                }

                if (float.TryParse(textBox4.Text, out f))
                {
                    easel.targetRA = f;
                }
                if (float.TryParse(textBox5.Text, out f))
                {
                    easel.targetDec = f;
                }
                easel.coordinates = checkBox1.Checked;

                easel.MakeNewEasel();
                pictureBox1.Image = easel.sky;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Point pt = new Point(e.X, e.Y);
            if (easel.starsInSky.ContainsKey(pt))
            {
                _toolTip.Show($"{easel.starsInSky[pt].Name}", pictureBox1);
            }
            //else
            //{
            //    _toolTip.Show($"{e.X}, {180 - e.Y}", pictureBox1);
            //}
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DrawSky();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DrawSky();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            DrawSky();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Start animation
            _animationTimerStep = 1;
            _animationTimer.Start();
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void AnimationTick(object sender, System.EventArgs e)
        {
            _animationTimerStep++;
            DrawSky();
            if (_animationTimerStep >= _totalAnimationTimerSteps)
            {
                _animationTimer.Stop();
                button1.Enabled = true;
                button2.Enabled = false;
                _animationTimerStep = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Stop animation
            _animationTimer.Stop();
            button1.Enabled = true;
            button2.Enabled = false;
        }
    }
}
