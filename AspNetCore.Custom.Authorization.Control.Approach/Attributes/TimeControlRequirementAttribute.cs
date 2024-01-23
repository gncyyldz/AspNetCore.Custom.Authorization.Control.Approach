using AspNetCore.Custom.Authorization.Control.Approach.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Custom.Authorization.Control.Approach.Attributes
{
    public class TimeControlRequirementAttribute : TypeFilterAttribute
    {
        public TimeControlRequirementAttribute(int second) : base(typeof(TimeControlRequirementFilter))
        {
            Arguments = new object[] { second };
        }
    }
}
