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

    public class EditDietModel : PageModel
    {
        private ICommunicationService _communicationservice;
        public DeitTable Diet;
        public static string page;
        public List<DeitTable> DList;
        public static int id;
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
        public EditDietModel(ICommunicationService serv)
        {
            _communicationservice = serv;
        }
        public void OnGet(int ID)
        {
            id = ID;
            page = SessionHelpers.GetObject<string>(HttpContext.Session, Constant.RedirectPage);
            HttpContext.Session.Remove(Constant.RedirectPage);
            DList = SessionHelpers.GetObject<List<DeitTable>>(HttpContext.Session, Constant.AllDeits);
            Diet = DList.Where(p => p.DeitID == ID).FirstOrDefault<DeitTable>();
            SessionHelpers.StoreObject(HttpContext.Session, Constant.Diet, Diet);
        }

        public async Task<IActionResult> OnPostEditAsync()
        {
            bool check = SessionHelpers.GetObject<bool>(HttpContext.Session, Constant.IsLoggedIn);
            u = SessionHelpers.GetObject<User>(HttpContext.Session, Constant.UserDetails);
            if(u.Username == "Chachi" && check)
            {
                p.DeitTable.DeitID = id;
                p.DeitTable.DeitSummary = DietContent;
                p.DeitTable.DietName = DietName;
                p.DeitTable.DeittypeID = DietType;
                p.DeitTable.Princing = DietPrice;
                p.DeitTable.TrialPeriod = DietTrialPeriod;
                int i = await _communicationservice.UpdateDiet(p);
                if (i > 0)
                {
                    return RedirectToPage(page);

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