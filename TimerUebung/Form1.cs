using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimerUebung.Properties;

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
        Hindernis recHindernis;
        bool moveUp;
        int movingSpeed = 5;
        int score = 0;
        Bitmap spieler;

        private void timerGame_Tick(object sender, EventArgs e)
        {
            ResetHindernis();
            KollisionMitSpieler();
            recHindernis.Move();
            PlayerMovement();
            Refresh();
        }

        private void ResetHindernis()
        {
            if (recHindernis.recOben.Right < 0 || recHindernis.recUnten.Right<0)
            {
                SpawnHindernis();
                score++;
            }
        }

        private void PlayerMovement()
        {
            if (moveUp)
            {
                recSpieler.Y -= movingSpeed;
            }
            else
            {
                recSpieler.Y += movingSpeed;
                if (recSpieler.Bottom > ClientSize.Height)
                {
                    recSpieler.Y = ClientSize.Height - recSpieler.Height;
                }
            }
        }

        private void KollisionMitSpieler()
        {
            if (recSpieler.IntersectsWith(recHindernis.recOben) || recSpieler.IntersectsWith(recHindernis.recUnten))
            {
                timerGame.Stop();
            }
        }

        private void SpawnHindernis()
        {
             recHindernis = new Hindernis(
                 new Rectangle(ClientSize.Width, 0, ClientSize.Width / 10, ClientSize.Height));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;

            spieler = Resources.Fuchs;

            recSpieler = new Rectangle(50, ClientSize.Height / 2, ClientSize.Width / 20, ClientSize.Width / 20);
            SpawnHindernis();

            timerGame.Interval = 10;
            timerGame.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            graphics.DrawImage(spieler, recSpieler);
            graphics.FillRectangle(greenBrush, recHindernis.recOben);
            graphics.FillRectangle(greenBrush, recHindernis.recUnten);
            graphics.DrawString("Score: " + score.ToString(), new Font("Arial", 20), new SolidBrush(Color.Black), 0, 0);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                moveUp = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                moveUp = false;
            }
        }
    }
}
