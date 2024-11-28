using System.Xml;
using System.Xml.Linq;

namespace XML_Manager;

public class LINQParser : Parser
{
    public LINQParser()
    {
        Clubs = new List<Club>();
    }

    public override bool Load(Stream inputStream, XmlReaderSettings settings)
    {
        XDocument document;
        using var reader = XmlReader.Create(inputStream, settings);
        try
        {
            Clubs.Clear();
            document = XDocument.Load(reader);
            if (document == null)
            {
                return true;
            }
            var result = from club in document.Descendants("Club")
                         select
            new Club
            {
                Title = club.Element("Title")?.Value ?? "",
                Faculty = club.Element("Faculty")?.Value ?? "",
                Department = club.Element("Department")?.Value ?? "",
                Schedule = new Club.Date
                {
                    Day = club.Element("Schedule")?.Element("day")?.Value ?? "",
                    Time = club.Element("Schedule")?.Element("time")?.Value ?? ""
                },
                Leader = new Club.Person
                {
                    FirstName = club.Element("Leader")?.Element("FirstName")?.Value ?? "",
                    LastName = club.Element("Leader")?.Element("LastName")?.Value ?? ""
                },
                Starosta = new Club.Person
                {
                    FirstName = club.Element("Starosta")?.Element("FirstName")?.Value ?? "",
                    LastName = club.Element("Starosta")?.Element("LastName")?.Value ?? ""
                }
            };
            foreach (var club in result)
            {
                Clubs.Add(club);
            }
            return true;
        }
        catch
        {
            return false;
        }
    }
}
