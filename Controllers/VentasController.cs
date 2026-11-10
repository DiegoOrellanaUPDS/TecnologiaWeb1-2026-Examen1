using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Examen_1.Dominio;

// Controlador de ventas de Marco
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
}
