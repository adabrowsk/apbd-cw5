using AppT.Database;
using AppT.Models;

namespace AppT.Endpoints;

public static class AnimalEndpoints
{
    public static void MapAnimalEndpoints(this WebApplication app)
    {
        app.MapGet("/animals/{id}", (int id) =>
        {
            //200 - Ok
            //400 - bad request
            //401 - unathorized 
            //403 - forbidden
            //404 - not found
            //500 - internal server error

            var animals = StaticData.animals;
            
            return Results.Ok(animals);
        });

        app.MapGet("/animals/{id}", (int id) => { return Results.Ok(id); });

        app.MapPost("/animals", (Animal animal) =>
        {
            //201 - created
            return Results.Created(" ", animal);
        });
    }
}