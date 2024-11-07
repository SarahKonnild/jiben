using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace JiBen.Server.Data.Test;

public partial class DatabaseTest : IDisposable
{
    private readonly SqliteConnection _connection;
    private readonly JiBenDbContext _jiBenDbContext;
    private readonly ILogger<Repository.Repository> _loggerMock = Substitute.For<ILogger<Repository.Repository>>();
    private readonly Repository.Repository _repository;
    private bool _disposed;

    public DatabaseTest()
    {
        _connection = new SqliteConnection("DataSource=../../../JiBen.Server.Data.Test/TestDbs/test.db");

        var options = new DbContextOptionsBuilder<JiBenDbContext>()
            .UseSqlite(_connection)
            .Options;

        _jiBenDbContext = new JiBenDbContext(options);
        _jiBenDbContext.Database.EnsureCreated();

        _repository = new Repository.Repository(_loggerMock, _jiBenDbContext);
    }

    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        _disposed = true;
        _connection.Close();
        _jiBenDbContext.Database.EnsureDeleted();
        _jiBenDbContext.Dispose();
        GC.SuppressFinalize(this);
    }
}