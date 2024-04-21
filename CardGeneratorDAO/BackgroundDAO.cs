using CardGenerationEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.Remoting.Messaging;

namespace CardGeneratorDAO
{
    public class BackgroundDAO
    {
        #region "PATRON SINGLETON"
        private static BackgroundDAO conexionDao = null;
        //Ocultamos el constructor
        private BackgroundDAO() { }

        // Validamos 
        public static BackgroundDAO getInstance()
        {
            if (conexionDao == null)
            {
                conexionDao = new BackgroundDAO();
            }
            return conexionDao;
        }
        #endregion

        // Metodo lista de backgrounds 

        public List<Backgrounds> ListarBack()
        {
            // Inicializamos variables 
            SqlConnection conexion = null;
            SqlCommand comando = null;
            SqlDataReader dr = null;
            List<Backgrounds> lISTA = new List<Backgrounds>();           

            // Asiganamos valores 
            conexion = Conexion.getInstance().ConexionDB();
            comando = new SqlCommand("spListarBackgrounds", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            dr = comando.ExecuteReader();

            while (dr.Read())
            {
                

                Backgrounds objBack = new Backgrounds();
                objBack.idBackground = Convert.ToInt32(dr["idBackground"].ToString());
                objBack.BackgroundUrl = dr["BackgroundUrl"].ToString();
                objBack.DescripcionEN = dr["DescripcionEN"].ToString();
                objBack.DescriptionES = dr["DescriptionES"].ToString();

                lISTA.Add(objBack);
            }
            conexion.Close();
            return lISTA;
        }


    }
}
