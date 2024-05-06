using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchNet.Domain.Entities;

namespace CleanArchNet.Domain.Interfaces
{
    public interface ITodoRepository
    {
        Task<IEnumerable<TodoItem>> GetAllAsync();
        Task<TodoItem> GetByIdAsync(Guid id);
        Task<TodoItem> AddAsync(TodoItem item);
        Task UpdateAsync(TodoItem item);
        Task DeleteAsync(Guid id);
    }
}
