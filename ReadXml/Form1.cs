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
using ReadXml.Utilities;
using ReadXml.Model;

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

                        var doc = Utils.CreateXmlTemplate(codeListName, codeListDescription);

                        var newNode = Utils.CreateXmlNodeValues(doc, dataUpdaterList);

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

                            Utils.SaveFile(doc);
                            string docFile = doc.SelectSingleNode("//DataUpdater//CodeList//Code//ReferenceCode").InnerText;
                            MessageBox.Show($"Saved successfully: {docFile.ToUpper()}");
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
    }
}
