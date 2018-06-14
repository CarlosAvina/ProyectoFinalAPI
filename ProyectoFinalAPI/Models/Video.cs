using System;
namespace ProyectoSwiftAPI.Models
{
    public class Video
	{
		public int id { get; set; }
		public string titulo { get; set; }
		public string descripcion { get; set; }
		public int likes { get; set; }
		public int dislike { get; set; }
	}
}
