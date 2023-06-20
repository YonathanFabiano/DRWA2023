using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PresensiHarianGuruController : ControllerBase
{
    private readonly BooksService _presensiharianguruService;

    public PresensiHarianGuruController(BooksService presensiharianguruService) =>
        _presensiharianguruService = presensiharianguruService;

    /// <summary>
    /// get
    /// </summary>
    /// <param name=""></param>
    /// <returns>A newly created TodoItem</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Todo
    ///     {
    ///        "id": 1,
    ///        "name": "Item #1",
    ///        "isComplete": true
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="401">HTTP request has not been applied because it lacks valid authentication credentials for the requested resource</response>
    /// <response code="404">The server was unable to find the requested resource</response>
    /// <response code="500">The server encountered an unexpected condition that prevented it from fulfilling the request</response>
    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<List<Book>> Get() =>
        await _presensiharianguruService.GetAsync();


    /// <summary>
    /// post
    /// </summary>
    /// <param name="newBook"></param>
    /// <returns>A newly created TodoItem</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Todo
    ///     {
    ///        "id": 1,
    ///        "name": "Item #1",
    ///        "isComplete": true
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="401">HTTP request has not been applied because it lacks valid authentication credentials for the requested resource</response>
    /// <response code="404">The server was unable to find the requested resource</response>
    /// <response code="500">The server encountered an unexpected condition that prevented it from fulfilling the request</response>
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post(Book newBook)
    {
        await _presensiharianguruService.CreateAsync(newBook);

        return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
    }

    /// <summary>
    /// put
    /// </summary>
    /// <param name="updatedBook"></param>
    /// <returns>A newly created TodoItem</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Todo
    ///     {
    ///        "id": 1,
    ///        "name": "Item #1",
    ///        "isComplete": true
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="401">HTTP request has not been applied because it lacks valid authentication credentials for the requested resource</response>
    /// <response code="404">The server was unable to find the requested resource</response>
    /// <response code="500">The server encountered an unexpected condition that prevented it from fulfilling the request</response>
    [HttpPut("{id:length(24)}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update(string id, Book updatedBook)
    {
        var book = await _presensiharianguruService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        updatedBook.Id = book.Id;

        await _presensiharianguruService.UpdateAsync(id, updatedBook);

        return NoContent();
    }

    /// <summary>
    /// delete
    /// </summary>
    /// <param name="id"></param>
    /// <returns>A newly created TodoItem</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Todo
    ///     {
    ///        "id": 1,
    ///        "name": "Item #1",
    ///        "isComplete": true
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="401">HTTP request has not been applied because it lacks valid authentication credentials for the requested resource</response>
    /// <response code="404">The server was unable to find the requested resource</response>
    /// <response code="500">The server encountered an unexpected condition that prevented it from fulfilling the request</response>
    [HttpDelete("{id:length(24)}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(string id)
    {
        var book = await _presensiharianguruService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        await _presensiharianguruService.RemoveAsync(id);

        return NoContent();
    }
}