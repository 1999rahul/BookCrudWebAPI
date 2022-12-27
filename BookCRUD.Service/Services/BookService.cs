using System;
using System.Collections.Generic;
using BookCrudApp.IServices;
using BookCrud.Services.ViewModels;
using BookCRUD.Domain.Models.Wrapper;
using BookCRUD.Data.UnitOfWorks;
using BookCRUD.Domain.Models;
using AutoMapper;

namespace BookCRUD.Service.Services;

public class BookService : IBookService
{
    IMapper _mapper;
    public BookService(IMapper mapper)
    {
        _mapper = mapper;
    }
    public Result<IEnumerable<GetBookVM>> GetAllBooks()
    {
        using (DapUnitOfWork _unitOfWork = new DapUnitOfWork("Server=localhost;Database=DEMO;Uid=root;Pwd=20842085;"))
        {
            var books = _unitOfWork.BookRepository.GetAllBooks();
            List<GetBookVM> bookResult = new List<GetBookVM>();

            foreach (var book in books)
            {
                bookResult.Add(_mapper.Map<GetBookVM>(book));
            }
            return Result<IEnumerable<GetBookVM>>.Success(bookResult);
        };
    }
    public Result<GetBookVM> GetBook(int id)
    {
        using (DapUnitOfWork _unitOfWork = new DapUnitOfWork("Server=localhost;Database=DEMO;Uid=root;Pwd=20842085;"))
        {
            var book = _mapper.Map<GetBookVM>(_unitOfWork.BookRepository.GetBook(id));
            return Result<GetBookVM>.Success(book);
        };
    }
    public Result<GetBookVM> PostBook(CreateBookVM book)
    {
        using (DapUnitOfWork _unitOfWork = new DapUnitOfWork("Server=localhost;Database=DEMO;Uid=root;Pwd=20842085;"))
        {
            var bookRes = _unitOfWork.BookRepository.PostBook(_mapper.Map<SpBook>(book));
            return Result<GetBookVM>.Success(_mapper.Map<GetBookVM>(bookRes));
        };
    }

    public Result<GetBookVM> UpdateBook(UpdateBookVM book)
    {
        using (DapUnitOfWork _unitOfWork = new DapUnitOfWork("Server=localhost;Database=DEMO;Uid=root;Pwd=20842085;"))
        {
            var bookRes = _unitOfWork.BookRepository.UpdateBook(_mapper.Map<SpBook>(book));
            return Result<GetBookVM>.Success(_mapper.Map<GetBookVM>(bookRes));
        };
    }
}