# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY PizzariaAPI/PizzariaAPI.csproj PizzariaAPI/
RUN dotnet restore PizzariaAPI/PizzariaAPI.csproj

COPY PizzariaAPI/ PizzariaAPI/
WORKDIR /src/PizzariaAPI
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "PizzariaAPI.dll"]
