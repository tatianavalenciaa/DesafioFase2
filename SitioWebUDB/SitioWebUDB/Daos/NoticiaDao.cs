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
    public class NoticiaDao : Conexion {

        // OBTENER NOTICIAS DESC

        public List<Noticia> ObtenerNoticiasDesc() {

            List<Noticia> noticias = new List<Noticia>();
            Noticia noticia = null;

            try {

                AbrirConexion();
                command = new SqlCommand("sp_obtener_noticias_desc", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
                reader = command.ExecuteReader();

                while (reader.Read()) {

                    noticia = new Noticia();
                    noticia.IdNoticia = (int)reader.GetValue(reader.GetOrdinal("id_noticia"));
                    noticia.Titulo = (string)reader.GetValue(reader.GetOrdinal("titulo"));
                    noticia.Descripcion = (string)reader.GetValue(reader.GetOrdinal("descripcion"));
                    noticia.FechaCrea = (DateTime)reader.GetValue(reader.GetOrdinal("fecha_crea"));
                    noticias.Add(noticia);
                }

            } catch (Exception ex) {
                Debug.WriteLine(ex.StackTrace.ToString());
            } finally {
                CerrarConexion();
            }

            return noticias;

        }

        // OBTENER NOTICIAS

        public List<Noticia> ObtenerNoticias() {

            List<Noticia> noticias = new List<Noticia>();
            Noticia noticia = null;

            try {

                AbrirConexion();
                command = new SqlCommand("sp_obtener_noticias", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
                reader = command.ExecuteReader();

                while (reader.Read()) {

                    noticia = new Noticia();
                    noticia.IdNoticia = (int)reader.GetValue(reader.GetOrdinal("id_noticia"));
                    noticia.Titulo = (string)reader.GetValue(reader.GetOrdinal("titulo"));
                    noticia.Descripcion = (string)reader.GetValue(reader.GetOrdinal("descripcion"));
                    noticia.FechaCrea = (DateTime)reader.GetValue(reader.GetOrdinal("fecha_crea"));
                    noticias.Add(noticia);
                }

            } catch (Exception ex) {
                Debug.WriteLine(ex.StackTrace.ToString());
            } finally {
                CerrarConexion();
            }

            return noticias;

        }

        // OBTENER UNO POR ID
        public Noticia ObtenerNoticia(int id) {

            Noticia noticia = null;

            try {

                AbrirConexion();
                command = new SqlCommand("sp_obtener_noticia", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@id_noticia", SqlDbType.Int).Value = id;
                command.Connection = connection;
                reader = command.ExecuteReader();

                while (reader.Read()) {

                    noticia = new Noticia();
                    noticia.IdNoticia = (int)reader.GetValue(reader.GetOrdinal("id_noticia"));
                    noticia.Titulo = (string)reader.GetValue(reader.GetOrdinal("titulo"));
                    noticia.Descripcion = (string)reader.GetValue(reader.GetOrdinal("descripcion"));
                    noticia.FechaCrea = (DateTime)reader.GetValue(reader.GetOrdinal("fecha_crea"));
                }

            } catch (Exception ex) {
                Debug.WriteLine(ex.StackTrace.ToString());
            } finally {
                CerrarConexion();
            }

            return noticia;

        }

        // REGISTRAR
        public void RegistrarNoticia(Noticia noticia) {

            try {

                AbrirConexion();
                command = new SqlCommand("sp_registrar_noticia", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@titulo", SqlDbType.VarChar).Value = noticia.Titulo;
                command.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = noticia.Descripcion;
                command.Connection = connection;
                command.ExecuteNonQuery();

            } catch (Exception ex) {
                Debug.WriteLine(ex.StackTrace.ToString());
            } finally {
                CerrarConexion();
            }

        }

        // MODIFICAR
        public void ModificarNoticia(Noticia noticia) {

            try {

                AbrirConexion();
                command = new SqlCommand("sp_modificar_noticia", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@id_noticia", SqlDbType.Int).Value = noticia.IdNoticia;
                command.Parameters.Add("@titulo", SqlDbType.VarChar).Value = noticia.Titulo;
                command.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = noticia.Descripcion;

                command.Connection = connection;
                command.ExecuteNonQuery();

            } catch (Exception ex) {
                Debug.WriteLine(ex.StackTrace.ToString());
            } finally {
                CerrarConexion();
            }

        }

        // ACTIVAR O INACTIVAR
        public void ActInaNoticia(int id) {

            try {

                AbrirConexion();
                command = new SqlCommand("sp_act_ina_noticia", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@id_noticia", SqlDbType.Int).Value = id;

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