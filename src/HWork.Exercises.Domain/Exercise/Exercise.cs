using HWork.Exercises.Domain.Exercise.Events;
using HWork.Exercises.Domain.Exercise.Exceptions;
using HWork.Exercises.Domain.Exercise.ValueObjects;
using HWork.Exercises.Domain.Solution.ValueObjects;
using HWork.Shared.Domain;

namespace HWork.Exercises.Domain.Exercise;

public sealed class Exercise : AggregateRoot<ExerciseId>
{
    private readonly IDictionary<SolutionId, Score> _exerciseSolutions = new Dictionary<SolutionId, Score>();

    private Exercise(
        ExerciseId id,
        ExerciseInstructions instructions)
            : base(id)
    {
        Instructions = instructions;
    }

    public ExerciseInstructions Instructions { get; }

    public SolutionId? BestSolution =>
        _exerciseSolutions.Any()
            ? _exerciseSolutions
                .MaxBy(keyValuePair => keyValuePair.Value)
                .Key
            : null;

    public bool IsSolved =>
        BestSolution is not null;

    public static Exercise Create(
        ExerciseId id,
        ExerciseInstructions instructions)
    {
        var exercise = new Exercise(id, instructions);

        exercise.Enqueue(
            new ExerciseSubmitted(id));

        return exercise;
    }

    public void Solve(SolutionId solutionId)
    {
        if (!_exerciseSolutions.TryAdd(solutionId, Score.CreateEmpty()))
        {
            throw new SolutionAlreadySubmitted();
        }

        Enqueue(
            new ExerciseSolved(
                Id,
                solutionId));
    }
}