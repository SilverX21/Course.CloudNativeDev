# ASP.NET Core - Cloud-Native App Development

This is a course on Udemy on how to develop .NET apps for the Cloud.
We will have below the steps I've taken for this project 🚀

## 1. Setup

First let's start by pulling a docker container:

For windows:

```bash
    docker pull mcr.microsoft.com/mssql/server:2025-latest
```

For MacOS:

```bash
    docker pull --platform linux/amd64 mcr.microsoft.com/mssql/server:2025-latest
```

Then let's run it using the following command:

For windows:

```bash
    docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=YourStrong!Passw0rd" -p 1433:1433 --name sql25 -d mcr.microsoft.com/mssql/server:2025-latest
```

For MacOS:

```bash
    docker run --platform linux/amd64 -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=YourStrong!Passw0rd' -p 1433:1433 --name sql25 -d mcr.microsoft.com/mssql/server:2025-latest
```

This will run the docker container with on the port 1433 (default for SQL Server)

### Seq (logging)

Pull and run the [Seq](https://hub.docker.com/r/datalust/seq) container, used by Serilog for structured log viewing:

```bash
docker pull datalust/seq
docker run --name seq -d --restart unless-stopped -e ACCEPT_EULA=Y -e SEQ_FIRSTRUN_NOAUTHENTICATION=true -p 5341:80 datalust/seq
```

Open `http://localhost:5341` to view logs in the Seq UI.

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

**Why `host.docker.internal` and not `localhost` or the container name:**

- Each container gets its own isolated network namespace. Inside the API container, `localhost` refers to the API container itself, not your Mac — so it can't see the `mssql` container's `1433` that way.
- The `mssql` container was started on its own with a plain `docker run` (no `--network`), so it's not on a shared user-defined network with the API container. Docker only resolves containers by name (e.g. `Server=mssql,1433`) when they're joined to the *same* custom network — the default bridge network doesn't do name resolution.
- `host.docker.internal` is a special DNS name Docker Desktop maps to the host machine's IP. The API container uses it to go "out" to the host, which then routes back in through the `-p 1433:1433` port published by the SQL container. That round trip through the host is what makes the connection work without a shared network.

Connection string parts:

| Part | Meaning |
|---|---|
| `Server=host.docker.internal,1433` | host machine, on the port SQL Server published |
| `Database=YourDb` | database to connect to (must exist already) |
| `User Id=sa` / `Password=...` | SQL auth credentials — `sa` is the container's built-in admin |
| `TrustServerCertificate=True` | skips cert validation, since the container uses a self-signed dev cert |

If you instead put both containers on the same user-defined network (`docker network create devnet`, then `--network devnet` on both `docker run` commands), you could swap `host.docker.internal` for the container's name, e.g. `Server=mssql,1433` — no host round-trip needed.

### Step 3 — Launch with the debugger

1. Open the **Run & Debug** panel (`Ctrl+Shift+D`).
2. Select **Docker .NET Launch** from the dropdown.
3. Press `F5`.

VS Code will build the image, start the container, install `vsdbg`, and attach the debugger. The browser will open at `http://localhost:8080/scalar` once the API is ready.

Breakpoints set in VS Code will be hit exactly as they would in Visual Studio.
