using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TP1IdS_G15AccesoADatos;
using TP1IdS_G15Modelo.Entidades;
using TP1IdS_G15WebService.Controllers;

namespace Testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateNewProduct_ShouldReturnSameValues()
        {
            int coddigoDeBarra = 1;
            string descripcion = "Producto 1";
            double costo = 100;
            double margenDeGanancia = 20;
            double porcentajeIVA = 21;

            Producto p = new Producto()
            {
                CodigoDeBarra = coddigoDeBarra,
                Descripcion = descripcion,
                Costo = costo,
                MargenDeGanancia = margenDeGanancia,
                PorcentajeIVA = porcentajeIVA,
            };

            Assert.AreEqual(p.CodigoDeBarra, coddigoDeBarra, 0, "Código de barra no coincide");
            Assert.AreEqual(p.Descripcion, descripcion, "Descripción no coincide");
            Assert.AreEqual(p.Costo, costo, 0, "Costo no coincide");
            Assert.AreEqual(p.MargenDeGanancia, margenDeGanancia, 0, "Margen De Ganancia no coincide");
            Assert.AreEqual(p.PorcentajeIVA, porcentajeIVA, 0, "Porcentaje de IVA no coincide");
        }


        [TestMethod]
        public void CreateNewProductAndCheckNetoGravadoCalculated()
        {
            int coddigoDeBarra = 1;
            string descripcion = "";
            double costo = 100;
            double margenDeGanancia = 20;
            double porcentajeIVA = 21;

            Producto p = new Producto()
            {
                CodigoDeBarra = coddigoDeBarra,
                Descripcion = descripcion,
                Costo = costo,
                MargenDeGanancia = margenDeGanancia,
                PorcentajeIVA = porcentajeIVA,
            };

            double netoGravadoExpected = 120;
            double netoGravado = p.NetoGravado;
            Assert.AreEqual(netoGravadoExpected, netoGravado, 0, "Neto Gravado no generado correctamente");
        }

        [TestMethod]
        public void CreateNewProductAndCheckIVACalculated()
        {
            int coddigoDeBarra = 1;
            string descripcion = "";
            double costo = 100;
            double margenDeGanancia = 20;
            double porcentajeIVA = 21;

            Producto p = new Producto()
            {
                CodigoDeBarra = coddigoDeBarra,
                Descripcion = descripcion,
                Costo = costo,
                MargenDeGanancia = margenDeGanancia,
                PorcentajeIVA = porcentajeIVA,
            };

            
            double IVAExpected = 25.2;
            double IVA = p.IVA;
            Assert.AreEqual(IVAExpected, IVA, 0, "IVA no generado correctamente");
        }

        [TestMethod]
        public void CreateNewProductAndCheckPrecioDeVentaCalculated()
        {
            int coddigoDeBarra = 1;
            string descripcion = "";
            double costo = 100;
            double margenDeGanancia = 20;
            double porcentajeIVA = 21;

            Producto p = new Producto()
            {
                CodigoDeBarra = coddigoDeBarra,
                Descripcion = descripcion,
                Costo = costo,
                MargenDeGanancia = margenDeGanancia,
                PorcentajeIVA = porcentajeIVA,
            };


            double precioVentaExpected = 145.2;
            double precioVenta = p.PrecioVenta;
            Assert.AreEqual(precioVentaExpected, precioVenta, 0, "Precio de Venta no generado correctamente");
        }

        [TestMethod]
        public void CreateANewSell_ShouldAttachClienteConsumidorFinal()
        {
            Venta v = Repositorio.CreateNewVenta();

            Assert.AreEqual("Consumidor Final".ToLower(), v.cliente.RazonSocial.ToLower(), "", "Datos de Venta autogenerados incorrectamente. No se asoció o no existe el Cliente 'Consumidor Final'");
        }
    }
}
