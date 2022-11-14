#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["PathFinder.Presentation/PathFinder.Presentation.csproj", "PathFinder.Presentation/"]
COPY ["PathFinder.Service/PathFinder.Service.csproj", "PathFinder.Service/"]
COPY ["PathFinder.DataAccess/PathFinder.DataAccess.csproj", "PathFinder.DataAccess/"]
RUN dotnet restore "PathFinder.Presentation/PathFinder.Presentation.csproj"
COPY . .
WORKDIR "/src/PathFinder.Presentation"
RUN dotnet build "PathFinder.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PathFinder.Presentation.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PathFinder.Presentation.dll"]
