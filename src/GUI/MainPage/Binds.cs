using XML_Manager;
using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace GUI;

public partial class MainPage : ContentPage
{
	private string activitiesXSL = "D:\\study\\visual studio\\c#\\univ\\Lab2\\src\\GUI\\activities.xsl";

    private async void ExitButton_Clicked(object sender, EventArgs e)
	{
		var option = await DisplayAlert("Confirm exit", "Are you sure tou want to exit the program ?", "Yes", "No");
		if (option)
		{
			System.Environment.Exit(0);
		}
	}

	private async void OpenButton_Clicked(object sender, EventArgs e)
	{
		var customFileType = new FilePickerFileType(
				new Dictionary<DevicePlatform, IEnumerable<string>>
				{
					{ DevicePlatform.WinUI, new[] { "xml" } },
				});
		var options = new PickOptions() { PickerTitle = "Select xml file with books", FileTypes = customFileType };
		ChosenFile = await filePicker.PickAsync(options);
		StatusLabel.Text = "Chosen file: " + ChosenFile.FileName;
	}

	private async void ExportButton_Clicked(object sender, EventArgs e)
	{
		if (ChosenFile == null)
		{
			await DisplayAlert("Error", "Input file is not chosen", "I'm sorry");
			return;
		}

		if (exporter == null)
		{
			exporter = new();
			exporter.Load(activitiesXSL);
		}

		using var stream = new MemoryStream(Encoding.Default.GetBytes(""));
		var result = await fileSaver.SaveAsync(ChosenFile.FileName.Split(".")[0] + ".html", stream, new CancellationTokenSource().Token);
		exporter.Transform(ChosenFile.FullPath, result.FilePath);
		await DisplayAlert("Success", "File was exported successfully", "Ok");
	}

	private async void FindButton_Clicked(object sender, EventArgs e)
	{
		if (ChosenFile == null)
		{
			await DisplayAlert("Error", "Input file is not chosen", "I'm sorry");
			return;
		}

		if (parser == null)
		{
			await DisplayAlert("Error", "Parser type is not chosen", "I'm sorry");
			return;
		}

		var filterOptions = CollectFilters();

		var results = parser.Find(filterOptions);

		await Navigation.PushAsync(new ResultsPage(results));
	}

	private void ClearButton_Clicked(object sender, EventArgs e)
	{
		ClearFilters();
	}

	private async void Parser_Selected(object sender, EventArgs e)
	{
		switch (ParserPicker.SelectedIndex)
		{
			case 0:
				parser = new SAXParser();
				break;
			case 1:
				parser = new DOMParser();
				break;
			case 2:
				parser = new LINQParser();
				break;
		}
		await ValidateFile();
	}
}
