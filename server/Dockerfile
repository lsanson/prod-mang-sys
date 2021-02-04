FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./Api.Application/*.csproj ./
COPY ./Api.Application/database/database-template.sqlite ./database.sqlite
RUN dotnet restore

# Copy everything else and build
COPY . ./

RUN dotnet publish "./Api.Application/Application.csproj" -c Release -o out


# Build runtime image 
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/out .
COPY --from=build /app/database.sqlite .

ENTRYPOINT ["dotnet", "Application.dll"]