using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComisionesVentasMVC.Models
{
    public class Regla
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal PorcentajeComision { get; set; }
        
        [StringLength(500)]
        public string Descripcion { get; set; }
        
        // Relación con Vendedores
        public ICollection<Vendedor> Vendedores { get; set; }
    }
}