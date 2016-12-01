using OdeToFood.Entities;
using System.Collections.Generic;
using System;
using System.Linq;

namespace OdeToFood.Services
{
    public interface IResturantData
    {
        IEnumerable<Resturant> GetAll();
        Resturant Get(int id);
        Resturant Add(Resturant _newResturant);
    }

    public class SqlResturantData : IResturantData
    {
        private OdeToFoodDbContext _context;

        public SqlResturantData(OdeToFoodDbContext context)
        {
            _context = context;
        }

        public Resturant Add(Resturant newResturant)
        {
            _context.Add(newResturant);
            _context.SaveChanges();
            return newResturant;
        }

        public Resturant Get(int id)
        {
            return _context.Resturants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Resturant> GetAll()
        {
            return _context.Resturants;
        }
    }

    public class InMemoryResturantData : IResturantData
    {
        static InMemoryResturantData()
        {
            _resturants = new List<Resturant>
            {
                new Resturant{Id = 1,Name = "asdf"},
                new Resturant{Id = 2,Name = "asdf"},
                new Resturant{Id = 3,Name = "asdf"},
                new Resturant{Id = 4,Name = "asdf"},
                new Resturant{Id = 5,Name = "asdf"}
            };
        }

        public IEnumerable<Resturant> GetAll()
        {
            return _resturants;
        }

        public Resturant Get(int id)
        {
            return _resturants.FirstOrDefault(r => r.Id == id);
        }

        public Resturant Add(Resturant newResturant)
        {
            newResturant.Id = _resturants.Max(r => r.Id) + 1;
            _resturants.Add(newResturant);

            return newResturant;
        }

        static List<Resturant> _resturants;
    }
}
