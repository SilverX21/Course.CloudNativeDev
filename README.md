# ASP.NET Core - Cloud-Native App Development

This is a course on Udemy on how to develop .NET apps for the Cloud.
We will have below the steps I've taken for this project 🚀

## 1. Setup

First let's start by pulling a docker container:

```bash
    docker pull mcr.microsoft.com/mssql/server
```

Then let's run it using the following command:

```bash
    docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Your_Password' -p 1400:1433 -d mcr.microsoft.com/mssql/server
```

This will run the docker container with on the port 1433 (default for SQL Server)
