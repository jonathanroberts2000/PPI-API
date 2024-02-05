namespace PPI_API.Validations
{
    using FluentValidation;
    using PPI_API.Actions.Create;

    public class CreateOrderValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.AssetId)
                .InclusiveBetween(1, int.MaxValue - 1)
                    .WithMessage(m => $"El campo '{nameof(m.AssetId)}' es requerido y debe estar comprendido entre 1 y { int.MaxValue - 1}.")
                        .WithErrorCode("AssetIdValidator");

            RuleFor(x => x.Quantity)
                .InclusiveBetween(1, int.MaxValue - 1)
                    .WithMessage(m => $"El campo '{nameof(m.Quantity)}' es requerido y debe estar comprendido entre 1 y {int.MaxValue}.")
                        .WithErrorCode("QuantityValidator");

            RuleFor(x => x.Operation)
                .Must(CheckOperationValue)
                    .WithMessage(m => $"El campo '{nameof(m.Operation)}' es requerido y solo acepta los valores 'C' o 'V'")
                        .WithErrorCode("OperationValidator");
        }

        private static bool CheckOperationValue(char operation)
        {
            if(operation.ToString().ToUpper() != "C" && operation.ToString().ToUpper() != "V")
            {
                return false;
            }
            return true;
        }
    }
}