namespace PPI_API.UnitOfWork
{
    using PPI_API.UnitOfWork.Repositories.Asset;
    using PPI_API.UnitOfWork.Repositories.Order;
    using PPI_Data.UnitOfWork.Repositories.Rule;
    using PPI_Data.UnitOfWork.Repositories.User;

    public class UnitOfWork : IUnitOfWork
    {
        public IOrderRepository Order { get; }
        public IAssetRepository Asset { get; }
        public IRuleRepository Rule { get; }
        public IUserRepository User { get; }

        public UnitOfWork(
            IOrderRepository orderRepository,
            IAssetRepository assetRepository,
            IRuleRepository ruleRepository,
            IUserRepository userRepository

        )
        {
            Order = orderRepository;
            Asset = assetRepository;
            Rule = ruleRepository;
            User = userRepository;
        }
    }
}