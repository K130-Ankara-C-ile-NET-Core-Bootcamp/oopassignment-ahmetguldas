using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OOPAssignment.Test
{
    [TestClass]
    public class SurfaceTest
    {
        [TestMethod]
        public void Update_Should_AddOrUpdate()
        {
            // Arrange
            Surface surface = new(width: 5, height: 5);

            CarInfo carInfo1 = new CarInfo(Guid.NewGuid(), new Coordinates(0, 0));

            CarInfo carInfo2 = new CarInfo(Guid.NewGuid(), new Coordinates(1, 1));

            // Act
            surface.Update(carInfo1);

            surface.Update(carInfo2);

            surface.Update(carInfo1);

            // Assert
            Assert.AreEqual(surface.GetObservables().Count, 2, "Surface halihazırda takip ettiği araçları tekrar takip etmek yerine konum bilgilerini güncellemeli.");
        }

        [TestMethod]
        public void GetObservables_Should_ReturnNewListReference()
        {
            // Arrange
            Surface surface = new(width: 5, height: 5);

            CarInfo carInfo1 = new CarInfo(Guid.NewGuid(), new Coordinates(0, 0));

            CarInfo carInfo2 = new CarInfo(Guid.NewGuid(), new Coordinates(1, 1));

            // Act
            surface.Update(carInfo1);

            List<CarInfo> observableCars = surface.GetObservables();

            observableCars.Add(carInfo2);

            // Assert
            Assert.AreEqual(surface.GetObservables().Count, 1, "GetObservables yeni bir liste referansı dönmeli. Aksi takdirde yanlışlıkla Surface class'ı dışından manipüle edilebilir.");
        }
    }
}
