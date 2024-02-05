namespace PPI_API.OrderActions.GetOrderStatus
{
    using PPI_API.Models;
    using System.Collections.Generic;

    public class GetOrderStatusResponse
    {
        public List<OrderStatusModel> OrderStatus { get; set; }
    }
}