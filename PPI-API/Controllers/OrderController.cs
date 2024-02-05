namespace PPI_API.Controllers
{
    using System.Net;
    using PPI_API.Validations;
    using PPI_API.Actions.Delete;
    using PPI_API.Actions.Update;
    using PPI_API.Actions.Create;
    using PPI_Core.Services.Order;
    using FluentValidation.Results;
    using Microsoft.AspNetCore.Mvc;
    using PPI_API.Actions.GetOrder;
    using PPI_Core.CustomException;
    using PPI_API.Actions.GetOrders;
    using Microsoft.AspNetCore.Authorization;
    using Swashbuckle.AspNetCore.Annotations;
    using PPI_API.OrderActions.GetOrderStatus;

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class OrderController : BaseController
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost]
        [SwaggerOperation("Método que se encarga de crear una orden de compra o venta")]
        public IActionResult Create([FromBody] CreateOrderRequest request)
        {
            ValidationResult fvResult = new CreateOrderValidator().Validate(request);

            if (!fvResult.IsValid)
            {
                return CreateErrorResponseHelper(fvResult);
            }

            try
            {
                CreateOrderResponse result = orderService.CreateOrder(request, AccountId);

                return CreateResponseHelper(result, HttpStatusCode.Created, result.OrderId);
            }
            catch (RuleException ex)
            {
                return CreateErrorRulesResponseHelper(ex.Errors);
            }
        }

        [HttpPut("{orderId}/{statusId}")]
        [SwaggerOperation("Método que se encarga de actualizar el estado de una orden")]
        public IActionResult Update([FromRoute] UpdateOrderRequest request)
        {
            ValidationResult fvResult = new UpdateOrderValidator().Validate(request);

            if (!fvResult.IsValid)
            {
                return CreateErrorResponseHelper(fvResult);
            }

            try
            {
                orderService.UpdateOrder(request);

                return CreateResponseHelper<object>(null, HttpStatusCode.NoContent, request.OrderId);
            }
            catch (RuleException ex)
            {
                return CreateErrorRulesResponseHelper(ex.Errors);
            }
        }

        [HttpGet("{orderId}")]
        [SwaggerOperation("Método que se encarga de retornar una orden por id")]
        public IActionResult GetOrder([FromRoute] GetOrderRequest request)
        {
            ValidationResult fvResult = new GetOrderValidator().Validate(request);

            if (!fvResult.IsValid)
            {
                return CreateErrorResponseHelper(fvResult);
            }

            try
            {
                GetOrderResponse result = orderService.GetOrderById(request.OrderId);

                return CreateResponseHelper(result, HttpStatusCode.OK);
            }
            catch (RuleException ex)
            {
                return CreateErrorRulesResponseHelper(ex.Errors);
            }
        }

        [HttpGet("accounts")]
        [SwaggerOperation("Método que se encarga de retornar todas las ordenes para la cuenta asociada al token")]
        public IActionResult GetOrders()
        {
            try
            {
                GetOrdersResponse result = orderService.GetOrderByAccountId(AccountId);

                return CreateResponseHelper(result, HttpStatusCode.OK);
            }
            catch (RuleException ex)
            {
                return CreateErrorRulesResponseHelper(ex.Errors);
            }
        }

        [HttpDelete("{orderId}")]
        [SwaggerOperation("Método que se encarga de eliminar una orden")]
        public IActionResult Delete([FromRoute] DeleteOrderRequest request)
        {
            ValidationResult fvResult = new DeleteOrderValidator().Validate(request);

            if (!fvResult.IsValid)
            {
                return CreateErrorResponseHelper(fvResult);
            }

            try
            {
                orderService.DeleteOrder(request.OrderId);

                return CreateResponseHelper<object>(null, HttpStatusCode.OK);
            }
            catch (RuleException ex)
            {
                return CreateErrorRulesResponseHelper(ex.Errors);
            }
        }

        [HttpGet("status")]
        [SwaggerOperation("Método que se encarga de retornar todos los estados disponibles para una orden")]
        public IActionResult GetOrderStatus()
        {
            GetOrderStatusResponse result = orderService.GetOrderStatus();

            return CreateResponseHelper(result, HttpStatusCode.OK);
        }
    }
}
