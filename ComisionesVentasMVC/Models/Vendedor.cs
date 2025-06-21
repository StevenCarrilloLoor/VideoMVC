using System.ComponentModel.DataAnnotations;

namespace ComisionesVentasMVC.Models
{
    public class Vendedor
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        
        [StringLength(50)]
        public string Codigo { get; set; }
        
        // Relación con Ventas
        public ICollection<Venta> Ventas { get; set; }
        
        // Relación con Regla
        public int ReglaId { get; set; }
        public Regla Regla { get; set; }
    }
}