using CardGenerationEntidades;
using CardGeneratorLN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardGenerator
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verificar si hay un parámetro de éxito en la URL
                if (Request.QueryString["registrationSuccess"] == "true")
                {
                    // Mostrar el mensaje de éxito en el control de etiqueta
                    lblMesagge2.Text = "You have registered correctly, now log in with your registered information";

                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //LLamamos al metodo para validar los datos//
            
            Users objUser = ValidateUserLogin();
            string userName = objUser.userName;
            string password = objUser.userPassword;

            Users objUserAcept = new Users();
            objUserAcept = UsersLN.getInstance().BuscarUsers(userName, password);

            if (objUserAcept != null)
            {
                // Aqui se incia secion correctamente en la app;

                //Manejos de datos de las sesiones;
                Session["userName"] = objUser.userName;
                Session["idUser"] = objUserAcept.idUser;
                Session["ImageUrlProfile"] = objUserAcept.ImageUrlProfile;


                Response.Redirect("CardGeneratorHome.aspx?RegistionSuccess=true");
                lblidUser.Text = objUserAcept.idUser.ToString();
            }
            else
            {
                lblMesagge.Text = "The credentials entered are not valid. Please make sure you enter a correct username and password, or register if it is your first time.";
            }
        }

        public Users ValidateUserLogin()
        {
            Users objUser = new Users();
            objUser.userName = txtUsernameLog.Text;
            objUser.userPassword = txtPasswordLog.Text;

            return objUser;
        }
    }
}