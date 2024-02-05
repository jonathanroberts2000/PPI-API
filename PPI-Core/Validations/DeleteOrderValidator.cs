﻿namespace PPI_API.Validations
{
    using FluentValidation;
    using PPI_API.Actions.Delete;

    public class DeleteOrderValidator : AbstractValidator<DeleteOrderRequest>
    {
        public DeleteOrderValidator()
        {
            RuleFor(x => x.OrderId)
                .InclusiveBetween(1, int.MaxValue - 1)
                    .WithMessage(m => $"El campo '{nameof(m.OrderId)}' es requerido y debe estar comprendido entre 1 y {int.MaxValue - 1}.")
                        .WithErrorCode("OrderIdValidator");
        }
    }
}