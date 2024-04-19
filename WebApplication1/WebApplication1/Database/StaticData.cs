using WebApplication1.Models;

namespace WebApplication1.Database;

public class StaticData
{
    public static List<Animal> animals = new List<Animal>()
    {
        new Animal(),
        new Animal(),
        new Animal(),
    };
}