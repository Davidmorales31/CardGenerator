using CardGenerationEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CardGeneratorLN;

namespace CardGenerator
{
    public partial class AccountProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                imgProfile.Enabled = false;

                if (Session["userName"] == null || Session["idUser"] == null)
                {
                    // No esta auteticado
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    string idUser = Session["idUser"].ToString();
                    string userName = Session["userName"].ToString();
                    string ImageUrlProfile = Session["ImageUrlProfile"].ToString();

                    if (string.IsNullOrEmpty(ImageUrlProfile))
                    {
                        imgProfile.ImageUrl = "IMAGENES/AccountLogoDefault-removebg-preview.png";
                    }
                    else
                    {
                        imgProfile.ImageUrl = ImageUrlProfile;
                    }

                    lbluserName.Text = userName;
                    lblUsername2.Text = userName;
                    
                }

            }
        }

        protected void AccountLogo1_Click(object sender, ImageClickEventArgs e)
        {
            
            // Le damos click a una imagen lo primer es extraer su src! 
            string ImageUrl = "IMAGENES/AccountLogo1.png";
            imgProfile.ImageUrl = ImageUrl;
            Session["ImageUrlSelected"] = ImageUrl;
        }

        protected void AccountLogo2_Click(object sender, ImageClickEventArgs e)
        {
            string ImageUrl = "IMAGENES/AccountLogo2.png";
            imgProfile.ImageUrl = ImageUrl;
            Session["ImageUrlSelected"] = ImageUrl;
        }

        protected void AccountLogo3_Click(object sender, ImageClickEventArgs e)
        {
            string ImageUrl = "IMAGENES/AccountLogo3.png";
            imgProfile.ImageUrl = ImageUrl;
            Session["ImageUrlSelected"] = ImageUrl;
        }

        protected void AccountLogo5_Click(object sender, ImageClickEventArgs e)
        {
            string ImageUrl = "IMAGENES/AccountLogo5.png";
            imgProfile.ImageUrl = ImageUrl;
            Session["ImageUrlSelected"] = ImageUrl;
        }

        protected void AccountLogo6_Click(object sender, ImageClickEventArgs e)
        {
            string ImageUrl = "IMAGENES/AccountLogo6.png";
            imgProfile.ImageUrl = ImageUrl;
            Session["ImageUrlSelected"] = ImageUrl;
        }

        protected void AccountIcon4_Click(object sender, ImageClickEventArgs e)
        {
            string ImageUrl = "IMAGENES/AccountIcon4.png";
            imgProfile.ImageUrl = ImageUrl;
            Session["ImageUrlSelected"] = ImageUrl;
        }

        protected void btnAplyChangesProfile_Click(object sender, EventArgs e)
        {
            string ImagenUrl = Session["ImageUrlSelected"].ToString();
            //  obtener el valor del Image Url activo 
            string ImageUrlSelected = ImagenUrl;
            // Llamamos al metodo que guarda esta eleccion en la base de datos.
            string idUser = Session["idUser"].ToString();
            string userName = Session["userName"].ToString();

            
            bool ok = RegistrarUrlImage(ImageUrlSelected, idUser, userName);
            if (ok)
            {
                Session["ImageUrlProfile"] = ImageUrlSelected;
                Response.Redirect("AccountProfile.aspx");
            }
            // Mostramos mensaje que debera volver a inciar secion para ver reflejados los cambios
            
        }
        

        public bool RegistrarUrlImage(string ImageUrlSelected, string idUser, string username)
        {
            bool ok = UsersLN.getInstance().RegistrarUrlImage(ImageUrlSelected, idUser, username);
            return ok;
        }
    }
}