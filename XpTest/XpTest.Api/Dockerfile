#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["XpTest.Api/XpTest.Api.csproj", "XpTest.Api/"]
COPY ["XpTest.Infra.IoC/XpTest.Infra.IoC.csproj", "XpTest.Infra.IoC/"]
COPY ["XpTest.Application/XpTest.Application.csproj", "XpTest.Application/"]
COPY ["XpTest.Domain/XpTest.Domain.csproj", "XpTest.Domain/"]
COPY ["XpTest.Infra/XpTest.Infra.Data.csproj", "XpTest.Infra/"]
RUN dotnet restore "XpTest.Api/XpTest.Api.csproj"
COPY . .
WORKDIR "/src/XpTest.Api"
RUN dotnet build "XpTest.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "XpTest.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "XpTest.Api.dll"]