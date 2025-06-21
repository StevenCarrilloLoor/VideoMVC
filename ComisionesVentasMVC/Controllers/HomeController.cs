using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ComisionesVentasMVC.Data;
using ComisionesVentasMVC.Models;

namespace ComisionesVentasMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Comisiones()
        {
            ViewBag.TotalVentas = _context.Ventas.Count();
            ViewBag.TotalVendedores = _context.Vendedores.Count();
            
            var model = new ComisionViewModel
            {
                FechaInicio = new DateTime(2025, 5, 1),
                FechaFin = new DateTime(2025, 6, 30),
                Comisiones = new List<ComisionDetalle>()
            };
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Comisiones(ComisionViewModel model)
        {
            if (model.Comisiones == null)
            {
                model.Comisiones = new List<ComisionDetalle>();
            }

            ViewBag.TotalVentas = _context.Ventas.Count();
            ViewBag.TotalVendedores = _context.Vendedores.Count();
            
            if (ModelState.IsValid)
            {
                try
                {
                    var fechaInicio = model.FechaInicio.Date;
                    var fechaFin = model.FechaFin.Date.AddDays(1);

                    ViewBag.Debug = $"Buscando ventas desde {fechaInicio:yyyy-MM-dd} hasta {fechaFin:yyyy-MM-dd}";

                    // Obtener las ventas con sus vendedores y reglas
                    var ventasConDatos = await _context.Ventas
                        .Include(v => v.Vendedor)
                            .ThenInclude(vd => vd.Regla)
                        .Where(v => v.FechaVenta >= fechaInicio && v.FechaVenta < fechaFin)
                        .ToListAsync();

                    ViewBag.VentasEncontradas = ventasConDatos.Count;

                    if (ventasConDatos.Any())
                    {
                        // Agrupar por vendedor
                        var ventasAgrupadas = ventasConDatos
                            .GroupBy(v => v.VendedorId)
                            .Select(g => new ComisionDetalle
                            {
                                NombreVendedor = g.First().Vendedor.Nombre,
                                CodigoVendedor = g.First().Vendedor.Codigo,
                                TotalVentas = g.Sum(v => v.Monto),
                                PorcentajeComision = g.First().Vendedor.Regla.PorcentajeComision,
                                Comision = g.Sum(v => v.Monto) * g.First().Vendedor.Regla.PorcentajeComision / 100,
                                CantidadVentas = g.Count()
                            })
                            .OrderBy(x => x.NombreVendedor)
                            .ToList();

                        model.Comisiones = ventasAgrupadas;
                        model.TotalComisiones = ventasAgrupadas.Sum(c => c.Comision);
                    }
                    else
                    {
                        model.Comisiones = new List<ComisionDetalle>();
                        model.TotalComisiones = 0;
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Error = $"Error: {ex.Message}";
                    if (ex.InnerException != null)
                    {
                        ViewBag.Error += $" - Detalle: {ex.InnerException.Message}";
                    }
                    model.Comisiones = new List<ComisionDetalle>();
                    model.TotalComisiones = 0;
                }
            }
            else
            {
            
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                ViewBag.Error = "Errores de validación: " + string.Join(", ", errors.Select(e => e.ErrorMessage));
            }

            return View(model);
        }
    }
}