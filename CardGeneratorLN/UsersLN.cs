using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CardGenerationEntidades;
using CardGeneratorDAO;

namespace CardGeneratorLN
{
    public class UsersLN
    {
        #region "PATRON SINGLETON"
        private static UsersLN conexionDao = null;
        //Ocultamos el constructor
        private UsersLN() { }

        // Validamos 
        public static UsersLN getInstance()
        {
            if (conexionDao == null)
            {
                conexionDao = new UsersLN();
            }
            return conexionDao;
        }
        #endregion

        //Metodo para conectar el LN con el DAO
        public bool RegistrarUser(string username, string password)
        {
            return UsuersDAO.getInstance().RegistarUsuario(username, password);
        }
        //Metodo para buscar si estan en la base de datos los usuarios y contraseñas
        public Users BuscarUsers(string username, string password)
        {
            return UsuersDAO.getInstance().BuscarUsers(username, password);
        }

        public bool RegistrarUrlImage(string ImageUrlSelected, string username, string idUser)
        {
            try
            {

                return UsuersDAO.getInstance().RegistrarUrlImage(ImageUrlSelected, username, idUser);

            }
            catch(Exception ex)
            {
                throw ex;
               
            }
        }
    }

}
