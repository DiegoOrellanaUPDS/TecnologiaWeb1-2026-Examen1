using System.ComponentModel.DataAnnotations;

namespace Examen_1.Dominio
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }
        public string CodigoVenta { get; set; }
        public string CodigoCliente { get; set; }
        public string CodigoVendedor { get; set; }
        public string Estado { get; set; }


    }
}
