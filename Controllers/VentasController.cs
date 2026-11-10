using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Examen_1.Dominio;

[Route("api/[controller]")]
[ApiController]
public class VentasController : ControllerBase
{
    private readonly Examen_1Context _context;
    public VentasController(Examen_1Context context)
    {
        _context = context;
    }

    // GET: api/Venta
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Venta>>> GetVenta()
    {
        return await _context.Venta.ToListAsync();
    }

    // GET: api/Venta/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Venta>> GetVenta(int id)
    {
        var venta = await _context.Venta.FindAsync(id);

        if (venta == null)
        {
            return NotFound();
        }

        return venta;
    }

    // PUT: api/Venta/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVenta(int? id, Venta venta)
    {
        if (id != venta.Id)
        {
            return BadRequest();
        }

        _context.Entry(venta).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!VentaExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Venta
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Venta>> PostVenta(Venta venta)
    {
        _context.Venta.Add(venta);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetVenta", new { id = venta.Id }, venta);
    }

    // DELETE: api/Venta/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVenta(int? id)
    {
        var venta = await _context.Venta.FindAsync(id);
        if (venta == null)
        {
            return NotFound();
        }

        _context.Venta.Remove(venta);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool VentaExists(int? id)
    {
        return _context.Venta.Any(e => e.Id == id);
    }
    //Controlador Post
    [HttpPost("Post/Venta/YeymiRivera")]
    public async Task<IActionResult> PostVentaYeymi(string codigoventa, string codigocliente, string codigovendedor)
    {
        var venta =await (from v in _context.Venta where v.CodigoVenta==codigoventa&&v.CodigoVendedor==codigovendedor&&v.CodigoCliente==codigocliente&&v.Estado=="Pendiente"
        select v).FirstOrDefaultAsync();
        if(venta != null)
        {
            return NotFound("Esta venta ya existe y aun no se completo");
        }
        Venta venta1=new Venta();
        venta1.CodigoCliente=codigocliente;
        venta1.CodigoVendedor=codigovendedor;
        venta1.CodigoVenta=codigoventa;
        venta1.Estado="Pendiente";
        _context.Add(venta1);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetVenta", new { id = venta.Id }, venta);
    }
    //Controlador Get
    [HttpGet("GetVentaYEYMIRIVERA")]
    public async Task<IActionResult> GetVentaYeymi()
    {
    var ventas = await _context.Venta.ToListAsync();
            return Ok(ventas);
    }
    [HttpDelete("DeleteVentasYeymiRivera")]
    public async Task<IActionResult> DeleteYeymi(int id)
    {
        var venta=await (from v in _context.Venta where v.Id==id select v).FirstOrDefaultAsync();
        if(venta==null){return NotFound("Venta no existente");}
        _context.Remove(venta);
        await _context.SaveChangesAsync();
        return NotFound("Venta Borrada");
    }
}
