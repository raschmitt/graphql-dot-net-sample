# GraphQL .Net - Sample

Sample .Net project with GraphQL API.

[![Azure DevOps builds](https://img.shields.io/azure-devops/build/raschmitt/7618d927-8467-43e2-b5e9-1aeddc1fbfdc/24?label=Build%20%26%20Test&style=flat-square)](https://dev.azure.com/raschmitt/raschmitt/_build?definitionId=24)

## Dependencies 

- [Docker](https://docs.docker.com/get-docker/)

## How to run

- ### Running the API 

1. After cloning this repository go into the `GraphQL.Sample` directory and run `docker-compose up`.

2. Access [http://localhost:8080/ui/playground](http://localhost:8080/ui/playground) and you are good to start playing with this API.

For details on how to consume a GraphQL API please refer to the [official documentation](https://graphql.org/learn/queries/).

- ### Connecting to the container's database

If you wish to connect to the container's database with [mssql-cli](https://docs.microsoft.com/en-us/sql/tools/mssql-cli?view=sql-server-ver15), [SQL Server Management Studio](https://docs.microsoft.com/en-us/sql/ssms/sql-server-management-studio-ssms?view=sql-server-ver15), or any other database management tool you can do so with the following credentials:

| Parameter | Value |
| :---: | :---: |
| Server name | 127.0.0.1,1433 |
| Login | sa |
| Paswword | sa@a2020 |

## How to debug 

- [Visual Studio](https://docs.microsoft.com/en-us/visualstudio/containers/edit-and-refresh?view=vs-2019)
- [Visual Studio Code](https://code.visualstudio.com/docs/containers/debug-netcore)
- [Rider](https://blog.jetbrains.com/dotnet/2018/07/18/debugging-asp-net-core-apps-local-docker-container/)

## Useful links

- [GraphQL .Net - Docs](https://graphql-dotnet.github.io/docs/getting-started/introduction)
- [GraphQL .Net - Official repository](https://github.com/graphql-dotnet/graphql-dotnet)
 
## Contributions

  Contributions and feature requests are always welcome.
