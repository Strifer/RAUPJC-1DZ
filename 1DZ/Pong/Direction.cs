using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Direction
    {

        public static readonly Direction NW = new Direction(-1, -1);
        public static readonly Direction NE = new Direction(1, -1);
        public static readonly Direction SW = new Direction(-1, 1);
        public static readonly Direction SE = new Direction(1, 1);

        private float x;
        private float y;

        public float X
        {
            get
            {
                return x;
            }
            private set
            {
                this.x = value;
            }
        }



        public float Y
        {
            get
            {
                return y;
            }

            private set
            {
                this.y = value;
            }
        }


        private Direction(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static Direction operator *(Direction d1, Direction d2)
        {
            return new Direction(d1.X * d2.X, d1.Y * d2.Y);
        }

        public static Direction operator *(Direction d1, float scalar)
        {
            return new Direction(d1.X * scalar, d1.Y * scalar);
        }
    }
}
