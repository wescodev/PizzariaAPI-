FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Navegar para a pasta onde o arquivo de projeto está
WORKDIR /app/PizzariaAPI

# Copiar o arquivo de projeto
COPY PizzariaAPI.csproj ./

# Restaurar as dependências
RUN dotnet restore

# Copiar todo o código-fonte (relativo ao diretório do Dockerfile)
COPY ../. ./

# Remover a pasta obj ANTES da build
RUN rm -rf obj

# Build da aplicação
RUN dotnet build PizzariaAPI.csproj -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "PizzariaAPI.dll"]