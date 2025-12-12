# Plug-and-Play .NET 8 Controller-based API (In-memory)

This is a tiny plug-and-play ASP.NET Core 8 Web API scaffold following the Controller -> Manager -> Provider pattern.
No external database required — uses an in-memory provider.

## Requirements
- .NET 8 SDK installed

## How to run

```bash
cd src/PlugAndPlay.Api
dotnet restore
dotnet run
```

Open `https://localhost:<port>/swagger` to explore endpoints.

## Endpoints

- `GET /api/agenda` - get all agendas
- `GET /api/agenda/{id}` - get single agenda
- `POST /api/agenda` - create agenda

This project is intentionally minimal so you can plug it into your flow quickly.
# Dotnet8Basics
