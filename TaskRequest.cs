namespace MiniTaskManager.DTO_s
{
    public class TaskRequest
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsCompleted { get; set; }
    }
}
