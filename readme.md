# Oracle Web API

Este proyecto es una API desarrollada en .NET 8 conectada a una base de datos Oracle, diseñada para demostrar buenas prácticas de arquitectura, como el uso de **interfaces**, **servicios**, y **controladores**.

## Características

- **Framework**: .NET 8
- **Base de datos**: Oracle (usando `Oracle.EntityFrameworkCore`)
- **Arquitectura limpia**: Separación de responsabilidades mediante carpetas como `Services`, `Interfaces`, y `Models`.
- **Swagger**: Integrado para la documentación automática de la API.
- **Entity Framework Core**: Para interactuar con la base de datos Oracle.

## Requisitos Previos

1. **Herramientas Necesarias**:
   - .NET SDK 8.0 o superior
   - Visual Studio 2022 (o VS Code con extensiones C#)
   - Oracle Database (11g o superior)
   - Paquete NuGet: `Oracle.EntityFrameworkCore`

2. **Configuraciones del Entorno**:
   - Configurar la cadena de conexión en el archivo `appsettings.json` para conectarse a tu base de datos Oracle.

## Paquetes Necesarios

Los siguientes paquetes están configurados en el proyecto:

- **Microsoft.EntityFrameworkCore (9.0.0)**: ORM para trabajar con bases de datos.
- **Microsoft.EntityFrameworkCore.Tools (9.0.0)**: Herramientas de línea de comandos para EF Core.
- **Oracle.EntityFrameworkCore (9.23.60)**: Provider de EF Core para bases de datos Oracle.
- **Swashbuckle.AspNetCore (7.2.0)**: Para la integración de Swagger.

## Instalación y Configuración

1. **Clonar el Repositorio**:
   ```bash
   git clone https://github.com/Lemito66/oracle-web-api.git
   cd tu_repositorio
   ```

2. **Restaurar Dependencias**:
   ```bash
   dotnet restore
   ```

3. **Configurar la Cadena de Conexión**:
   Edita el archivo `appsettings.json` para incluir la cadena de conexión a Oracle:
   ```json
   {
     "ConnectionStrings": {
       "OracleDB": "User Id=tu_usuario;Password=tu_contraseña;Data Source=tu_host:puerto/tu_servicio",
       "Produccion": "Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = PROTOCOLNAME)(HOST = HOSTNAME)(PORT = PORTNAME))(CONNECT_DATA =(SERVICE_NAME = SERVICENAME))); User Id=IDNAME;Password=PASSWORDNAME;"
     }
   }
   ```

4. **Ejecutar la Aplicación**:
   ```bash
   dotnet run
   ```

5. **Acceder a Swagger**:
   Una vez que la aplicación esté en ejecución, accede a Swagger para probar los endpoints:
   - URL por defecto: `http://localhost:5052/swagger/index.html`

## Estructura del Proyecto

```plaintext
oracle-web-api
├── Context
│   └── ModelContext.cs      # Contexto de EF Core para la base de datos Oracle
├── Controllers
│   ├── AttentionController.cs # Controlador para gestionar las atenciones
│   └── WeatherForecastController.cs
├── Interfaces
│   └── IAttentionService.cs # Contrato para el servicio de atención
├── Models
│   └── Attention.cs          # Modelo de datos para la entidad Attention
├── Services
│   └── AttentionService.cs   # Implementación del servicio de atención
├── appsettings.json          # Configuración de la cadena de conexión
├── Program.cs                # Configuración del punto de entrada y DI
└── WeatherForecast.cs
```

## Endpoints Principales

### GET `/api/attention/{id}`
- **Descripción**: Devuelve la atención correspondiente al identificador especificado.
- **Respuesta Exitosa**:
  ```json
  {
    "status": true,
    "data": {
      "attentionId": 123,
      "dateAttention": "2024-01-08T10:00:00",
      "patientName": "John Doe"
    }
  }
  ```
- **Errores**:
  - `404`: No se encontraron resultados.
  - `500`: Error inesperado.

## Próximos Pasos

- Implementar más controladores para otras entidades.
- Añadir autenticación y autorización.
- Agregar más pruebas unitarias y de integración.

## Contribuciones

Las contribuciones son bienvenidas. Por favor, abre un issue o un pull request si deseas mejorar este proyecto.

