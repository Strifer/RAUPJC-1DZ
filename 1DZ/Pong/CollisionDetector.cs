using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class CollisionDetector
    {
        public static bool Overlaps(IPhysicalObject2D a, IPhysicalObject2D b)
        {
            Rectangle recA = new Rectangle(Convert.ToInt32(a.X), Convert.ToInt32(a.Y), a.Width, a.Height);
            Rectangle recB = new Rectangle(Convert.ToInt32(b.X), Convert.ToInt32(b.Y), b.Width, b.Height);
            return recA.Intersects(recB);
            
        }
    }
}
