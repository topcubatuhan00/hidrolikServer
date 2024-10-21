using Microsoft.Extensions.Configuration;
using Hidrolik.Domain.UnitOfWork;

namespace Hidrolik.Persistance.UnitOfWorks;

public class UnitOfWorkSqlServer : IUnitOfWork
{
    #region Fields
    private readonly IConfiguration _configuration;
    #endregion

    #region Ctor
    public UnitOfWorkSqlServer
    (
        IConfiguration configuration
    )
    {
        _configuration = configuration;
    }
    #endregion

    #region Methods
    public string GetConnectionString()
    {
        return _configuration.GetConnectionString("TaskAssignmentConnection");
    }
    public IUnitOfWorkAdapter Create()
    {
        var connectionString = GetConnectionString();
        return new UnitOfWorkSqlServerAdapter(connectionString);
    }
    #endregion
}
