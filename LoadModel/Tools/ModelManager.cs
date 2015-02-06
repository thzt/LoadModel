using System;
using System.Web;
using System.Xml;

namespace LoadModel.Tools
{
    public class ModelManager
    {
        public ModelManager(HttpServerUtilityBase server)
        {
            string xmlFilePath = server.MapPath("/Data/LoadModelDecision.xml");
            xmlDoc.Load(xmlFilePath);
        }

        public string GetViewName(int index)
        {
            foreach (XmlNode node in xmlDoc.SelectNodes("root/case"))
            {
                if (node.Attributes["index"].Value != index.ToString())
                {
                    continue;
                }

                return node.Attributes["viewname"].Value;
            }

            throw new Exception("Failed to get decision.");
        }

        public string GetModelName(int index)
        {
            foreach (XmlNode node in xmlDoc.SelectNodes("root/case"))
            {
                if (node.Attributes["index"].Value != index.ToString())
                {
                    continue;
                }

                return node.Attributes["modelname"].Value;
            }

            throw new Exception("Failed to get decision.");
        }

        public object CreateModel(string modelName)
        {
            return Activator.CreateInstance(Type.GetType(modelName));
        }

        private readonly XmlDocument xmlDoc = new XmlDocument();
    }
}