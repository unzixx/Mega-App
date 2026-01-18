using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using CG.Web.MegaApiClient;
using System;
using System.Linq;
using System.Collections.Generic;
namespace MegaApp;
public partial class MainWindow : Window {
    private MegaApiClient _c;
    private INode? _r;
    public MainWindow(MegaApiClient c) { InitializeComponent(); _c = c; Load(); }
    private async void Load() {
        try {
            Status.Text = "Frissítés...";
            var n = await _c.GetNodesAsync();
            _r = n.First(x => x.Type == NodeType.Root);
            FileList.ItemsSource = n.Where(x => x.ParentId == _r.Id && x.Type == NodeType.File).ToList();
            Status.Text = "Kész";
        } catch { Status.Text = "Hiba"; }
    }
    private void OnRefresh(object s, RoutedEventArgs e) => Load();
    private async void OnUp(object s, RoutedEventArgs e) {
        if (_r == null) return;
        var f = await StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions());
        if (f.Count > 0) {
            using var str = await f[0].OpenReadAsync();
            await _c.UploadAsync(str, f[0].Name, _r, progress: new Progress<double>(v => PBar.Value = v));
            PBar.Value = 0; Load();
        }
    }
    private async void OnDown(object s, RoutedEventArgs e) {
        if (FileList.SelectedItem is INode n) {
            var f = await StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions { SuggestedFileName = n.Name });
            if (f != null) {
                using var str = await f.OpenWriteAsync();
                var d = await _c.DownloadAsync(n, new Progress<double>(v => PBar.Value = v));
                await d.CopyToAsync(str);
                PBar.Value = 0;
            }
        }
    }
    private async void OnLogout(object s, RoutedEventArgs e) {
        await _c.LogoutAsync();
        new LoginWindow().Show();
        this.Close();
    }
}
