# perla-metro-stations-service

Servicio encargado de la gestión de estaciones para el transporte subterráneo de Antofagasta, siendo la empresa responsable Perla Metro. Este servicio forma parte de la arquitectura SOA  de monolito distribuido, especializado en la creación, despliegue, validación y administración de las estaciones de transporte.

## Arquitectura y Patrón de Diseño

### Arquitectura del repositorio: Monolito Distribuido componente de un SOA (Service-Oriented Architecture)

El Station Service implementa una arquitectura por capas (Layered Architecture) dentro del contexto SOA.
```mermaid
flowchart TD
    A[API MAIN
Orquestador]
    
    subgraph Station_Service
        B1[Controller] --> B2[Service/Mapper]
        B2 --> B3[Repository/Models]
    end
    A --> B1
    B3 --> C[MySQL
Base de datos]
```
### Patrones de diseño implementados:
1. **Repository Pattern:** Utilizado para la abstracción del acceso a datos.
2. **Data Transfer Object (DTO):** Utilizado para la transferencia de datos entre capas.

## Tecnologías utilizadas
- **Framework:** ASP.NET Core 9.0
- **Base de Datos:** MySQL
- **Deployment:** Render
- **Control de versiones:** Git con Conventional Commits

## Modelo de Datos
### Entidad Station (MySQL)
```
{
  Id: UUID v4 Guid,
  Name: string,
  Location: string,
  StopType: string¨// Origen | Intermedia | Destino,
  IsActive: bool, //true por default
}
```
### Estados de la estación:
- **Activa:** Estación se encuentra activa.
- **Inactiva:** Estación se encuentra inactiva.
### Tipos de parada:
- **Origen:** Estación de origen.
- **Intermedia:** Estación intermedia de ruta.
- **Destino:** Estación destino de ruta.

## Endpoints de la API

### Endpoint Disponibles

| Método | Endpoint | Descripción | Parámetros|
|--------|----------|-------------|-----------|
| `GET` | `/api/Station` | Listar todas las estaciones | `Query: name (string, opcional), stopType (string, opcional), status (string: true/false, opcional)` |
| `POST` | `/api/Station` | Crear nueva estación | `Body: Name: string, Location: string, StopType: string`|
| `GET` | `/api/Station/{id}` | Obtener estación por ID | `id: string (UUIDv4)` |
| `PUT` | `/api/Station/{id}` | Actualizar estación | `id: string(UUIDv4)`, `Body: Name: string, Location: string, StopType: string` |
| `DELETE` | `/api/Station/{id}` | Eliminar estación (soft delete) | `id: string (UUIDv4)` |

## Instalación y Configuración

