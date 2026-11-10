using Examen_1.Dominio;
using Microsoft.EntityFrameworkCore;

public class Examen_1Context(DbContextOptions<Examen_1Context> options) : DbContext(options)
{
    public DbSet<Producto> Producto { get; set; } = default!;
    public DbSet<Venta> Venta { get; set; } = default!;
}
