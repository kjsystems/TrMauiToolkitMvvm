using MobileApp.ViewModels;

namespace MobileApp.Views;

public partial class DetailsPage : ContentPage
{
    public DetailsPage(DetailsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}