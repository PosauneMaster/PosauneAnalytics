using PosauneAnalytics.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PosauneAnalytics.FileManager
{
    [Serializable]
    public class SettlementUtils : ISettlementUtils
    {
        public DateTime GetDateTimeFromNode(XmlNode node, string attrName)
        {
            if (node.Attributes[attrName] != null)
            {
                DateTime dt;

                if (DateTime.TryParse(node.Attributes[attrName].Value, out dt))
                {
                    return dt;
                }
            }

            return default(DateTime);
        }

        public string GetStringFromNode(XmlNode node, string attrName)
        {
            if (node.Attributes[attrName] != null)
            {
                return node.Attributes[attrName].Value;
            }

            return String.Empty;
        }

        public XmlNode GetInstrumentNode(XmlNode node)
        {
            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.Name == "Instrmt")
                {
                    return child;
                }
            }

            return node;
        }

        public XmlNode GetUnderlyingNode(XmlNode node)
        {
            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.Name == "Undly")
                {
                    return child;
                }
            }

            return node;
        }


        public string GetPrice(XmlNode node)
        {
            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.Name == "Full")
                {
                    if (child.Attributes["Typ"] != null)
                    {
                        string type = child.Attributes["Typ"].Value;
                        if (child.Attributes["Typ"].Value == "6")
                        {
                            return child.Attributes["Px"].Value;
                        }
                    }
                }
            }
            return String.Empty;
        }

        public SecurityType GetSecurityType(XmlNode node)
        {
            string secType = node.ChildNodes[0].Attributes["SecTyp"].Value;

            string putCall = String.Empty;
            if (node.ChildNodes[0].Attributes["PutCall"] != null)
            {
                putCall = node.ChildNodes[0].Attributes["PutCall"].Value;
            }


            if (secType.ToUpper() == "FUT")
            {
                return SecurityType.Future;
            }

            if (secType.ToUpper() == "OOF")
            {
                if (putCall == "1")
                {
                    return SecurityType.Call;
                }

                if (putCall == "0")
                {
                    return SecurityType.Put;
                }
            }

            return SecurityType.Other;
        }
    }
}
