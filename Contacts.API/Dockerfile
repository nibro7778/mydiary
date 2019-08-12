FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Contacts.API/Contacts.API.csproj", "Contacts.API/"]
RUN dotnet restore "Contacts.API/Contacts.API.csproj"
COPY . .
WORKDIR "/src/Contacts.API"
RUN dotnet build "Contacts.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Contacts.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Contacts.API.dll"]