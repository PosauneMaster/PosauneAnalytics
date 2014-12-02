using PosauneAnalytics.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PosauneAnalytics.FileManager
{
    public interface ISettlementUtils
    {
        DateTime GetDateTimeFromNode(XmlNode node, string attrName);
        string GetStringFromNode(XmlNode node, string attrName);
        XmlNode GetInstrumentNode(XmlNode node);
        XmlNode GetUnderlyingNode(XmlNode node);
        string GetPrice(XmlNode node);
        SecurityType GetSecurityType(XmlNode node);
    }
}
