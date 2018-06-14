using System;
namespace ProyectoSwiftAPI.Models
{
    public class Comentario : Usuario
    {
		public int idComentario { get; set; }
        //public Usuario usuario { get; set; }
        public Video video { get; set; }
        public string comentario { get; set; }
    }
}
