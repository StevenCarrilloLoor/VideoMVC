using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComisionesVentasMVC.Models
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public DateTime FechaVenta { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }
        
        [StringLength(200)]
        public string Descripcion { get; set; }
        
        // Relación con Vendedor
        public int VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }
    }
}