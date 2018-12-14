using Konfitura.Proxy.Core;

namespace Konfitura.Proxy
{
    public class DatabaseConfigurator : WcfProxy<IDatabaseConfigurator>, IDatabaseConfigurator
    {
        public void ConfigureFunctions(ConfigureFunctionsCommand command)
        {
            Execute(x => x.ConfigureFunctions(command));
        }
    }
}
