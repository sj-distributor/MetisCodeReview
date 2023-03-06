using FluentValidation;
using MetisCodeReview.Core.Middlewares.FluentMessageValidator;
using MetisCodeReview.Messages.Commands.Customers;

namespace MetisCodeReview.Core.Validators;


public class DeleteCustomerCommandValidator : FluentMessageValidator<DeleteCustomerCommand>
{
    public DeleteCustomerCommandValidator()
    {
        RuleFor(v => v.CustomerId).NotEmpty();
    }
}