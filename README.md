# UserManagement - Documentación Técnica

## 1. Resumen del Proyecto

UserManagement es una API RESTful desarrollada en .NET 8 para la gestión de usuarios y ubicaciones geográficas (países, estados y ciudades). Permite operaciones CRUD sobre cada entidad y está diseñada con una arquitectura por capas.

---

## 2. Estructura del Proyecto

```
UserManagement.sln
│
├── UserManagement.API/           # API RESTful (controladores, configuración)
├── UserManagement.Application/   # Lógica de negocio y servicios
├── UserManagement.Domain/        # Entidades y contratos
├── UserManagement.Infrastructure/# Acceso a datos y repositorios
└── Scripts/                      # Scripts SQL para la base de datos
```

---

## 3. Configuración y Dependencias

- **.NET 8**
- **Npgsql** (Proveedor PostgreSQL para .NET)
- **Swagger** (Documentación interactiva de la API)
- **Dapper**

---

## 4. Guía de Instalación

1. Clona el repositorio:
   ```sh
   git clone <URL-del-repositorio>
   ```
2. Restaura los paquetes NuGet:
   ```sh
   dotnet restore
   ```
3. Configura la cadena de conexión en `UserManagement.API/appsettings.json`.
4. Ejecuta los scripts SQL de la carpeta `Scripts/` para crear la base de datos y las tablas necesarias.
5. Ejecuta el proyecto:
   ```sh
   dotnet run --project UserManagement.API
   ```

---

## 5. Guía de Uso

- Accede a la documentación Swagger en `http://localhost:<puerto>/swagger` para probar los endpoints.
- Utiliza herramientas como Postman o cURL para consumir la API.

---

## 6. Arquitectura y Diseño

- **API:** Controladores que reciben las solicitudes HTTP y devuelven respuestas.
- **Application:** Servicios que contienen la lógica de negocio.
- **Domain:** Entidades y contratos que definen el modelo de datos.
- **Infrastructure:** Acceso a datos implementado usando  Dapper.

---

## 7. Endpoints de la API (Ejemplo)

| Método | Endpoint              | Descripción                |
|--------|-----------------------|----------------------------|
| GET    | /api/users            | Lista todos los usuarios   |
| POST   | /api/users            | Crea un nuevo usuario      |
| GET    | /api/countries        | Lista todos los países     |
| POST   | /api/countries        | Crea un nuevo país         |
| ...    | ...                   | ...                        |

Consulta la documentación Swagger para ver todos los endpoints disponibles y sus detalles.

---

## 8. Modelo de Base de Datos

Las tablas principales son:
- **country**
- **state**
- **city**
- **users**

Puedes encontrar los scripts de creación en la carpeta `Scripts/`.
 

 
