FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Definir o diretório de trabalho para onde o projeto está
WORKDIR /app/PizzariaAPI

# Copiar apenas o arquivo de projeto explicitamente
COPY PizzariaAPI.csproj ./

# Restaurar as dependências
RUN dotnet restore

# Voltar para a raiz para copiar o restante do código
WORKDIR /app

# Copiar a pasta PizzariaAPI que contém o código
COPY PizzariaAPI/PizzariaAPI ./PizzariaAPI

# Remover a pasta obj ANTES da build
RUN rm -rf obj

# Build da aplicação
WORKDIR /app/PizzariaAPI
RUN dotnet build PizzariaAPI.csproj -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "PizzariaAPI.dll"]