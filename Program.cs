// See https://aka.ms/new-console-template for more information

using System.Data;

InterfaceOrientedProgrammingExample();


void InterfaceOrientedProgrammingExample()
{
    var sqlConnection = new SqlServerDbConnection();
    var mongoDbConnection = new MongoDbConnection();

    var db = new Database(sqlConnection);
    
    db.OpenConnection();
    db.CloseConnection();

    db = new Database(mongoDbConnection);
    db.OpenConnection();
    db.CloseConnection();

}

public class Database
{
    private readonly IConnection _connection;

    public Database(IConnection connection)
    {
        _connection = connection;
    }

    public void OpenConnection()
    {
        _connection.Open();
    }

    public void CloseConnection()
    {
        _connection.Close();
    }
}

public interface IConnection
{
    void Open();
    void Close();
}

public class SqlServerDbConnection:IConnection
{
    public void Open()
    {
        Console.WriteLine("Opened SqlServer db connection");
    }

    public void Close()
    {
        Console.WriteLine("Closed SqlServer db connection");

    }
}

public class MongoDbConnection : IConnection
{
    public void Open()
    {
        Console.WriteLine("Opened mongoDb connection");

    }

    public void Close()
    {
        Console.WriteLine("Closed mongoDb db connection");

    }
}
