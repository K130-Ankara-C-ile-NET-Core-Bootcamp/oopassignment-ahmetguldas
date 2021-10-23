using OOPAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment.Classes
{
    public class CarInfo
    {
        public Guid CarId { get; set; }
        public Coordinates Coordinates { get; set; }
        public CarInfo(Guid carId, Coordinates coordinates)
        {
            CarId = carId;
            Coordinates = coordinates;
        }
    }
}
