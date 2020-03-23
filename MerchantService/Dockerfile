# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY MerchantService/*.csproj ./MerchantService/
RUN dotnet restore

# copy everything else and build app
COPY . .
WORKDIR /source/MerchantService
RUN dotnet publish -c release -o /app
RUN chmod +x ./entrypoint.sh
CMD /MerchantService/bash ./entrypoint.sh

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "MerchantService.dll"]