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
        private double _costo;
        private double _netoGravado;
        private double _porcentajeIVA;
        private double _IVA;
        private double _margenDeGanancia;
        private double _precioVenta;
        #endregion

        #region properties
        public int CodigoDeBarra { get; set; }
        public string Descripcion { get; set; }
        public double Costo
        {
            get
            {
                return _costo;
            }
            set
            {
                _costo = value;
                _netoGravado = _costo + (_costo * _margenDeGanancia);
                _IVA = _netoGravado * _porcentajeIVA;
                _precioVenta = _netoGravado + _IVA;
            }
        }
        public double MargenDeGanancia
        {
            get
            {
                return _margenDeGanancia * 100;
            }
            set
            {
                _margenDeGanancia = (value / 100);
                _netoGravado = _costo + (_costo * _margenDeGanancia);
                _IVA = _netoGravado * _porcentajeIVA;
                _precioVenta = _netoGravado + _IVA;
            }
        }
        public double NetoGravado
        {
            get
            {
                return _netoGravado;
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
                _IVA = _netoGravado * _porcentajeIVA;
                _precioVenta = _netoGravado + _IVA;
            }
        }
        public double IVA
        {
            get
            {
                return _IVA;
            }
        }
        public double PrecioVenta
        {
            get
            {
                return _precioVenta;
            }
        }
        public Marca Marca { get; set; }
        public Rubro Rubro { get; set; }
        #endregion
    }
}
