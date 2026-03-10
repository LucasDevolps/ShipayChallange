FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["ShipayChallange.Api.csproj", "./"]
COPY ["ShipayChallange.Application/ShipayChallange.Application.csproj", "ShipayChallange.Application/"]
COPY ["ShipayChallange.Domain/ShipayChallange.Domain.csproj", "ShipayChallange.Domain/"]
COPY ["ShipayChallange.Infrastructure/ShipayChallange.Infrastructure.csproj", "ShipayChallange.Infrastructure/"]

RUN dotnet restore "ShipayChallange.Api.csproj"

COPY . .
RUN dotnet build "ShipayChallange.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShipayChallange.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "ShipayChallange.Api.dll"]