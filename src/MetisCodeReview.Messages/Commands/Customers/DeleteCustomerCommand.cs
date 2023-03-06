using Mediator.Net.Contracts;

namespace MetisCodeReview.Messages.Commands.Customers;

public class DeleteCustomerCommand : ICommand
{
    public Guid CustomerId { get; set; }
}