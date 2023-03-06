using Mediator.Net.Contracts;

namespace MetisCodeReview.Messages.Commands.Customers
{
    public class CreateCustomerCommand : ICommand
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
    }

    public class CreateCustomerResponse : IResponse
    {
        public Guid CustomerId { get; set; }
    }
}