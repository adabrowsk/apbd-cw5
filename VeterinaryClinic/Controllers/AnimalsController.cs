using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.Models;
using VeterinaryClinic.Database;


namespace VeterinaryClinic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalsController : ControllerBase
    {
        // GET: /animals
        [HttpGet]
        public IActionResult GetAnimals()
        {
            return Ok(Database.Database.Animals);
        }

        // GET: /animals/{id}
        [HttpGet("{id}")]
        public IActionResult GetAnimal(Guid id)
        {
            var animal = Database.Database.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null) return NotFound();
            return Ok(animal);
        }

        // POST: /animals
        [HttpPost]
        public IActionResult CreateAnimal([FromBody] Animal animal)
        {
            animal.Id = Guid.NewGuid();
            Database.Database.Animals.Add(animal);
            return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, animal);
        }

        // PUT: /animals/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateAnimal(Guid id, [FromBody] Animal animalUpdate)
        {
            var animal = Database.Database.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null) return NotFound();

            animal.Name = animalUpdate.Name;
            animal.Category = animalUpdate.Category;
            animal.Weight = animalUpdate.Weight;
            animal.FurColor = animalUpdate.FurColor;

            return NoContent();
        }

        // DELETE: /animals/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(Guid id)
        {
            var animal = Database.Database.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null) return NotFound();

            Database.Database.Animals.Remove(animal);
            return NoContent();
        }
    }
}

