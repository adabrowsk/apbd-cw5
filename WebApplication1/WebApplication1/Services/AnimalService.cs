using WebApplication1.Models;

namespace WebApplication1.Services;

public class AnimalService
{
    private readonly List<Animal> _animals = new List<Animal>();
    private int _nextAnimalId = 1;

    public IEnumerable<Animal> GetAllAnimals()
    {
        return _animals;
    }

    public Animal AddAnimal(Animal animal)
    {
        animal.Id = _nextAnimalId++;
        _animals.Add(animal);
        return animal;
    }
    
    public Animal? GetAnimalById(int id)
        {
            return _animals.FirstOrDefault(a => a.Id == id);
        }
    
    public void UpdateAnimal(Animal animal)
    {
        var alreadyAnimal = _animals.FirstOrDefault(a => a.Id == animal.Id);
        if (alreadyAnimal != null)
        {
            alreadyAnimal.Name = animal.Name;
            alreadyAnimal.Category = animal.Category;
            alreadyAnimal.Weight = animal.Weight;
            alreadyAnimal.Color = animal.Color;
        }
    }

    public void DeleteAnimal(int id)
    {
        var animalDeleting = _animals.FirstOrDefault(a => a.Id == id);
        if (animalDeleting != null)
        {
            _animals.Remove(animalDeleting);
        }
    }
}