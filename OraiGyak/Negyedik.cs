using MySql.Data.MySqlClient;

class DBConnect {
    private MySqlConnection connection;
    private string server;
    private string database;
    private string uid;
    private string password;
    public DBConnect() {
        Initialize();
    }
    private void Initialize() {
        server = "localhost";
        database = "freedb_pythonzh";
        uid = "root";
        password = "Admin123";
        string connectionString;
        connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
        connection = new MySqlConnection(connectionString);
    }
    private bool OpenConnection(){
        try {
            connection.Open();
            return true;
        }catch (MySqlException ex) {
            switch (ex.Number) {
                case 0:
                    Console.WriteLine("Cannot connect to server.  Contact administrator");
                    break;
                case 1045:
                    Console.WriteLine("Invalid username/password, please try again");
                    break; 
            }
            return false;
        }
    }
    private bool CloseConnection() {
        try {
            connection.Close();
            return true;
        }
        catch (MySqlException ex) {
            Console.WriteLine(ex);
            return false;
        }
    }
    public List< string >[] Select() {
        string query = "SELECT * FROM users";
        List< string >[] list = new List< string >[3];
        list[0] = new List< string >();
        list[1] = new List< string >();
        list[2] = new List< string >();
        if (this.OpenConnection() == true) {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read()){
                list[0].Add(dataReader["id"] + "");
                list[1].Add(dataReader["name"] + "");
                list[2].Add(dataReader["email"] + "");
            }
            dataReader.Close();
            this.CloseConnection();
            return list;
        }
        else
            return list;
    }
}
class Negyedik
{
    public static void testDB()
    {
        DBConnect dbc = new();
        var res = dbc.Select();
        foreach (var el in res) {
            foreach (var elem in el) {  
                Console.WriteLine(elem);
            
        }
}