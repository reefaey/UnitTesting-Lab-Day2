using CarAPI.Entities;
using CarAPI.Repositories_DAL;
using CarAPI.Services_BLL;
using CarFactoryAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarFactoryAPI.Repositories_DAL
{
    public class OwnerRepository : IOwnersRepository
    {
        private readonly FactoryContext context;

        public OwnerRepository(FactoryContext context)
        {
            this.context = context;
        }
        public bool AddOwner(Owner owner)
        {
            try
            {
                context.Owners.Add(owner);
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Owner> GetAllOwners()
        {
            return context.Owners.ToList();
        }

        public Owner GetOwnerById(int id)
        {
            return context.Owners.Include(o=>o.Car).SingleOrDefault(o => o.Id == id);
        }
    }
}
