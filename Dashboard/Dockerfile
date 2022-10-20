FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
EXPOSE 80
EXPOSE 443
WORKDIR /src
COPY ["Dashboard/Dashboard.csproj", "Dashboard/"]
RUN dotnet restore "Dashboard/Dashboard.csproj"
COPY . .
WORKDIR /src/Dashboard
RUN dotnet build "Dashboard.csproj" -c Release -o /app/build

RUN dotnet publish "Dashboard.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
EXPOSE 80
EXPOSE 443
WORKDIR /app
COPY --from=build /app/publish .

RUN useradd -rm -d /home/appuser -s /bin/bash -g root -G sudo -u 1001 appuser
USER appuser
WORKDIR /home/appuser

ENTRYPOINT ["dotnet", "Dashboard.dll"]