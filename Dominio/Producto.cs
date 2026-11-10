using System.ComponentModel.DataAnnotations;

namespace Examen_1.Dominio
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public int Precio { get; set; }
        public string Estado { get; set; }
    }
}
