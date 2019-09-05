FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/Services/Events Service/Events.API/Events.API.csproj", "src/Services/Events Service/Events.API/"]
COPY ["src/Common/MyDiary.API/MyDiary.API.csproj", "src/Common/MyDiary.API/"]
RUN dotnet restore "src/Services/Events Service/Events.API/Events.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Events Service/Events.API"
RUN dotnet build "Events.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Events.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Events.API.dll"]