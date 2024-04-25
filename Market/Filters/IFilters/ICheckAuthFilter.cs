using Microsoft.AspNetCore.Mvc.Filters;

namespace Market.Filters.IFilters;

public interface ICheckAuthFilter
{
    Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next);

    bool TryGetLoginAndPasswordFromHeader(string authHeaderParameter, out string login, out string password);

    void AppendUserIdToClaims(Guid userId, ActionExecutingContext context);
}