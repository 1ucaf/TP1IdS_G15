using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1IdS_G15Modelo.Entidades;

namespace TP1IdS_G15AccesoADatos
{
    public static class Repositorio
    {
        public static List<Cliente> Clientes = new List<Cliente>()
        {
            new Cliente()
            {
                RazonSocial = "Consumidor Final",
            }
        };
        public static List<Rubro> Rubros = new List<Rubro>
        {
            new Rubro { Id = 0, Descripcion = "Calzados" },
            new Rubro { Id = 1, Descripcion = "Camperas" },
            new Rubro { Id = 2, Descripcion = "Remeras" },
            new Rubro { Id = 3, Descripcion = "Camisas" },
            new Rubro { Id = 4, Descripcion = "Pantalones" },
        };

        public static List<Marca> Marcas = new List<Marca>
        {
            new Marca { Id = 0, Descripcion = "Nike" },
            new Marca { Id = 1, Descripcion = "Bando" },
            new Marca { Id = 2, Descripcion = "Lee" },
            new Marca { Id = 3, Descripcion = "Adidas" },
            new Marca { Id = 4, Descripcion = "Polo" },
            new Marca { Id = 5, Descripcion = "Puma" },
            new Marca { Id = 6, Descripcion = "Kevingston" },
        };

        public static List<Color> Colores = new List<Color>
        {
            new Color { Descripcion = "Negro" },
            new Color { Descripcion = "Rojo" },
            new Color { Descripcion = "Amarillo" },
            new Color { Descripcion = "Azul" },
            new Color { Descripcion = "Bordeau" },
            new Color { Descripcion = "Blanco" },
        };

        public static List<Talle> Talles = new List<Talle>
        {
            new Talle { Descripcion = "XS" },
            new Talle { Descripcion = "S" },
            new Talle { Descripcion = "M" },
            new Talle { Descripcion = "L" },
            new Talle { Descripcion = "XL" },
            new Talle { Descripcion = "XXL" },
        };

        public static List<Producto> Productos = new List<Producto>
        {
            new Producto
            {
                CodigoDeBarra = 0,
                Descripcion = "Zapatilla",
                Costo = 5000,
                MargenDeGanancia = 30,
                PorcentajeIVA = 21,
                Marca = Marcas[5],
                Rubro = Rubros[0],
            },
            new Producto
            {
                CodigoDeBarra = 1,
                Descripcion = "Jean",
                Costo = 5000,
                MargenDeGanancia = 30,
                PorcentajeIVA = 21,
                Marca = Marcas[2],
                Rubro = Rubros[4],
            },
            new Producto
            {
                CodigoDeBarra = 2,
                Descripcion = "Chomba",
                Costo = 3000,
                MargenDeGanancia = 30,
                PorcentajeIVA = 21,
                Marca = Marcas[6],
                Rubro = Rubros[2],
            },
        };

        public static Venta CreateNewVenta()
        {
            Cliente c = Clientes.Where(cliente => cliente.RazonSocial.Equals("Consumidor Final")).First();
            Venta v = new Venta()
            {
                Cliente = c,
            };
            return v;
        }
    }
}
