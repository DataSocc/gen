using System;

namespace CleanArchNet.Domain.Entities
{
    public class TodoItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
