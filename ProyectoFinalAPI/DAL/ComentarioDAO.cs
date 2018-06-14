using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using MySql.Data.MySqlClient;
using ProyectoSwiftAPI.Models;
using System.Configuration;
using System.Linq;

namespace ProyectoSwiftAPI.DAL
{
    public class ComentarioDAO
    {
		static readonly string CadenaConexion = ConfigurationManager.ConnectionStrings["bd_macos"].ToString();

        public static List<Comentario> ConsultarPorID(int id)
        {
            using (var conexion = new MySqlConnection(CadenaConexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("v_id", id);

                return conexion.Query<Comentario>(
                    "stp_comentario_consultar",
                    parametros,
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public static bool Insertar(Comentario comentario)
        {
            using (var conexion = new MySqlConnection(CadenaConexion))
            {
                var parametros = new DynamicParameters();

                parametros.Add("c_usuario", comentario.id);
                parametros.Add("c_video", comentario.video.id);
                parametros.Add("c_descripcion", comentario.comentario);

                conexion.Execute(
                    "stp_comentario_insertar",
                    parametros,
                    commandType: CommandType.StoredProcedure);
                

                return true;
            }
        }
    }
}
