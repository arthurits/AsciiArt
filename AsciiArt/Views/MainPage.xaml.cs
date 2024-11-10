using AsciiArt.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;

namespace AsciiArt.Views;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        InitializeComponent();
        ViewModel = App.GetService<MainViewModel>();
        
    }

    private void Grid_DragOver(object sender, DragEventArgs e)
    {
        e.AcceptedOperation = DataPackageOperation.Copy;
    }

    private async void Grid_Drop(object sender, DragEventArgs e)
    {
        if (e.DataView.Contains(StandardDataFormats.StorageItems))
        {
            var items = await e.DataView.GetStorageItemsAsync();
            if (items.Count > 0)
            {
                var storageFile = items[0] as StorageFile;
                var bitmapImage = new BitmapImage();
                bitmapImage.SetSource(await storageFile.OpenAsync(FileAccessMode.Read));
                // Set the image on the main page to the dropped image
                Image.Source = bitmapImage;
            }
        }
    }
}
