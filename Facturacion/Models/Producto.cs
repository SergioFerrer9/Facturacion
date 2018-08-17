using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Facturacion.Models
{
    public class Producto
    {
        public int idProducto { get; set; }
        public String nombreProducto { get; set; }
        public double precio { get; set; }    
    }
}