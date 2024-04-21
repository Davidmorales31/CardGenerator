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
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using Microsoft.SqlServer.Server;
using System.IO.Pipes;
using System.Text;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;


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
                //    string apiKey = "8HCAdU7MjfrU59taNVBv7P5j";
                //    string ImageUrl = "https://fcb-abj-pre.s3.amazonaws.com/img/jugadors/MESSI.jpg";
                //    await RemoveBackgroundFromImage(apiKey, ImageUrl);
                //}

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
        public void LLenarDDL()
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


        //protected async void urlImagehtml2_ValueChanged(object sender, EventArgs e)
        //{


        //}

        public async Task RemoveBackgroundFromImage(string apiKey, string imageUrl)
        {
            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {
                formData.Headers.Add("X-Api-Key", apiKey);
                formData.Add(new StringContent(imageUrl), "image_file_b64");
                formData.Add(new StringContent("auto"), "size");

                var response = await client.PostAsync("https://api.remove.bg/v1.0/removebg", formData);

                if (response.IsSuccessStatusCode)
                {
                    // Guardar la imagen eliminada del fondo
                    // Leer la imagen eliminada del fondo como un arreglo de bytes
                    byte[] imageBytes = await response.Content.ReadAsByteArrayAsync();

                    // Convertir los bytes de la imagen a una cadena base64
                    string base64String = Convert.ToBase64String(imageBytes);

                    // Establecer la URL base64 en el control Image
                    //imgHiddenBase64.ImageUrl = "data:image/png;base64," + base64String;
                    // Notificar al usuario que la operación fue exitosa
                    Response.Write("Background removed successfully!");
                }
                else
                {
                    Console.WriteLine("Error: " + await response.Content.ReadAsStringAsync());
                }
            }
        }

        protected async void Button1_Click(object sender, EventArgs e)
        {
            // Este es el evento cuando elvalor de hidden field cambia, 

            //Lo primero es asignar este valor a una variable;
            string UrlImage = urlImagehtml2.Value.ToString();


            // Llamamaos el metodo que realiza la solicitud a la PAI de removeImg y le mandamos el valor de UrlImage 
            string apiKey = "8HCAdU7MjfrU59taNVBv7P5j";
            await RemoveBackgroundFromImage(apiKey, UrlImage);
        }
    }

}
