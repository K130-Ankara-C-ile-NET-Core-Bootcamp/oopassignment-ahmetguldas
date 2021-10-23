using OOPAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment.Interfaces
{
    public interface ISurface
    {
        public long Width { get; }
        public long Height { get; }
        public bool IsCoordinatesInBounds(Coordinates coordinates);
    }
}
