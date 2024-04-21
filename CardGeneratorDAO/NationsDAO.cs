using CardGenerationEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGeneratorDAO
{
    public class NationsDAO
    {
        #region "PATRON SINGLETON"
        private static NationsDAO conexionDao = null;
        //Ocultamos el constructor
        private NationsDAO() { }

        // Validamos 
        public static NationsDAO getInstance()
        {
            if (conexionDao == null)
            {
                conexionDao = new NationsDAO();
            }
            return conexionDao;
        }
        #endregion


        public List<Nation> ListarBack()
        {
            // Inicializamos variables 
            SqlConnection conexion = null;
            SqlCommand comando = null;
            SqlDataReader dr = null;
            List<Nation> lISTA = new List<Nation>();

            // Asiganamos valores 
            conexion = Conexion.getInstance().ConexionDB();
            comando = new SqlCommand("spListarNations", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            dr = comando.ExecuteReader();

            while (dr.Read())
            {


                Nation objNat = new Nation();
                objNat.IdNation = Convert.ToInt32(dr["IdNation"].ToString());
                objNat.Nations = dr["Nation"].ToString();
                objNat.NationUrl = dr["NationUrl"].ToString();

                lISTA.Add(objNat);
            }
            conexion.Close();
            return lISTA;
        }

        public List<Nation> ListarFiltrado(string searchText)
        {
            // Inicializamos variables 
            SqlConnection conexion = null;
            SqlCommand comando = null;
            SqlDataReader dr = null;
            List<Nation> lISTA = new List<Nation>();

            // Asiganamos valores 
            conexion = Conexion.getInstance().ConexionDB();
            comando = new SqlCommand("spListarNationsFiltradas", conexion);
            comando.Parameters.AddWithValue("@searchText", searchText);
            comando.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            dr = comando.ExecuteReader();

            while (dr.Read())
            {


                Nation objNat = new Nation();
                objNat.IdNation = Convert.ToInt32(dr["IdNation"].ToString());
                objNat.Nations = dr["Nation"].ToString();
                objNat.NationUrl = dr["NationUrl"].ToString();

                lISTA.Add(objNat);
            }
            conexion.Close();
            return lISTA;
        }
    }
}
