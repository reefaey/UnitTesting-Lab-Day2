using CarAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CarAPI.Repositories_DAL
{
    public class OwnersStaticRepository : IOwnersRepository
    {

        private readonly IInMemoryContext _context;

        public OwnersStaticRepository(IInMemoryContext inMemoryContext)
        {
            _context = inMemoryContext;
        }

        public List<Owner> GetAllOwners()
        {
            return _context.Owners;
        }

        public Owner GetOwnerById(int id)
        {
            return _context.Owners.FirstOrDefault(o => o.Id == id);
        }

        public bool AddOwner(Owner owner)
        {
            _context.Owners.Add(owner);
            return true;
        }

    }
}