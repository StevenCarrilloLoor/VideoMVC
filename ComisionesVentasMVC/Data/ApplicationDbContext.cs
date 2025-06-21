using Microsoft.EntityFrameworkCore;
using ComisionesVentasMVC.Models;

namespace ComisionesVentasMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Regla> Reglas { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Quema de datos para Reglas
            modelBuilder.Entity<Regla>().HasData(
                new Regla { Id = 1, Nombre = "Comisión Básica", PorcentajeComision = 5, Descripcion = "5% de comisión" },
                new Regla { Id = 2, Nombre = "Comisión Estándar", PorcentajeComision = 10, Descripcion = "10% de comisión" },
                new Regla { Id = 3, Nombre = "Comisión Premium", PorcentajeComision = 15, Descripcion = "15% de comisión" }
            );
            
            // Quema de datos para Vendedores
            modelBuilder.Entity<Vendedor>().HasData(
                new Vendedor { Id = 1, Nombre = "Pedro García", Codigo = "VEN001", ReglaId = 2 },
                new Vendedor { Id = 2, Nombre = "María López", Codigo = "VEN002", ReglaId = 1 },
                new Vendedor { Id = 3, Nombre = "Juan Martínez", Codigo = "VEN003", ReglaId = 3 }
            );
            
            // Quema de datos para Ventas
            modelBuilder.Entity<Venta>().HasData(
                new Venta { Id = 1, FechaVenta = new DateTime(2025, 6, 2), Monto = 500, Descripcion = "Venta de producto A", VendedorId = 1 },
                new Venta { Id = 2, FechaVenta = new DateTime(2025, 6, 15), Monto = 300, Descripcion = "Venta de producto B", VendedorId = 1 },
                new Venta { Id = 3, FechaVenta = new DateTime(2025, 5, 29), Monto = 700, Descripcion = "Venta de producto C", VendedorId = 2 },
                new Venta { Id = 4, FechaVenta = new DateTime(2025, 6, 3), Monto = 900, Descripcion = "Venta de producto D", VendedorId = 2 },
                new Venta { Id = 5, FechaVenta = new DateTime(2025, 6, 20), Monto = 600, Descripcion = "Venta de producto E", VendedorId = 3 }
            );
        }
    }
}