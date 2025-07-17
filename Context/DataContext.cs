using Microsoft.Data.SqlClient;

namespace CQRSDemo.Context;

public class DataContext
{
    private readonly IConfiguration _config;
    private readonly string _sqlString;

    public DataContext(IConfiguration config)
    {
        _config = config;
        _sqlString = _config.GetConnectionString("SQLString")!;
    }

    public SqlConnection GetSql()
    {
        return new SqlConnection(_sqlString);
    }

    //ejemplo para otra base de datos, debe ser algo parecido a SqlConnection
    public bool GetMongoDB()
    {
        return true;
    }
}
