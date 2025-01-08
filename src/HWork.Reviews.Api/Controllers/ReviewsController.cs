using HWork.Reviews.Api.Commands;
using HWork.Shared.Application.Abstractions.Messaging;
using Microsoft.AspNetCore.Mvc;

namespace HWork.Reviews.Api.Controllers;

[ApiController]
[Route("reviews")]
public sealed class ReviewsController : ControllerBase
{
    private readonly ICommandBus _commandBus;

    public ReviewsController(ICommandBus commandBus)
    {
        _commandBus = commandBus;
    }

    [HttpPost]
    public async Task<IActionResult> ReviewAsync([FromBody] ReviewCommand reviewCommand)
    {
        await _commandBus.SendAsync(reviewCommand);
        return CreatedAtRoute(
            routeName: nameof(GetReviewAsync),
            routeValues: new { reviewId = reviewCommand.ReviewId },
            value: new { message = "Review created successfully", id = reviewCommand.SolutionId });
    }

    [HttpGet("{reviewId:guid}", Name = nameof(GetReviewAsync))]
    public Task<IActionResult> GetReviewAsync(
        [FromRoute] Guid reviewId,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}