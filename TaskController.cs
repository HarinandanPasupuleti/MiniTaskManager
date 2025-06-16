using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;
using MiniTaskManager.DTO_s;
using MiniTaskManager.Model;
using MiniTaskManager.Repositories;

namespace MiniTaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class TaskController : ControllerBase
    {

        private readonly ITasksRepository tasksRepository;

        public TaskController(ITasksRepository tasksRepository)
        {
            this.tasksRepository = tasksRepository;
        }



        [HttpPost]

        public async Task<IActionResult> CreateTask(TaskRequest request)
        {
            var taskDetails = new TaskDetails
            {
                Title = request.Title,
                Description = request.Description,
                DueDate = request.DueDate,
                IsCompleted = request.IsCompleted
            };

            await tasksRepository.CreateAsync(taskDetails);

            var response = new TaskResponse
            {
                Id = taskDetails.Id,
                Title = taskDetails.Title,
                Description = taskDetails.Description,
                DueDate = taskDetails.DueDate,
                IsCompleted = taskDetails.IsCompleted
            };

            return Ok(response);


        }


        [HttpGet]

        public async Task<IActionResult> GetAllTaskDetails()
        {
            var tasks = await tasksRepository.GetAllAsync();

            var response = new List<TaskResponse>();
            foreach (var task in tasks)
            {
                response.Add(new TaskResponse
                {
                    Id = task.Id,
                    Title = task.Title,
                    Description = task.Description,
                    DueDate = task.DueDate,
                    IsCompleted = task.IsCompleted
                });

            }

            return Ok(response);
            
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetTaskDetailsbyId([FromRoute] int id)
        {
            var existing = await tasksRepository.GetById(id);

            if (existing is null)
            {
                return NotFound();
            }

            var response = new TaskResponse
            {
                Id = existing.Id,
                Title = existing.Title,
                Description = existing.Description,
                DueDate = existing.DueDate,
                IsCompleted = existing.IsCompleted

            };

            return Ok(response);

        }

        [HttpPut]
        [Route("{id:int}")]

        public async Task<IActionResult> Updatetask([FromRoute] int id, TaskUpdate request)
        {
            var taskDetails = new TaskDetails
            {
                Id = id,
                Title = request.Title,
                Description = request.Description,
                DueDate = request.DueDate,
                IsCompleted = request.IsCompleted
            };

            taskDetails = await tasksRepository.UpdateAsync(taskDetails);

            if (taskDetails == null)
            {
                return NotFound();
            }

            var response = new TaskResponse
            {
                Id = taskDetails.Id,
                Title = taskDetails.Title,
                Description = taskDetails.Description,
                DueDate = taskDetails.DueDate,
                IsCompleted = taskDetails.IsCompleted

            };

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:int}")]

        public async Task<IActionResult> DeleteTask([FromRoute] int id)
        {
            var existing = await tasksRepository.DeleteAsync(id);
            if (existing == null)
            {
                return NotFound();
            }

            var response = new TaskResponse
            {

                Id= existing.Id,
                Title = existing.Title,
                Description = existing.Description,
                DueDate = existing.DueDate,
                IsCompleted = existing.IsCompleted

            };

            return Ok(response);
        }

    }

    //[HttpDelete]
    //    [Route("{id:int}")]
    //    public async Task<IActionResult> DeleteTask([FromRoute] int id)
    //    {
    //        var existing = await tasksRepository.DeleteAsync(id);
    //        if (existing == null)
    //        {
    //            return NotFound();
    //        }

    //        var response = new TaskResponse
    //        {
    //            Title = existing.Title,
    //            Description = existing.Description,
    //            DueDate = existing.DueDate,
    //            IsCompleted = existing.IsCompleted
    //        };

    //        return Ok(response);
    //    }

    }
