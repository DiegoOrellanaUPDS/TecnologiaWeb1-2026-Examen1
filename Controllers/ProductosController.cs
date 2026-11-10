using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Examen_1.Dominio;

[Route("api/[controller]")]
[ApiController]
public class ProductosController : ControllerBase
{


// Rama POST: implementacion de CristianEzequielGallardo


// Rama GET: implementacion de CristianEzequielGallardo


    private readonly Examen_1Context _context;
    public ProductosController(Examen_1Context context)
    {
        _context = context;
    }

   // GET: api/Productos/getProductosCristianEzequielGallardo
[HttpGet("getProductosCristianEzequielGallardo")]
public async Task<ActionResult<IEnumerable<Producto>>>
 getProductosCristianEzequielGallardo()
    {
        return await _context.Producto.ToListAsync();
    }

  

   // GET: api/Productos/getProductoCristianEzequielGallardo/5
[HttpGet("getProductoCristianEzequielGallardo/{id}")]
public async Task<ActionResult<Producto>>
 getProductoCristianEzequielGallardo(int id)
    {
        var producto = await _context.Producto.FindAsync(id);

        if (producto == null)
        {
            return NotFound();
        }

        return producto;
    }

    // PUT: api/Producto/
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
// POST: api/Productos/postProductoCristianEzequielGallardo
    [HttpPost("postProductoCristianEzequielGallardo")]
    public async Task<ActionResult<Producto>> postProductoCristianEzequielGallardo(Producto producto)
    {
        _context.Producto.Add(producto);
        await _context.SaveChangesAsync();

        return StatusCode(201, producto);
    }

    // DELETE: api/Producto/
    // DELETE: api/Productos/deleteProductoCristianEzequielGallardo/5
[HttpDelete("deleteProductoCristianEzequielGallardo/{id}")]
public async Task<IActionResult> deleteProductoCristianEzequielGallardo(int id)
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
    public async Task<IActionResult> DeleteProducto(int? id)
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
