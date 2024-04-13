using System.Collections.Generic;
using VeterinaryClinic.Models;

namespace VeterinaryClinic.Database
{
    public static class Database
    {
        public static List<Animal> Animals { get; } = new List<Animal>();
        public static List<Visit> Visits { get; } = new List<Visit>();
    }
}