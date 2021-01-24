using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DietSite.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DietSite.Pages
{
    public class IndexModel : PageModel
    {
        //Constant constant;
        public void OnGet()
        {
           // SessionHelpers.StoreObject(HttpContext.Session, constant.RedirectPage, "Index");
        }
        
    }
}
