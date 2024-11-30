FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ASPNET.csproj", "ASPNET.csproj"]
RUN dotnet restore "ASPNET.csproj"
COPY . .
RUN dotnet publish "ASPNET.csproj" -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
EXPOSE 80
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "ASPNET.dll"]