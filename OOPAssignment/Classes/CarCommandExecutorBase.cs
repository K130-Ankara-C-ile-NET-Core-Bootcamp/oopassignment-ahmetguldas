using OOPAssignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment.Classes
{
    public class CarCommandBase
    {
        protected readonly ICarCommand CarCommand;

        public CarCommandBase(ICarCommand carCommand)
        {
            CarCommand = carCommand;
        }
    }
}
