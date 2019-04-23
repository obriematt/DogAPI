using DogAPI.Models;
using DogAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        private readonly IDogService _dogService;

        public DogsController(IDogService dogSerivce)
        {
            _dogService = dogSerivce;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Dog), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Dog>> GetDogs()
        {
            var dogList = _dogService.GetDogs();
            return Ok(dogList.ToList());
        }

        [HttpPost]
        [ProducesResponseType(typeof(Dog), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Dog> CreateDog([FromBody] Dog dog)
        {
            var dogCreated = _dogService.CreateDog(dog);
            if (dogCreated == null)
            {
                return BadRequest();
            }
            return Ok(dogCreated);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Dog), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Dog> GetDog(int id)
        {
            var dog = _dogService.GetDog(id);
            if(dog == null)
            {
                return BadRequest();
            }
            return Ok(dog);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Dog), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Dog> UpdateDog(int id, [FromBody] Dog dog)
        {
            var updatedDog = _dogService.UpdateDog(id, dog);
            if(updatedDog == null)
            {
                return BadRequest();
            }
            return Ok(updatedDog);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<bool> RemoveDog(int id)
        {
            var removed = _dogService.DeleteDog(id);
            if(removed == false)
            {
                return BadRequest();
            }
            return Ok(removed);
        }
    }
}