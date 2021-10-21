namespace DesignPatterns.UnitOfWork.Entities
{
    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Plate { get; set; }
        public Owner Owner { get; set; }
    }
}
