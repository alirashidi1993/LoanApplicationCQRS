#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/LoanApplications.Projections.Sql/LoanApplications.Projections.Sql.csproj", "src/LoanApplications.Projections.Sql/"]
COPY ["framework/Framework.Core/Framework.Core.csproj", "framework/Framework.Core/"]
COPY ["src/LoanApplications.Domain.Contracts/LoanApplications.Domain.Contracts.csproj", "src/LoanApplications.Domain.Contracts/"]
COPY ["framework/Framework.Domain/Framework.Domain.csproj", "framework/Framework.Domain/"]
RUN dotnet restore "src/LoanApplications.Projections.Sql/LoanApplications.Projections.Sql.csproj"
COPY . .
WORKDIR "/src/src/LoanApplications.Projections.Sql"
RUN dotnet build "LoanApplications.Projections.Sql.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LoanApplications.Projections.Sql.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LoanApplications.Projections.Sql.dll"]