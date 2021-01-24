using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DietSite.Helpers;
using DietSite.Service;
namespace DietSite.Pages
{
    public class CreateModel : PageModel
    {
        public Param p;
        public User u;
        [BindProperty]
        public string DietName { get; set; }
        [BindProperty]
        public string DietContent { get; set; }
        [BindProperty]
        public int DietTrialPeriod { get; set; }
        [BindProperty]
        public string DietPrice { get; set; }
        [BindProperty]
        public int DietType { get; set; }
        private ICommunicationService _communicationservice;
        public CreateModel(ICommunicationService serv)
        {
            _communicationservice = serv;
        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            bool check = SessionHelpers.GetObject<bool>(HttpContext.Session, Constant.IsLoggedIn);
            u = SessionHelpers.GetObject<User>(HttpContext.Session, Constant.UserDetails);
            if(check && u.Username == "Chachi")
            {
                p.DeitTable.DeitSummary = DietContent;
                p.DeitTable.DietName = DietName;
                p.DeitTable.DeittypeID = DietType;
                p.DeitTable.Princing = DietPrice;
                p.DeitTable.TrialPeriod = DietTrialPeriod;
                int id = await _communicationservice.CreateDiet(p);
                if (id > 0)
                {
                    return RedirectToPage("Index");
                }
                else
                {
                    return Page();
                }
            }
            else
            {
                return RedirectToPage("Index");
            }
        }
    }
}