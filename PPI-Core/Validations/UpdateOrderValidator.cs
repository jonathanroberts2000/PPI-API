namespace PPI_API.Validations
{
    using System;
    using PPI_API.Domain;
    using FluentValidation;
    using PPI_API.Actions.Update;

    public class UpdateOrderValidator : AbstractValidator<UpdateOrderRequest>
    {
        public UpdateOrderValidator()
        {
            int[] values = (int[])Enum.GetValues(typeof(EStatus));

            RuleFor(x => x.OrderId)
                .InclusiveBetween(1, int.MaxValue - 1)
                    .WithMessage(m => $"El campo '{nameof(m.OrderId)}' es requerido y debe estar comprendido entre 1 y {int.MaxValue - 1}.")
                        .WithErrorCode("OrderIdValidator");

            RuleFor(x => x.StatusId)
                .Must(x => Enum.IsDefined(typeof(EStatus), (EStatus)x))
                    .WithMessage(m => $"El campo '{nameof(m.StatusId)}' es requerido y debe ser uno de los siguientes valores: {string.Join(", ", values)}.")
                        .WithErrorCode("StatusIdValidator");
        }
    }
}