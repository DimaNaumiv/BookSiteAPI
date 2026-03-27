FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY APIBooks/APIBooks.csproj APIBooks/
COPY APIBooks.DAL/APIBooks.DAL.csproj APIBooks.DAL/

RUN dotnet restore APIBooks/APIBooks.csproj

COPY . .

RUN dotnet publish APIBooks/APIBooks.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:${PORT:-8080}

ENTRYPOINT ["dotnet", "APIBooks.dll"]
