﻿using Microsoft.EntityFrameworkCore;

namespace MiniTaskManager.Model
{
    public class TaskDetails
    {
        
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsCompleted { get; set; } 
    }
}
