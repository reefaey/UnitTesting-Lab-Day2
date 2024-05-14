using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarAPI.Entities
{

    public enum CarType
    {
        Audi,
        BMW
    }
    public class Car
    {
        public int Id { get; set; }
        [Display(Name = "Vehicle Identification Number")]
        public string VIN { get; set; }
        public CarType Type { get; set; }

        public double Velocity { get; set; }
        public double Price { get; set; }

        [ForeignKey("Owner")]
        public int? OwnerId { get; set; }
        public Owner Owner { get; set; }

        public Car(int id, CarType carType, double initialVelocity)
        {
            Id = id;
            Type = carType;
            Velocity = initialVelocity;
        }
        public Car()
        {

        }
    }
}