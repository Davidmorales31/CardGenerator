using CardGenerationEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGeneratorDAO;

namespace CardGeneratorLN
{
    public class BackgroundLN
    {

        public static  List<Backgrounds> ListarBack()
        {
            try 
            {
                return BackgroundDAO.getInstance().ListarBack();
            }
            catch (Exception e)
            {
                throw e;
            }
            
            
        }


    }
}
