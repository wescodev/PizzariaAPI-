FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar a pasta que contém o arquivo de projeto
COPY PizzariaAPI/PizzariaAPI ./

# Navegar para a pasta do projeto
WORKDIR /app/PizzariaAPI

# Restaurar as dependências
RUN dotnet restore PizzariaAPI.csproj

# Copiar todo o código-fonte (agora no contexto correto)
COPY . ./

# Remover a pasta obj ANTES da build
RUN rm -rf obj

# Build da aplicação
RUN dotnet build PizzariaAPI.csproj -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "PizzariaAPI.dll"]