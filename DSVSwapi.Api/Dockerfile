FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["DSVSwapiApi/DSVSwapiApi.csproj", "DSVSwapiApi/"]
RUN dotnet restore "DSVSwapiApi/DSVSwapiApi.csproj"
COPY . .
WORKDIR "/src/DSVSwapiApi"
RUN dotnet build "DSVSwapiApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DSVSwapiApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DSVSwapiApi.dll"]
