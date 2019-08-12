FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Notes.API/Notes.API.csproj", "Notes.API/"]
RUN dotnet restore "Notes.API/Notes.API.csproj"
COPY . .
WORKDIR "/src/Notes.API"
RUN dotnet build "Notes.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Notes.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Notes.API.dll"]