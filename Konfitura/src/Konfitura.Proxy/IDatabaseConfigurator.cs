using System.ServiceModel;

namespace Konfitura.Proxy
{
    [ServiceContract]
    public interface IDatabaseConfigurator
    {
        [OperationContract]
        void ConfigureFunctions(ConfigureFunctionsCommand command);
    }
}