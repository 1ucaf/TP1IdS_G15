﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TP1IdS_G15AccesoADatos;
using TP1IdS_G15Modelo.Entidades;
using System.Web.Http.Cors;

namespace TP1IdS_G15WebService.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("productos")]
    public class ProductosController : ApiController
    {
        [HttpGet]
        [Route("lista")]
        public HttpResponseMessage GetAllProductos()
        {
            return Request.CreateResponse(
                HttpStatusCode.OK,
                Repositorio.Productos
            );
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetProducto(int id)
        {
            return Request.CreateResponse(
                HttpStatusCode.OK,
                Repositorio.Productos.Where(producto => producto.CodigoDeBarra == id).ToList().First()
            );
        }

    }
}