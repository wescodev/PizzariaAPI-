WORKDIR /app

COPY ./PizzariaAPI/PizzariaAPI.csproj ./PizzariaAPI/
RUN dotnet restore ./PizzariaAPI/PizzariaAPI.csproj

COPY ./PizzariaAPI/. ./PizzariaAPI/
WORKDIR /app/PizzariaAPI

RUN dotnet build -c Release -o out
RUN dotnet publish -c Release -o out

ENTRYPOINT ["dotnet", "out/PizzariaAPI.dll"]
