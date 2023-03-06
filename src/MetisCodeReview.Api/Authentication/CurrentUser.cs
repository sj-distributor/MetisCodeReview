using MetisCodeReview.Core.Services.Identity;

namespace MetisCodeReview.Api.Authentication;

public class CurrentUser : ICurrentUser
{
    public string Id => "__metis_code_review_user_id";
}