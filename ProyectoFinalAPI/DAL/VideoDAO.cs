using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using ProyectoSwiftAPI.Models;

namespace ProyectoSwiftAPI.DAL
{
    public class VideoDAO
    {
        static readonly string CadenaConexion = ConfigurationManager.ConnectionStrings["bd_macos"].ToString();

        public static List<Video> ConsultarTodos()
        {
            using (var conexion = new MySqlConnection(CadenaConexion))
            {
                return conexion.Query<Video>("stp_video_consultart", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public static Video ConsultarPorID(int id)
        {
            using (var conexion = new MySqlConnection(CadenaConexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("v_id", id);

                return conexion.Query<Video>(
                    "stp_video_consultar",
                    parametros,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
