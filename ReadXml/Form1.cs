using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using System.Xml.Linq;

namespace ReadXml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if(DialogResult.OK == openFileDialog.ShowDialog())
            {
                if(openFileDialog.FileName.Length > 0)
                    txt_FilePath.Text = openFileDialog.FileName;
            }
        }

        private void btn_ParseFile_Click(object sender, EventArgs e)
        {
            XmlDocument xml = new XmlDocument();

            if (!String.IsNullOrEmpty(txt_FilePath.Text))
            {
                //Dictionary<string, string> valuePairs = new Dictionary<string, string>();
                xml.Load(txt_FilePath.Text);
                XmlNamespaceManager xmlNamespace = new XmlNamespaceManager(xml.NameTable);

                var att = xml.DocumentElement.Attributes;
                if(att.Count > 0)
                {
                    for(int i = 0; i < att.Count; i++)
                    {
                        string prefix = att[i].Name.Substring(att[i].Name.IndexOf(":") + 1);
                        string uri = att[i].Value;

                        if (prefix.StartsWith("ns"))
                        {
                            xmlNamespace.AddNamespace(prefix, uri);
                        }
                    } 
                }
                List<DataUpdater> dataUpdaterList = new List<DataUpdater>();

                var parentNodeList = xml.SelectNodes("//ns0:RDEntityList//ns2:RDEntity", xmlNamespace);

                string displayText = String.Empty;

                if (parentNodeList.Count > 0)
                {
                    List<XmlDocument> docsToSave = new List<XmlDocument>();
                    for (int i = 0; i < parentNodeList.Count; i++)
                    {
                        string codeListName = String.Empty;
                        string codeCode = String.Empty;
                        string codeValue = String.Empty;
                        string codeDescription = String.Empty;

                        if (!String.IsNullOrEmpty(parentNodeList[i].Attributes[0].InnerText))
                        {
                            codeListName = parentNodeList[i].Attributes[0].InnerText;
                        }

                        var nodeCollection = parentNodeList[i].ChildNodes;
                        for (int j = 0; j < nodeCollection.Count; j++)
                        {
                            var child = nodeCollection[j].ChildNodes;
                            foreach(XmlNode node in child)
                            {
                                if (node.Name == "ns4:dataItem")
                                {
                                    codeCode = node.InnerText;
                                    codeValue = node.InnerText;

                                } 
                                else if(node.Name == "ns4:LsdList")
                                {
                                    if(node.ChildNodes.Count > 0)
                                    {
                                        var descriptionChildNodes = node.ChildNodes;
                                        int count = 0;
                                        foreach(XmlNode nodeDesc in descriptionChildNodes)
                                        {
                                            if (nodeDesc.Attributes["lang"].Value == "en")
                                            {
                                                codeDescription = nodeDesc.InnerText;
                                            }
                                        }
                                    }
                                    
                                }
                                else
                                {
                                    codeDescription = codeCode.ToUpper().Trim();
                                }
                            }

                            if(codeValue != String.Empty && codeDescription != String.Empty)
                            {
                                DataUpdater dataUpdater = new DataUpdater(codeListName, codeCode, codeValue, codeDescription);
                                if (dataUpdater != null)
                                {
                                    dataUpdaterList.Add(dataUpdater);
                                }
                            }
                        }

                        string codeListDescription = codeListName + "_AES";

                        var doc = CreateXmlTemplate(codeListName, codeListDescription);

                        var newNode = CreateXmlNodeValues(doc, dataUpdaterList);

                        var codeList = doc.SelectSingleNode("//Code");
                        codeList.AppendChild(newNode);

                        docsToSave.Add(doc);

                        dataUpdaterList.Clear();
                    }

                    foreach (XmlDocument doc in docsToSave)
                    {
                        txt_Output.Text += doc.OuterXml;
                        try
                        {
                            SaveFile(doc);
                            string docFile = doc.SelectSingleNode("//DataUpdater//CodeList//Code//ReferenceCode").InnerText;
                            MessageBox.Show($"File salvo com sucesso: {docFile.ToUpper()}");
                        }
                        catch (Exception)
                        {
                            string docFile = doc.SelectSingleNode("//DataUpdater//CodeList//Code//ReferenceCode").InnerText;
                            throw new Exception($"Unable to save file: {docFile.ToUpper()}");
                        }
                        
                        
                    }

                    this.Close();
                }
            }
        }

        public static void SaveFile(XmlDocument xmlDocument)
        {
            if (xmlDocument != null)
            {
                string directory = "C:\\01. Paulo Huertas\\c#\\Expeditors\\";
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

        public class DataUpdater
        {
            public string Name { get; set; }
            public string Code { get; set; }
            public string Value { get; set; }
            public string Description { get; set; }

            public DataUpdater(string name, string code, string value, string description)
            {
                Name = name;
                Code = code;
                Value = value;
                Description = description;
            }
        }
    }
}
