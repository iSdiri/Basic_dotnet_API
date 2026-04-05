FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY Basic_dotnet_API.csproj .
RUN dotnet restore Basic_dotnet_API.csproj
COPY . .
RUN dotnet publish Basic_dotnet_API.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "Basic_dotnet_API.dll"]
