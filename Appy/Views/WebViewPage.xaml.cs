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
        string text = "";
#if __ANDROID__
        text= FontAwesomeIcons.Chrome;
#elif __IOS__
        text= FontAwesomeIcons.Safari;
#else
        text = FontAwesomeIcons.Edge;
#endif
        browser_btn.Text = text;
    }
}