using CarFactoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryLibaray_test
{
    public class ToyotaTests
    {
        [Fact]
        public void IsStopped_velocity0_true()
        {
            // Arrange
            Toyota toyota = new Toyota();
            toyota.velocity = 0;

            // Act
            bool result = toyota.IsStopped();

            // Boolean Asserts
            Assert.True(result);
        }
        [Fact]
        public void IsStopped_velocity10_false()
        {
            // Arrange
            Toyota toyota = new Toyota();
            toyota.velocity = 10;

            // Act
            bool result = toyota.IsStopped();

            // Boolean Asserts
            Assert.False(result);
        }

        [Fact]
        public void IncreaseVelocity_valocity10Add20_30()
        {
            // Arrange
            Toyota toyota = new Toyota();
            toyota.velocity = 10;
            double AddedVelocitoy = 20;

            // Act
            toyota.IncreaseVelocity(AddedVelocitoy);

            // Equality Assert
            Assert.Equal(30, toyota.velocity);
            Assert.NotEqual(10, toyota.velocity);

            // Numeric Asserts
            Assert.False(toyota.velocity < 10);

            Assert.InRange(toyota.velocity, 20, 30);
            Assert.NotInRange(toyota.velocity, 10, 20);
        }

        [Fact]
        public void GetDirection_DirectionForward_Forward()
        {
            // Arrange
            Toyota toyota = new Toyota();
            toyota.drivingMode = DrivingMode.Forward;

            // Act
            string result = toyota.GetDirection();

            // string Asserts
            //Assert.Equal(DrivingMode.Forward.ToString(), result);

            //Assert.StartsWith("F", result);
            //Assert.EndsWith("rd", result);

            Assert.Contains("wa", result);
            Assert.DoesNotContain("zx", result);

            //Assert.Matches("regex", result);
            //Assert.DoesNotMatch("regex", result);
        }

        [Fact]
        public void GetMyCar_callFunction_SameCar()
        {
            // Arrange
            Toyota toyota = new Toyota();
            Toyota t2 = new Toyota();

            // Act
            Car car = toyota.GetMyCar();

            // Refrence Assert
            Assert.Same(toyota, car);
            Assert.NotSame(t2, car);
        }
    }
}
