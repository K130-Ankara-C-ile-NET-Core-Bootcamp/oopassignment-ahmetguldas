using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment.Structs
{
    public struct MovementFactor
    {
        public int XFactor;
        public int YFactor;

        public MovementFactor(int xFactor, int yFactor)
        {
            XFactor = xFactor;
            YFactor = yFactor;
        }
    }
}
