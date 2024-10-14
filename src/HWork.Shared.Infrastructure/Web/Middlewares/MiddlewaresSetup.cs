using Microsoft.AspNetCore.Builder;

namespace HWork.Shared.Infrastructure.Web.Middlewares;

public static class MiddlewaresSetup
{
    public static WebApplication UseSharedInfrastructureMiddlewares(this WebApplication webApplication)
    {
        webApplication
            .UseDocumentationMiddlewares()
            .UseHttpsRedirection();

        return webApplication;
    }
}
