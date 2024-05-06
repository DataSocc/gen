using Microsoft.AspNetCore.Mvc;
using CleanArchNet.Application.Interfaces;
using CleanArchNet.Domain.Entities;

namespace CleanArchNet.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoItemsController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _todoService.GetAllItemsAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var item = await _todoService.GetItemByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TodoItem item)
        {
            var newItem = await _todoService.CreateItemAsync(item);
            return CreatedAtAction(nameof(Get), new { id = newItem.Id }, newItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] TodoItem item)
        {
            if (id != item.Id) return BadRequest();
            await _todoService.UpdateItemAsync(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _todoService.DeleteItemAsync(id);
            return NoContent();
        }
    }
}
