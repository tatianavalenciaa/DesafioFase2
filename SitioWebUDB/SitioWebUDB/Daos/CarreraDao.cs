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
    public class CarreraDao : Conexion {

        // OBTENER CARRERAS X ID_FACULTAD
        public List<Carrera> ObtenerCarrerasXIdFac(int idFacultad) {

            List<Carrera> carreras = new List<Carrera>();
            Carrera carrera = null;

            try {

                AbrirConexion();
                command = new SqlCommand("sp_obtener_carreras_x_fac", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@id_facultad", SqlDbType.Int).Value = idFacultad;
                command.Connection = connection;
                reader = command.ExecuteReader();

                while (reader.Read()) {

                    carrera = new Carrera();
                    carrera.IdCarrera = (int) reader.GetValue(reader.GetOrdinal("id_carrera"));
                    carrera.Nombre = (string) reader.GetValue(reader.GetOrdinal("nombre"));
                    carrera.Descripcion = (string) reader.GetValue(reader.GetOrdinal("descripcion"));
                    carreras.Add(carrera);
                }

            } catch (Exception ex) {
                Debug.WriteLine(ex.StackTrace.ToString());
            } finally {
                CerrarConexion();
            }

            return carreras;

        }

        // OBTENER CARRERAS

        public List<Carrera> ObtenerCarreras() {

            List<Carrera> carreras = new List<Carrera>();
            Carrera carrera = null;

            try {

                AbrirConexion();
                command = new SqlCommand("sp_obtener_carrerass", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
                reader = command.ExecuteReader();

                while (reader.Read()) {

                    carrera = new Carrera();
                    carrera.IdCarrera = (int) reader.GetValue(reader.GetOrdinal("id_carrera"));
                    carrera.Nombre = (string) reader.GetValue(reader.GetOrdinal("nombre"));
                    carrera.Descripcion = (string) reader.GetValue(reader.GetOrdinal("descripcion"));
                    carrera.Facultad = (string)reader.GetValue(reader.GetOrdinal("facultad"));
                    carreras.Add(carrera);
                }

            } catch (Exception ex) {
                Debug.WriteLine(ex.StackTrace.ToString());
            } finally {
                CerrarConexion();
            }

            return carreras;

        }

        // OBTENER UNO POR ID
        public Carrera ObtenerCarrera(int id) {

            Carrera carrera = null;

            try {

                AbrirConexion();
                command = new SqlCommand("sp_obtener_carrera", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@id_carrera", SqlDbType.Int).Value = id;
                command.Connection = connection;
                reader = command.ExecuteReader();

                while (reader.Read()) {

                    carrera = new Carrera();
                    carrera.IdCarrera = (int)reader.GetValue(reader.GetOrdinal("id_carrera"));
                    carrera.Nombre = (string)reader.GetValue(reader.GetOrdinal("nombre"));
                    carrera.Descripcion = (string)reader.GetValue(reader.GetOrdinal("descripcion"));
                }

            } catch (Exception ex) {
                Debug.WriteLine(ex.StackTrace.ToString());
            } finally {
                CerrarConexion();
            }

            return carrera;

        }

        // REGISTRAR
        public void RegistrarCarrera(Carrera carrera) {

            try {

                AbrirConexion();
                command = new SqlCommand("sp_registrar_carrera", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = carrera.Nombre;
                command.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = carrera.Descripcion;
                command.Connection = connection;
                command.ExecuteNonQuery();

            } catch (Exception ex) {
                Debug.WriteLine(ex.StackTrace.ToString());
            } finally {
                CerrarConexion();
            }

        }

        // MODIFICAR
        public void ModificarCarrera(Carrera carrera) {

            try {

                AbrirConexion();
                command = new SqlCommand("sp_modificar_carrera", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@id_carrera", SqlDbType.Int).Value = carrera.IdCarrera;
                command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = carrera.Nombre;
                command.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = carrera.Descripcion;

                command.Connection = connection;
                command.ExecuteNonQuery();

            } catch (Exception ex) {
                Debug.WriteLine(ex.StackTrace.ToString());
            } finally {
                CerrarConexion();
            }

        }

        // ACTIVAR O INACTIVAR
        public void ActInaCarrera(int id) {

            try {

                AbrirConexion();
                command = new SqlCommand("sp_act_ina_carrera", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@id_carrera", SqlDbType.Int).Value = id;

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