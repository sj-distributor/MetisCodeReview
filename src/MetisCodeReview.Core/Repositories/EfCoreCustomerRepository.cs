using MetisCodeReview.Core.Data;
using MetisCodeReview.Core.DependencyInjection;
using MetisCodeReview.Core.Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace MetisCodeReview.Core.Repositories;

public class EfCoreCustomerRepository : EfCoreBasicRepository<Customer>, ICustomerRepository, IScopedDependency
{
    public EfCoreCustomerRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public Task<Customer> FindByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return Query(c => c.Name == name).FirstOrDefaultAsync(cancellationToken);
    }
}