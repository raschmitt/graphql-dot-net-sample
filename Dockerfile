FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build-env

WORKDIR /src
COPY GraphQL.Sample ./

WORKDIR /src/GraphQL.Sample.Api
RUN dotnet restore 
RUN dotnet publish -c Release -o out --no-restore

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1

COPY --from=build-env /src/GraphQL.Sample.Api/out .
ENTRYPOINT ["dotnet", "GraphQL.Sample.Api.dll"]

EXPOSE 80