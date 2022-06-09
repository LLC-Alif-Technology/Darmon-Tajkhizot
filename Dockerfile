FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /Darmon Tajkhizot/

# Copy csproj and restore as distinct layers
COPY . .
WORKDIR /Darmon Tajkhizot/

# Copy everything else and build
#COPY . .
WORKDIR /Darmon Tajkhizot/
RUN dotnet publish -c Debug -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /api/

COPY --from=build-env /Darmon Tajkhizot/out .
ENTRYPOINT ["dotnet", "/DarmonTajkhizot.dll"]