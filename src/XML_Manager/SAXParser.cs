using System.Xml;

namespace XML_Manager;

public class SAXParser : Parser
{
    public SAXParser()
    {
        Clubs = new List<Club>();
    }

    public override bool Load(Stream inputStream, XmlReaderSettings settings)
    {
        Clubs.Clear();
        try
        {
            var reader = XmlReader.Create(inputStream, settings);
            while (reader.Read())
            {
                if (!(reader.NodeType == XmlNodeType.Element && reader.Name == "Club"))
                {
                    continue;
                }

                var club = new Club();
                SkipToText(reader);
                club.Title = reader.Value;
                SkipToText(reader);
                club.Faculty = reader.Value;
                SkipToText(reader);
                club.Department = reader.Value;
                SkipToText(reader);
                club.Schedule.Day = reader.Value;
                SkipToText(reader);
                club.Schedule.Time = reader.Value;
                SkipToText(reader);
                club.Leader.FirstName = reader.Value;
                SkipToText(reader);
                club.Leader.LastName = reader.Value;
                SkipToText(reader);
                club.Starosta.FirstName = reader.Value;
                SkipToText(reader);
                club.Starosta.LastName = reader.Value;

                Clubs.Add(club);
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    private static void SkipToText(XmlReader reader)
    {
        do
        {
            if (!reader.Read())
            {
                throw new Exception();
            }
        } while (reader.NodeType != XmlNodeType.Text);
    }
}
