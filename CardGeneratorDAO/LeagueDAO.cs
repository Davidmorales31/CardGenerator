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
    public class LeagueDAO
    {
        //Patron Singleton
        #region "PATRON SINGLETON"
        private static LeagueDAO conexionDao = null;
        //Ocultamos el constructor
        private LeagueDAO() { }

        // Validamos 
        public static LeagueDAO getInstance()
        {
            if (conexionDao == null)
            {
                conexionDao = new LeagueDAO();
            }
            return conexionDao;
        }
        #endregion

        // Metodo que retorna un Lista de Leagues 
        public List<League> ListarBack()
        {
            // Inicializamos variables 
            SqlConnection conexion = null;
            SqlCommand comando = null;
            SqlDataReader dr = null;
            List<League> lISTA = new List<League>();

            // Asiganamos valores 
            conexion = Conexion.getInstance().ConexionDB();
            comando = new SqlCommand("spListarLeague", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            dr = comando.ExecuteReader();

            while (dr.Read())
            {
                League objNat = new League();
                objNat.idLeague = Convert.ToInt32(dr["idLegaue"].ToString());
                objNat.LegaueText = dr["LeagueText"].ToString();
                objNat.LeagueUrl = dr["LeagueUrl"].ToString();
                objNat.LeagueTextES = dr["LeagueTextES"].ToString();

                lISTA.Add(objNat);
            }
            conexion.Close();
            return lISTA;
        }
    }
}
