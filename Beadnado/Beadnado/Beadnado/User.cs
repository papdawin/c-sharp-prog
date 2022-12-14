using System.Text.Json.Nodes;

namespace Beadnado;

public class User
{
    
    public string firstName;
    public string lastName;
    public string title;
    public string fullName;
    private JsonNode userjson;
    public User(JsonNode userjson){
        this.userjson=userjson;
        title=userjson["results"][0]["name"]["title"].ToString();
        firstName=userjson["results"][0]["name"]["first"].ToString();
        lastName=userjson["results"][0]["name"]["last"].ToString();
        fullName = string.Format("{0}. {1} {2}", title, firstName, lastName);
    }
}