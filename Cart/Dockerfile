#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Cart/CartK8s.Api.csproj", "Cart/"]
RUN dotnet restore "Cart/CartK8s.Api.csproj"
COPY . .
WORKDIR "/src/Cart"
RUN dotnet build "CartK8s.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CartK8s.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY Cart/Db ./Db
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CartK8s.Api.dll"]
