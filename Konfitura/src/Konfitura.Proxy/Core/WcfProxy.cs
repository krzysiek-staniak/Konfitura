using System;
using System.ServiceModel;

namespace Konfitura.Proxy.Core
{
    public class WcfProxy<T>
    {
        private static readonly ChannelFactory<T> ChannelFactory = new ChannelFactory<T>("*");

        public static void Execute(Action<T> serviceAction)
        {
            var proxy = (IClientChannel)ChannelFactory.CreateChannel();
            var success = false;
            try
            {
                serviceAction((T)proxy);
                proxy.Close();
                success = true;
            }
            finally
            {
                if (!success)
                {
                    proxy.Abort();
                }
            }
        }

        public static TResponse Execute<TResponse>(Func<T, TResponse> serviceAction)
        {
            var response = default(TResponse);
            Execute(new Action<T>(service => response = serviceAction(service)));
            return response;
        }
    }
}
