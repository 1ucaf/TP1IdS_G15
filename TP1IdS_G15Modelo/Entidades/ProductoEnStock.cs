using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1IdS_G15Modelo.Entidades
{
    public class ProductoEnStock
    {
        [Key]
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public Producto Producto { get; set; }
        public Color Color { get; set; }
        public Talle Talle { get; set; }
        public int SucursalId { get; set; }
    }
}
