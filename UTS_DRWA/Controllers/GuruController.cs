using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UTS_DRWA.Models;

namespace TodoApi.Controllers;

[Route("guru")]
[ApiController]
public class TodoItemsController : ControllerBase
{
    private readonly TodoContext _context;

    public TodoItemsController(TodoContext context)
    {
        _context = context;
    }

    // POST
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // <snippet_Create>
    [HttpPost]
    public async Task<ActionResult<TodoItemDTO>> PostTodoItem(TodoItemDTO todoDTO)
    {
        var todoItem = new Guru
        {
            IsComplete = todoDTO.IsComplete,
            Name = todoDTO.Name
        };

        _context.TodoItems.Add(todoItem);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetTodoItem),
            new { id = todoItem.NIP },
            ItemToDTO(todoItem));
    }
    // </snippet_Create>

    // GET
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoItemDTO>>> GetTodoItems()
    {
        return await _context.TodoItems
            .Select(x => ItemToDTO(x))
            .ToListAsync();
    }

    // GET NIP
    // <snippet_GetByID>
    [HttpGet("{NIP}")]
    public async Task<ActionResult<TodoItemDTO>> GetTodoItem(long id)
    {
        var todoItem = await _context.TodoItems.FindAsync(id);

        if (todoItem == null)
        {
            return NotFound();
        }

        return ItemToDTO(todoItem);
    }
    // </snippet_GetByID>


    private bool TodoItemExists(long id)
    {
        return _context.TodoItems.Any(e => e.NIP == id);
    }

    private static TodoItemDTO ItemToDTO(Guru todoItem) =>
       new TodoItemDTO
       {
           Id = todoItem.NIP,
           Name = todoItem.Name,
           IsComplete = todoItem.IsComplete
       };
}
