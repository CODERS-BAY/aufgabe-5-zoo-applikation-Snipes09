using MySqlConnector;
using ZooAPI.controller;

namespace ZooAPI.Service;

public class DBConnectionService
{    
    private DBConnection _dbConnection;

  
    public DBConnectionService()
    {
        _dbConnection = new DBConnection();
    }


    public async Task<MySqlConnection> GetConnection()
    {
        if (_dbConnection == null){
            _dbConnection = new DBConnection();
        }
        return await _dbConnection.GetConnection();
    }
}