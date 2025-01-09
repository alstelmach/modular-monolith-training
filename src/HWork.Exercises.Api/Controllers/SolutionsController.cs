using Microsoft.AspNetCore.Mvc;

namespace HWork.Exercises.Api.Controllers;

[ApiController]
[Route("solutions")]
public class SolutionsController : ControllerBase
{
    [HttpGet("{solutionId:guid}", Name = nameof(GetSolutionAsync))]
    public Task<IActionResult> GetSolutionAsync(
        [FromRoute] Guid solutionId,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
