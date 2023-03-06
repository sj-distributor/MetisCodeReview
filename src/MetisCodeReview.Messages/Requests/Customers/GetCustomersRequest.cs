using Mediator.Net.Contracts;
using MetisCodeReview.Messages.Dtos.Customers;

namespace MetisCodeReview.Messages.Requests.Customers;

public class GetCustomerRequest : IRequest
{
    public Guid CustomerId { get; set; }
}

public class GetCustomerResponse : IResponse
{
    public CustomerShortInfo Customer { get; set; }
}