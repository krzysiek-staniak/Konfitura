using Konfitura.Proxy;
using System;
using System.Collections.Generic;

namespace Konfitura.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Press a key to send request ...");
            Console.ReadKey();
            Console.WriteLine("Start sending request ...");

            var databaseConfigurator = new DatabaseConfigurator();
            var command = new ConfigureFunctionsCommand
            {
                FunctionConfigurations = new List<FunctionConfiguration>()
                {
                    new FunctionConfiguration
                    {
                    },
                    new FunctionConfiguration
                    {
                    }
                }
            };
            databaseConfigurator.ConfigureFunctions(command);

            Console.WriteLine("Request send!");
            Console.WriteLine("Press a key to exit ...");
            Console.ReadKey();
        }
    }
}