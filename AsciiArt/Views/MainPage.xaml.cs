﻿using AsciiArt.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;
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
        InitializeComponent();
        ViewModel = App.GetService<MainViewModel>();
        
    }

    // See code references here
    // https://learn.microsoft.com/en-us/windows/apps/design/input/drag-and-drop
    // https://stackoverflow.com/questions/77298989/how-to-drag-and-drop-external-files-into-winui3-apps
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
