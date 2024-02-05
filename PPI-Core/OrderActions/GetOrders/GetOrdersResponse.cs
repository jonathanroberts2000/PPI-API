namespace PPI_API.Actions.GetOrders
{
    using PPI_API.Models;
    using System.Collections.Generic;

    public class GetOrdersResponse
    {
        public List<OrderShortModel> Orders { get; set; }
    }
}