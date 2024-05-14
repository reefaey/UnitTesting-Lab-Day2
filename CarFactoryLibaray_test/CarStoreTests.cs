using CarFactoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryLibaray_test
{
    public class CarStoreTests
    {
        [Fact]
        public void AddCar_AddToyota_ListContainOneCar()
        {
            // Arrange
            CarStore carStore = new CarStore();
            Toyota toyota = new Toyota();

            // Act
            carStore.AddCar(toyota);

            // Collection Asserts
            //Assert.Empty()
            Assert.NotEmpty(carStore.cars);


            // value Equality => Equals => Car
            Assert.Contains<Car>(toyota, carStore.cars);
            Assert.Contains<Car>(new BMW(), carStore.cars);
            Assert.DoesNotContain<Car>(new BMW() { velocity=10}, carStore.cars);
            //Assert.DoesNotContain<Car>(new BMW(), carStore.cars);

            Assert.Contains<Car>(carStore.cars, (car) => car.drivingMode == DrivingMode.Stopped);
        }
    }
}
