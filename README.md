#  MiniSistema de Gestión de Inventario

Este proyecto es un sistema de gestión de inventario desarrollado con:
- **Frontend:** Angular 19 + Angular Material
- **Backend:** .NET Core 9 con Entity Framework Core
- **Base de Datos:** PostgreSQL

##  Requisitos Previos

Asegúrate de tener instalados los siguientes programas en tu sistema:

1. [Node.js](https://nodejs.org/) (Versión 18+)
2. [Angular CLI](https://angular.io/cli)  
   ```sh
   npm install -g @angular/cli
   ```
3. [.NET SDK 9](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
4. [PostgreSQL](https://www.postgresql.org/download/)
5. [Visual Studio 2022](https://visualstudio.microsoft.com/es/) (para el backend)

---

##  **Configuración del Backend (.NET Core)**

### 1️ **Clonar el repositorio**
```sh
git clone https://github.com/tu-usuario/tu-repositorio.git
cd tu-repositorio/InventarioPruebaBackend
```

### 2️ **Configurar la Base de Datos**
1. Inicia **PostgreSQL** y crea una base de datos llamada `MiniInventarioDB`.
2. Modifica el archivo **`appsettings.json`** con tu configuración:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=MiniInventarioDB;Username=postgres;Password=tu_password"
}
```

### 3️ **Instalar dependencias**
```sh
dotnet restore
```

### 4️ **Ejecutar las migraciones**
```sh
dotnet ef database update
```

### 5️ **Ejecutar el backend**
```sh
dotnet run
```
El servidor iniciará en `https://localhost:7236/` y `http://localhost:5134/`.

---

##  **Configuración del Frontend (Angular 19 + Angular Material)**

### 1️ **Ir a la carpeta del frontend**
```sh
cd inventario-app-frontend
```

### 2️ **Instalar dependencias**
```sh
npm install
```

### 3️ **Configurar API en `src/environments/environment.ts`**
```typescript
export const environment = {
  production: false,
  apiUrl: 'https://localhost:7236' // Ajusta según la URL del backend
};
```

### 4️ **Ejecutar el frontend**
```sh
ng serve
```
El frontend se ejecutará en `http://localhost:4200/`.

---

##  **Uso del Sistema**
### 🔹 **1. Iniciar Sesión**
1. Accede a `http://localhost:4200/login`.
2. Ingresa usuario: **admin**, contraseña: **1234**.

### 🔹 **2. Inventario**
- Visualiza los productos existentes en `http://localhost:4200/inventario`.
- Haz clic en **"Mover Producto"** para actualizar el stock.

### 🔹 **3. Movimiento de Productos**
- En `http://localhost:4200/movimiento/:id`, ingresa una cantidad positiva (entrada) o negativa (salida).
- Presiona **"Registrar"** para actualizar el inventario.

---

##  **API Endpoints (Backend)**
| Método | Endpoint                | Descripción |
|--------|--------------------------|-------------|
| `POST` | `/auth/login`            | Iniciar sesión (devuelve JWT) |
| `GET`  | `/productos/inventario`  | Obtener el listado de productos |
| `POST` | `/productos/movimiento`  | Registrar entrada/salida de productos |

 **Usar Postman o cURL para probar los endpoints manualmente.**

---

## 🛠 **Tecnologías Usadas**
- **Frontend:** Angular 19, Angular Material, TypeScript
- **Backend:** .NET Core 9, Entity Framework Core, JWT Auth
- **Base de Datos:** PostgreSQL
- **Herramientas:** Visual Studio 2022, Railway para despliegue

---

##  **Mejoras Futuras**
- 🔹 Implementar roles y permisos.
- 🔹 Agregar gráficos de stock en tiempo real.
- 🔹 Integración con código de barras.

---

##  **Licencia**
Este proyecto está bajo la licencia MIT.

 **¡Contribuciones y mejoras son bienvenidas!** 
