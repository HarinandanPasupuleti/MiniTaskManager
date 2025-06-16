using MiniTaskManager.DTO_s;
using MiniTaskManager.Model;

namespace MiniTaskManager.Repositories
{
    public interface ITasksRepository
    {

        Task<TaskDetails> CreateAsync(TaskDetails taskDetails);
        Task<IEnumerable<TaskDetails>> GetAllAsync();

        Task<TaskDetails?> GetById(int id);

        Task<TaskDetails> UpdateAsync(TaskDetails taskDetails);

        Task<TaskDetails> DeleteAsync(int id);
    }
}
