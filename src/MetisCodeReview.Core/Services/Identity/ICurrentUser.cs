using MetisCodeReview.Core.DependencyInjection;

namespace MetisCodeReview.Core.Services.Identity
{
    public interface ICurrentUser : IScopedDependency
    {
        string Id { get; }
    }
}