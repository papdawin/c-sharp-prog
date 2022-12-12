using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;
using DynamicData;

namespace AvaloniaCrossPlatformApplication1.Views;

public partial class robotUI : UserControl
{
    private List<JsonNode> _users;
    public robotUI(){
        InitializeComponent();
        for (int i = 0; i < 3; i++)
            getJsonData("https://randomuser.me/api/");
    }
    private void addUserClick(object sender, RoutedEventArgs e) {
        getJsonData("https://randomuser.me/api/");
    }
    private HttpClient _httpClient;
    private async void getJsonData(string url){
        string resp = null;
        var response = await _httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode) {
            resp = await response.Content.ReadAsStringAsync();
            renderUserToUI(this.FindControl<StackPanel>("stackPanel"),JsonObject.Parse(resp));
        }else
            Console.WriteLine("err at response");
    }
    private void renderUserToUI(StackPanel findControl, JsonNode parse) {
        _users.Add(parse);
        DockPanel panel = new();
        TextBlock tb = new();
        String user = "";
        user += parse["results"][0]["name"]["first"] + " ";
        user += parse["results"][0]["name"]["last"].ToString();
        tb.Text = user;
        panel.Children.Add(tb);
        findControl.Children.Add(panel);
    }

    private void InitializeComponent()
    {
        _users = new();
        _httpClient = new();
        AvaloniaXamlLoader.Load(this);
    }


    private void playAgainst(object sender, RoutedEventArgs e) {
        Console.WriteLine(_users.Count);
        Random random = new Random();
        int rndnum = random.Next(0, _users.Count-1);
        JsonNode player1 = _users.ToArray()[rndnum];
        String p1 = player1["results"][0]["name"]["last"].ToString();
        rndnum = random.Next(0, _users.Count-1);
        JsonNode player2 = _users.ToArray()[rndnum];
        String p2 = player2["results"][0]["name"]["last"].ToString();
        int dobas1 = random.Next(0, 6);
        int dobas2 = random.Next(0, 6);
        String data = "player "+p1+" scored ["+ dobas1 +"] against: ";
        data += p2+", who rolled ["+ dobas2 +"]";
        renderResultToUI(this.FindControl<StackPanel>("resultPanel"),data);
        saveToDB(p1,dobas1,p2,dobas2);
    }

    private void saveToDB(String player1, int dobas1, String player2, int dobas2)
    {
        DBConnector dbc = new();
        dbc.Insert(player1,player2,dobas1,dobas2);
    }

    private void renderResultToUI(StackPanel findControl, String data)
    {
        TextBlock tb = new();
        tb.Text = data;
        findControl.Children.Add(tb);
    }
}
