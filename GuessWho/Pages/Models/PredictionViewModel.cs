using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;

namespace GuessWho.Pages
{
    public class PredictionViewModel
    {
        public void OnGet()
        {
        }
        public bool FileUploaded { get; set; }
        public List<Prediction> PredictionResults { get; set; }
        public string RawPredictionResults { get; set; }
         public byte[] IMGBits{get;set;}
           
        public PredictionViewModel()
        {
            FileUploaded = false;
            PredictionResults = new List<Prediction>();
        }

        public void ParsePredictionResults(string result)
        {
            this.RawPredictionResults = result;
                dynamic woot = JObject.Parse(result);
              this.PredictionResults= new List<Prediction>();
                foreach (var w in woot.predictions)
                {
                    var prob = w.probability;
                    Prediction p = new Prediction();
                    p.Probability = w.probability;
                    p.TagName = w.tagName;
                    this.PredictionResults.Add(p);
                }

        }
        public void ConvertImageFile(IFormFile file){
            using (var memoryStream = new MemoryStream())
            {
                 file.CopyToAsync(memoryStream);
                IMGBits = memoryStream.ToArray();
            }

        }
    }
}
