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
    [RoutePrefix("api/v1/videos")]
    public class VideoController : ApiController
    {
        [HttpGet]
        [Route("todos")]
        public HttpResponseMessage ObtenerTodos()
        {

            try
            {
                var videos = VideoDAO.ConsultarTodos();
                return Request.CreateResponse(HttpStatusCode.OK, videos);
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

        [HttpGet]
        [Route("porId/{id}")]
        public HttpResponseMessage ObtenerPorId([FromUri] int id)
        {

            try
            {
                var video = VideoDAO.ConsultarPorID(id);

                if (video != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, video);
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
