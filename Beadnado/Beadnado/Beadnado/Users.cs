using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Avalonia.Controls;

namespace Beadnado;
public class Users : IEnumerable<User>
{
    public IEnumerator<User> GetEnumerator()
    {
        return _users.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private readonly StackPanel _usersPanel; // where to render
    private List<User> _users;
    private const string _url = "https://randomuser.me/api/";
    
    public Users(int usersToInitialize, StackPanel usersPanel) //numberOfStartingUsers, whereToRenderUsers
    {
        _users = new();
        this._usersPanel = usersPanel;
        for (int i = 0; i < usersToInitialize; i++)
            AddUser();
    }
    public async Task AddUser()
    {
        HttpClient _httpClient = new HttpClient();
        string resp = null;
        var response = await _httpClient.GetAsync(_url);
        if (response.IsSuccessStatusCode) {
            resp = await response.Content.ReadAsStringAsync();
            _users.Add(new User(JsonObject.Parse(resp)));
        } else
            throw new Exception("No response");
        RenderUsers();
    }
    public void RenderUsers()
    {
        _usersPanel.Children.Clear();
        foreach (User user in _users) {
            TextBlock tb = new TextBlock();
            tb.Text = user.fullName;
            _usersPanel.Children.Add(tb);
        }
    }
    public User GetUser(int index)
    {
        return _users.ToArray()[index];
    }
    public int GetUsercount()
    {
        return _users.Count;
    }
    

    
}