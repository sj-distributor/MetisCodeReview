using FluentValidation;
using MetisCodeReview.Core.Middlewares.FluentMessageValidator;
using MetisCodeReview.Messages.Commands.Customers;

namespace MetisCodeReview.Core.Validators;

public class UpdateCustomerCommandValidator : FluentMessageValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(v => v.CustomerId).NotEmpty();
        RuleFor(v => v.Name).NotEmpty().MaximumLength(64);
        RuleFor(v => v.Address).MaximumLength(512);
        RuleFor(v => v.Contact).MaximumLength(128);
    }
}