using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1IdS_G15Modelo.Entidades
{
    public class Sucursal
    {
        public string Nombre { get;set;}
        public string Ubicacion {get;set;}
        public List<PuntoDeVenta> puntoDeVentas { get; set; }
        public List<Empleado> empleados { get; set; }
        public List<ProductoEnStock> stocks { get; set; }
        
    }
}
