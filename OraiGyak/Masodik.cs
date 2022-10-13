using System.Text.Json.Nodes;

namespace DefaultNamespace;

public class Masodik
{
    static String[] cities =
        { "ROME", "LONDON", "NAIROBI", "CALIFORNIA", "ZURICH", "NEW DELHI", "AMSTERDAM", "ABU DHABI", "PARIS" };
    public static async void linqExcercise()
    {
        Console.WriteLine("Simple approach:");
        simpleApproach();
        Console.WriteLine("Advanced approach:");
        advancedApproach().Wait();
    }

    static private List<string> countryList = new List<string>();
    private static async Task advancedApproach()
    {
        string resp = null;
        var client = new HttpClient();
        var response = await client.GetAsync("https://restcountries.com/v3.1/all");
        if (response.IsSuccessStatusCode)
        {
            resp = await response.Content.ReadAsStringAsync();
        }

        JsonArray? content = JsonObject.Parse(resp).AsArray();
        foreach (JsonNode? elem in content){
            countryList.Add(elem["name"]["common"].ToString());
        }

        var res = from county in countryList
            where county.StartsWith("N")
            select county;
        foreach (string el in res){
            Console.WriteLine(el);
        }
    }

    private static void simpleApproach()
    {
        IEnumerable<string> citiesThatStartWithN = 
            from city in cities 
            where city.StartsWith("N") 
            select city;
        foreach (string city in citiesThatStartWithN)
        {
            Console.WriteLine(city);
        }
    }
}