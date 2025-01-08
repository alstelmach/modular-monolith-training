using HWork.Exercises.Api.Requests;
using HWork.Exercises.Application.Exercise.Commands.SolveExercise;
using HWork.Exercises.Application.Exercise.Commands.SubmitExercise;
using HWork.Shared.Application.Abstractions.Messaging;
using Microsoft.AspNetCore.Mvc;

namespace HWork.Exercises.Api.Controllers;

[ApiController]
[Route("exercises")]
public sealed class ExercisesController(ICommandBus commandBus) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateExercisesAsync([FromBody] CreateExerciseRequest request)
    {
        var command = new SubmitExerciseCommand(request.Instructions);

        await commandBus.SendAsync(command);
        
        return CreatedAtRoute(
            routeName: nameof(GetExerciseAsync),
            routeValues: new { exerciseId = command.ExerciseId.Value },
            value: new { message = "Exercise created successfully", id = command.ExerciseId.Value });
    }

    [HttpPost("{exerciseId:guid}/solutions")]
    public async Task<IActionResult> SolveExerciseAsync(
        [FromRoute] Guid exerciseId,
        [FromBody] SolveExerciseRequest request)
    {
        var command = new SolveExerciseCommand(exerciseId, request.SolutionText);

        await commandBus.SendAsync(command);

        return Ok();
    }

    [HttpGet("{exerciseId:guid}", Name = nameof(GetExerciseAsync))]
    public Task<IActionResult> GetExerciseAsync(
        [FromRoute] Guid exerciseId,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
