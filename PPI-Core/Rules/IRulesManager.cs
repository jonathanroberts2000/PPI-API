namespace PPI_Core.Rules
{
    using PPI_Model.Models;
    using PPI_API.Actions.Create;
    using System.Collections.Generic;

    public interface IRulesManager
    {
        List<KeyValuePair<string, ErrorModel>> Create(CreateOrderRequest request);

        List<KeyValuePair<string, ErrorModel>> Update(int orderId);

        List<KeyValuePair<string, ErrorModel>> Delete(int orderId);

        List<KeyValuePair<string, ErrorModel>> GetOrder(int orderId);
    }
}