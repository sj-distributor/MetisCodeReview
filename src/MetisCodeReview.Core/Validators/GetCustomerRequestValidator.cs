using FluentValidation;
using MetisCodeReview.Core.Middlewares.FluentMessageValidator;
using MetisCodeReview.Messages.Requests.Customers;

namespace MetisCodeReview.Core.Validators;

public class GetCustomerRequestValidator : FluentMessageValidator<GetCustomerRequest>
{
    public GetCustomerRequestValidator()
    {
        RuleFor(v => v.CustomerId).NotEmpty();
    }
}