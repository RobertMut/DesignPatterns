using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Singleton.Naive
{
    public class SingletonNaive
    {
        private static SingletonNaive _instance;
        private SingletonNaive(){}
        public static SingletonNaive GetInstance()
        {
            if (_instance is null)
            {
                Console.WriteLine("Instance was null");
                _instance = new SingletonNaive();
            }
            Console.WriteLine("Returned instance");
            return _instance;
        }
    }
}
