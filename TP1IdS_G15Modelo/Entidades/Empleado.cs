using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1IdS_G15Modelo.Entidades
{
    public class Empleado
    {
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        public List<Venta> ventas { get; set; }

    }
}
