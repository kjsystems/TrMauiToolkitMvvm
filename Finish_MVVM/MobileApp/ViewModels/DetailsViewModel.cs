using CommunityToolkit.Mvvm.ComponentModel;
using MobileApp.Models;

namespace MobileApp.ViewModels;

[QueryProperty(nameof(Weather), "Weather")]
public partial class DetailsViewModel : ViewModelBase
{
    [ObservableProperty]
    Weather _weather;
}
