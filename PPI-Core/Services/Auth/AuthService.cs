namespace PPI_Core.Services.Auth
{
    using PPI_Model.Models;
    using PPI_API.UnitOfWork;

    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork unitOfWork;

        public AuthService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public bool CheckValidUser(string username, string password, out int accountId)
        {
            UserModel user = unitOfWork.User.ExistsUser(username, password);
            accountId = user.AccountId;

            return user.Exists;
        }
    }
}