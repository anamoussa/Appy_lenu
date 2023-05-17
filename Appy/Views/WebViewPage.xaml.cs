using Appy.Handlers;
using Appy.ViewModels;
using Appy.Views.Dashboard;
using CommunityToolkit.Mvvm.Messaging;

namespace Appy.Views;

public partial class WebViewPage : ContentPage
{
    public WebViewPage(WebViewViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private async void btn_scan_Clicked(object sender, EventArgs e)
    {

        NetworkAccess accessType = Connectivity.Current.NetworkAccess;
        if (accessType != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("Uh Oh!", "No Internet!", "Ok");
        }

        else
        {
            await Navigation.PushModalAsync(new NavigationPage(new CameraViewPage()));
        }
    }
}