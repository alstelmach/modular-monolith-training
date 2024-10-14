using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace HWork.Shared.Infrastructure.Web.Middlewares;

public static class DocumentationMiddlewaresRegistry
{
    public static WebApplication UseDocumentationMiddlewares(this WebApplication webApplication)
    {
        if (webApplication.Environment.IsDevelopment())
        {
            webApplication.UseSwagger();
            webApplication.UseSwaggerUI();
        }

        return webApplication;
    }
}
