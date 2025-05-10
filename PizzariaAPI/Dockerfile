FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar apenas o arquivo de projeto para restauração
COPY PizzariaAPI/PizzariaAPI.csproj ./
RUN dotnet restore

# Copiar todo o código-fonte
COPY PizzariaAPI ./PizzariaAPI
COPY *.cs ./
COPY *.json ./

# Definir o diretório de trabalho para a build
WORKDIR /app/PizzariaAPI

# Remover a pasta obj ANTES da build
RUN rm -rf obj

# Build da aplicação
RUN dotnet build -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "PizzariaAPI.dll"]