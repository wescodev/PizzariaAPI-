# Etapa 1: Construção da imagem (Build)
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PizzariaAPI/PizzariaAPI.csproj", "PizzariaAPI/"]
RUN dotnet restore "PizzariaAPI/PizzariaAPI.csproj"
COPY . .
WORKDIR "/src/PizzariaAPI"
RUN dotnet build "PizzariaAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PizzariaAPI.csproj" -c Release -o /app/publish

# Etapa 2: Imagem final (Runtime)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PizzariaAPI.dll"]

