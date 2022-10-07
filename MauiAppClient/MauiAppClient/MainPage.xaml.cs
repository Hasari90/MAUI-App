using MauiAppClient.Models;
using MauiAppClient.Services;
using MauiAppClient.Views;
using System.Diagnostics;
using Debug = System.Diagnostics.Debug;

namespace MauiAppClient;

public partial class MainPage : ContentPage
{
	private IRestDataService _dataService;

	public MainPage(IRestDataService dataService)
	{
		InitializeComponent();

		_dataService = dataService;
	}

	protected async override void OnAppearing()
	{
		base.OnAppearing();

        collectionView.ItemsSource = await _dataService.GetAllUsersAsync();
	}

	async void OnAddUserClicked(object sender, EventArgs e)
	{
		Debug.WriteLine("");

		var navigationParametr = new Dictionary<string, object>
		{
			{nameof(User), new User()}
		};

		await Shell.Current.GoToAsync(nameof(ManageUsersPage), navigationParametr);
	}

    async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Debug.WriteLine("");

        var navigationParametr = new Dictionary<string, object>
        {
            {nameof(User), e.CurrentSelection.FirstOrDefault() as User}
        };

        await Shell.Current.GoToAsync(nameof(ManageUsersPage), navigationParametr);
    }
}

