using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Maps;
using MoveToRegionException.Models;

namespace MoveToRegionException.ViewModels;

[QueryProperty(nameof(City), "City")]
public partial class MapPageViewModel : ObservableObject
{
	public MapPageViewModel()
	{
	}

    [ObservableProperty]
    private City _city;
}

