using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TP1IdS_G15AccesoADatos;

namespace TP1IdS_G15WebService.Controllers
{
    [RoutePrefix("marcas")]
    public class MarcasController : ApiController
    {
        [HttpGet]
        [Route("lista")]
        public HttpResponseMessage GetAllMarcas()
        {
            return Request.CreateResponse(HttpStatusCode.OK, Repositorio.Marcas);
        }
    }
}
