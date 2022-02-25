using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimerUebung
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SolidBrush greenBrush = new SolidBrush(Color.LightGreen);
        SolidBrush blueBrush = new SolidBrush(Color.LightBlue);
        Rectangle recNachRechts = new Rectangle();
        Rectangle recNachLinks = new Rectangle();

        private void timerRechteck_Tick(object sender, EventArgs e)
        {
            recNachRechts.X+=5;
            if (recNachRechts.Right >= ClientSize.Width)
            {
                timerNachRechts.Stop();
            }
        }
        private void timerNachLinks_Tick(object sender, EventArgs e)
        {
            recNachLinks.X -= 5;
            Refresh();
            if (recNachLinks.Left <= 0)
            {
                timerNachLinks.Stop();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            recNachRechts = new Rectangle(0,0,ClientSize.Width/10, ClientSize.Height);

            recNachLinks = new Rectangle(ClientSize.Width, 0, ClientSize.Width / 10, ClientSize.Height);

            timerNachRechts.Interval = 10;
            timerNachLinks.Interval = 10;
            timerNachRechts.Start();
            timerNachLinks.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            graphics.FillRectangle(greenBrush, recNachRechts);
            graphics.FillRectangle(blueBrush, recNachLinks);
        }
    }
}
