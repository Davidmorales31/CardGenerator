using CardGenerationEntidades;
using CardGeneratorDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGeneratorLN
{
    public class NationsLN
    {
        #region "PATRON SINGLETON"
        private static NationsLN conexionDao = null;
        //Ocultamos el constructor
        private NationsLN() { }

        // Validamos 
        public static NationsLN getInstance()
        {
            if (conexionDao == null)
            {
                conexionDao = new NationsLN();
            }
            return conexionDao;
        }
        #endregion

        public static List<Nation> ListarBack()
          {
             try
                {                                    
                List<Nation> Lista = NationsDAO.getInstance().ListarBack();
                return Lista;
                }
                catch (Exception e)
                {
                throw e;
                }

          }

        public static List<Nation> ListarFiltrado(string searchText)
        {
            try
            {
                List<Nation> Lista = NationsDAO.getInstance().ListarFiltrado(searchText);
                return Lista;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

    }

}
