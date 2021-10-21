using System.Collections.Generic;

namespace DesignPatterns.UnitOfWork.Entities
{
    public class Owner
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Plate { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
