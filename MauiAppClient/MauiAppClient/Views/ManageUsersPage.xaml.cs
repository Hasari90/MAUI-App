using MauiAppClient.Models;
using MauiAppClient.Services;
using System.Diagnostics;

namespace MauiAppClient.Views;

[QueryProperty(nameof(User), "User")]
public partial class ManageUsersPage : ContentPage
{
	private readonly IRestDataService dataService;
    User _user;
    bool _isNew;

    public User User
    {
        get => _user;
        set
        {
            _isNew = IsNew(value);
            _user = value;
            OnPropertyChanged();
        }
    }

    public ManageUsersPage(IRestDataService dataService)
	{
		InitializeComponent();

		this.dataService = dataService;
		BindingContext = this;
	}

    bool IsNew(User user)
    {
        if (user.Id == 0)
            return true;
        return false;
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        if (_isNew)
        {
            Debug.WriteLine("---> Add new user");
            await dataService.AddUserAsync(User);

        }
        else
        {
            Debug.WriteLine("---> Update an user");
            await dataService.UpdateUserAsync(User);
        }

        await Shell.Current.GoToAsync("..");

    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        await dataService.DeleteUserAsync(User.Id);
        await Shell.Current.GoToAsync("..");
    }

    async void OnCancelButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}