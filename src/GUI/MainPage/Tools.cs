using XML_Manager;

namespace GUI;

public partial class MainPage : ContentPage
{
	private FilterOptions CollectFilters()
	{
		var filters = new FilterOptions();
		if (TitleCheckbox.IsChecked)
		{
			filters.Title = TitleEntry.Text ?? "";
		}

		if (FacultyCheckbox.IsChecked)
		{
			filters.Faculty = FacultyEntry.Text ?? "";
		}

		if (DepartmentCheckbox.IsChecked)
		{
			filters.Department = DepartmentEntry.Text ?? "";
		}

		if (ScheduleCheckbox.IsChecked)
		{
			filters.Schedule = ScheduleEntry.Text ?? "";
		}

		if (LeaderCheckbox.IsChecked)
		{
			filters.Leader = LeaderEntry.Text ?? "";
		}

		if (StarostaCheckbox.IsChecked)
		{
			filters.Starosta = StarostaEntry.Text ?? "";
		}

		return filters;
	}

	private void ClearFilters()
	{
		TitleEntry.Text = "";
		TitleCheckbox.IsChecked = false;
		DepartmentEntry.Text = "";
		DepartmentCheckbox.IsChecked = false;
		FacultyEntry.Text = "";
		FacultyCheckbox.IsChecked = false;
		ScheduleEntry.Text = "";
		ScheduleCheckbox.IsChecked = false;
		LeaderEntry.Text = "";
		LeaderCheckbox.IsChecked = false;
		StarostaEntry.Text = "";
		StarostaCheckbox.IsChecked = false;
	}

	private async Task ValidateFile()
	{
		if (parser == null || ChosenFile == null)
		{
			return;
		}
		if (parser.Load(await ChosenFile.OpenReadAsync(), validationSettings))
		{
			return;
		}

		StatusLabel.Text = "File is not chosen";
		ChosenFile = null;
		await DisplayAlert("Invalid file", "The file does not satisfy XSD Schema", "Ok");
	}
}
