using XML_Manager;

namespace GUI;

public partial class ResultsPage : ContentPage
{
    private IList<Club> Clubs { get; set; }
    public ResultsPage(IList<Club> clubs)
    {
        InitializeComponent();
        Clubs = clubs;
        Display();
    }
}