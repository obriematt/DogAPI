using DogAPI.Models;
using System.Collections.Generic;

namespace DogAPI.Services
{
    public interface IDogService
    {
        Dog CreateDog(Dog dog);
        Dog GetDog(int id);
        Dog UpdateDog(int id, Dog dog);
        bool DeleteDog(int id);
        List<Dog> GetDogs();
    }
}
