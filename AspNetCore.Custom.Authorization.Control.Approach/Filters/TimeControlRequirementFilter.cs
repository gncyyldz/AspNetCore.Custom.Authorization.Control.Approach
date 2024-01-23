using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetCore.Custom.Authorization.Control.Approach.Filters
{
    public class TimeControlRequirementFilter : IAuthorizationFilter, IAsyncAuthorizationFilter
    {
        int second;
        public TimeControlRequirementFilter(int second)
            => this.second = second;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (DateTime.UtcNow.Second < second)
                context.Result = new UnauthorizedResult();
        }

        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (DateTime.UtcNow.Second < second)
                context.Result = new UnauthorizedResult();
            return Task.CompletedTask;
        }
    }
}
