using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;

namespace GuessWho.Pages
{
    public class IndexModel
    {
        public void OnGet()
        {

        }
        public bool FileUploaded { get; set; }
        public List<Prediction> PredictionResults { get; set; }
        public string RawPredictionResults { get; set; }
        public IndexModel()
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
                    Prediction p = new Prediction(w.tagName,w.probability);
                  this.PredictionResults.Add(p);
                }

        }
    }
}
