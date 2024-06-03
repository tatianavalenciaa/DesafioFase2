using SitioWebUDB.Connection;
using SitioWebUDB.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SitioWebUDB.Daos {
    public class UsuarioDao : Conexion {

        public Usuario ObtenerUsuario(string usuario, string password) {
            Usuario user = null;

            try {

                AbrirConexion();
                command = new SqlCommand("sp_obtener_usuario", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@usuario", SqlDbType.VarChar).Value = usuario;
                command.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
                command.Connection = connection;
                reader = command.ExecuteReader();

                if (reader.Read()) {
                    user = new Usuario();
                    user.User = (string) reader.GetValue(reader.GetOrdinal("usuario"));
                    user.Pass = (string) reader.GetValue(reader.GetOrdinal("password"));
                }

            } catch (Exception ex) {
                Debug.WriteLine(ex.StackTrace.ToString());
            } finally {
                CerrarConexion();
            }

            return user;
        }

    }
}