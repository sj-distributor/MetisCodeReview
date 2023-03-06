using AutoMapper;
using Mediator.Net.Context;
using Mediator.Net.Contracts;
using MetisCodeReview.Core.Domain.Customers.Exceptions;
using MetisCodeReview.Core.Repositories;
using MetisCodeReview.Messages.Commands.Customers;

namespace MetisCodeReview.Core.Handlers.CommandHandlers.Customers;

public class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCustomerCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(IReceiveContext<UpdateCustomerCommand> context, CancellationToken cancellationToken)
    {
        var customer = await _unitOfWork.Customers.GetByIdAsync(context.Message.CustomerId, cancellationToken);

        if (customer.Name != context.Message.Name)
        {
            var existing = await _unitOfWork.Customers.FindByNameAsync(context.Message.Name, cancellationToken);

            if (existing != null)
            {
                throw new CustomerNameAlreadyExistsException();
            }
        }

        _mapper.Map(context.Message, customer);

        await _unitOfWork.Customers.UpdateAsync(customer, cancellationToken).ConfigureAwait(false);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}