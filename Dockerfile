FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.
RUN mkdir app
COPY docker-guide/dist/* /app/
EXPOSE 80
ENTRYPOINT ["dotnet", "/app/docker-guide.dll"]  
