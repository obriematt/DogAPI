using DogAPI.Models;
using System.Collections.Generic;

namespace DogAPI.Repositories
{
    public interface IDogRepository
    {
        bool DogExists(int id);
        Dog CreateDog(Dog dog);
        Dog GetDog(int id);
        Dog UpdateDog(Dog dog);
        bool DeleteDog(int id);
        List<Dog> GetDogs();
    }
}
