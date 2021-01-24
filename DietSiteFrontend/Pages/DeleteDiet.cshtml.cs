using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DietSite.Helpers;
using DietSite.Service;
using DietSite.Models;
namespace DietSite.Pages
{
    public class DeleteDietModel : PageModel
    {
        public string page;
        public static int id;
        public Param p;
        private ICommunicationService _communicationservice;
        public DeleteDietModel(ICommunicationService serv)
        {
            _communicationservice = serv;
        }
        public void OnGet(int ID)
        {
            id = ID;
        }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            page = SessionHelpers.GetObject<string>(HttpContext.Session, Constant.RedirectPage);
            HttpContext.Session.Remove(Constant.RedirectPage);
            p.DeitTable.DeitID = id;
            int i = await _communicationservice.DeleteDiet(p);
            if (i > 0)
            {
                return RedirectToPage(page);
            }
            else
            {
                return Page();
            }
        }

    }
}