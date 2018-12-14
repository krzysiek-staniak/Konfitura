using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Konfitura.Proxy
{
    [DataContract]
    public class ConfigureFunctionsCommand
    {
        [DataMember]
        public IEnumerable<FunctionConfiguration> FunctionConfigurations { get; set; }
    }
}