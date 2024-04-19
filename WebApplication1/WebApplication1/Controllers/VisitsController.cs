using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class VisitsController : ControllerBase
{
    private static List<Visit> _visits = new List<Visit>();

    [HttpGet("{animalId}")]
    public ActionResult<List<Visit>> GetVisitsByAnimalId(int animalId)
    {
        var visits = _visits.Where(v => v.Animal.Id == animalId).ToList();
        if (!visits.Any())
        {
            return NotFound();
        }
        return Ok(visits);
    }

    [HttpPost]
    public ActionResult<Visit> AddVisit(Visit visit)
    {
        visit.Id = _visits.Any() ? _visits.Max(v => v.Id) + 1 : 1;
        _visits.Add(visit);
        return CreatedAtAction(nameof(GetVisitsByAnimalId), new { animalId = visit.Animal.Id }, visit);
    }
}