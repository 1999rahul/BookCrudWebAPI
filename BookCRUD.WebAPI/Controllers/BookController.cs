
using Microsoft.AspNetCore.Mvc;
using BookCrudApp.IServices;
using BookCrud.Services.ViewModels;

namespace BookCrudApp.WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    public IBookService bookservice;
    public BookController(IBookService _bookservice)
    {
        bookservice = _bookservice;
    }


    [HttpGet("GetBook/{id}")]
    public IActionResult getBook(int id)
    {
        var response = bookservice.GetBook(id);
        return Ok(response);
    }


    [HttpGet("GeAllBooks")]
    public IActionResult GetAllBooks()
    {
        var response = bookservice.GetAllBooks();
        return Ok(response);
    }


    [HttpPost("AddBook")]
    public IActionResult AddBook([FromBody] CreateBookVM bookVM)
    {
        var response = bookservice.PostBook(bookVM);
        return Ok(response);
    }

    [HttpPut("UpdateBook")]
    public IActionResult UpdateBook([FromBody] UpdateBookVM bookVM)
    {
        var response = bookservice.UpdateBook(bookVM);
        return Ok(response);
    }



}