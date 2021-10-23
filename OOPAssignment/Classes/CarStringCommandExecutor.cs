using OOPAssignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment.Classes
{
    public class CarStringCommand : CarCommandBase, IStringCommand
    {
        public CarStringCommand(ICarCommand carCommand) : base(carCommand)
        {
            //ExecuteCommand(carCommand.ToString());
        }

        public void ExecuteCommand(string commandObject)
        {
            if (string.IsNullOrEmpty(commandObject))
            {
                throw new Exception();
            }

            foreach (char item in commandObject)
            {
                if (item == 'L')
                {
                    CarCommand.TurnLeft();
                }
                else if (item == 'R')
                {
                    CarCommand.TurnRight();
                }
                else if (item == 'M')
                {
                    CarCommand.Move();
                }
                else
                {
                    throw new Exception();
                }
            }
        }
    }
}
