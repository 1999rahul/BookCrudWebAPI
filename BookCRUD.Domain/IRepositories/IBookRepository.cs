using BookCRUD.Domain.Models;

namespace BookCRUD.Domain.IRepositories
{
    public interface IBookRepository
    {
        SpBook GetBook(int id);
        SpBook PostBook(SpBook book);
        SpBook UpdateBook(SpBook book);
        IEnumerable<SpBook> GetAllBooks();
    }
}