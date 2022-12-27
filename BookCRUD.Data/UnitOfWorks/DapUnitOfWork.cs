

using MySql.Data.MySqlClient;
using System.Data;
using BookCRUD.Data.Repository;
using BookCRUD.Domain.IRepositories;

namespace BookCRUD.Data.UnitOfWorks
{
    public class DapUnitOfWork : IDisposable
    {
        IDbConnection connection;

        public DapUnitOfWork(string connString)
        {
            connection = new MySqlConnection(connString);
        }

        private IBookRepository _bookRepository;

        public IBookRepository BookRepository
        {
            get
            {
                return _bookRepository ?? (_bookRepository = new BookRepository(connection));
            }
        }

        public void Dispose()
        {
            // if (connection != null)
            // {
            //     connection = null;
            // }

        }
    }
}
