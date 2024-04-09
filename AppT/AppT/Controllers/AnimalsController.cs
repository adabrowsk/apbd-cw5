using AppT.Database;
using Microsoft.AspNetCore.Mvc;

namespace AppT.Controllers;

[ApiController]
[Route("/animals-controller")] //zazwyczaj pisac po prostu animals
//[Route("[controller]")]
public class AnimalsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAnimals()
    {
        var animals = new MockDb().Animals;
        return Ok(animals);
    }
    
    [HttpPost]
    public IActionResult AddAnimals()
    {
        return Created();
    }
}