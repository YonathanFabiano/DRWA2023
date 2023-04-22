using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly BooksService _booksService;

    public BooksController(BooksService booksService) =>
        _booksService = booksService;

    [HttpGet]
    public async Task<List<Book>> Get() =>
        await _booksService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Book>> Get(string id){
        var book = await _booksService.GetAsync(id);

        if (book is null){
            return NotFound();
        }

        return book;
    }

    // [HttpPost]
    // public async Task<IActionResult> Post(Book newBook){
    //     await _booksService.CreateAsync(newBook);

    //     return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
    // }
    
    public HttpResponseMessage Post(Book newBook){
        if (ModelState.IsValid){
            // Do something with the product (not shown).

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        else{
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }

    
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Book updatedBook){
        var book = await _booksService.GetAsync(id);

        if (book is null){
            return NotFound();
        }

        updatedBook.Id = book.Id;

        await _booksService.UpdateAsync(id, updatedBook);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id){
        var book = await _booksService.GetAsync(id);

        if (book is null){
            return NotFound();
        }

        await _booksService.RemoveAsync(id);

        return NoContent();
    }
}