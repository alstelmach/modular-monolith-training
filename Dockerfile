FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY ./src/HWork.Launcher/HWork.Launcher.csproj ./src/HWork.Launcher/
RUN dotnet restore ./src/HWork.Launcher/HWork.Launcher.csproj

COPY ./src ./src
WORKDIR /app/src/HWork.Launcher

RUN dotnet publish HWork.Launcher.csproj -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

EXPOSE 44365
ENTRYPOINT ["dotnet", "HWork.Launcher.dll"]
