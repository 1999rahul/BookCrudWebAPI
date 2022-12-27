using BookCRUD.Data.IConnection;
namespace BookCRUD.WebAPI.Connection.Concrete
{
    public class ConnectionFactory : IConnectionFactory
    {

        public string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfigurationRoot Configuration = builder.Build();
            var connectionString = Configuration.GetSection("ConnectionStrings:sqlConnection");

            return connectionString.Value;
        }
    }
}
