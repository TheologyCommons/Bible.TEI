using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Newtonsoft.Json;

namespace AlterText
{
    class Program
    {
        static void Main(string[] args)
        {
            // To convert an XML node contained in string xml into a JSON string   
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../../KJV.xml");
            string jsonText = JsonConvert.SerializeXmlNode(doc.DocumentElement);

            File.WriteAllText("../../../../KJV.json", jsonText);
        }
    }
}
