using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using TP1IdS_G15AccesoADatos;
using TP1IdS_G15Modelo.Entidades;
using TP1IdS_G15WebService.Models;

namespace TP1IdS_G15WebService.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("productos")]
    public class ProductosController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Productos
        public IQueryable<Producto> GetProducto()
        {
            return db.Productos;
        }

        // GET: api/Productos/5
        [ResponseType(typeof(Producto))]
        public IHttpActionResult GetProducto(int id)
        {
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        // PUT: api/Productos/?id=5
        [HttpPut]
        [Route("Modify")]
        public HttpResponseMessage ModifyProducto(int id, [FromBody] ProductoDTO productoDTO)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != productoDTO.CodigoDeBarra)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            Producto producto = db.Productos.Where(prod => prod.CodigoDeBarra == productoDTO.CodigoDeBarra).ToList().First();

            producto.Marca = db.Marcas.Where(marc => marc.Id == productoDTO.MarcaId).ToList().First();
            producto.Rubro = db.Rubros.Where(rubr => rubr.Id == productoDTO.RubroId).ToList().First();

            db.Entry(producto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(id))
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    throw;
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, producto);
        }

        [HttpPost]
        [Route("initialize")]
        public HttpResponseMessage CreateProducto(ProductoDTO productoDTO)
        {
            Marca marca = null;
            Rubro rubro = null;
            try
            {
                marca = db.Marcas.Where(marc => marc.Id == productoDTO.MarcaId).ToList().First();
                rubro = db.Rubros.Where(rubr => rubr.Id == productoDTO.RubroId).ToList().First();
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            var producto = new Producto(productoDTO.CodigoDeBarra, productoDTO.Descripcion, productoDTO.Costo, productoDTO.MargenDeGanancia, productoDTO.PorcentajeIVA, marca, rubro);
            return Request.CreateResponse(HttpStatusCode.OK, producto);
        }

        // POST: api/Productos
        [HttpPost]
        [Route("save")]
        public HttpResponseMessage SaveProducto(ProductoDTO productoDTO)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, productoDTO);
            }

            var marca = db.Marcas.Where(marc => marc.Id == productoDTO.MarcaId).ToList().First();
            var rubro = db.Rubros.Where(rubr => rubr.Id == productoDTO.RubroId).ToList().First();
            var producto = new Producto(productoDTO.CodigoDeBarra, productoDTO.Descripcion, productoDTO.Costo, productoDTO.MargenDeGanancia, productoDTO.PorcentajeIVA, marca, rubro);
            db.Productos.Add(producto);
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, producto);
        }

        // DELETE: api/Productos/5
        [ResponseType(typeof(Producto))]
        public IHttpActionResult DeleteProducto(int id)
        {
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return NotFound();
            }

            db.Productos.Remove(producto);
            db.SaveChanges();

            return Ok(producto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductoExists(int id)
        {
            return db.Productos.Count(e => e.CodigoDeBarra == id) > 0;
        }
    }
}