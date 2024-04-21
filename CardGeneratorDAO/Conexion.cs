using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGeneratorDAO
{
    public class Conexion
    {
        #region "PATRON SINGLETON"
        private static Conexion conexionDao = null;
        //Ocultamos el constructor
        private Conexion() { }

        // Validamos 
        public static Conexion getInstance()
        {
            if (conexionDao == null)
            {
                conexionDao = new Conexion();
            }
            return conexionDao;
        }
        #endregion

        //Creamos metodo para la conexion
        public SqlConnection ConexionDB()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = "Data Source=DESKTOP-LOMTSA2\\MSSQLSERVER01;Initial Catalog=CardGeneration;User ID=David;Password=12345;";
            return conexion;
        }
    }
}
