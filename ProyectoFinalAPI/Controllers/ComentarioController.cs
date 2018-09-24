using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ProyectoSwiftAPI.DAL;
using ProyectoSwiftAPI.Models;

namespace ProyectoSwiftAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/v1/comentario")]
    public class ComentarioController : ApiController
    {
        [HttpPost]
        [Route("insertar")]
        public HttpResponseMessage Insertar([FromBody] Comentario comentario)
        {

            try
            {
                var comentarioCreado = ComentarioDAO.Insertar(comentario);
                return Request.CreateResponse(HttpStatusCode.OK, comentarioCreado);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(
                    HttpStatusCode.InternalServerError,
                    new
                    {
                        Mensaje = ex.Message
                    });//hhh
            }
        }

        [HttpGet]
        [Route("porId/{id}")]
        public HttpResponseMessage ObtenerPorId([FromUri] int id)
        {

            try
            {
                var persona = ComentarioDAO.ConsultarPorID(id);

                if (persona != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, persona);
                }
                else
                {
                    return Request.CreateResponse(
                        HttpStatusCode.NotFound,
                        new
                        {
                            Mensaje = $"No se encontró comentarios relacionado con este film {id}"
                        });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(
                    HttpStatusCode.InternalServerError,
                    new
                    {
                        Mensaje = ex.Message
                    });
            }
        }
    }
}
