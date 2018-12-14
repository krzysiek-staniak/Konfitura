using Konfitura.Proxy;
using System.Xml;

namespace Konfitura.Service
{
    public class DatabaseConfigurator : IDatabaseConfigurator
    {
        readonly string configFile = @"C:\sample.config";

        public void ConfigureFunctions(ConfigureFunctionsCommand command)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(configFile);

            XmlElement root = doc.DocumentElement;
            XmlNodeList functionList = root.SelectNodes("database[@name='SampleDb']//sempleNode//sempleNode2");

            foreach (var functionConfiguration in command.FunctionConfigurations)
            {
                SetFunction(functionList, functionConfiguration.FunctionName, functionConfiguration.ConnectionStringName);
            }

            doc.Save(configFile);
        }

        private void SetFunction(XmlNodeList functionList, string functionName, string connectionStringName)
        {                       
            foreach(XmlElement function in functionList)
            {
                var nodeName = function.Attributes["name"];
                if (nodeName != null && nodeName.Value == functionName)
                {
                    var connectionString = function.Attributes["connectionString"];
                    connectionString.Value = connectionStringName;
                }
            }            
         }
    }
}