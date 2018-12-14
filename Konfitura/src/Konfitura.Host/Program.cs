using Konfitura.Proxy;
using Konfitura.Service;
using System;
using System.Collections.Generic;
using Topshelf;

namespace Konfitura.Konsola
{
    class Program
    {
        public const string ServiceName ="GNB.Konfitura";        

        static void Main(string[] args)
        {           
            var serviceRunner = HostFactory.Run(x =>
            {
                x.Service<KonfituraService>(service =>
                {
                    service.ConstructUsing(srv => new KonfituraService(ServiceName));
                    service.WhenStarted(tc => tc.Start());
                    service.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();
                
                x.SetServiceName(ServiceName);
                x.SetDescription("This is sample service powered by TopShelf.");
                x.StartAutomatically();
                
                x.UseLog4Net();

                x.OnException(ex =>
                {
                    Console.WriteLine("An error occurred: \n" + ex.Message);
                });
            });

            var exitCode = (int)Convert.ChangeType(serviceRunner, serviceRunner.GetTypeCode());
            Environment.ExitCode = exitCode;
        }        
    }
}
