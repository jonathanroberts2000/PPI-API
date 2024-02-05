namespace PPI_API.UnitOfWork.Repositories.Order
{
    using PPI_API.Domain;
    using PPI_API.Models;
    using System.Collections.Generic;

    public interface IOrderRepository
    {
        IEnumerable<OrderShortModel> GetOrdersByAccountId(int accountId);

        OrderModel GetOrderById(int orderId);

        int InsertOrder(Order order);

        void UpdateOrder(int orderId, int statusId);

        void DeleteOrder(int orderId);

        IEnumerable<OrderStatusModel> GetOrderStatus();

        bool ExistsOrder(int orderId);
    }
}