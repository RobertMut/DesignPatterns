using System;
using DesignPatterns.Factory.Abstract;

namespace DesignPatterns.Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarFactory factory = new NissanFactory();
            factory.Sell(10).Car();
            factory = new OpelFactory();
            factory.Sell(20).Car();
        }
    }
}
