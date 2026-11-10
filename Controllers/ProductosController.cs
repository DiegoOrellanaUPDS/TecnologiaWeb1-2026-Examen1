using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Examen_1.Dominio;

[Route("api/[controller]")]
[ApiController]
public class ProductosController : ControllerBase
// Misael Choque: integración de operaciones de productos.
{
    private readonly Examen_1Context _context;
    public ProductosController(Examen_1Context context)
    {
        _context = context;
    }
    // GET: api/Producto
    [HttpGet("getProductoMisaelChoque")]
    public async Task<ActionResult<IEnumerable<Producto>>> GetProductoMisaelChoque()
    {
    return await _context.Producto.ToListAsync();
    }
    // GET: api/Producto/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Producto>> GetProducto(int id)
    {
        var producto = await _context.Producto.FindAsync(id);

        if (producto == null)
        {
            return NotFound();
        }

        return producto;
    }

    // PUT: api/Producto/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProducto(int? id, Producto producto)
    {
        if (id != producto.Id)
        {
            return BadRequest();
        }

        _context.Entry(producto).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductoExists(id))
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

    // POST: api/Producto
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost("postProductoMisaelChoque")]
    public async Task<ActionResult<Producto>> PostProductoMisaelChoque(Producto producto)
    {
      _context.Producto.Add(producto);
    await _context.SaveChangesAsync();

    return CreatedAtAction("GetProducto", new { id = producto.Id }, producto);
    }
    
    
    // DELETE: api/Producto/5
    [HttpDelete("deleteProductoMisaelChoque/{id}")]
    public async Task<IActionResult> deleteProductoMisaelChoque(int? id)
    {
      var producto = await _context.Producto.FindAsync(id);

    if (producto == null)
    {
        return NotFound();
    }

    _context.Producto.Remove(producto);
    await _context.SaveChangesAsync();

    return NoContent();
    }

    private bool ProductoExists(int? id)
    {
        return _context.Producto.Any(e => e.Id == id);
    }
}
