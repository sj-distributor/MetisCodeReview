using AutoMapper;
using MetisCodeReview.Core.Domain.Customers;
using MetisCodeReview.Messages.Commands.Customers;
using MetisCodeReview.Messages.Dtos.Customers;

namespace MetisCodeReview.Core.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerShortInfo>();
        CreateMap<CreateCustomerCommand, Customer>();
        CreateMap<UpdateCustomerCommand, Customer>();
    }
}