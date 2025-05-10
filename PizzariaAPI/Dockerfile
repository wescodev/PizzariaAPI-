FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY PizzariaAPI/PizzariaAPI.csproj ./
RUN rm -rf /src/obj
RUN dotnet restore "PizzariaAPI.csproj"
COPY PizzariaAPI ./PizzariaAPI
COPY *.cs ./
# Copie outras pastas de código-fonte conforme necessário (Repositories, Services, Controllers, etc.)
# Exemplo: COPY Repositories ./Repositories
#          COPY Services ./Services
#          COPY Controllers ./Controllers
COPY appsettings*.json ./
COPY *.json ./

WORKDIR "/src/."
RUN rm -rf /src/obj
RUN dotnet build "PizzariaAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PizzariaAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PizzariaAPI.dll"]