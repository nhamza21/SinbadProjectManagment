#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/SinbadProjectManagement.API/SinbadProjectManagement.API.csproj", "src/SinbadProjectManagement.API/"]
COPY ["src/SinbadProjectManagement.Application/SinbadProjectManagement.Application.csproj", "src/SinbadProjectManagement.Application/"]
COPY ["src/SinbadProjectManagement.Domain/SinbadProjectManagement.Domain.csproj", "src/SinbadProjectManagement.Domain/"]
COPY ["src/SinbadProjectManagement.Common/SinbadProjectManagement.Common.csproj", "src/SinbadProjectManagement.Common/"]
COPY ["src/SinbadProjectManagement.Infrastructure/SinbadProjectManagement.Infrastructure.Persistance/SinbadProjectManagement.Infrastructure.Persistance.csproj", "src/SinbadProjectManagement.Infrastructure/SinbadProjectManagement.Infrastructure.Persistance/"]
RUN dotnet restore "src/SinbadProjectManagement.API/SinbadProjectManagement.API.csproj"
COPY . .
WORKDIR "/src/src/SinbadProjectManagement.API"
RUN dotnet build "SinbadProjectManagement.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SinbadProjectManagement.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS http://*:80
ENV ASPNETCORE_ENVIRONMENT docker
ENTRYPOINT ["dotnet", "SinbadProjectManagement.API.dll"]