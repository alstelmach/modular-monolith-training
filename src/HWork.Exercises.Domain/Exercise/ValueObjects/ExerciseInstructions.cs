using HWork.Shared.Domain;

namespace HWork.Exercises.Domain.Exercise.ValueObjects;

public sealed record ExerciseInstructions : ValueObject
{
    public ExerciseInstructions(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
        {
            throw new ArgumentException("Exercise instruction text cannot be empty.");
        }

        Content = content;
    }

    public string Content { get; }
}
