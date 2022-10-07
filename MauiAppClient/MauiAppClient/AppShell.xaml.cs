using MauiAppClient.Views;

namespace MauiAppClient;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(ManageUsersPage), typeof(ManageUsersPage));
	}
}
