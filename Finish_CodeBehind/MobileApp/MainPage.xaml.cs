using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http.Json;

namespace MobileApp;

public partial class MainPage : ContentPage
{
    public ObservableCollection<Weather> Weathers = new();

    bool _firstAppearing = true;

    public MainPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (_firstAppearing)
            GetWeathersAsync();

        _firstAppearing = false;
    }

    private void GetWeathersButtonOnClicked(object sender, EventArgs e)
    {
        GetWeathersAsync();
    }

    private void PullToRefreshing(object sender, EventArgs e)
    {
        button.IsEnabled = false;

        GetWeathersAsync();
        refreshView.IsRefreshing = false;

        button.IsEnabled = true;
    }

    private void SwitchOnToggled(object sender, ToggledEventArgs e)
    {
        button.IsEnabled = e.Value;
        refreshView.IsEnabled = e.Value;
    }

    private async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count == 0)
            return;

        var current = e.CurrentSelection.FirstOrDefault() as Weather;
        collectionView.SelectedItem = null;

        var message = $"{current?.Date:yyyy/MM/dd} は {current?.Temperature}℃ で {current?.Summary} です。";
        await Shell.Current.DisplayAlert("weather", message, "OK");
    }

    void GetWeathersAsync()
    {
        Weathers.Clear();

        Weathers = new ObservableCollection<Weather>
            {
                new Weather
                {
                    Date = new DateTime(2020,11,1),
                    Summary = "Rainy",
                    Temperature = 20
                },
                new Weather
                {
                    Date = new DateTime(2020,11,2),
                    Summary = "Cloudy",
                    Temperature = 25
                },
                new Weather
                {
                    Date = new DateTime(2020,11,3),
                    Summary = "Sunny",
                    Temperature = 30
                }
            };

        BindingContext = Weathers;
    }


    //static HttpClient _httpClient = new HttpClient();
    //async Task GetWeathersAsync()
    //{
    //    Weathers.Clear();

    //    try
    //    {
    //        // サイトからデータを取得
    //        var response = await _httpClient.GetAsync("https://weatherforecastsampleforprism.azurewebsites.net/weatherforecast");
    //        // レスポンスコード（200 など）を確認
    //        response.EnsureSuccessStatusCode();

    //        // レスポンスからコンテンツ（JSON）を取得
    //        Weathers = await response.Content.ReadFromJsonAsync<ObservableCollection<Weather>>();
    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.WriteLine(ex.Message);
    //    }

    //    BindingContext = Weathers;
    //}
}

