using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1IdS_G15Modelo.Entidades
{
    public class Venta
    {
        public double Monto { get; set; }
        public DateTime Fecha { get; set; }
        public int NroFacturaAfip { get; set; }
        public List<LineaDeVenta> lineaDeVentas { get; set; }
        public MedioDePago MedioDePago { get; set; }
        public TipoComprobante tipoComprobante { get; set; }
        public Comprobante comprobante { get; set; }
        public Cliente cliente { get; set; }
        public TipoFactura tipoFactura { get; set; }
    }
}
