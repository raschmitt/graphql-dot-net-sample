# GraphQL .Net - Sample

[![Azure DevOps builds](https://img.shields.io/azure-devops/build/raschmitt/7618d927-8467-43e2-b5e9-1aeddc1fbfdc/24?label=Build%20%26%20Test&style=flat-square)](https://dev.azure.com/raschmitt/raschmitt/_build?definitionId=24)

Sample .Net project with GraphQL API.

## Dependencies 

- [Docker](https://docs.docker.com/get-docker/)

## How to run

- ### Running the API 

1. After cloning this repository go into the `GraphQL.Sample` directory and run `docker-compose up`.

2. Consume the API through `http://localhost:8080/graphql`.

For details on how to consume a GraphQL API please refer to the [official documentation](https://graphql.org/learn/queries/).

- ### Database credentials

| Parameter | Value |
| :---: | :---: |
| Server name | 127.0.0.1,1433 |
| Login | sa |
| Paswword | sa@a2020 |

## Useful links

- [GraphQL .Net - Docs](https://graphql-dotnet.github.io/docs/getting-started/introduction)
- [GraphQL .Net - Official repository](https://github.com/graphql-dotnet/graphql-dotnet)
 
## Contributions

  Contributions and feature requests are always welcome.
