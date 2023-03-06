using AutoMapper;
using Mediator.Net.Context;
using Mediator.Net.Contracts;
using MetisCodeReview.Core.Repositories;
using MetisCodeReview.Messages.Dtos.Customers;
using MetisCodeReview.Messages.Requests.Customers;

namespace MetisCodeReview.Core.Handlers.RequestHandlers.Customers;

public class GetCustomerRequestHandler : IRequestHandler<GetCustomerRequest, GetCustomerResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetCustomerRequestHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<GetCustomerResponse> Handle(IReceiveContext<GetCustomerRequest> context,
        CancellationToken cancellationToken)
    {
        var customer = await _unitOfWork.Customers.GetByIdAsync(context.Message.CustomerId, cancellationToken);

        return new GetCustomerResponse
        {
            Customer = _mapper.Map<CustomerShortInfo>(customer)
        };
    }
}