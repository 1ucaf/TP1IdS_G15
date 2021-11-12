using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1IdS_G15Modelo.Entidades
{
    public class Producto
    {

        #region members
        private double _porcentajeIVA;
        private double _margenDeGanancia;
        #endregion

        #region properties
        public int CodigoDeBarra { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        public double MargenDeGanancia
        {
            get
            {
                return _margenDeGanancia * 100;
            }
            set
            {
                _margenDeGanancia = (value / 100);
            }
        }
        public double NetoGravado
        {
            get
            {
                return Costo + (Costo * _margenDeGanancia);
            }
        }
        public double PorcentajeIVA
        {
            get
            {
                return _porcentajeIVA * 100;
            }
            set
            {
                if (value < 0) throw new Exception("El impuesto IVA no puede ser inferior a 0 por ciento");
                _porcentajeIVA = (value / 100);
            }
        }
        public double IVA
        {
            get
            {
                return NetoGravado * _porcentajeIVA;
            }
        }
        public double PrecioVenta
        {
            get
            {
                return NetoGravado + IVA;
            }
        }
        public Marca Marca { get; set; }
        public Rubro Rubro { get; set; }
        #endregion
    }
}
