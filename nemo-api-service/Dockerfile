FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["nemo-api-service/nemo-api-service.csproj", "nemo-api-service/"]
RUN dotnet restore "nemo-api-service/nemo-api-service.csproj"
COPY . .
WORKDIR "/src/nemo-api-service"
RUN dotnet build "nemo-api-service.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "nemo-api-service.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "nemo-api-service.dll"]