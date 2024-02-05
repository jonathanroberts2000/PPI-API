namespace PPI_Core.Rules
{
    using System.Linq;
    using PPI_Model.Models;
    using PPI_API.UnitOfWork;
    using PPI_API.Actions.Create;
    using System.Collections.Generic;

    public class RulesManager : IRulesManager
    {
        private readonly Globals globals;
        private readonly IUnitOfWork unitOfWork;

        public RulesManager(Globals globals, IUnitOfWork unitOfWork)
        {
            this.globals = globals;
            this.unitOfWork = unitOfWork;
        }

        public List<KeyValuePair<string, ErrorModel>> Create(CreateOrderRequest request)
        {
            List<KeyValuePair<string, ErrorModel>> rsp = new();

            if (!globals.AvailableAssetIds.Contains(request.AssetId))
            {
                ErrorModel error = (from m in globals.ErrorMessages
                                  where m.ErrorCode == "010001"
                                  select m).Single();

                rsp.Add(new(nameof(request.AssetId), error));
            }

            return rsp;
        }

        public List<KeyValuePair<string, ErrorModel>> Update(int orderId)
        {
            List<KeyValuePair<string, ErrorModel>> rsp = new();

            KeyValuePair<string, ErrorModel> checkExistsOrder = ValidateExistsOrder(orderId);

            if (!string.IsNullOrEmpty(checkExistsOrder.Key))
            {
                rsp.Add(checkExistsOrder);
            }

            return rsp;
        }

        public List<KeyValuePair<string, ErrorModel>> Delete(int orderId)
        {
            List<KeyValuePair<string, ErrorModel>> rsp = new();

            KeyValuePair<string, ErrorModel> checkExistsOrder = ValidateExistsOrder(orderId);

            if (!string.IsNullOrEmpty(checkExistsOrder.Key))
            {
                rsp.Add(checkExistsOrder);
            }

            return rsp;
        }

        public List<KeyValuePair<string, ErrorModel>> GetOrder(int orderId)
        {
            List<KeyValuePair<string, ErrorModel>> rsp = new();

            KeyValuePair<string, ErrorModel> checkExistsOrder = ValidateExistsOrder(orderId);

            if (!string.IsNullOrEmpty(checkExistsOrder.Key))
            {
                rsp.Add(checkExistsOrder);
            }

            return rsp;
        }

        private KeyValuePair<string, ErrorModel> ValidateExistsOrder(int orderId)
        {
            bool existsOrder = unitOfWork.Order.ExistsOrder(orderId);

            if (!existsOrder)
            {
                ErrorModel error = (from m in globals.ErrorMessages
                                  where m.ErrorCode == "010002"
                                  select m).Single();

                return new(nameof(orderId), error);
            }

            return new(string.Empty, null);
        }
    }
}