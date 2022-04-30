#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SwaggerDocumentation.Api/SwaggerDocumentation.Api.csproj", "SwaggerDocumentation.Api/"]
RUN dotnet restore "SwaggerDocumentation.Api/SwaggerDocumentation.Api.csproj"
COPY . .
WORKDIR "/src/SwaggerDocumentation.Api"
RUN dotnet build "SwaggerDocumentation.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SwaggerDocumentation.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SwaggerDocumentation.Api.dll"]