using HWork.Exercises.Domain.Solution.Events;
using HWork.Exercises.Domain.Solution.Exceptions;
using HWork.Exercises.Domain.Solution.ValueObjects;
using HWork.Shared.Domain;

namespace HWork.Exercises.Domain.Solution;

public sealed class Solution : AggregateRoot<SolutionId>
{
    public Solution(
        SolutionId id,
        string solutionText,
        Score score)
            : base(id)
    {
        SolutionText = solutionText;
        Score = score;

        Enqueue(new SolutionPublished());
    }

    public string SolutionText { get; private set; }
    public Score Score { get; }
    public bool IsDismissed { get; private set; }

    public void Dismiss()
    {
        if (IsDismissed)
        {
            throw new SolutionAlreadyDismissedException();
        }

        IsDismissed = true;
        
        Enqueue(new SolutionDismissed());
    }
}
