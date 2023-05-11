using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using ReadXml.Utilities;
using ReadXml.Model;

namespace ReadXml
{
    public partial class MainForm : Form
    {
        public MainForm()
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
                if (att.Count > 0)
                {
                    for (int i = 0; i < att.Count; i++)
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

                XmlNode requestInformation = xml.SelectSingleNode("/ns8:ExtractValidReferenceDataRespMsg/ns0:MessageHeader/ns1:RequestInformation", xmlNamespace);

                XmlNamespaceManager validReferenceNamespace = new XmlNamespaceManager(xml.NameTable);

                if(requestInformation != null)
                {
                    XmlNode referenceData = requestInformation.ChildNodes[0];

                    if(referenceData != null)
                    {
                        var attributes = referenceData.Attributes;

                        for(int i = 0; i < attributes.Count; i++)
                        {
                            string prefix = attributes[i].Name.Substring(attributes[i].Name.IndexOf(":") + 1);
                            string uri = attributes[i].Value;

                            if (prefix.StartsWith("ns"))
                            {
                                validReferenceNamespace.AddNamespace(prefix, uri);
                            }
                        }
                    }
                }

                string codeListVersion = xml.SelectSingleNode("//ns5:Extract//ns6:ExportingEntities//ns8:RDView", validReferenceNamespace).Attributes[0].Value;
                codeListVersion = String.Concat("_", codeListVersion);

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
                            codeListName = parentNodeList[i].Attributes[0].InnerText + codeListVersion;
                        }

                        var nodeCollection = parentNodeList[i].ChildNodes;

                        if (!codeListName.StartsWith("CustomsOffice"))
                        {

                            for (int j = 0; j < nodeCollection.Count; j++)
                            {
                                var children = nodeCollection[j].ChildNodes;

                                foreach (XmlNode node in children)
                                {
                                    if (node.Name == "ns4:dataItem")
                                    {
                                        if (node.NextSibling == null)
                                        {
                                            codeCode = node.InnerText;
                                            codeValue = node.InnerText;
                                        }
                                        else if (node.NextSibling.Name != "ns4:dataItem" && node.PreviousSibling.Name != "ns4:dataItem")
                                        {
                                            codeCode = node.InnerText;
                                            codeValue = node.InnerText;
                                        }
                                        else if (node.Attributes[0].InnerText == "CountryCode" || node.Attributes[0].InnerText.Contains("Currency") || node.Attributes[0].InnerText.Contains("RateValue"))
                                        {
                                            string attributeName = node.Attributes[0].InnerText;

                                            switch (attributeName)
                                            {
                                                case "Currency":
                                                    codeCode = node.InnerText;
                                                    codeValue = node.InnerText;
                                                    break;
                                                case "RateValue":
                                                    codeValue = node.InnerText;
                                                    break;
                                                case "CountryCode":
                                                    codeCode = node.InnerText;
                                                    codeValue = node.InnerText;
                                                    break;
                                                default:
                                                    break;
                                            }
                                        }
                                    }
                                    else if (node.Name == "ns4:LsdList")
                                    {
                                        if (node.ChildNodes.Count > 0)
                                        {
                                            var descriptionChildNodes = node.ChildNodes;

                                            foreach (XmlNode nodeDesc in descriptionChildNodes)
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

                                if (codeValue != String.Empty && codeDescription != String.Empty)
                                {
                                    DataUpdater dataUpdater = new DataUpdater(codeListName, codeCode, codeValue, codeDescription);
                                    if (dataUpdater != null)
                                    {
                                        dataUpdaterList.Add(dataUpdater);
                                    }
                                }
                            }
                        }
                        else
                        {
                            dataUpdaterList = Utils.CustomsOfficeCodeListType(nodeCollection, codeListName, xmlNamespace);
                        }

                        string codeListDescription = codeListName;

                        var doc = Utils.CreateXmlTemplate(codeListName, codeListDescription);

                        var newNode = Utils.CreateXmlNodeValues(doc, dataUpdaterList);

                        var codeList = doc.SelectSingleNode("//Code");
                        codeList.AppendChild(newNode);

                        docsToSave.Add(doc);

                        dataUpdaterList.Clear();
                    }

                    int numberFiles = 0;

                    foreach (XmlDocument doc in docsToSave)
                    {
                        txt_Output.Text += doc.OuterXml;
                        try
                        {
                            Utils.SaveFile(doc);
                            string docFile = doc.SelectSingleNode("//DataUpdater//CodeList//Code//ReferenceCode").InnerText;
                            numberFiles++;
                            if (numberFiles == 45)
                                //MessageBox.Show($"Saved successfully: {docFile.ToUpper()}", "Saved", MessageBoxButtons.OK);
                                MessageBox.Show("Files saving successfully. Click OK to continue", "Info", MessageBoxButtons.OK);

                        }
                        catch (Exception ex)
                        {
                            string docFile = doc.SelectSingleNode("//DataUpdater//CodeList//Code//ReferenceCode").InnerText;
                            throw new Exception($"Unable to save file: {docFile.ToUpper()}", ex);
                        }
                    }

                    if (numberFiles <= 1)
                        this.lbl_Output.Text = $"{numberFiles} file has been converted";
                    else
                        this.lbl_Output.Text = $"{numberFiles} files have been converted";

                    MessageBox.Show("Files saved successfully!", "Info", MessageBoxButtons.OK);
                }
            }

            this.txt_FilePath.Text = String.Empty;
            this.Show();
        }
    }
}
