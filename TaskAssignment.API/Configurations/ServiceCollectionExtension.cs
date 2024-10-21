using Hidrolik.Application.Services;
using Hidrolik.Domain.UnitOfWork;
using Hidrolik.Persistance.Mapping;
using Hidrolik.Persistance.Services;
using Hidrolik.Persistance.UnitOfWorks;

namespace Hidrolik.API.Configurations;

public static class ServiceCollectionExtension
{
    public static IServiceCollection ApplicationServiceConfigurations(this IServiceCollection services)
    {
        #region AppScopes
        services.AddScoped<IMissionService, MissionService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IAutoReminderService, AutoReminderService>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<ITicketService, TicketService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<INotificationService, NotificationService>();
        #endregion

        #region Utilities
        services.AddTransient<IUnitOfWork, UnitOfWorkSqlServer>();
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddEndpointsApiExplorer();
        services.AddControllers();
        #endregion

        return services;
    }
}
