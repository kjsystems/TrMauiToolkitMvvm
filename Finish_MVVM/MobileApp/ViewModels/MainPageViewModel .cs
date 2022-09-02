using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileApp.Models;
using MobileApp.Services;
using MobileApp.Views;

namespace MobileApp.ViewModels;

public partial class MainPageViewModel : ViewModelBase
{
    private readonly IWeatherService _weatherService;

    public ObservableCollection<Weather> Weathers { get; private set; } = new();

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(GetWeathersCommand))]
    private bool _canClick = true;

    [ObservableProperty]
    private bool _isRefreshing;

    [ObservableProperty]
    private Weather _selectedWeather;

    public MainPageViewModel(IWeatherService weatherService)
    {
        Title = "Main Page";
        _weatherService = weatherService;
    }

    [RelayCommand(CanExecute = nameof(CanClick))]
    private async Task GetWeathersAsync()
    {
        CanClick = false;

        Weathers.Clear();
        // サービスの GetWeathersAsync メソッドをコールし、一時的に保存
        var tempWeathers = await _weatherService.GetWeathersAsync();
        // View から参照できるようにプロパティに流し込み
        if (tempWeathers != null)
        {
            foreach (var weather in tempWeathers)
            {
                Weathers.Add(weather);
            }
        }

        CanClick = true;
        IsRefreshing = false;
    }

    [RelayCommand]
    private async void SelectWeather()
    {
        if (SelectedWeather == null)
            return;

        // ダイアログを表示するパターン
        //await Shell.Current.DisplayAlert("Dialog Title", $"{SelectedWeather.Date:yyyy/MM/dd} は {SelectedWeather.Temperature}℃ で {SelectedWeather.Summary} です。", "OK");

        // 詳細画面に遷移するパターン
        await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, object>
        {
            {"Weather", SelectedWeather}
        });
    }
}
