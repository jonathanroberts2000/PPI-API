namespace PPI_Core.Services.Auth
{
    public interface IAuthService
    {
        bool CheckValidUser(string username, string password, out int accountId);
    }
}