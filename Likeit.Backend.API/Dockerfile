FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Likeit.Backend.API/Likeit.Backend.API.csproj", "Likeit.Backend.API/"]
RUN dotnet restore "Likeit.Backend.API/Likeit.Backend.API.csproj"
COPY . .
WORKDIR "/src/Likeit.Backend.API"
RUN dotnet build "Likeit.Backend.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Likeit.Backend.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Likeit.Backend.API.dll"]
