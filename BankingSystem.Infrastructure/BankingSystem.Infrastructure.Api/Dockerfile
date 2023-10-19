FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BankingSystem.Infrastructure/BankingSystem.Infrastructure.Api/BankingSystem.Infrastructure.Api.csproj", "BankingSystem.Infrastructure/BankingSystem.Infrastructure.Api/"]
COPY ["BankingSystem.Application/BankingSystem.Application.Services/BankingSystem.Application.Services.csproj", "BankingSystem.Application/BankingSystem.Application.Services/"]
COPY ["BankingSystem.Context/BankingSystem.Context.Domain/BankingSystem.Context.Domain.csproj", "BankingSystem.Context/BankingSystem.Context.Domain/"]
COPY ["BankingSystem.Infrastructure/BankingSystem.Infrastructure.Repositories/BankingSystem.Infrastructure.Repositories.csproj", "BankingSystem.Infrastructure/BankingSystem.Infrastructure.Repositories/"]
COPY ["BankingSystem.Infrastructure/BankingSystem.Infrastructure.Data/BankingSystem.Infrastructure.Data.csproj", "BankingSystem.Infrastructure/BankingSystem.Infrastructure.Data/"]
RUN dotnet restore "BankingSystem.Infrastructure/BankingSystem.Infrastructure.Api/BankingSystem.Infrastructure.Api.csproj"
COPY . .
WORKDIR "/src/BankingSystem.Infrastructure/BankingSystem.Infrastructure.Api"
RUN dotnet build "BankingSystem.Infrastructure.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BankingSystem.Infrastructure.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BankingSystem.Infrastructure.Api.dll"]
