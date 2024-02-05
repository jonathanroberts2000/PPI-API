namespace PPI_API.UnitOfWork.Repositories.Order
{
    using Dapper;
    using PPI_API.Models;
    using PPI_API.Domain;
    using System.Globalization;
    using Microsoft.Data.SqlClient;
    using PPI_API.UnitOfWork.Commons;
    using System.Collections.Generic;
    using Microsoft.Extensions.Configuration;

    public class OrderRepository : IOrderRepository
    {
        private readonly string cs;

        public OrderRepository(IConfiguration configuration)
        {
            cs = configuration.GetConnectionString("PPI");
        }

        public IEnumerable<OrderShortModel> GetOrdersByAccountId(int accountId)
        {
            string query = string.Format(Queries.GetOrdersByAccountIdQuery, accountId);

            using SqlConnection connection = new(cs);
            IEnumerable<OrderShortModel> result = connection.Query<OrderShortModel>(query);

            return result;
        }

        public OrderModel GetOrderById(int orderId)
        {
            string query = string.Format(Queries.GetOrderByIdQuery, orderId);

            using SqlConnection connection = new(cs);
            OrderModel result = connection.QuerySingle<OrderModel>(query);

            return result;
        }

        public int InsertOrder(Order order)
        {
            string query = string.Format(CultureInfo.InvariantCulture, Queries.InsertOrderQuery, order.AccountId, order.AssetId, order.Quantity, order.Price, order.Commission, order.Taxes, order.Operation, order.TotalAmount);

            using SqlConnection connection = new(cs);
            int result = connection.QuerySingle<int>(query);

            return result;
        }

        public void UpdateOrder(int orderId, int statusId)
        {
            string query = string.Format(Queries.UpdateOrderQuery, statusId, orderId);

            using SqlConnection connection = new(cs);
            connection.Execute(query);
        }

        public void DeleteOrder(int orderId)
        {
            string query = string.Format(Queries.DeleteOrderQuery, orderId);

            using SqlConnection connection = new(cs);
            connection.Execute(query);
        }

        public IEnumerable<OrderStatusModel> GetOrderStatus()
        {
            SqlConnection connection = new(cs);
            IEnumerable<OrderStatusModel> result = connection.Query<OrderStatusModel>(Queries.GetOrderStatusQuery);

            return result;
        }

        public bool ExistsOrder(int orderId)
        {
            string query = string.Format(Queries.GetExistsOrderQuery, orderId);

            SqlConnection connection = new(cs);
            bool result = connection.QuerySingle<bool>(query);

            return result;
        }
    }
}