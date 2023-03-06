using MetisCodeReview.Core.Domain.Customers;

namespace MetisCodeReview.Core.Repositories;

public interface ICustomerRepository : IBasicRepository<Customer>
{
    Task<Customer> FindByNameAsync(string name, CancellationToken cancellationToken = default);
}