using DogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DogAPI.Contexts
{
    public class DogContext : DbContext
    {
        public DogContext(DbContextOptions<DogContext> options)
            : base(options)
        {
        }

        public DbSet<Dog> Dogs { get; set; }
    }
}
