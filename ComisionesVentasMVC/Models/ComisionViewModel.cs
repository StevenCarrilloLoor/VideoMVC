using System.ComponentModel.DataAnnotations;

namespace ComisionesVentasMVC.Models
{
    public class ComisionViewModel
    {
        [Required]
        [Display(Name = "Fecha Inicio")]
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get; set; }
        
        [Required]
        [Display(Name = "Fecha Fin")]
        [DataType(DataType.Date)]
        public DateTime FechaFin { get; set; }
        
        public List<ComisionDetalle>? Comisiones { get; set; }
        
        public decimal TotalComisiones { get; set; }
    }
    
    public class ComisionDetalle
    {
        public string NombreVendedor { get; set; } = string.Empty;
        public string CodigoVendedor { get; set; } = string.Empty;
        public decimal TotalVentas { get; set; }
        public decimal PorcentajeComision { get; set; }
        public decimal Comision { get; set; }
        public int CantidadVentas { get; set; }
    }
}