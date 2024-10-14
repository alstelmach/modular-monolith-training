using Microsoft.AspNetCore.Mvc;

namespace HWork.Exercises.Api.Controllers;

[ApiController]
[Route("exercises")]
public sealed class ExercisesController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAsync() =>
        Ok(new[] { "SMiW" });
}
