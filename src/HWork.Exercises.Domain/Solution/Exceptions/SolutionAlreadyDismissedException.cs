namespace HWork.Exercises.Domain.Solution.Exceptions;

public sealed class SolutionAlreadyDismissedException() : Exception("Solution can't be dismissed more than once");
