using System;
using System.Collections.Generic;
using BookCrud.Services.ViewModels;
using BookCRUD.Domain.Models.Wrapper;

namespace BookCrudApp.IServices;

public interface IBookService
{
    Result<IEnumerable<GetBookVM>> GetAllBooks();
    Result<GetBookVM> GetBook(int id);
    Result<GetBookVM> PostBook(CreateBookVM book);
    Result<GetBookVM> UpdateBook(UpdateBookVM book);

}