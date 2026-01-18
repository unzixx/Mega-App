using Avalonia.Controls;
using Avalonia.Interactivity;
using CG.Web.MegaApiClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
namespace MegaApp;
public class SavedAccount {
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
}
public partial class LoginWindow : Window {
    private const string F = "accounts.json";
    private List<SavedAccount> _a = new();
    public LoginWindow() { InitializeComponent(); Load(); }
    private void Load() {
        if (File.Exists(F)) try {
            _a = JsonSerializer.Deserialize<List<SavedAccount>>(File.ReadAllText(F)) ?? new();
            SavedList.ItemsSource = _a.ToList();
        } catch {}
    }
    private async void OnLogin(object sender, RoutedEventArgs e) {
        if (string.IsNullOrEmpty(User.Text) || string.IsNullOrEmpty(Pass.Text)) return;
        try {
            var c = new MegaApiClient();
            await c.LoginAsync(User.Text, Pass.Text);
            if (RememberMe.IsChecked == true && !_a.Any(x => x.Email == User.Text)) {
                _a.Add(new SavedAccount { Email = User.Text, Password = Pass.Text });
                File.WriteAllText(F, JsonSerializer.Serialize(_a));
            }
            new MainWindow(c).Show();
            this.Close();
        } catch (Exception ex) { Err.Text = "Hiba: " + ex.Message; }
    }
    private void OnAccountSelected(object sender, SelectionChangedEventArgs e) {
        if (SavedList.SelectedItem is SavedAccount a) { User.Text = a.Email; Pass.Text = a.Password; }
    }
    private void OnDeleteAccount(object sender, RoutedEventArgs e) {
        if ((sender as Control)?.DataContext is SavedAccount a) {
            _a.Remove(a);
            File.WriteAllText(F, JsonSerializer.Serialize(_a));
            Load();
        }
    }
}
