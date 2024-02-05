namespace PPI_Core.Services.Order
{
    using System.Linq;
    using PPI_Core.Rules;
    using PPI_API.Domain;
    using PPI_Model.Models;
    using PPI_API.UnitOfWork;
    using PPI_API.Actions.Create;
    using PPI_API.Actions.Update;
    using PPI_API.Actions.GetOrder;
    using PPI_Core.CustomException;
    using PPI_API.Actions.GetOrders;
    using System.Collections.Generic;
    using PPI_API.OrderActions.GetOrderStatus;

    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRulesManager rulesManager;

        public OrderService(IUnitOfWork unitOfWork, IRulesManager rulesManager)
        {
            this.unitOfWork = unitOfWork;
            this.rulesManager = rulesManager;
        }

        public GetOrderResponse GetOrderById(int orderId)
        {
            List<KeyValuePair<string, ErrorModel>> rules = rulesManager.GetOrder(orderId);

            if (rules.Count > 0)
            {
                throw new RuleException(rules);
            }

            return new()
            {
                Order = unitOfWork.Order.GetOrderById(orderId),
            };
        }

        public GetOrdersResponse GetOrderByAccountId(int accountId)
        {
            return new()
            {
                Orders = unitOfWork.Order.GetOrdersByAccountId(accountId).ToList()
            };
        }

        public void DeleteOrder(int orderId)
        {
            List<KeyValuePair<string, ErrorModel>> rules = rulesManager.Delete(orderId);

            if (rules.Count > 0)
            {
                throw new RuleException(rules);
            }

            unitOfWork.Order.DeleteOrder(orderId);
        }

        public void UpdateOrder(UpdateOrderRequest request)
        {
            List<KeyValuePair<string, ErrorModel>> rules = rulesManager.Update(request.OrderId);

            if (rules.Count > 0)
            {
                throw new RuleException(rules);
            }

            unitOfWork.Order.UpdateOrder(request.OrderId, request.StatusId);
        }

        public CreateOrderResponse CreateOrder(CreateOrderRequest request, int accountId)
        {
            List<KeyValuePair<string, ErrorModel>> rules = rulesManager.Create(request);

            if (rules.Count > 0)
            {
                throw new RuleException(rules);
            }

            Order order = new()
            {
                AccountId = accountId,
                AssetId = request.AssetId,
                Operation = request.Operation,
                Quantity = request.Quantity,
                Price = request.Price
            };

            EAssetType type = (EAssetType)unitOfWork.Asset.GetAssetType(request.AssetId);
            decimal unitPrice = unitOfWork.Asset.GetAssetPrice(request.AssetId);

            switch (type)
            {
                case EAssetType.Accion:
                    order.Price = unitPrice;
                    order.TotalAmount = unitPrice * request.Quantity;
                    order.Commission = 0.006m * order.TotalAmount;
                    order.Taxes = 0.21m * order.Commission;
                    break;
                case EAssetType.Bono:
                    order.TotalAmount = request.Price * request.Quantity;
                    order.Commission = 0.002m * order.TotalAmount;
                    order.Taxes = 0.21m * order.Commission;
                    break;
                case EAssetType.FCI:
                    order.TotalAmount = request.Price * request.Quantity;
                    break;
                default:
                    break;
            }

            int orderId = unitOfWork.Order.InsertOrder(order);

            return new CreateOrderResponse
            {
                OrderId = orderId,
                Status = "En proceso"
            };
        }

        public GetOrderStatusResponse GetOrderStatus()
        {
            return new()
            {
                OrderStatus = unitOfWork.Order.GetOrderStatus().ToList()
            };
        }
    }
}