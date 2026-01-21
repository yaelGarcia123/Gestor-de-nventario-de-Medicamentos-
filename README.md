# Gestor de Inventario de Medicamentos - Medigroup

Proyecto desarrollado para la evaluación técnica de Medigroup del Pacífico.

## Cómo ejecutar el proyecto

Para evitar restricciones de seguridad del navegador (CORS/Private Network Access) al conectar un sitio web público con una base de datos local

### 1. Base de Datos

1. Abra **SQL Server Management Studio**.
2. Ejecute el script `script_db.sql` incluido en la raíz de este repositorio para crear la tabla `Medicamentos`.

### 2. Backend (api.net)

1. Abra la carpeta `backend` y ejecute el archivo `Apimedigroup.sln` con **Visual Studio**.
2. En el archivo `appsettings.json`, asegúrese de que la cadena de conexión coincida con su servidor local (DefaultConnection).
3. Presione **F5** para iniciar la API. Se abrirá una ventana de Swagger en `https://localhost:7231`.

### 3. Frontend

1. Navegue a la carpeta `front-end`.
2. Abra el archivo `index.html` directamente en su navegador.
3. Y **¡Listo!** Al estar ambos componentes en el mismo entorno local, podrá realizar el CRUD completo, filtros y búsquedas sin bloqueos de seguridad.

---

**Hosting demo online (Solo Visualización):** https://gleeful-babka-a16bc0.netlify.app/
