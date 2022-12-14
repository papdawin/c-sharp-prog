using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Beadnado;

namespace AvaloniaCrossPlatformApplication1.Views;

public partial class robotUI : UserControl
{
    private Users users;
    public robotUI()
    {
        InitializeComponent();
        users = new Users(2,this.FindControl<StackPanel>("stackPanel"));
    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
    private async void addUserClick(object sender, RoutedEventArgs e) {
        await users.AddUser();
        users.RenderUsers();
    }
    private void playAgainst(object sender, RoutedEventArgs e) 
    {
        Random random = new Random();
        User player1 = users.GetUser(random.Next(0, users.GetUsercount() - 1));
        User player2 = users.GetUser(random.Next(0, users.GetUsercount() - 1));
        int roll1 = random.Next(1, 6);
        int roll2 = random.Next(1, 6);
        TextBlock tb = new();
        tb.Text = string.Format("( {0} rolled [{1}] )\n", player1.fullName, roll1);
        tb.Text += string.Format("( {0} rolled [{1}] )\n", player2.fullName, roll2);
        if (roll2 < roll1)
            tb.Text += string.Format("\t--{0} won", player1.lastName);
        else
            tb.Text += string.Format("\t--{0} won", player2.lastName);
        this.FindControl<StackPanel>("resultPanel").Children.Add(tb);
        
        DBConnector dbc = new();
        dbc.Insert(player1.fullName,player2.fullName,roll1,roll2);
    }

}