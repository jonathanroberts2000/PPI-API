namespace PPI_Data.UnitOfWork.Repositories.User
{
    using PPI_Model.Models;

    public interface IUserRepository
    {
        bool ExistsAccountId(int accountId);

        UserModel ExistsUser(string username, string password);
    }
}