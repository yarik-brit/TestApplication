using System;
using System.Configuration;
using PL = PresentationLayer;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PL.PLPresenter plPresenter = new();

            plPresenter.ShowAllLibrary();
            plPresenter.DoTask();

            Console.ReadKey();
        }
    }
}
