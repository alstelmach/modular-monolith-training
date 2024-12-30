using HWork.Exercises.Domain.Exercise.ValueObjects;
using HWork.Exercises.Domain.Solution.Events;
using HWork.Exercises.Domain.Solution.ValueObjects;
using HWork.Shared.Domain;

namespace HWork.Exercises.Domain.Solution;

public sealed class Solution : AggregateRoot<SolutionId>
{
    public Solution(
        SolutionId id,
        ExerciseId exerciseId,
        string text,
        Score score)
            : base(id)
    {
        ExerciseId = exerciseId;
        Text = text;
        Score = score;

        Enqueue(new SolutionSubmitted(
            id,
            exerciseId,
            text));
    }

    public ExerciseId ExerciseId { get; }

    public string Text { get; private set; }

    public Score Score { get; }
}
