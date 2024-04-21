using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CardGenerationEntidades;

namespace CardGeneratorDAO
{
    public class UsuersDAO
    {
        #region "PATRON SINGLETON"
        private static UsuersDAO conexionDao = null;
        //Ocultamos el constructor
        private UsuersDAO() { }

        // Validamos 
        public static UsuersDAO getInstance()
        {
            if (conexionDao == null)
            {
                conexionDao = new UsuersDAO();
            }
            return conexionDao;
        }
        #endregion

        // Metodo que registra el nuevo usuario;

        public bool RegistarUsuario (string userName, string password)
        {
            //Iniciamos variables 
            SqlConnection conexion = null;
            SqlCommand comando = null;
            int Filas;
            bool ok = false;

            // Asigamos los valores a la aplicacion
            try
            {
                conexion = Conexion.getInstance().ConexionDB();
                comando = new SqlCommand("spRegistrarUsuario", conexion);
                comando.Parameters.AddWithValue("@userName", userName);
                comando.Parameters.AddWithValue("@password", password);
                comando.CommandType = CommandType.StoredProcedure;

                conexion.Open();
                Filas = comando.ExecuteNonQuery();

                if (Filas > 0)
                {
                    ok = true;
                }
            }catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }

            return ok;
            
        }

        public Users BuscarUsers(string userName, string password)
        {
            //Iniciamos variables 
            SqlConnection conexion = null;
            SqlCommand comando = null;
            SqlDataReader dr = null;
            Users objUserAcept = null;
            bool ok = false;

            // Asigamos los valores a la aplicacion
            try
            {
                conexion = Conexion.getInstance().ConexionDB();
                comando = new SqlCommand("spBuscarUsers", conexion);
                comando.Parameters.AddWithValue("@userName", userName);
                comando.Parameters.AddWithValue("@password", password);
                comando.CommandType = CommandType.StoredProcedure;

                conexion.Open();
                dr = comando.ExecuteReader();

                if (dr.Read())
                {
                    objUserAcept= new Users();
                    objUserAcept.idUser = Convert.ToInt32(dr["idUser"].ToString());
                    objUserAcept.ImageUrlProfile = dr["ImageUrlProfile"].ToString();
                    ok = true;
                 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }

            return objUserAcept;

        }

        public bool RegistrarUrlImage(string ImageUrlSelected, string idUser, string username)
        {
            //Iniciamos variables 
            SqlConnection conexion = null;
            SqlCommand comando = null;
            int Filas;
            bool ok = false;

            // Asigamos los valores a la aplicacion
            try
            {
                conexion = Conexion.getInstance().ConexionDB();
                comando = new SqlCommand("spRegistrarImagen", conexion);
                comando.Parameters.AddWithValue("@username", username);
                comando.Parameters.AddWithValue("@idUser", idUser);
                comando.Parameters.AddWithValue("@Imagen", ImageUrlSelected);
                comando.CommandType = CommandType.StoredProcedure;

                conexion.Open();
                Filas = comando.ExecuteNonQuery();

                if (Filas > 0)
                {
                    ok = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }

            return ok;
        }
    }
}
