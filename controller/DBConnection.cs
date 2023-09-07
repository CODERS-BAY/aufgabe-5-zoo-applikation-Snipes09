using MySqlConnector;

namespace ZooAPI.controller;

public class DBConnection
{
    private  MySqlConnection Connection{get;set;}
    private readonly string constr = "Server=192.168.86.128;Database=Zoo;UserID=Snipes;Password=mariadb;SslMode=Disabled";
  
    public DBConnection(MySqlConnection connection)
    {
        Connection = connection;
    }
  
    public DBConnection(string connectionString)
    {
        Connection = new MySqlConnection(connectionString);
    }

    public DBConnection()
    {        
        Connection = new MySqlConnection(constr);
    }

       
    public async Task<MySqlConnection> GetConnection()
    {
        Connection = new MySqlConnection(constr);
        await Connection.OpenAsync();
        return  Connection;
    }
    
}