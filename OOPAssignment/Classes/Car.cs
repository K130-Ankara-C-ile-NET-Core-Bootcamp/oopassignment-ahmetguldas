using OOPAssignment.Interfaces;
using OOPAssignment.Enums;
using OOPAssignment.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment.Classes
{
    public class Car : ICarCommand, Interfaces.IObservable<CarInfo>
    {
        public Guid Id { get; set; }
        public Coordinates Coordinates;

        public Direction Direction;

        public ISurface Surface;

        private Interfaces.IObserver<CarInfo> Observer { get; set; }

        public void Attach(Interfaces.IObserver<CarInfo> observer)
        {
            Observer = observer;
            Notify();
        }

        public void Move()
        {
            switch (Direction)
            {
                case Direction.N:
                    Coordinates.Y++;
                    break;
                case Direction.S:
                    Coordinates.Y--;
                    break;
                case Direction.E:
                    Coordinates.X++;
                    break;
                case Direction.W:
                    Coordinates.X--;
                    break;
            }
            if (Surface.IsCoordinatesInBounds(Coordinates) == false)
            {
                throw new Exception();
            }
            Notify();


        }

        public void Notify()
        {
            Observer.Update(new CarInfo(Id, Coordinates));
        }

        public void TurnLeft()
        {
            switch (Direction)
            {
                case Direction.N:
                    Direction = Direction.W;
                    break;
                case Direction.S:
                    Direction = Direction.E;
                    break;
                case Direction.E:
                    Direction = Direction.N;
                    break;
                case Direction.W:
                    Direction = Direction.S;
                    break;

            }
        }

        public void TurnRight()
        {
            switch (Direction)
            {
                case Direction.N:
                    Direction = Direction.E;
                    break;
                case Direction.S:
                    Direction = Direction.W;
                    break;
                case Direction.E:
                    Direction = Direction.S;
                    break;
                case Direction.W:
                    Direction = Direction.N;
                    break;
            }
        }

        public Car(Coordinates coordinates, Direction direction, ISurface surface)
        {
            Coordinates = coordinates;
            Direction = direction;
            Surface = surface;
        }
    }
}
