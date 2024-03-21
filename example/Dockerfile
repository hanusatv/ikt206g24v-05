#dockerfile for building the image of this project

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS run-env
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "Example.dll"]

# Build the image, use:
# docker build -t example:latest -f Dockerfile .