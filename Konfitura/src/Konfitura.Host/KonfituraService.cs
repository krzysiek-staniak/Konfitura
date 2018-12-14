using Konfitura.Service;
using System;
using System.ServiceModel;

namespace Konfitura.Konsola
{
    public class KonfituraService : ServiceHost
    {
        private ServiceHost _serviceHost;

        public string ServiceName { get; }

        public KonfituraService(string serviceName)
        {
            ServiceName = serviceName;
        }

        public void Start()
        {
            Console.WriteLine(ServiceName + " starting...");
            bool openSucceeded = false;
            try
            {
                if (_serviceHost != null)
                {
                    _serviceHost.Close();
                }

                _serviceHost = new ServiceHost(typeof(DatabaseConfigurator));
            }
            catch (Exception e)
            {
                Console.WriteLine("Caught exception while creating " + ServiceName + ": " + e);
                return;
            }

            try
            {             
                _serviceHost.Open();
                openSucceeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Caught exception while starting " + ServiceName + ": " + ex);
            }
            finally
            {
                if (!openSucceeded)
                {
                    _serviceHost.Abort();
                }
            }

            if (_serviceHost.State == CommunicationState.Opened)
            {
                Console.WriteLine(ServiceName + " started");
            }
            else
            {
                Console.WriteLine(ServiceName + " failed to open");
                bool closeSucceeded = false;
                try
                {
                    _serviceHost.Close();
                    closeSucceeded = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ServiceName + " failed to close: " + ex);
                }
                finally
                {
                    if (!closeSucceeded)
                    {
                        _serviceHost.Abort();
                    }
                }
            }
        }

        public void Stop()
        {
            Console.WriteLine(ServiceName + " stopping...");
            try
            {
                if (_serviceHost != null)
                {
                    _serviceHost.Close();
                    _serviceHost = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Caught exception while stopping " + ServiceName + ": " + ex);
            }
            finally
            {
                Console.WriteLine(ServiceName + " stopped...");
            }
        }
    }
}