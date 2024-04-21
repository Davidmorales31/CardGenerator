using CardGeneratorLN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CardGenerationEntidades;
using System.Web.Services;
using System.Web.Configuration;
using Newtonsoft.Json;



namespace CardGenerator
{
    public partial class CardGeneratorHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LLenarDDL();
            LLenarDDL2();
            LLenarDDLLeague();


            if (!IsPostBack)
            {

                string NationText = lblNationText.Value;
                string NationUrl = imgNatioDefault.Src;
                imgNation.ImageUrl = NationUrl;
                lblNationsTextSleeted.Text = NationText;

                string LeagueText = lblLeagueText.Value;
                string LeagueUrl = imgLeagueDefault.Src;

                lblLeagueSelect.Text = LeagueText;
                imgLeagueSelect.ImageUrl = LeagueUrl;




                // Verificar si hay un parámetro de éxito en la URL
                if (Request.QueryString["RegistionSuccess"] == "true")
                {

                }
            }
        }

        protected void btnAplychange_Click(object sender, EventArgs e)
        {
            // Extraemos los datos 
            string Name = txtName.Text;
            string POS = txtPOS.Text;
            string OVR = txtOVR.Text;

            // Ponemos los datos 

            lblName.Text = Name;
            lblPos.Text = POS;
            lblOVR.Text = OVR;
        }
        public  void LLenarDDL()
        {
            List<Backgrounds> Lista = Listar();

            ddlBackgrounds.DataSource = Lista;
            ddlBackgrounds.DataTextField = "DescripcionEN";
            ddlBackgrounds.DataValueField = "BackgroundUrl";
       //     ddlBackgrounds.Attributes["style"] = "color: black;";

            ddlBackgrounds.DataBind();
        }

        public void LLenarDDLLeague()
        {
            List<League> Lista = ListarLeague();
         

            ddlLeague.DataSource = Lista;
            ddlLeague.DataTextField = "LegaueText";
            ddlLeague.DataValueField = "LeagueUrl";
            //     ddlBackgrounds.Attributes["style"] = "color: black;";

            ddlLeague.DataBind();
        }
        public void LLenarDDL2()
        {
            List<Nation> Lista = Listar2();
        


            ddlNation.DataSource = Lista;
            ddlNation.DataTextField = "Nations";
            ddlNation.DataValueField = "NationUrl";
            ddlNation.Attributes["style"] = "color: black;";


            ddlNation.DataBind();
        }

        public List<Backgrounds> Listar()
        {
            List<Backgrounds> Lista = BackgroundLN.ListarBack();
            return Lista;
        }
        public List<Nation> Listar2()
        {
            List<Nation> Lista = NationsLN.ListarBack();         
            return Lista;
        }

        public List<League> ListarLeague()
        {
            List<League> Lista = LeagueLN.getInstance().ListarBack();
            return Lista;
        }

        [WebMethod]
        public static List<Nation> JsonResponse(string text)
        {
            List<Nation> ListaFiltrada = new List<Nation>();
            ListaFiltrada = FiltrarNaciones(text);
            return ListaFiltrada;

        }


        public static List<Nation> FiltrarNaciones(string searchText)
        {
            List<Nation> Lista = NationsLN.ListarFiltrado(searchText);
            return Lista;
            
        }
    }
}