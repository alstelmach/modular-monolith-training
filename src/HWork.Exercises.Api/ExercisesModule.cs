using HWork.Exercises.Application.Exercise.Commands.SolveExercise;
using HWork.Exercises.Application.Exercise.Commands.SubmitExercise;
using HWork.Exercises.Application.Solution.Events;
using HWork.Exercises.Domain.Exercise;
using HWork.Exercises.Domain.Solution;
using HWork.Exercises.Infrastructure.Persistence;
using HWork.Shared.Abstractions;
using HWork.Shared.Application.Abstractions.Services;
using HWork.Shared.Infrastructure.DependencyInjection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using SolutionSubmitted = HWork.Exercises.Domain.Solution.Events.SolutionSubmitted;

namespace HWork.Exercises.Api;

public sealed class ExercisesModule : IModule
{
    public string Name =>
        "Exercises";

    public IServiceCollection AddModuleDependencies(IServiceCollection services)
    {
        var assemblyPart = new AssemblyPart(GetType().Assembly);
        
        services
            .AddSingleton<IExerciseRepository, ExerciseRepository>()
            .AddSingleton<ISolutionRepository, SolutionRepository>()
            .AddScoped<IRequestHandler<SubmitExerciseCommand>, SubmitExerciseCommandHandler>()
            .AddScoped<IRequestHandler<SolveExerciseCommand>, SolveExerciseCommandHandler>()
            .AddScoped<IDomainEventHandler<SolutionSubmitted>, SolutionSubmittedDomainEventHandler>()
            .UseTransactionsForCommands([typeof(SubmitExerciseCommand).Assembly])
            .AddControllers()
            .PartManager
            .ApplicationParts
            .Add(assemblyPart);

        return services;
    }

    public void UseModuleMiddlewares(IApplicationBuilder app)
    {
    }
}
