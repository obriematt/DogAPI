using DogAPI.Contexts;
using DogAPI.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DogAPI.Repositories
{
    public class DogRepository : IDogRepository
    {
        private readonly DogContext _context;

        public DogRepository(DogContext context)
        {
            _context = context;
        }

        private void UpdateJsonStore()
        {
            string json = JsonConvert.SerializeObject(_context.Dogs.ToList(), Formatting.Indented);
            File.WriteAllText(@"dogs.json", json);
        }

        public Dog CreateDog(Dog dog)
        {
            _context.Dogs.Add(dog);

            _context.SaveChanges();

            UpdateJsonStore();

            return dog;
        }

        public bool DeleteDog(int id)
        {
            var dog = _context.Dogs.Find(id);
            if(dog == null)
            {
                return false;
            }
            else
            {
                _context.Dogs.Remove(dog);
                _context.SaveChanges();
                UpdateJsonStore();
                return true;
            }
        }

        public bool DogExists(int id)
        {
            if(_context.Dogs.Find(id) == null)
            {
                return false;
            }
            return true;
        }

        public Dog GetDog(int id)
        {
            var dog = _context.Dogs.Find(id);
            return dog;
        }

        public List<Dog> GetDogs()
        {
            return _context.Dogs.ToList();
        }

        public Dog UpdateDog(Dog dog)
        {
            var updatedDog = _context.Dogs.Where(x => x.Id == dog.Id).AsQueryable().FirstOrDefault();
            if(updatedDog == null)
            {
                _context.Dogs.Add(dog);
            }
            else
            {
                _context.Entry(updatedDog).CurrentValues.SetValues(dog);
            }
            _context.SaveChanges();
            UpdateJsonStore();
            return updatedDog;
        }
    }
}
