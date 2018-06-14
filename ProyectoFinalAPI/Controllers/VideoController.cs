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
    }
}
