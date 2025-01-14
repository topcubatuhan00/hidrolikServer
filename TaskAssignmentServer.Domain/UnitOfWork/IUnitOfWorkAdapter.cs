﻿namespace Hidrolik.Domain.UnitOfWork;

public interface IUnitOfWorkAdapter : IDisposable
{
    IUnitOfWorkRepository Repositories { get; }
    void SaveChanges();
}
