using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using DynamicData;

namespace AvaloniaCrossPlatformApplication1.Views;

public partial class robotUI : UserControl
{
    private List<JsonObject> _users;
    public robotUI(){
        InitializeComponent();
        for (int i = 0; i < 3; i++)
            getJsonData("https://randomuser.me/api/");
    }
    private HttpClient _httpClient;
    private async void getJsonData(string url){
        string resp = null;
        var response = await _httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode) {
            resp = await response.Content.ReadAsStringAsync();
            renderUserToUI(this.FindControl<DockPanel>("dockPanel"),JsonObject.Parse(resp));
            
        }else
            Console.WriteLine("err at response");
    }

    private void renderUserToUI(DockPanel findControl, JsonNode parse) {
        TextBlock tb = new();
        String a = parse["results"][0]["name"].ToString();
        tb.Text = a;
        findControl.Children.Add(tb);
    }

    private void InitializeComponent()
    {
        _users = new();
        _httpClient = new();
        AvaloniaXamlLoader.Load(this);
    }

    private void addUserClick(object sender, RoutedEventArgs e) {
        getJsonData("https://randomuser.me/api/");
        foreach (var el in _users) {
            Console.WriteLine(el);
        }
    }
}