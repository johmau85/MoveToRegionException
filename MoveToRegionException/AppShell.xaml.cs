using MoveToRegionException.Views;

namespace MoveToRegionException;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(MapPage), typeof(MapPage));
    }
}

