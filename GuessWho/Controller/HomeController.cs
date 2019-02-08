using GuessWho.Pages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            return RedirectToAction("Index", model);
        }        
    }
}
