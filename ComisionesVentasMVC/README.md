# Sistema de Cálculo de Comisiones - MVC .NET 8

## Descripción
Sistema MVC desarrollado en .NET 8 para calcular comisiones de vendedores basado en un rango de fechas. El sistema cuenta con tres tablas relacionadas: Vendedores, Ventas y Reglas.

## Funcionalidad Principal
- Filtrar ventas por rango de fechas
- Calcular automáticamente las comisiones según las reglas asignadas
- Mostrar resumen detallado por vendedor

## Estructura de la Base de Datos
- **Vendedores**: Información de los vendedores (Id, Nombre, Código, ReglaId)
- **Ventas**: Registro de ventas (Id, FechaVenta, Monto, Descripción, VendedorId)
- **Reglas**: Porcentajes de comisión (Id, Nombre, PorcentajeComision, Descripción)

## Video Tutorial
[Link al video en Loom/YouTube explicando el desarrollo]

## Tecnologías Utilizadas
- ASP.NET Core MVC 8.0
- Entity Framework Core
- SQL Server
- Bootstrap 5

## Instalación y Configuración

1. **Configurar la cadena de conexión**
   - Editar `appsettings.json`
   - Modificar la cadena de conexión según tu servidor SQL

2. **Crear la base de datos**
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

5. **Ejecutar el proyecto**
```bash
dotnet run
```

## Uso del Sistema
1. Acceder a la página principal
2. Navegar a "Calcular Comisiones"
3. Seleccionar fecha inicio y fecha fin
4. Hacer clic en "Calcular"
5. Ver el resumen de comisiones por vendedor

## Documentación ASP.NET Core MVC
- [Documentación oficial de ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/)
- [Tutorial de Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [Guía de MVC en .NET](https://docs.microsoft.com/en-us/aspnet/core/mvc/)

## Contacto
- Nombre: Steven Carrillo
- Email: steven.carrillo@udla.edu.ec
- Email alternativo: steven.carrillo@gmail.com

## Autor
Steven Carrillo - 2025

## links de contenido
Link GitHub: 
Link Video:
Link Deploy:

