FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["API.CompoundInterest/CalcTest.CompoundInterest.csproj", "API.CompoundInterest/"]
COPY ["Contracts/CalcTest.Contracts.csproj", "Contracts/"]
COPY ["Data/CalcTest.Data.csproj", "Data/"]
RUN dotnet restore "API.CompoundInterest/CalcTest.CompoundInterest.csproj"
COPY . .
WORKDIR "/src/API.CompoundInterest"
RUN dotnet build "CalcTest.CompoundInterest.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CalcTest.CompoundInterest.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CalcTest.CompoundInterest.dll"]