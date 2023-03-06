using MetisCodeReview.Core.Exceptions;

namespace MetisCodeReview.Core.Domain.Customers.Exceptions
{
    public class CustomerNameAlreadyExistsException : BusinessException
    {
        public CustomerNameAlreadyExistsException() : base("Customer with this name already exists.")
        {
        }
    }
}