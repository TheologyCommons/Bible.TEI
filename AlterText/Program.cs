using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace AlterText
{
    class Program
    {
        static void Main(string[] args)
        {
            

            string text = File.ReadAllText("../../../../KJV.xml", Encoding.UTF8);

            text = Regex.Replace(text, $"<p>[\\d]+:[\\d]+\\s", "<p>");

            string result = "";

            MemoryStream mStream = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(mStream, Encoding.Unicode);
            XmlDocument document = new XmlDocument();

            try
            {
                // Load the XmlDocument with the XML.
                document.LoadXml(text);

                writer.Formatting = Formatting.Indented;

                // Write the XML into a formatting XmlTextWriter
                document.WriteContentTo(writer);
                writer.Flush();
                mStream.Flush();

                // Have to rewind the MemoryStream in order to read
                // its contents.
                mStream.Position = 0;

                // Read MemoryStream contents into a StreamReader.
                StreamReader sReader = new StreamReader(mStream);

                // Extract the text from the StreamReader.
                string formattedXml = sReader.ReadToEnd();

                result = formattedXml;
            }
            catch (XmlException)
            {
                // Handle the exception
            }



            File.WriteAllText("../../../../KJV1.xml", result);
        }
    }
}
