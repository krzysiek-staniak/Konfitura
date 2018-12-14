using System.Runtime.Serialization;

namespace Konfitura.Proxy
{
    [DataContract]
    public class FunctionConfiguration
    {
        [DataMember]
        public string FunctionName { get; set; }

        [DataMember]
        public string ConnectionStringName { get; set; }
    }
}