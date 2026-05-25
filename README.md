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

## 2. Running with the VS Code Container Profile

This setup runs both the API and the database in Docker containers, with the VS Code debugger attached to the API — the same experience as Visual Studio's "Container (Dockerfile)" profile.

### Prerequisites

Install the following VS Code extensions:
- [Docker](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-docker)
- [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)

### Step 1 — Run the MSSQL container

```bash
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Your_Password' \
  --name mssql \
  -p 1433:1433 \
  -d mcr.microsoft.com/mssql/server
```

### Step 2 — Configure the connection string

In `appsettings.Development.json`, use `host.docker.internal` so the API container can reach the database on the host:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=host.docker.internal,1433;Database=YourDb;User Id=sa;Password=Your_Password;TrustServerCertificate=True;"
  }
}
```

### Step 3 — Launch with the debugger

1. Open the **Run & Debug** panel (`Ctrl+Shift+D`).
2. Select **Docker .NET Launch** from the dropdown.
3. Press `F5`.

VS Code will build the image, start the container, install `vsdbg`, and attach the debugger. The browser will open at `http://localhost:8080/scalar` once the API is ready.

Breakpoints set in VS Code will be hit exactly as they would in Visual Studio.
