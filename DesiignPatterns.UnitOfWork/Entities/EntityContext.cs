using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.UnitOfWork.Logic;

namespace DesignPatterns.UnitOfWork.Entities
{
    public class EntityContext : Context
    {
        public List<Car> Cars { get; set; }
        public List<Owner> Owners { get; set; }
    }
}
