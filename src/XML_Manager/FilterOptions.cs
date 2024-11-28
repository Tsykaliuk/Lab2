namespace XML_Manager;

public struct FilterOptions
{
    public string Title { get; set; }

    public string Faculty { get; set; }

    public string Department { get; set; }

    public string Leader { get; set; }

    public string Starosta { get; set; }

    public string Schedule { get; set; }

    public FilterOptions()
    {
        Title = "";
        Department = "";
        Faculty = "";
        Leader = "";
        Starosta = "";
        Schedule = "";
    }

    public readonly bool ValidateClub(Club club)
    {
        var title = club.Title.ToLower().Contains(Title.ToLower());
        var department = club.Department.ToLower().Contains(Department.ToLower());
        var faculty = club.Faculty.ToLower().Contains(Faculty.ToLower());
        var schedule = (club.Schedule.Day + " " + club.Schedule.Time).ToLower().Contains(Schedule.ToLower());
        var starosta = (club.Starosta.FirstName + " " + club.Starosta.LastName).ToLower().Contains(Starosta.ToLower());
        var leader = (club.Leader.FirstName + " " + club.Leader.LastName).ToLower().Contains(Leader.ToLower());

        return title && department && faculty && schedule && starosta && leader;
    }
}
