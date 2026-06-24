# PanelDeControl

Panel central de enlaces (Razor Pages + Supabase/Postgres via EF Core)

Instrucciones rápidas para configurar Supabase:

1) Variables de entorno recomendadas (no pongas la contraseña en el repo):

- SUPABASE_CONNECTION (opcional): cadena de conexión completa Npgsql, por ejemplo:
  Host=zwirxnsdhgsmypwqxiah.supabase.co;Port=5432;Database=postgres;Username=postgres;Password=MI_PASS;SSL Mode=Require;Trust Server Certificate=true

- O alternativa (más segura): deja la connection en appsettings.json con el placeholder y define solo la contraseña en una variable:
  - SUPABASE_DB_PASSWORD: la contraseña de la base de datos (postgres)

2) Ejemplo para PowerShell (session only):

$env:SUPABASE_DB_PASSWORD = 'MI_PASS'
# O definir SUPABASE_CONNECTION directamente:
$env:SUPABASE_CONNECTION = 'Host=zwirxnsdhgsmypwqxiah.supabase.co;Port=5432;Database=postgres;Username=postgres;Password=MI_PASS;SSL Mode=Require;Trust Server Certificate=true'

3) Migraciones y despliegue (cuando uses Supabase):

- Instala o actualiza dotnet-ef (si no lo tienes):
  dotnet tool install --global dotnet-ef --version 8.0.8

- Crear la migración (desde la carpeta con el .csproj):
  dotnet ef migrations add InitialCreate

- Aplicar la migración (esto aplica el esquema en la base de datos Supabase/Postgres):
  dotnet ef database update

4) Ejecutar la app localmente (fallback SQLite si no configuras Supabase):

- dotnet restore
- dotnet run

Notas importantes:
- El proyecto ahora detecta si la connection string contiene "supabase.co" y, si es así, usará Postgres. Si no detecta una cadena válida, usa SQLite fallback (links.db) y crea la tabla automáticamente — útil para desarrollo.
- En producción no uses el fallback SQLite; siempre configura SUPABASE_CONNECTION o la password en secrets.
- Si tu Supabase usa un usuario/DB distinto a los valores por defecto, ajusta la cadena de conexión con Database/Username adecuados.
