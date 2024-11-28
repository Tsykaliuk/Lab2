using XML_Manager;

namespace GUI;

public partial class ResultsPage
{
    public void Display()
    {
        for (int i = 1; i <= Clubs.Count; i++)
        {
            DisplayResult(Clubs[i - 1], i);
        }
    }

    private void CreateLabel(int row, int column, string text)
    {
        var label = new Label
        {
            Text = text,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center
        };
        grid.SetRow(label, row);
        grid.SetColumn(label, column);
        grid.Children.Add(label);
    }

    private void DisplayResult(Club club, int row)
    {
        grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        CreateLabel(row, 0, club.Title);
        CreateLabel(row, 1, club.Faculty);
        CreateLabel(row, 2, club.Department);
        CreateLabel(row, 3, club.Schedule.Day + ", " + club.Schedule.Time);
        CreateLabel(row, 4, club.Leader.FirstName + " " + club.Leader.LastName);
        CreateLabel(row, 5, club.Starosta.FirstName + " " + club.Starosta.LastName);
    }
}