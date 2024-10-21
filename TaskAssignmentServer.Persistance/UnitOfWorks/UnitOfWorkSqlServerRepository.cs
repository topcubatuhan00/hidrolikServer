using Microsoft.Data.SqlClient;
using Hidrolik.Domain.Repositories.AuthRepositories;
using Hidrolik.Domain.Repositories.AutoReminderRepositories;
using Hidrolik.Domain.Repositories.CommentRepositories;
using Hidrolik.Domain.Repositories.MissionRepositories;
using Hidrolik.Domain.Repositories.NotificationRepositories;
using Hidrolik.Domain.Repositories.TicketRepositories;
using Hidrolik.Domain.Repositories.UserRepositories;
using Hidrolik.Domain.UnitOfWork;
using Hidrolik.Persistance.Repositories.AppRepositories.AuthRepositories;
using Hidrolik.Persistance.Repositories.AppRepositories.AutoReminderRepositories;
using Hidrolik.Persistance.Repositories.AppRepositories.CommentRepositories;
using Hidrolik.Persistance.Repositories.AppRepositories.MissionRepositories;
using Hidrolik.Persistance.Repositories.AppRepositories.NotificationRepositories;
using Hidrolik.Persistance.Repositories.AppRepositories.TicketRepositories;
using Hidrolik.Persistance.Repositories.AppRepositories.UserRepositories;

namespace Hidrolik.Persistance.UnitOfWorks;

public class UnitOfWorkSqlServerRepository : IUnitOfWorkRepository
{
    #region Fields

    #region Mission
    public IMissionCommandRepository missionCommandRepository { get; }
    public IMissionQueryRepository missionQueryRepository { get; }
    #endregion

    #region Auth
    public IAuthCommandRepository authCommandRepository { get; }
    public IAuthQueryRepository authQueryRepository { get; }
    #endregion

    #region AutoReminder
    public IAutoReminderCommandRepository autoReminderCommandRepository { get; }
    public IAutoReminderQueryRepository autoReminderQueryRepository{ get; }
    #endregion

    #region TicketReminder
    public ITicketCommandRepository ticketCommandRepository { get; }
    public ITicketQueryRepository ticketQueryRepository { get; }
    #endregion

    #region CommentReminder
    public ICommentCommandRepository commentCommandRepository { get; }
    public ICommentQueryRepository commentQueryRepository { get; }
    #endregion

    #region UserReminder
    public IUserCommandRepository userCommandRepository { get; }
    public IUserQueryRepository userQueryRepository { get; }
    #endregion

    #region UserReminder
    public INotificationCommandRepository notificationCommandRepository { get; }
    public INotificationQueryRepository notificationQueryRepository { get; }
    #endregion

    #endregion

    #region Ctor
    public UnitOfWorkSqlServerRepository
    (
        SqlConnection context,
        SqlTransaction transaction
    )
    {
        missionCommandRepository = new MissionCommandRepository(context, transaction);
        missionQueryRepository = new MissionQueryRepository(context, transaction);
        authCommandRepository = new AuthCommandRepository(context, transaction);
        authQueryRepository = new AuthQueryRepository(context, transaction);
        autoReminderCommandRepository = new AutoReminderCommandRepository(context, transaction);
        autoReminderQueryRepository = new AutoReminderQueryepository(context, transaction);
        ticketCommandRepository = new TicketCommandRepository(context, transaction);
        ticketQueryRepository = new TicketQueryRepository(context, transaction);
        commentCommandRepository = new CommentCommandRepository(context, transaction);
        commentQueryRepository = new CommentQueryRepository(context, transaction);
        userCommandRepository = new UserCommandRepository(context, transaction);
        userQueryRepository = new UserQueryRepository(context, transaction);
        notificationCommandRepository = new NotificationCommandRepository(context, transaction);
        notificationQueryRepository = new NotificationQueryRepository(context, transaction);
    }
    #endregion
}
