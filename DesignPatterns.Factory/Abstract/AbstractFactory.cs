using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory.Abstract
{
    #region Cars
    public interface ICar
    {
        void Car();
    }

    internal class Nissan : ICar
    {
        public void Car()
        {
            Console.WriteLine("Nissan");
        }
    }

    internal class Opel : ICar
    {
        public void Car()
        {
            Console.WriteLine("Opel");
        }
    }
    #endregion

    #region CarFactory

    public interface ICarFactory
    {
        ICar Sell(int amount);
    }

    internal class NissanFactory : ICarFactory
    {
        public ICar Sell(int amount)
        {
            Console.WriteLine($"You sold {amount} cars!");
            return new Nissan();
        }
    }

    internal class OpelFactory : ICarFactory
    {
        public ICar Sell(int amount)
        {
            Console.WriteLine($"You sold {amount} cars!");
            return new Opel();
        }
    }

    #endregion

}
