namespace PPI_Data.UnitOfWork.Repositories.User
{
    using Dapper;
    using PPI_Model.Models;
    using Microsoft.Data.SqlClient;
    using PPI_API.UnitOfWork.Commons;
    using Microsoft.Extensions.Configuration;

    public class UserRepository : IUserRepository
    {
        private readonly string cs;

        public UserRepository(IConfiguration configuration)
        {
            cs = configuration.GetConnectionString("PPI");
        }

        public bool ExistsAccountId(int accountId)
        {
            string query = string.Format(Queries.GetExistsAccountQuery, accountId);

            using SqlConnection connection = new(cs);
            bool result = connection.QuerySingle<bool>(query);

            return result;
        }

        public UserModel ExistsUser(string username, string password)
        {
            string query = string.Format(Queries.GetExistsUserQuery, username, password);

            using SqlConnection connection = new(cs);
            UserModel result = connection.QuerySingle<UserModel>(query);

            return result;
        }
    }
}