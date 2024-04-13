namespace VeterinaryClinic.Models

{
    public class Visit
    {
        public Guid Id { get; set; }
        public DateTime DateOfVisit { get; set; }
        public Guid AnimalId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}