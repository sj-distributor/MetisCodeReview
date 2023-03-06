using System.Threading;
using System.Threading.Tasks;
using Mediator.Net.Context;
using MetisCodeReview.Core.Domain.Customers;
using MetisCodeReview.Core.Domain.Customers.Exceptions;
using MetisCodeReview.Core.Handlers.CommandHandlers.Customers;
using MetisCodeReview.Messages.Commands.Customers;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Shouldly;
using Xunit;

namespace Wax.UnitTests.Customers;

public class CreateCustomerTests : CustomerTestFixture
{
    private readonly CreateCustomerCommandHandler _handler;

    public CreateCustomerTests()
    {
        _handler = new CreateCustomerCommandHandler(Mapper, UnitOfWork);
    }

    [Fact]
    public async Task ShouldNotCreateCustomerWhenNameAlreadyExists()
    {
        var command = new CreateCustomerCommand
        {
            Name = "microsoft"
        };

        Customers.FindByNameAsync(command.Name).Returns(new Customer { Name = "google" });

        await Should.ThrowAsync<CustomerNameAlreadyExistsException>(async () =>
            await _handler.Handle(new ReceiveContext<CreateCustomerCommand>(command), CancellationToken.None));
    }

    [Fact]
    public async Task ShouldCallInsert()
    {
        var command = new CreateCustomerCommand
        {
            Name = "microsoft",
            Contact = "+861306888888"
        };

        Customers.FindByNameAsync(command.Name).ReturnsNull();

        await _handler.Handle(new ReceiveContext<CreateCustomerCommand>(command), CancellationToken.None);

        await Customers.Received().InsertAsync(Arg.Any<Customer>());
    }
}