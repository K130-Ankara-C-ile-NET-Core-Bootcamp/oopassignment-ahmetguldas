using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OOPAssignment.Test
{
    [TestClass]
    public class CarStringCommandExecutorTest
    {
        [TestMethod]
        public void ExecuteCommand_NullOrEmptyCommand_ThrowsException()
        {
            // Arrange
            Car car = new Car(new Coordinates(), Direction.N, null);

            CarStringCommandExecutor commandExecutor = new CarStringCommandExecutor(car);

            // Act
            void actionNull() => commandExecutor.ExecuteCommand(null);

            void actionEmptyString() => commandExecutor.ExecuteCommand(string.Empty);

            // Assert
            Assert.ThrowsException<Exception>(actionNull);

            Assert.ThrowsException<Exception>(actionEmptyString);
        }

        [TestMethod]
        public void ExecuteCommand_WrongCommand_ThrowsException()
        {
            // Arrange
            Car car = new Car(new Coordinates(), Direction.N, null);

            CarStringCommandExecutor commandExecutor = new CarStringCommandExecutor(car);

            // Act
            void actionNull() => commandExecutor.ExecuteCommand("X");

            // Assert
            Assert.ThrowsException<Exception>(actionNull);
        }
    }
}
