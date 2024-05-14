using CarAPI.Entities;

namespace CarAPI.Repositories_DAL
{
    public class CarsStaticRepository : ICarsRepository
    {

        private readonly IInMemoryContext _context;

        public CarsStaticRepository(IInMemoryContext inMemoryContext)
        {
            _context = inMemoryContext;
        }

        public List<Car> GetAllCars()
        {
            // Get cars from dependency
            // Logic
            return _context.Cars;
        }

        public Car GetCarById(int id)
        {
            throw new Exception();
            return _context.Cars.FirstOrDefault(c => c.Id == id);
        }

        public bool AddCar(Car car)
        {
            _context.Cars.Add(car);
            return true;
        }

        public bool Remove(int carId)
        {
            var car = _context.Cars.Find(c => c.Id == carId);
            return _context.Cars.Remove(car);
        }

        public bool AssignToOwner(int carId, int OwnerId)
        {
            var car = _context.Cars.Find(c => c.Id == carId);
            if (car == null) return false;

            car.OwnerId = OwnerId;

            var owner = _context.Owners.Find(o => o.Id == OwnerId);
            if (owner == null) return false;

            car.Owner = owner;
            owner.Car = car;

            return true;
        }
    }
}