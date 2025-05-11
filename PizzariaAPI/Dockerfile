FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar a pasta raiz do projeto (PizzariaAPI) para /app
COPY PizzariaAPI ./

# Definir o diretório de trabalho para dentro da pasta do projeto
WORKDIR /app/PizzariaAPI

# Restaurar as dependências
RUN dotnet restore PizzariaAPI.csproj

# Copiar o restante dos arquivos (já dentro da pasta correta)
COPY . ./

# Remover a pasta obj ANTES da build
RUN rm -rf obj

# Build da aplicação
RUN dotnet build PizzariaAPI.csproj -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "PizzariaAPI.dll"]