using WebApplication1.Models;

namespace WebApplication1.Services;

public class VisitService
{
    private readonly List<Visit> _visits = new List<Visit>();
    private int _nextVisitId = 1;

    public IEnumerable<Visit> GetVisitsByAnimalId(int animalId)
    {
        return _visits.Where(v => v.Animal.Id == animalId);
    }

    public Visit AddVisit(Visit visit)
    {
        visit.Id = _nextVisitId++;
        _visits.Add(visit);
        return visit;
    }
}