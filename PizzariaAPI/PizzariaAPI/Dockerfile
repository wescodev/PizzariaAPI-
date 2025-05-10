# Etapa 1: Usar a imagem base do .NET 8
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Etapa 2: Usar a imagem SDK do .NET 8 para compilar a aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["PizzariaAPI/PizzariaAPI.csproj", "PizzariaAPI/"]
RUN dotnet restore "PizzariaAPI/PizzariaAPI.csproj"
COPY . .
WORKDIR "/src/PizzariaAPI"
RUN dotnet build "PizzariaAPI.csproj" -c Release -o /app/build

# Etapa 3: Publicar a aplicação
FROM build AS publish
RUN dotnet publish "PizzariaAPI.csproj" -c Release -o /app/publish

# Etapa 4: Criar a imagem final com a aplicação pronta
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PizzariaAPI.dll"]
