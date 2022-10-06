using MauiAppClient.Services;
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
	}

    async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Debug.WriteLine("");
    }
}

