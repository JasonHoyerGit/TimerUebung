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
            recHindernis = rectangle;
            this.movingSpeed = movingSpeed;
        }

        public Rectangle recHindernis;
        public int movingSpeed;

        public void Move()
        {
            recHindernis.X -= movingSpeed;
        }
    }
}
