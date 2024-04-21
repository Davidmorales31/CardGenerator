using CardGenerationEntidades;
using CardGeneratorDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGeneratorLN
{
    public class LeagueLN
    {
        // Patron singleton
        #region "PATRON SINGLETON"
        private static LeagueLN conexionDao = null;
        //Ocultamos el constructor
        private LeagueLN() { }

        // Validamos 
        public static LeagueLN getInstance()
        {
            if (conexionDao == null)
            {
                conexionDao = new LeagueLN();
            }
            return conexionDao;
        }
        #endregion

        // Metodo devuelve lista de Objetos
        public List<League> ListarBack()
        {
            try
            {
                List<League> Lista = LeagueDAO.getInstance().ListarBack();
                return Lista;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
    }
}
