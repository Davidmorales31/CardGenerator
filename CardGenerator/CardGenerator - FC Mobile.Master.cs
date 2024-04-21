using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CardGenerator
{
    public partial class CardGenerator___FC_Mobile : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["userName"] == null || Session["idUser"] == null)
            {
                // No esta autenticado 
                string ImageMin = "IMAGENES/LoginIcon.png";
                imgProfile.ImageUrl = ImageMin.ToString();
            }
            else
            {
                // El usuario si esta autenticado
                string userName = Session["UserName"].ToString();
                int userId = Convert.ToInt32(Session["UserId"]);
                btnLoginC.Visible = false;
                btnLogOut.Visible = true;

                string ImagenMin2 = Session["ImageUrlProfile"].ToString();
                if (string.IsNullOrEmpty(ImagenMin2))
                {
                    ImagenMin2 = "IMAGENES/LoginIcon.png";
                    imgProfile.ImageUrl = ImagenMin2.ToString();
                }
                else
                {
                    imgProfile.ImageUrl = ImagenMin2.ToString();
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("CardGeneratorHome.aspx?RegistionSuccess=false");
        }

        protected void imgProfile_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AccountProfile.aspx");
        }
    }
}