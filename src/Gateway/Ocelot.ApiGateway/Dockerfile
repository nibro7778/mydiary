FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/Gateway/Ocelot.ApiGateway/Ocelot.ApiGateway.csproj", "src/Gateway/Ocelot.ApiGateway/"]
COPY ["src/Common/MyDiary.API/MyDiary.API.csproj", "src/Common/MyDiary.API/"]
RUN dotnet restore "src/Gateway/Ocelot.ApiGateway/Ocelot.ApiGateway.csproj"
COPY . .
WORKDIR "/src/src/Gateway/Ocelot.ApiGateway"
RUN dotnet build "Ocelot.ApiGateway.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Ocelot.ApiGateway.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Ocelot.ApiGateway.dll"]