FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ng-i18n-helper.csproj", "."]
RUN dotnet restore "./ng-i18n-helper.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ng-i18n-helper.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ng-i18n-helper.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ng-i18n-helper.dll"]