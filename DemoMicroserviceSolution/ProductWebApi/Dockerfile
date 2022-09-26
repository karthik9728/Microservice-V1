#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DemoMicroserviceSolution/ProductWebApi/ProductWebApi.csproj", "DemoMicroserviceSolution/ProductWebApi/"]
RUN dotnet restore "DemoMicroserviceSolution/ProductWebApi/ProductWebApi.csproj"
COPY . .
WORKDIR "/src/DemoMicroserviceSolution/ProductWebApi"
RUN dotnet build "ProductWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductWebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductWebApi.dll"]