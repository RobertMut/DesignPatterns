using System;
using System.Threading;
using DesignPatterns.Singleton.Naive;
using DesignPatterns.Singleton.ThreadSafe;

namespace DesignPatterns.Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Naive");
            SingletonNaive naive = SingletonNaive.GetInstance();
            SingletonNaive naive2 = SingletonNaive.GetInstance();
            Thread first = new Thread(() =>
            {
                ThreadSingleton("TEST1");
            });
            Thread second = new Thread(() =>
            {
                ThreadSingleton("TEST2");
            });
            first.Start();
            second.Start();
            first.Join();
            second.Join();
        }

        public static void ThreadSingleton(string value)
        {
            ThreadSafeSingleton singleton = ThreadSafeSingleton.GetInstance(value);
            Console.WriteLine(singleton.Value);
        }

    }

}