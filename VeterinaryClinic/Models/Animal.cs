namespace VeterinaryClinic.Models
{
    public class Animal
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Weight { get; set; }
        public string FurColor { get; set; }
    }
}
