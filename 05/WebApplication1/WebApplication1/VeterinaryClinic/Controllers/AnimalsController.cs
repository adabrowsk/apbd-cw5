using Microsoft.AspNetCore.Mvc;
using WebApplication1.VeterinaryClinic.Data;
using WebApplication1.VeterinaryClinic.Models;

namespace WebApplication1.VeterinaryClinic.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimalsController : ControllerBase
{
    // GET: /animals
    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(Database.Animals);
    }

    // GET: /animals/{id}
    [HttpGet("{id}")]
    public IActionResult GetAnimal(Guid id)
    {
        var animal = Database.Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null) return NotFound();
        return Ok(animal);
    }

    // POST: /animals
    [HttpPost]
    public IActionResult CreateAnimal([FromBody] Animal animal)
    {
        animal.Id = Guid.NewGuid();
        Database.Animals.Add(animal);
        return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, animal);
    }

    // PUT: /animals/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateAnimal(Guid id, [FromBody] Animal animalUpdate)
    {
        var animal = Database.Animals.FirstOrDefault(a => a.Id == id);
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
        var animal = Database.Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null) return NotFound();

        Database.Animals.Remove(animal);
        return NoContent();
    }
}