namespace PPI_API.UnitOfWork
{
    using PPI_API.UnitOfWork.Repositories.Asset;
    using PPI_API.UnitOfWork.Repositories.Order;
    using PPI_Data.UnitOfWork.Repositories.Rule;
    using PPI_Data.UnitOfWork.Repositories.User;

    public interface IUnitOfWork
    {
        IOrderRepository Order { get; }
        IAssetRepository Asset { get; }
        IRuleRepository Rule { get; }
        IUserRepository User { get; }
    }
}