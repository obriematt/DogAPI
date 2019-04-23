using System.ComponentModel.DataAnnotations;

namespace DogAPI.Models
{
    public class Dog
    {
        [Key]
        public int Id { get; set; }

        public string DogName { get; set; }

        public string OwnerName { get; set; }

        public string Notes { get; set; }
    }
}
