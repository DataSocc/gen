using CleanArchNet.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace CleanArchNet.Application.Interfaces
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItem>> GetAllItemsAsync();
        Task<TodoItem> GetItemByIdAsync(Guid id);
        Task<TodoItem> CreateItemAsync(TodoItem item);
        Task UpdateItemAsync(TodoItem item);
        Task DeleteItemAsync(Guid id);
    }
}
