using CleanArchNet.Application.Interfaces;
using CleanArchNet.Domain.Entities;
using CleanArchNet.Domain.Interfaces;


namespace CleanArchNet.Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<IEnumerable<TodoItem>> GetAllItemsAsync()
        {
            return await _todoRepository.GetAllAsync();
        }

        public async Task<TodoItem> GetItemByIdAsync(Guid id)
        {
            return await _todoRepository.GetByIdAsync(id);
        }

        public async Task<TodoItem> CreateItemAsync(TodoItem item)
        {
            return await _todoRepository.AddAsync(item);
        }

        public async Task UpdateItemAsync(TodoItem item)
        {
            await _todoRepository.UpdateAsync(item);
        }

        public async Task DeleteItemAsync(Guid id)
        {
            await _todoRepository.DeleteAsync(id);
        }
    }
}
