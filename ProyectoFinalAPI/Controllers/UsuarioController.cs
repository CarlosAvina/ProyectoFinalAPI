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
    [RoutePrefix("api/v1/usuario")]
    public class PersonaController : ApiController
    {
        [HttpGet]
        [Route("porCredenciales/{username}/{password}")]
        public HttpResponseMessage ObtenerPorCredenciales([FromUri] string username, string password)
        {

            try
            {
                var usuario = UsuarioDAO.ConsultarPorID(username, password);

                if (usuario != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, usuario);
                }
                else
                {
                    return Request.CreateResponse(
                        HttpStatusCode.NotFound,
                        new
                        {
                            Mensaje = $"No se encontró el usuario con el nombre {username}"
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
