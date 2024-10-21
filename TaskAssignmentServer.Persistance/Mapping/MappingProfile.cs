using AutoMapper;
using Hidrolik.Domain.Entities;
using Hidrolik.Domain.Models.AutoReminder;
using Hidrolik.Domain.Models.CommentModels;
using Hidrolik.Domain.Models.MissionModels;
using Hidrolik.Domain.Models.NotificationModels;
using Hidrolik.Domain.Models.TicketModels;
using Hidrolik.Domain.Models.UserModels;

namespace Hidrolik.Persistance.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region Mission
        CreateMap<Mission, CreateMissionModel>().ReverseMap();
        CreateMap<Mission, UpdateMissionModel>().ReverseMap();
        #endregion

        #region Reminder
        CreateMap<AutoReminder, CreateReminderModel>().ReverseMap();
        CreateMap<AutoReminder, UpdateReminderModel>().ReverseMap();
        #endregion

        #region User
        CreateMap<User, CreateUserModel>().ReverseMap();
        CreateMap<User, UpdateUserModel>().ReverseMap();
        #endregion

        #region Comment
        CreateMap<Comment, CreateCommentModel>().ReverseMap();
        CreateMap<Comment, UpdateCommentModel>().ReverseMap();
        #endregion

        #region Ticket
        CreateMap<Ticket, CreateTicketModel>().ReverseMap();
        CreateMap<Ticket, UpdateTicketModel>().ReverseMap();
        #endregion

        #region Notify
        CreateMap<Notification, CreateNotificationModel>().ReverseMap();
        #endregion
    }
}
