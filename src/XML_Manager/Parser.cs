using System.Xml;

namespace XML_Manager;

public abstract class Parser : IParser
{
    protected IList<Club> Clubs;
    public IList<Club> Find(FilterOptions filters)
    {
        return Clubs.Where(filters.ValidateClub).ToList();

    }

    public abstract bool Load(Stream inputstream, XmlReaderSettings settings);
}