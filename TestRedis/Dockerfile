FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["TestRedis/TestRedis.csproj", "TestRedis/"]
RUN dotnet restore "TestRedis/TestRedis.csproj"
COPY . .
WORKDIR "/src/TestRedis"
RUN dotnet build "TestRedis.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestRedis.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestRedis.dll"]