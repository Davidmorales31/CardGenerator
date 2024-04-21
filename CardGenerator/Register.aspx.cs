using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CardGenerationEntidades;
using CardGeneratorLN;

namespace CardGenerator
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            
            Users objUser = AbsorverDatos();
            string username = objUser.userName;
            string password = objUser.userPassword;
            bool ok = UsersLN.getInstance().RegistrarUser(username, password);
            if (ok)
            {         
                    Response.Redirect("Login.aspx?registrationSuccess=true");
            }
            else
            {
                lblMessage.Text = "The email or username is already registered, please log in with your email or username";
             //  Response.Write("<script> alert('The email or username is already registered, please log in with your email or username')</script>");
            }
            
        }
        public Users AbsorverDatos()
        {
            Users objUser = new Users();      
            objUser.userName = txtUserName.Text;
            objUser.userPassword = txtPassword.Text;
            return objUser;

        }
    }
}