# Usando a imagem base para o ASP.NET Core
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Usando o SDK do .NET 8 para o processo de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiando o arquivo .csproj para o container
COPY PizzariaAPI/PizzariaAPI.csproj PizzariaAPI/

# Executando o comando restore no arquivo .csproj copiado
RUN dotnet restore "PizzariaAPI/PizzariaAPI/PizzariaAPI.csproj"

# Copiando o restante dos arquivos do projeto
COPY . .

# Definindo o diretório de trabalho do projeto
WORKDIR /src/PizzariaAPI

# Construindo o projeto
RUN dotnet build "PizzariaAPI.csproj" -c Release -o /app/build

# Publicando a aplicação
FROM build AS publish
RUN dotnet publish "PizzariaAPI.csproj" -c Release -o /app/publish

# Imagem final com a aplicação publicada
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish . 

# Configurando o ponto de entrada para o Docker container
ENTRYPOINT ["dotnet", "PizzariaAPI.dll"]
