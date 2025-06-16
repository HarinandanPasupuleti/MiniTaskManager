
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MiniTaskManager.Controllers;
using MiniTaskManager.DTO_s;
using MiniTaskManager.Model;

namespace MiniTaskManager.Repositories
{
    public class TasksRepository : ITasksRepository
    {

        private readonly TaskDbContext DbContext;

        public TasksRepository(TaskDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<TaskDetails> CreateAsync(TaskDetails taskDetails)
        {
            await DbContext.Tasks.AddAsync(taskDetails);
            await DbContext.SaveChangesAsync();

            return taskDetails;
        }

        public async Task<IEnumerable<TaskDetails>> GetAllAsync()
        {
            return (IEnumerable<TaskDetails>)await DbContext.Tasks.ToListAsync();
        }

        public async Task<TaskDetails?> GetById(int id)
        {
            return await DbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TaskDetails> UpdateAsync(TaskDetails taskDetails)
        {
            var existing = await DbContext.Tasks.FirstOrDefaultAsync(x => x.Id == taskDetails.Id);

            if (existing != null)
            {

                DbContext.Entry(existing).CurrentValues.SetValues(taskDetails);
                await DbContext.SaveChangesAsync();

                return taskDetails;
            }

            return null;
        }

        public async Task<TaskDetails> DeleteAsync(int id)
        {
            var existing = await DbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);

            if (existing is null)
            {
                return null;
            }

            DbContext.Tasks.Remove(existing);
            await DbContext.SaveChangesAsync();
            return existing;
        }


    }
}
