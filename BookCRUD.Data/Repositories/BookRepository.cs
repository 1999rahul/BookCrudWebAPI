using System.Data;
using System.Data.SqlClient;
using BookCRUD.Domain.IRepositories;
using BookCRUD.Domain.Models;
using Dapper;

namespace BookCRUD.Data.Repository;
public class BookRepository : IBookRepository
{
    IDbConnection connection;
    public BookRepository(IDbConnection Connection)
    {
        connection = Connection;

    }
    public SpBook GetBook(int id)
    {
        var parameters = new DynamicParameters();
        parameters.Add("Id", id, DbType.Int16);
        var res = connection.Query<SpBook>("spGetBook", parameters, commandType: CommandType.StoredProcedure).ToList()[0];
        return res;
    }

    public SpBook PostBook(SpBook book)
    {
        var parameters = new DynamicParameters();
        parameters.Add("BookName", book.BookName, DbType.String);
        parameters.Add("AuthorName", book.AuthorName, DbType.String);
        var res = connection.Query<SpBook>("spAddBook", parameters, commandType: CommandType.StoredProcedure).ToList()[0];
        return res;
    }

    public SpBook UpdateBook(SpBook book)
    {
        var parameters = new DynamicParameters();
        parameters.Add("Id", book.Id, DbType.Int32);
        parameters.Add("BookName", book.BookName, DbType.String);
        parameters.Add("AuthorName", book.AuthorName, DbType.String);
        var res = connection.Query<SpBook>("spUpdateBook", parameters, commandType: CommandType.StoredProcedure).ToList()[0];
        return res;

    }

    public IEnumerable<SpBook> GetAllBooks()
    {
        var res = connection.Query<SpBook>("spGetAllBooks", new DynamicParameters(), commandType: CommandType.StoredProcedure);
        return res;

    }
}