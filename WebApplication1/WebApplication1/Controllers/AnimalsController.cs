using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimalsController : ControllerBase
{
    private static List<Animal> _animals = new();

    [HttpGet]
    public ActionResult<List<Animal>> GetAnimals()
    {
        return Ok(_animals);
    }

    [HttpGet("{id}")]
    public ActionResult<Animal> GetAnimalById(int id)
    {
        var animal = _animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
        {
            return NotFound();
        }
        return Ok(animal);
    }

    [HttpPost]
    public ActionResult<Animal> AddAnimal(Animal animal)
    {
        animal.Id = _animals.Any() ? _animals.Max(a => a.Id) + 1 : 1;
        _animals.Add(animal);
        return CreatedAtAction(nameof(GetAnimalById), new { id = animal.Id }, animal);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var existingAnimal = _animals.FirstOrDefault(a => a.Id == id);
        if (existingAnimal == null)
        {
            return NotFound();
        }
        existingAnimal.Name = animal.Name;
        existingAnimal.Category = animal.Category;
        existingAnimal.Weight = animal.Weight;
        existingAnimal.FurColor = animal.FurColor;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animal = _animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
        {
            return NotFound();
        }
        _animals.Remove(animal);
        return NoContent();
    }
}