using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReadXml.Form1;
using System.Xml;
using ReadXml.Model;
using System.Configuration;

namespace ReadXml.Utilities
{
    public class Utils
    {
        public static void SaveFile(XmlDocument xmlDocument)
        {
            if (xmlDocument != null)
            {
                string directory = ConfigurationManager.AppSettings.Get("directory");
                string docFile = xmlDocument.SelectSingleNode("//DataUpdater//CodeList//Code//ReferenceCode").InnerText;
                string fileName = directory + docFile + ".xml";
                xmlDocument.Save(fileName);
            }
        }

        public static XmlDocument CreateXmlTemplate(string referenceCode, string descriptionCode)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlNode root = xmlDocument.CreateNode(XmlNodeType.Element, "DataUpdater", null);
            xmlDocument.AppendChild(root);

            XmlNode codeList = xmlDocument.CreateNode(XmlNodeType.Element, "CodeList", null);
            root.AppendChild(codeList);

            XmlNode code = xmlDocument.CreateNode(XmlNodeType.Element, "Code", null);
            XmlAttribute xmlAttribute = xmlDocument.CreateAttribute("full");
            xmlAttribute.Value = "Y";
            code.Attributes.Append(xmlAttribute);

            codeList.AppendChild(code);

            XmlElement refCode = xmlDocument.CreateElement("ReferenceCode");
            if (!String.IsNullOrEmpty(referenceCode))
            {
                refCode.InnerText = referenceCode;
                code.AppendChild(refCode);
            }

            Dictionary<string, string> metdaDataNodes = new Dictionary<string, string>();
            metdaDataNodes.Add("CodeConstraint", "2");
            metdaDataNodes.Add("ValueConstraint", "2");
            metdaDataNodes.Add("Qual1Constraint", "1");
            metdaDataNodes.Add("Qual2Constraint", "0");
            metdaDataNodes.Add("Qual3Constraint", "0");
            metdaDataNodes.Add("Description", descriptionCode);

            foreach (var kvp in metdaDataNodes)
            {
                XmlNode metaData = xmlDocument.CreateNode(XmlNodeType.Element, kvp.Key, null);
                metaData.InnerText = kvp.Value;
                if (metaData.Name == "Description")
                {
                    var att = xmlDocument.CreateAttribute("lang");
                    att.Value = "en";
                    metaData.Attributes.Prepend(att);
                }
                code.AppendChild(metaData);
            }

            XmlNode codeValueListNode = xmlDocument.CreateNode(XmlNodeType.Element, "CodeValueList", null);
            code.AppendChild(codeValueListNode);

            return xmlDocument;
        }
        public static XmlNode CreateXmlNodeValues(XmlDocument xmldoc, List<DataUpdater> updater)
        {
            try
            {
                if (xmldoc != null && updater.Count > 0)
                {

                    XmlNode codeValueListNode = xmldoc.LastChild.SelectSingleNode("//CodeValueList");

                    if (updater.Count > 0)
                    {
                        for (int i = 0; i < updater.Count; i++)
                        {
                            XmlNode codeValue = xmldoc.CreateNode(XmlNodeType.Element, "CodeValue", null);

                            XmlElement valueCode = xmldoc.CreateElement("ValueCode");
                            valueCode.InnerText = updater[i].Code;
                            codeValue.AppendChild(valueCode);

                            XmlElement valueValue = xmldoc.CreateElement("ValueValue");
                            valueValue.InnerText = updater[i].Value;
                            codeValue.AppendChild(valueValue);

                            XmlElement description = xmldoc.CreateElement("Description");
                            XmlAttribute xmlAttribute = xmldoc.CreateAttribute("lang");
                            xmlAttribute.Value = "en";
                            description.Attributes.Append(xmlAttribute);
                            description.InnerText = updater[i].Description;

                            codeValue.AppendChild(description);

                            codeValueListNode.AppendChild(codeValue);
                        }
                    }

                    return codeValueListNode;
                }
                return null;
            }
            catch
            {
                throw new Exception("Failed to load Updater Element");
            }
        }
    }
}
