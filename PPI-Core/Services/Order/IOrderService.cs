namespace PPI_Core.Services.Order
{
    using PPI_API.Actions.Create;
    using PPI_API.Actions.Update;
    using PPI_API.Actions.GetOrder;
    using PPI_API.Actions.GetOrders;
    using PPI_API.OrderActions.GetOrderStatus;

    public interface IOrderService
    {
        GetOrderResponse GetOrderById(int orderId);

        GetOrdersResponse GetOrderByAccountId(int accountId);

        CreateOrderResponse CreateOrder(CreateOrderRequest request, int accountId);

        void UpdateOrder(UpdateOrderRequest request);

        void DeleteOrder(int orderId);

        GetOrderStatusResponse GetOrderStatus();
    }
}