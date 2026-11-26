using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DotnetAPI.Data;

public class DataContextDapper(IConfiguration config)
{
    private readonly IConfiguration _configuration = config;

    public IEnumerable<T> LoadData<T>(string sqlCmd)
    {
        IDbConnection dbConnection = new SqlConnection(config.GetConnectionString("DefaultConnection"));
        return dbConnection.Query<T>(sqlCmd);
    }
    
    public T LoadDataSingle<T>(string sqlCmd)
    {
        IDbConnection dbConnection = new SqlConnection(config.GetConnectionString("DefaultConnection"));
        return dbConnection.QuerySingle<T>(sqlCmd);
    }

    public bool ExecuteQuery(string sql)
    {
        IDbConnection dbConnection = new SqlConnection(config.GetConnectionString("DefaultConnection"));
        return dbConnection.Execute(sql) > 0;
    }

    public int ExecuteSqlWithRowCount(string sql)
    {
        IDbConnection dbConnection = new SqlConnection(config.GetConnectionString("DefaultConnection"));
        return dbConnection.Execute(sql);
    }
}