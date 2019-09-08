FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["CalcTest.InterestRate/CalcTest.InterestRate.csproj", "CalcTest.InterestRate/"]
COPY ["CalcTest.Data/CalcTest.Data.csproj", "CalcTest.Data/"]
COPY ["CalcTest.Contracts/CalcTest.Contracts.csproj", "CalcTest.Contracts/"]
RUN dotnet restore "CalcTest.InterestRate/CalcTest.InterestRate.csproj"
COPY . .
WORKDIR "/src/CalcTest.InterestRate"
RUN dotnet build "CalcTest.InterestRate.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CalcTest.InterestRate.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CalcTest.InterestRate.dll"]