using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP1IdS_G15Modelo.Entidades;

namespace TP1IdS_G15WebService.Models
{
    public class ProductoDTO
    {
        public int CodigoDeBarra { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        public double MargenDeGanancia { get; set; }
        public double PorcentajeIVA { get; set; }
        public Marca Marca { get; set; }
        public Rubro Rubro { get; set; }
    }
}