using GuessWho.Pages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GuessWho.Controller
{
    public class HomeController: Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Index(IndexModel model)
        {
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> PictureUpload(IFormFile file)
        {

            IndexModel model = new IndexModel();
            model.FileUploaded = true;
          byte[] imgBits; 
 using (var memoryStream = new MemoryStream())
        {
        
            await file.CopyToAsync(memoryStream);
           imgBits = memoryStream.ToArray();
        }

          string results =  await MakePredictionRequest(imgBits);
           model.PredictionResults = results;

            return RedirectToAction("Index", model);
        }        
         static async Task<string> MakePredictionRequest(byte[] imageBits)
        {
             const string uriBase = "https://southcentralus.api.cognitive.microsoft.com/customvision/v2.0/Prediction/4cd177a0-a38f-442e-8c16-ad17dede0ea4/image?iterationId=23743eb6-5d1e-4f3a-8df4-3683dbcaf91df";
            string contentString;
            var client = new HttpClient();

            // Request headers - replace this example key with your valid subscription key.
            client.DefaultRequestHeaders.Add("Prediction-Key", "");

            HttpResponseMessage response;
            using (var content = new ByteArrayContent(imageBits))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(uriBase, content);
                 contentString = await response.Content.ReadAsStringAsync();
            }
            return contentString;
        }
    }
}