- **.NET 9 SDK:** [Download](https://dotnet.microsoft.com/download/dotnet/9.0)
- **Visual Studio Code o Visual Studio 2022:** [Download](https://code.visualstudio.com/)
- **MySQL DB desplegada (Ofrecida gratuitamente por Railway):** [Railway](https://railway.com/)

1. **Clonar el repositorio**
    ```bash
    git clone https://github.com/Proyecto-Perla-Metro-2025/perla-metro-stations-service.git

    cd <Directorio donde fue clonado>
    ```
2. **Configurar Varibles de Entorno (.env)**
   ```env
   ///Recuerda eliminar comillas ("")
   DB_CONNECTION=Server="Tu Host";Port="Tu puerto";Database="Tu nombre de base de datos";User="Tu usuario";Password="Tu contraseña";
    ```
    **Nota importante:** Considera la URL publica de MySQL ofrecida por railway, donde los valores se ven tal que: ***mysql://USER:PASSWORD@HOST:PORT/DATABASE***

4. **Instalar Dependencias**
    ```bash
    dotnet restore
    ```

5. **Ejecutar el Proyecto**
    ```bash
    dotnet run
    ```

## Despliegue en Render

### 1. Configuración del Servicio (Docker)
- **Repository:** Conectar con el repositorio de Github
- **Branch:** main
- **Enviroment:** Docker
- **Root Directory:** perla-metro-stations-service-api
- **Dockerfile Path:** perla-metro-stations-service-api/dockerfile
- **Enviroment Variables:** DB_CONNECTION
- **Enviroment Variable Value:** <Tu DB_CONNECTION, detalles en el apartado Instalación y configuración paso 2>
### 2. Obten tu URL de producción
  Deberia verse similar a "https://nombre-repositorio.onrender.com"
### 3. Endpoints disponibles en producción
| Método | Endpoint | Descripción | Parámetros|
|--------|----------|-------------|-----------|
| `GET` | `/api/Station` | Listar todas las estaciones | `Query: name (string, opcional), stopType (string, opcional), status (string: true/false, opcional)`|
| `POST` | `/api/Station` | Crear nueva estación | `Body: Name: string, Location: string, StopType: string`|
| `GET` | `/api/Station/{id}` | Obtener estación por ID | `id: string (UUIDv4)` |
| `PUT` | `/api/Station/{id}` | Actualizar estación | `id: string(UUIDv4)`, `Body: Name: string, Location: string, StopType: string` |
| `DELETE` | `/api/Station/{id}` | Eliminar estación (soft delete) | `id: string (UUIDv4)` |

### Ejemplos de uso (Postman):

**Asumiendo que su URL es la obtenida en producción "https://nombre-repositorio.onrender.com". En caso de estar ejecutándose localmente, su URL debería verse similar a: "http://localhost:8080".**

**1. POST:**
```
URL: https://nombre-repositorio.onrender.com/api/Station
Body (JSON):
{
  "Name": "Estación La Torre",
  "Location": "Antofagasta, calle La Torre",
  "StopType": "Origen"
}
Response (200 OK):
{
    "data": {
        "name": "Estación La Torre",
        "location": "Calle La Torre, Antofagasta",
        "stopType": "Origen"
    },
    "message": "Station created successfully",
    "success": true
}
```
**2. GET /api/Station:**
```
URL: https://nombre-repositorio.onrender.com/api/Station
Response (200 OK):
{
    "data": [
        {
            "id": "2fb729b3-5af3-4fa6-b2ec-a2173f9adb30",
            "name": "Estación La Torre",
            "location": "Calle La Torre, Antofagasta",
            "stopType": "Origen",
            "status": "Active",
            "isActive": true
        }
    ],
    "message": "Stations retrieved successfully",
    "success": true
}
```
**2.1. GET /api/Station?name=La%20Torre:**
```
URL: https://nombre-repositorio.onrender.com/api/Station?name=La%20Torre
Response (200 OK):
{
    "data": [
        {
            "id": "2fb729b3-5af3-4fa6-b2ec-a2173f9adb30",
            "name": "Estación La Torre",
            "location": "Calle La Torre, Antofagasta",
            "stopType": "Origen",
            "status": "Active",
            "isActive": true
        }
    ],
    "message": "Stations retrieved successfully",
    "success": true
}
```
**3. GET /api/Station/{Id}:**
```
URL: https://nombre-repositorio.onrender.com/api/Station/2fb729b3-5af3-4fa6-b2ec-a2173f9adb30
Response (200 OK)
{
    "data": {
        "id": "2fb729b3-5af3-4fa6-b2ec-a2173f9adb30",
        "name": "Estación La Torre",
        "location": "Antofagasta, calle La Torre",
        "stopType": "Origen",
        "status": "Active",
        "isActive": true
    },
    "message": "Station retrieved successfully",
    "success": true
}
```
**4. PUT /api/Station/{Id}:**
```
URL: https://nombre-repositorio.onrender.com/api/Station/2fb729b3-5af3-4fa6-b2ec-a2173f9adb30
Body (JSON):
{
  "Name": "Estación La Torre 2",
  "Location": "Antofagasta, calle La Torre",
  "StopType": "Origen"
}
Response (200 OK):
{
    "data": {
        "id": "2fb729b3-5af3-4fa6-b2ec-a2173f9adb30",
        "name": "Estación La Torre 2",
        "location": "Antofagasta, calle La Torre",
        "stopType": "Origen",
        "status": "Active",
        "isActive": true
    },
    "message": "Station updated successfully",
    "success": true
}
```
**4. DELETE /api/Station/{Id}:**
```
URL: https://nombre-repositorio.onrender.com/api/Station/2fb729b3-5af3-4fa6-b2ec-a2173f9adb30
Response (200 OK):
{
    "data": {
        "id": "2fb729b3-5af3-4fa6-b2ec-a2173f9adb30",
        "name": "Estación La Torre 2",
        "location": "Calle La Torre, Antofagasta",
        "stopType": "Origen",
        "status": "Inactive",
        "isActive": false
    },
    "message": "Station deleted successfully",
    "success": true
}
```
### Ignacio Carvajal, 21.411.819-K
### Observaciones / Consideraciones

- Se considera que las estaciones solo pueden ser de tipo origen, destino o intermedia de forma unica y exclusiva.
- La base de datos desplegada en Railway puede estar en modo *Serverless*, lo que significa que, en caso de bajo tráfico, puede apagarse automáticamente y se encenderá al recibir la primera solicitud. Por lo tanto, se solicita reintentar las solicitudes iniciales.
