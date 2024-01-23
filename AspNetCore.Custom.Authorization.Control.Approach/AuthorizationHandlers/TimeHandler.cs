using AspNetCore.Custom.Authorization.Control.Approach.AuthorizationRequirements;
using Microsoft.AspNetCore.Authorization;

namespace AspNetCore.Custom.Authorization.Control.Approach.AuthorizationHandlers
{
    public class TimeHandler : AuthorizationHandler<TimeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, TimeRequirement requirement)
        {
            if (DateTime.UtcNow.Second >= 30)
                context.Succeed(requirement);
            else
                context.Fail();
            return Task.CompletedTask;
        }
    }
}
