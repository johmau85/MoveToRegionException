using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;
using MoveToRegionException.Models;
using MoveToRegionException.Views;
using MoveToRegionException.Services;

namespace MoveToRegionException.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    private readonly ILogger<MainPageViewModel> _logger;
    private readonly DataService _dataService;

    public MainPageViewModel(ILogger<MainPageViewModel> logger, DataService dataService)
    {
        _logger = logger;
        _dataService = dataService;
    }

    public ObservableCollection<City> Cities { get; } = new();

    [ObservableProperty]
    bool isBusy;

    [ObservableProperty]
    bool isRefreshing;

    [RelayCommand]
    public void GetCities()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;

            IEnumerable<City> data = _dataService.GetCities();

            if (data.Any())
            {
                Cities.Clear();

                foreach (var city in data)
                    Cities.Add(city);
            }

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unable to get cities");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }
    }

    [ObservableProperty]
    private City selectedCity = null;

    async partial void OnSelectedCityChanged(City value)
    {
        await GoToDetails(value);
        SelectedCity = null;
    }


    [RelayCommand]
    private async Task GoToDetails(City city)
    {
        if (city == null)
            return;

        await Shell.Current.GoToAsync(nameof(MapPage), true, new Dictionary<string, object>
        {
            {"City", city }
        });
    }
}

