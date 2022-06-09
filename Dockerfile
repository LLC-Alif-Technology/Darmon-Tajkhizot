FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /src

ARG src="./Darmon Tajkhizot/*.csproj"
ARG target="./Darmon Tajkhizot/"
# Copy csproj and restore as distinct layers
COPY *.sln .
COPY ${src} ${target}
COPY Contracts/*.csproj Contracts/
COPY Entities/*.csproj Entities/
COPY LoggerService/*.csproj LoggerService/
COPY Repositories/*.csproj Repositories/
COPY Services/*.csproj Services/
COPY Tests/*.csproj Tests/

RUN dotnet restore --disable-parallel

# Copy everything else and build
COPY . .
WORKDIR "/src/Darmon Tajkhizot/"

RUN dotnet publish -c Release -o /out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app

COPY --from=build-env /out ./
ENTRYPOINT ["dotnet", "Darmon Tajkhizot.dll"]
