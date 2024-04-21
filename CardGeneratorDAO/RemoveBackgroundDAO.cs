using Microsoft.SqlServer.Server;
using System;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CardGeneratorDAO
{
    public class RemoveBackgroundService
    {
        //    private static RemoveBackgroundService rbService = null;

        //    // Patron Singleton
        //    private RemoveBackgroundService() { }

        //    public static RemoveBackgroundService Get()
        //    {
        //        if (rbService == null)
        //        {
        //            rbService = new RemoveBackgroundService();
        //        }
        //        return rbService;
        //    }

        //    public async Task RemoveBackgroundFromImage(string apiKey, string imageUrl)
        //    {
        //        using (var client = new HttpClient())
        //        using (var formData = new MultipartFormDataContent())
        //        {
        //            formData.Headers.Add("X-Api-Key", apiKey);
        //            formData.Add(new StringContent(imageUrl), "image_url");
        //            formData.Add(new StringContent("auto"), "size");

        //            var response = await client.PostAsync("https://api.remove.bg/v1.0/removebg", formData);

        //                if (response.IsSuccessStatusCode)
        //                {
        //                    // Obtener el contenido de la respuesta como un flujo de datos
        //                    using (Stream imageStream = await response.Content.ReadAsStreamAsync())
        //                    {
        //                        // Convertir el flujo de datos en una imagen
        //                        Image image = Image.FromStream(imageStream);

        //                        // Mostrar la imagen en un control de imagen en tu página web
        //                        // (Puedes asignarla a un control de imagen en tu página HTML)
        //                        imgProcessed.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(imageToByteArray(image));
        //                    }
        //                }
        //            else
        //            {
        //                Console.WriteLine("Error: " + await response.Content.ReadAsStringAsync());
        //            }
        //        }
        //    }
        //}
    }
}
