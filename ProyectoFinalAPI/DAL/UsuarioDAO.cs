using System;
using System.Configuration;
using System.Data;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using ProyectoSwiftAPI.Models;

namespace ProyectoSwiftAPI.DAL
{
    public class UsuarioDAO
    {
        static readonly string CadenaConexion = ConfigurationManager.ConnectionStrings["bd_macos"].ToString();

        public static Usuario ConsultarPorID(string usuario, string password)
        {
            using (var conexion = new MySqlConnection(CadenaConexion))
            {
                var parametros = new DynamicParameters();
                parametros.Add("u_nickname", usuario);
                parametros.Add("u_password", password);

                return conexion.Query<Usuario>(
                    "stp_usuario_consultar",
                    parametros,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
