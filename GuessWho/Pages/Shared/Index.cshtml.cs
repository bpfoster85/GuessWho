using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuessWho.Pages
{
    public class IndexModel
    {
        public void OnGet()
        {

        }
        public bool FileUploaded { get; set; }
        public IndexModel()
        {
            FileUploaded = false;
        }
    }
}
