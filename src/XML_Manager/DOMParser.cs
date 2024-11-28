using System.Xml;
using System.Xml.Schema;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Linq;

namespace XML_Manager;

public class DOMParser : Parser
{
    public DOMParser()
    {
        Clubs = new List<Club>();
    }

    public override bool Load(Stream inputStream, XmlReaderSettings settings)
    {
        Clubs.Clear();
        var document = new XmlDocument();
        using var reader = XmlReader.Create(inputStream, settings);
        try
        {
            document.Load(reader);
            if (document == null || document.DocumentElement == null)
            {
                return true;
            }
            var serializer = new XmlSerializer(typeof(Club));
            foreach (XmlNode child in document.DocumentElement.ChildNodes)
            {
                if (serializer.Deserialize(new StringReader(child.OuterXml)) is Club club)
                {
                    Clubs.Add(club);
                }
            }
        }
        catch
        {
            return false;
        }

        return true;
    }
}
