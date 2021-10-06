using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OOPAssignment.Test
{
    [TestClass]
    public class CarTest
    {
        [TestMethod]
        public void ExecuteCommand_Should_TurnLeft()
        {
            // Arrange
            Surface surface = new(width: 5, height: 5);

            Car car = new(coordinates: new Coordinates(x: 1, y: 2), direction: Direction.N, surface: surface);

            car.Attach(surface);

            IStringCommand commandExecutor = new CarStringCommandExecutor(car);

            // Act
            commandExecutor.ExecuteCommand("L");

            // Assert
            Assert.AreEqual(Direction.W, car.Direction);
        }

        [TestMethod]
        public void ExecuteCommand_Should_TurnRight()
        {
            // Arrange
            Surface surface = new(width: 5, height: 5);

            Car car = new(coordinates: new Coordinates(x: 1, y: 2), direction: Direction.N, surface: surface);

            car.Attach(surface);

            IStringCommand commandExecutor = new CarStringCommandExecutor(car);

            // Act
            commandExecutor.ExecuteCommand("R");

            // Assert
            Assert.AreEqual(Direction.E, car.Direction);
        }

        [TestMethod]
        public void ExecuteCommand_Should_Move()
        {
            // Arrange
            Surface surface = new(width: 5, height: 5);

            Car car = new(coordinates: new Coordinates(x: 1, y: 2), direction: Direction.N, surface: surface);

            car.Attach(surface);

            IStringCommand commandExecutor = new CarStringCommandExecutor(car);

            // Act
            commandExecutor.ExecuteCommand("M");

            // Assert
            Assert.AreEqual("1 3", string.Concat(car.Coordinates.X, " ", car.Coordinates.Y));
        }

        [TestMethod]
        public void ExecuteCommand_BoundaryExceeded_ThrowsException()
        {
            // Arrange
            Surface surface = new(width: 5, height: 5);

            Car car = new(coordinates: new Coordinates(x: 5, y: 5), direction: Direction.N, surface: surface);

            car.Attach(surface);

            IStringCommand commandExecutor = new CarStringCommandExecutor(car);

            // Act
            void action() => commandExecutor.ExecuteCommand("M");

            // Assert
            Assert.ThrowsException<Exception>(action);
        }

        [TestMethod]
        public void ExecuteCommand_CollidedAnotherCar_ThrowsException()
        {
            // Arrange
            Surface surface = new(width: 5, height: 5);

            Car car1 = new(coordinates: new Coordinates(x: 1, y: 2), direction: Direction.N, surface: surface);

            Car car2 = new(coordinates: new Coordinates(x: 1, y: 1), direction: Direction.N, surface: surface);

            car1.Attach(surface);

            car2.Attach(surface);

            IStringCommand commandExecutor = new CarStringCommandExecutor(car2);

            // Act
            void action() => commandExecutor.ExecuteCommand("M");

            // Assert
            Assert.ThrowsException<Exception>(action);
        }
    }
}
