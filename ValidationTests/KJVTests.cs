using System;
using System.Xml;
using Xunit;

namespace ValidationTests
{
    public class KJVTests
    {
        [Fact]
        public void VerfyVerseNumbers()
        {
            XmlDocument xd = new XmlDocument();
            xd.Load("../../../../KJV.xml");

            var bible = xd.ChildNodes[1].ChildNodes[1].ChildNodes[1];

            for (int i = 0; i < bible.ChildNodes.Count; i++)
            {
                var testament = bible.ChildNodes[i].ChildNodes[1];
                for (int i2 = 0; i2 < testament.ChildNodes.Count; i2++)
                {
                    var book = testament.ChildNodes[i2];
                    for (int i3 = 0; i3 < book.ChildNodes[1].ChildNodes.Count; i3++)
                    {
                        var chapter = book.ChildNodes[1].ChildNodes[i3];
                        for (int i4 = 0; i4 < chapter.ChildNodes.Count; i4++)
                        {
                            var verse = chapter.ChildNodes[i4];
                            var verseInnerText = verse.InnerText.Trim();
                            if (!verseInnerText.StartsWith(string.Concat(i3+1, ":", i4+1)))
                            {
                                var bookname = book.ChildNodes[0].InnerText.Trim();
                                throw new Exception($"{bookname} {i3 + 1}:{i4 + 1}");
                            }
                        }
                    }
                }
            }
        }
    }
}
