using DogAPI.Models;
using DogAPI.Repositories;
using System.Collections.Generic;

namespace DogAPI.Services
{
    public class DogService : IDogService
    {
        private readonly IDogRepository _dogRepository;

        public DogService(IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }

        public Dog CreateDog(Dog dog)
        {
            if (!_dogRepository.DogExists(dog.Id))
            {
                return _dogRepository.CreateDog(dog); ;
            }
            return null;
        }

        public bool DeleteDog(int id)
        {
            return _dogRepository.DeleteDog(id);
        }

        public Dog GetDog(int id)
        {
            return _dogRepository.GetDog(id);
        }

        public List<Dog> GetDogs()
        {
            return _dogRepository.GetDogs();
        }

        public Dog UpdateDog(int id, Dog dog)
        {
            if(id != dog.Id)
            {
                return null;
            }
            return _dogRepository.UpdateDog(dog);
        }
    }
}
