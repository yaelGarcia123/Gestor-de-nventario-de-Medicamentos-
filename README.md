# 💊 Gestor de Inventario de Medicamentos - Medigroup

Este es un proyecto FullStack desarrollado como parte de la evaluación técnica para **Medigroup del Pacífico**. La aplicación permite la gestión completa (CRUD) de inventarios de medicamentos, incluyendo filtros avanzados de búsqueda.

## 🚀 Tecnologías Utilizadas

### Frontend

- [cite_start]**HTML5 & CSS3**: Estructura y diseño responsivo[cite: 11].
- [cite_start]**Bootstrap 5**: Framework de estilos para una interfaz moderna[cite: 11].
- [cite_start]**JavaScript (Vanilla) & jQuery**: Lógica de cliente y manipulación del DOM[cite: 9, 10].
- [cite_start]**AJAX**: Consumo de la API REST[cite: 12].

### Backend

- [cite_start]**ASP.NET Core Web API**: Creación de servicios RESTful[cite: 15, 16].
- **Entity Framework Core**: ORM para la gestión de la base de datos.
- [cite_start]**SQL Server**: Motor de base de datos relacional[cite: 18].

---

## 🛠️ Configuración y Ejecución

### 1. Base de Datos

Ejecute el siguiente script en su instancia de **SQL Server** para crear la tabla necesaria:

```sql
CREATE TABLE Medicamentos (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(255) NOT NULL,
    categoria VARCHAR(100) NOT NULL,
    cantidad INT NOT NULL,
    fecha_expiracion DATE NOT NULL
);
```
