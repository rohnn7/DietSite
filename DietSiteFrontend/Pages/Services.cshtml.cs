using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DietSite.Helpers;
using DietSite.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DietSite.Pages
{
    public class ServicesModel : PageModel
    {
        Constant Constant;
        List<DeitTable> ListDeits;
        private ICommunicationService _communicationService;
        public ServicesModel(ICommunicationService serv)
        {
            _communicationService = serv;  
        }
        public void OnGet()
        {
        }
        public IActionResult OnGetWeightLoss()
        {

            bool IsLoggedIn = SessionHelpers.GetObject<bool>(HttpContext.Session, Constant.IsLoggedIn);
            if (IsLoggedIn)
            {
                return RedirectToPage("WeightLoss");
            }
            else
            {
                SessionHelpers.StoreObject(HttpContext.Session, Constant.RedirectPage, "Services");
                return RedirectToPage("Login");
            }
        }
        public async Task<IActionResult> OnGetClinical()
        {

            bool IsLoggedIn =  SessionHelpers.GetObject<bool>(HttpContext.Session, Constant.IsLoggedIn);
            if (IsLoggedIn)
            {
                ListDeits = await _communicationService.GetAllDeits();      
                SessionHelpers.StoreObject(HttpContext.Session, Constant.IsPresent, true);
                SessionHelpers.StoreObject(HttpContext.Session, Constant.AllDeits, ListDeits);
                return RedirectToPage("Clinical");
            }
            else
            {
                SessionHelpers.StoreObject(HttpContext.Session, Constant.RedirectPage, "Services");
                return RedirectToPage("Login");
            }
        }
        public async Task<IActionResult> OnGetAnalysis()
        {

            bool IsLoggedIn = SessionHelpers.GetObject<bool>(HttpContext.Session, Constant.IsLoggedIn);
            if (IsLoggedIn)
            {
                if (!SessionHelpers.GetObject<bool>(HttpContext.Session, Constant.IsPresent))
                {
                    ListDeits = await _communicationService.GetAllDeits();
                    SessionHelpers.StoreObject(HttpContext.Session, Constant.IsPresent, true);
                    SessionHelpers.StoreObject(HttpContext.Session, Constant.AllDeits, ListDeits);
                }
                return RedirectToPage("Analysis");
            }
            else
            {
                SessionHelpers.StoreObject(HttpContext.Session, Constant.RedirectPage, "Services");
                return RedirectToPage("Login");
            }
        }
    }
}