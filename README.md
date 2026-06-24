# PanelDeControl

Panel central de enlaces (Razor Pages + Supabase/Postgres via EF Core)

Instrucciones rápidas:

- Agrega la cadena de conexión de Supabase en GitHub Actions/Secrets o en appsettings.json como ConnectionStrings:DefaultConnection.
  Ejemplo de connection string compatible Npgsql:
  Host=your-db-host.supabase.co;Port=5432;Database=postgres;Username=postgres;Password=YOUR_PASSWORD;SSL Mode=Require;Trust Server Certificate=true

- Para ejecutar localmente:
  - dotnet restore
  - dotnet ef migrations add InitialCreate
  - dotnet ef database update
  - dotnet run

- Recomendado: almacenar la cadena en la variable de entorno SUPABASE_CONNECTION o en ConnectionStrings:DefaultConnection.

Lo generado es un scaffold mínimo para que puedas seguir desarrollando (CRUD básico, búsqueda y estructura por capas).
