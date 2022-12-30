using Hangfire.Dashboard;

namespace Kaya.Service.WebAPI.Filters;

public class NoDashboardAuthorizationFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context)
    {
        return true;
    }
}