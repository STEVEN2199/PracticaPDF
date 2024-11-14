using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PuntoDeVenta.Data;
using PuntoDeVenta.Dtos;
using PuntoDeVenta.Models;
using System.Data;

namespace PuntoDeVenta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BodegaController : Controller
    {
        private DataContext _context;

        public BodegaController(DataContext context) {
            _context = context;
        }

        [HttpPost("")]
        public async Task<ActionResult<int>> StoreBodega(BodegaDTO bodega)
        {
            var paramId = new SqlParameter("@id", SqlDbType.Int);
            paramId.Direction = ParameterDirection.Output;

            await _context.Database.ExecuteSqlInterpolatedAsync($@"
                EXEC spInsertarBodega 
                    @nombre={bodega.Nombre}, 
                    @direccion={bodega.Direccion}, 
                    @telefono={bodega.Telefono},
                    @id={paramId} OUTPUT
            ");

            int idBodega = (int)paramId.Value;
            return Ok(idBodega);
        }
    }
}
