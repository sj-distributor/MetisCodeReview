using Mediator.Net.Context;
using Mediator.Net.Contracts;
using MetisCodeReview.Core.Repositories;
using MetisCodeReview.Messages.Commands.Customers;

namespace MetisCodeReview.Core.Handlers.CommandHandlers.Customers;

public class DeleteCustomerCommandHandler: ICommandHandler<DeleteCustomerCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task Handle(IReceiveContext<DeleteCustomerCommand> context, CancellationToken cancellationToken)
    {
        var customer = await _unitOfWork.Customers.GetByIdAsync(context.Message.CustomerId, cancellationToken);

        await _unitOfWork.Customers.DeleteAsync(customer, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}