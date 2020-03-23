# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY ProductService/*.csproj ./ProductService/
RUN dotnet restore

# copy everything else and build app
COPY . .
WORKDIR /source/ProductService
RUN dotnet publish -c release -o /app
RUN chmod +x ./entrypoint.sh
CMD /ProductService/bash ./entrypoint.sh

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "ProductService.dll"]
