#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["FruitEcommerce.API/FruitEcommerce.API.csproj", "FruitEcommerce.API/"]
COPY ["FruitEcommerce.Infrastructure/FruitEcommerce.Infrastructure.csproj", "FruitEcommerce.Infrastructure/"]
COPY ["FruitEcommerce.ApplicationCore/FruitEcommerce.ApplicationCore.csproj", "FruitEcommerce.ApplicationCore/"]
RUN dotnet restore "FruitEcommerce.API/FruitEcommerce.API.csproj"
COPY . .
WORKDIR "/src/FruitEcommerce.API"
RUN dotnet build "FruitEcommerce.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FruitEcommerce.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FruitEcommerce.API.dll"]