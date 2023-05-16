using Appy.Views.Dashboard;
using BarcodeScanner.Mobile;
using Microsoft.Maui.Controls.Internals;
using System;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace Appy.Views;

public partial class CameraViewPage : ContentPage
{
    private string result = "";
    public CameraViewPage()
    {
        InitializeComponent();
        BarcodeScanner.Mobile.Methods.AskForRequiredPermission();
        Camera.IsEnabled = true;
        Camera.IsScanning = true;
    }


    private void Camera_BarcodeDetected(object sender, BarcodeScanner.Mobile.OnDetectedEventArg args)
    {

        List<BarcodeResult> obj = args.BarcodeResults;
        if (obj.Count != 0)
            result = $"{obj[0].DisplayValue}{Environment.NewLine}";
        //for (int i = 0; i < obj.Count; i++)
        //{
        //    result += $"{obj[i].DisplayValue}{Environment.NewLine}";
        //}
        //Vibration.Vibrate(50);
        string url = $"//{nameof(WebViewPage)}?source={result}";
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            await Shell.Current.GoToAsync(url);
        });
        Camera.IsScanning = false;

    }

    private async void btn_cancel_Clicked(object sender, EventArgs e)
    {
        FlashlightSwitch.IsToggled = false;
        await Shell.Current.GoToAsync($"//{nameof(DashboardPage)}");
    }



    private async void FlashlightSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        try
        {

            if (FlashlightSwitch.IsToggled)
            {
                Camera.TorchOn = true;
            }
            else
                Camera.TorchOn = false;
        }
        catch (Exception ex)
        {
            var x = ex.ToString();
            await Shell.Current.DisplayAlert("Erorr", $"{x} Unable to turn on/off flashlight ", "OK");
        }
    }

    protected override void OnDisappearing()
    {
        FlashlightSwitch.IsToggled = false;
        Camera.IsEnabled = false;
        Camera.IsScanning = false;

    }
    protected override void OnAppearing()
    {
        Camera.IsVisible = true;
        Camera.IsEnabled = true;
        Camera.IsScanning = true;

    }

}