using AsciiArt.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace AsciiArt.Views;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
    }
}
