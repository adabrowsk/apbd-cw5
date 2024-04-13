using Microsoft.AspNetCore.Mvc;
using WebApplication1.VeterinaryClinic.Data;
using WebApplication1.VeterinaryClinic.Models;

namespace WebApplication1.VeterinaryClinic.Controllers;

[ApiController]
[Route("[controller]")]
public class VisitsController : ControllerBase
{
    // GET: /visits/{animalId}
    [HttpGet("{animalId}")]
    public IActionResult GetVisitsForAnimal(Guid animalId)
    {
        var visits = Database.Visits.Where(v => v.AnimalId == animalId).ToList();
        return Ok(visits);
    }

    // POST: /visits
    [HttpPost]
    public IActionResult CreateVisit([FromBody] Visit visit)
    {
        visit.Id = Guid.NewGuid();
        Database.Visits.Add(visit);
        return CreatedAtAction("GetVisitsForAnimal", new { animalId = visit.AnimalId }, visit);
    }
}