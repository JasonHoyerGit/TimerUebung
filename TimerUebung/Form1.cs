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
        Rectangle recSpieler = new Rectangle();
        List<Hindernis> alleHindernisse = new List<Hindernis>();
        int spawnZaehler = 0;
        int spawRate = 30;

        private void timerGame_Tick(object sender, EventArgs e)
        {
            if (spawnZaehler >= spawRate)
            {
                SpawnHindernis();
            }
            else
            {
                spawnZaehler++;
            }
            foreach (Hindernis hindernis in alleHindernisse)
            {
                hindernis.Move();
                Refresh();
            }
        }

        private void SpawnHindernis()
        {
            alleHindernisse.Add(
                new Hindernis(
                    new Rectangle(ClientSize.Width, 0, ClientSize.Width / 10, ClientSize.Height)));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            recSpieler = new Rectangle(0, ClientSize.Height / 2, ClientSize.Width / 20, ClientSize.Width / 20);

            timerGame.Interval = 10;
            timerGame.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            graphics.FillRectangle(greenBrush, recSpieler);
            foreach (Hindernis hindernis in alleHindernisse)
            {
                graphics.FillRectangle(greenBrush, hindernis.recHindernis);
            }
        }
    }
}
