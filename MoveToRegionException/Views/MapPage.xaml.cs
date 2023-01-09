using Microsoft.Maui.Maps;
using MoveToRegionException.ViewModels;

namespace MoveToRegionException.Views;

public partial class MapPage : ContentPage
{
    private readonly MapPageViewModel _viewModel;

	public MapPage(MapPageViewModel viewModel)
	{
        BindingContext = _viewModel = viewModel;
        InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Map.MoveToRegion(MapSpan.FromCenterAndRadius(
            new Location(_viewModel.City.Latitude,
                _viewModel.City.Longitude), new Distance(100000.0)));
    }
}
