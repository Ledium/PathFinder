FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
 WORKDIR /app
 EXPOSE 80
 FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
 WORKDIR /PathFinder.Presentation
 COPY ["PathFinder.Presentation.csproj", ""]
 RUN dotnet restore "./PathFinder.Presentation.csproj.csproj"
 COPY . .
 WORKDIR "/PathFinder.Presentation"
 RUN dotnet build "PathFinder.Presentation.csproj" -c Release -o /app/build
 FROM build AS publish
 RUN dotnet publish "PathFinder.Presentation.csproj" -c Release -o /app/publish
 FROM base AS final
 WORKDIR /app
 COPY --from=publish /app/publish .
 ENTRYPOINT ["dotnet", "PathFinder.Presentation.dll"]
