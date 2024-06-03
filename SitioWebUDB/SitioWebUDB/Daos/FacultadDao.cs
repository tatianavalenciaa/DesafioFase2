using SitioWebUDB.Connection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using SitioWebUDB.Models;

namespace SitioWebUDB.Daos {
    public class FacultadDao : Conexion {

        // OBTENER FACULTADES

        public List<Facultad> ObtenerFacultades() {

            List<Facultad> facultades = new List<Facultad>();
            Facultad facultad = null;

            try {

                AbrirConexion();
                command = new SqlCommand("sp_obtener_facultades", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
                reader = command.ExecuteReader();

                while (reader.Read()) {

                    facultad = new Facultad();
                    facultad.IdFacultad = (int) reader.GetValue(reader.GetOrdinal("id_facultad"));
                    facultad.Nombre = (string) reader.GetValue(reader.GetOrdinal("nombre"));
                    facultad.Descripcion = (string) reader.GetValue(reader.GetOrdinal("descripcion"));
                    facultades.Add(facultad);
                }

            } catch (Exception ex) {
                Debug.WriteLine(ex.StackTrace.ToString());
            } finally {
                CerrarConexion();
            }

            return facultades;

        }

        // OBTENER UNO POR ID
        public Facultad ObtenerFacultad(int id) {

            Facultad facultad = null;

            try {

                AbrirConexion();
                command = new SqlCommand("sp_obtener_facultad", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@id_facultad", SqlDbType.Int).Value = id;
                command.Connection = connection;
                reader = command.ExecuteReader();

                while (reader.Read()) {

                    facultad = new Facultad();
                    facultad.IdFacultad = (int)reader.GetValue(reader.GetOrdinal("id_facultad"));
                    facultad.Nombre = (string)reader.GetValue(reader.GetOrdinal("nombre"));
                    facultad.Descripcion = (string)reader.GetValue(reader.GetOrdinal("descripcion"));
                }

            } catch (Exception ex) {
                Debug.WriteLine(ex.StackTrace.ToString());
            } finally {
                CerrarConexion();
            }

            return facultad;

        }

        // REGISTRAR
        public void RegistrarFacultad(Facultad facultad) {

            try {

                AbrirConexion();
                command = new SqlCommand("sp_registrar_facultad", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = facultad.Nombre;
                command.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = facultad.Descripcion;
                command.Connection = connection;
                command.ExecuteNonQuery();

            } catch (Exception ex) {
                Debug.WriteLine(ex.StackTrace.ToString());
            } finally {
                CerrarConexion();
            }

        }

        // MODIFICAR
        public void ModificarFacultad(Facultad facultad) {

            try {

                AbrirConexion();
                command = new SqlCommand("sp_modificar_facultad", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@id_facultad", SqlDbType.Int).Value = facultad.IdFacultad;
                command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = facultad.Nombre;
                command.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = facultad.Descripcion;

                command.Connection = connection;
                command.ExecuteNonQuery();

            } catch (Exception ex) {
                Debug.WriteLine(ex.StackTrace.ToString());
            } finally {
                CerrarConexion();
            }

        }

        // ACTIVAR O INACTIVAR
        public void ActInaFacultad(int id) {

            try {

                AbrirConexion();
                command = new SqlCommand("sp_act_ina_facultad", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@id_facultad", SqlDbType.Int).Value = id;

                command.Connection = connection;
                command.ExecuteNonQuery();

            } catch (Exception ex) {
                Debug.WriteLine(ex.StackTrace.ToString());
            } finally {
                CerrarConexion();
            }


        }
    }
}