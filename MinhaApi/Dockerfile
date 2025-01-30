FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Expor a porta padrão do .NET
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia os arquivos do projeto e restaura as dependências
COPY ["MinhaApi.csproj", "./"]
RUN dotnet restore

# Copia o restante do código-fonte
COPY . .
WORKDIR /src

# Compila a aplicação
RUN dotnet build -c Release -o /app/build
RUN dotnet publish -c Release -o /app/publish

# Cria a imagem final
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

# Configura variáveis de ambiente para conexão com o banco de dados
ENV ASPNETCORE_URLS="http://+:5000"
ENV ConnectionStrings__DefaultConnection="Host=db;Port=5432;Database=mydb;Username=myuser;Password=mypassword"

# Comando para iniciar a aplicação
ENTRYPOINT ["dotnet", "MinhaApi.dll"]
