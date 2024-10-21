using Hidrolik.Domain.Repositories.AuthRepositories;
using Hidrolik.Domain.Repositories.AutoReminderRepositories;
using Hidrolik.Domain.Repositories.CommentRepositories;
using Hidrolik.Domain.Repositories.MissionRepositories;
using Hidrolik.Domain.Repositories.NotificationRepositories;
using Hidrolik.Domain.Repositories.TicketRepositories;
using Hidrolik.Domain.Repositories.UserRepositories;

namespace Hidrolik.Domain.UnitOfWork;

public interface IUnitOfWorkRepository
{
    #region MissionRepositories
    IMissionCommandRepository missionCommandRepository { get; }
    IMissionQueryRepository missionQueryRepository { get; }
    #endregion

    #region AuthRepositories
    IAuthCommandRepository authCommandRepository { get; }
    IAuthQueryRepository authQueryRepository { get; }
    #endregion
    
    #region ReminderRepositories
    IAutoReminderCommandRepository autoReminderCommandRepository { get; }
    IAutoReminderQueryRepository autoReminderQueryRepository{ get; }
    #endregion

    #region CommentRepositories
    ICommentCommandRepository commentCommandRepository { get; }
    ICommentQueryRepository commentQueryRepository { get; }
    #endregion

    #region TicketRepositories
    ITicketCommandRepository ticketCommandRepository { get; }
    ITicketQueryRepository ticketQueryRepository { get; }
    #endregion

    #region UserRepositories
    IUserCommandRepository userCommandRepository { get; }
    IUserQueryRepository userQueryRepository { get; }
    #endregion

    #region NotifRepositories
    INotificationCommandRepository notificationCommandRepository { get; }
    INotificationQueryRepository notificationQueryRepository { get; }
    #endregion
}
