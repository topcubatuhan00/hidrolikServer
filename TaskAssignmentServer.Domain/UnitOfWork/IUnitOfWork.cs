namespace Hidrolik.Domain.UnitOfWork;

public interface IUnitOfWork
{
    IUnitOfWorkAdapter Create();
}
