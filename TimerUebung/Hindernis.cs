using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TimerUebung
{
    class Hindernis
    {
        public Hindernis(Rectangle rectangle, int movingSpeed = 5)
        {
            Random rnd = new Random();

            int positionluecke = rnd.Next(50, rectangle.Height - 50);
            recOben = rectangle;
            recUnten = rectangle;

            recOben.Height = positionluecke;
            recUnten.Y = positionluecke + 150;

            this.movingSpeed = movingSpeed;
        }

        public Rectangle recOben;
        public Rectangle recUnten;
        public int movingSpeed;

        public void Move()
        {
            recOben.X -= movingSpeed;
            recUnten.X -= movingSpeed;
        }
    }
}
