using DesignPatterns.UnitOfWork.Entities;

namespace DesignPatterns.UnitOfWork
{
    public class UnitOfWork
    {
        private EntityContext context;
        private Repository<Car> carRepository;
        private Repository<Owner> ownerRepository;

        public UnitOfWork(EntityContext context)
        {
            this.context = context;
        }

        public Repository<Car> CarRepository
        {
            get
            {
                if (carRepository is null)
                {
                    carRepository = new Repository<Car>(context);
                }

                return carRepository;
            }
            
        }
        public Repository<Owner> OwnerRepository
        {
            get
            {
                if (ownerRepository is null)
                {
                    ownerRepository = new Repository<Owner>(context);
                }

                return ownerRepository;
            }

        }
    }
}