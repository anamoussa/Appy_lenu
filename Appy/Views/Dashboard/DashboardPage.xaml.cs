
using Appy.Services;
using Appy.ViewModels.Dashboard;
using System.Globalization;

namespace Appy.Views.Dashboard;

public partial class DashboardPage : ContentPage
{

    public DashboardPage(DashboardPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        //get current language
       // var xx = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
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