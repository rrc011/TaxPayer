# Prueba Técnica - Analista Programador Senior.

Aplicacion web para ver un listado de contribuyentes y sus compobantes fiscales.

## Tecnologías utilizadas

- Backend: .NET Framework/Core 7.0
- Base de datos: SQL Server
- Frontend: ReactJS

## Requisitos previos

- [.NET Framework/Core SDK](https://dotnet.microsoft.com/download) instalado en el servidor.
- [SQL Server](https://www.microsoft.com/es-es/sql-server/sql-server-downloads) instalado y configurado.
- [Node.js](https://nodejs.org/es/download) instalado en el servidor.
- Un editor de código (por ejemplo, Visual Studio Code) para trabajar con el código fuente.

## Configuración del Backend

1. Clona o descarga este repositorio en el servidor.
2. Abre la solución de Visual Studio en la carpeta `TaxPayers`.
3. Restaura los paquetes NuGet y compila el proyecto.
4. Configura la cadena de conexión a la base de datos SQL Server en el archivo `appsettings.json`.
5. Ejecuta las migraciones para crear las tablas de la base de datos:

```console
dotnet ef database update
```

6. Inicia el backend:

```console
dotnet run
```

El backend estará disponible en la URL [http://localhost:5000](http://localhost:5000).

## Configuración del Frontend

1. Abre una nueva terminal en la carpeta `taxpayer-app`.
2. Instala las dependencias del proyecto:

```console
npm install
```

3. Configura la URL del backend en el archivo `contanst.ts`:

```
export const BASE_API_URL = 'http://localhost:8578/api/';
```

4. Inicia el frontend:

```console
npm run dev
```

El frontend estará disponible en la URL [http://localhost:5173](http://localhost:5173).

## Uso de la Aplicación

La aplicacion tiene un listado de contribuyentes por defecto, para ver los comprobantes fiscales de cada contribuyente en el dropdown de opciones haces click en ver y veras el listado de los comprobantes, de igual forma puedes crear contribuyentes y comprobantes nuevos.
