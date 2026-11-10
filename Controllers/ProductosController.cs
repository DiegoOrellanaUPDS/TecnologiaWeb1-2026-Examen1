// Se agrega linea en f0-MihaelCalvetty
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Examen_1.Dominio;

// Comentario exaamen
[Route("api/[controller]")]
[ApiController]

<<<<<<< HEAD
// Comentario practico.
=======
// Control de productos - Jheferson Velasco (Rama f2 GET)

>>>>>>> f0-Jheferson-Velasco
public class ProductosController : ControllerBase
{


    //linea conflicto post

    //mesaje cinflicto de get
    //Gitflow JuliethFlores: POST GET integrados 

    private readonly Examen_1Context _context;
    public ProductosController(Examen_1Context context)
    {
        _context = context;
    }

    [HttpGet("getProductoCarlosMiranda")]
    public async Task<IActionResult> getProductoCarlosMiranda()
    {
        var productos = await _context.Producto.ToListAsync();

        return Ok(productos);
    }

    // GET: api/Producto
   // GET: api/Producto
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Producto>>> GetProducto()
    {
        return await _context.Producto.ToListAsync();
    }
    
    // productos/max
    [HttpGet("Max")]
    public async Task<ActionResult<IEnumerable<Producto>>> GetProductoMaxCaceres()
    {
        return await _context.Producto.ToListAsync();
    }

    // Comentario modificado para la rama GET de Gerson

    // GET personalizado de Julieth Flores
    [HttpGet("getProductoJuliethFlores")]
    public async Task<IActionResult> getProductoJuliethFlores()
    {
    var productos = await _context.Producto.ToListAsync();
    return Ok(productos);
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

<<<<<<< HEAD
    // GET específico con identificador propio
    [HttpGet("gerson/{id}")]
    public async Task<ActionResult<Producto>> getProductoGersonCari(int id)
    {
        var producto = await _context.Producto.FindAsync(id);
        if (producto == null)
        {
            return NotFound();
        }
        return producto;
=======
    // GET personalizado
    [HttpGet("getProductoJhefersonVelasco")]
    public async Task<ActionResult<IEnumerable<Producto>>> getProductoJhefersonVelasco()
    {
        return await _context.Producto.ToListAsync();
>>>>>>> f0-Jheferson-Velasco
    }

    // PUT: api/Producto/5
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

    [HttpPost("postProductoCarlosMiranda")]
    public async Task<IActionResult> postProductoCarlosMiranda(Producto producto)
    {
        _context.Producto.Add(producto);
        await _context.SaveChangesAsync();

        return Ok(producto);
    }

    // POST: api/Producto
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
<<<<<<< HEAD

=======
   // POST: api/Producto
>>>>>>> f0-Jheferson-Velasco
    [HttpPost]
    public async Task<ActionResult<Producto>> postProductoGersonCari(Producto producto)
    {
        _context.Producto.Add(producto);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProducto", new { id = producto.Id }, producto);
    }

<<<<<<< HEAD
    // api/Producto/Max
    //maxCaceres
    [HttpPost("Max")]
     public async Task<ActionResult<Producto>> PostProductoMaxCaceres(Producto producto)
=======
    // POST personalizado
    [HttpPost("postProductoJhefersonVelasco")]
    public async Task<ActionResult<Producto>> postProductoJhefersonVelasco(Producto producto)
>>>>>>> f0-Jheferson-Velasco
    {
        _context.Producto.Add(producto);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProducto", new { id = producto.Id }, producto);
    }
<<<<<<< HEAD

    // POST personalizado de Julieth Flores
    [HttpPost("postProductoJuliethFlores")]
    public async Task<ActionResult<Producto>> postProductoJuliethFlores(Producto producto)
    {
        _context.Producto.Add(producto);

        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetProducto),
            new { id = producto.Id },
            producto
        );
    }
=======
    
>>>>>>> f0-Jheferson-Velasco

    // DELETE: api/Producto/5
    [HttpDelete("{id}")]
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


    [HttpPost("postProductoMihaelCalvetty")]
    public async Task<ActionResult<Producto>> PostProductoMihaelCalvetty(Producto producto)
    {
        _context.Producto.Add(producto);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProducto", new { id = producto.Id }, producto);

    }
    [HttpGet("getProductoMihaelCalvetty")]
    public async Task<ActionResult<IEnumerable<Producto>>> GetProductoMihaelCalvetty()
    {
        return await _context.Producto.ToListAsync();

    }
}

