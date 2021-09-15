using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1IdS_G15Modelo.Entidades
{
    public class PuntoDeVenta
    {
        public int NumeroPDV { get; set; }
        public Sesion sesion { get; set; }
        public List<Venta> venta { get; set; }

    }
}
