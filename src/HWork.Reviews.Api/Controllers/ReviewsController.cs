using Microsoft.AspNetCore.Mvc;

namespace HWork.Reviews.Api.Controllers;

[ApiController]
[Route("reviews")]
public sealed class ReviewsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAsync() =>
        Ok(new[] { "Ok!" });
}