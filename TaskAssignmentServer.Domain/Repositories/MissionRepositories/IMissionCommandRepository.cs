using Hidrolik.Domain.Models.MissionModels;

namespace Hidrolik.Domain.Repositories.MissionRepositories;

public interface IMissionCommandRepository
{
    Task CreateTaskAsync(CreateMissionModel model);
    Task UpdateTaskAsync(UpdateMissionModel model);
    Task RemoveTaskByIdAsync(int taskId);
}
