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
    public class EditAppModel : PageModel
    {
        
        public Param p;
        public User u;
        public static string page;
        [BindProperty]
        public int AvgTime { get; set; }
        [BindProperty]
        public DateTime MorningTimeBegins { get; set; }
        [BindProperty]
        public DateTime MorningTimeEnds { get; set; }
        [BindProperty]
        public DateTime AfternoonTimeBegins { get; set; }
        [BindProperty]
        public DateTime AfternoonTimeEnds { get; set; }
        [BindProperty]
        public int Day { get; set; }
        private ICommunicationService _communicationservice;
        public EditAppModel(ICommunicationService serv)
        {
            _communicationservice = serv;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostEditAppAsync()
        {
            bool check = SessionHelpers.GetObject<bool>(HttpContext.Session, Constant.IsLoggedIn);
            u = SessionHelpers.GetObject<User>(HttpContext.Session, Constant.UserDetails);
            page = SessionHelpers.GetObject<string>(HttpContext.Session, Constant.RedirectPage);
            HttpContext.Session.Remove(Constant.RedirectPage);
            appparam isenable = SessionHelpers.GetObject<appparam>(HttpContext.Session, Constant.TodaySlots);
            if (check && u.Username == "Chachi" && isenable.Enabled ==0)
            {
                p.AppPara.Avgtime = AvgTime;
                p.AppPara.MorinigScheduleBegin = MorningTimeBegins;
                p.AppPara.MorningScheduleEnds = MorningTimeEnds;
                p.AppPara.AfternoonScheduleBegins = AfternoonTimeBegins;
                p.AppPara.AfternoonSCheduleEnds = AfternoonTimeEnds;
                p.AppPara.Offday = Day;
                p.AppPara.Datefrom = DateTime.Now;
                p.AppPara.Dateto = DateTime.Now;
                p.AppPara.CityName = "Raipur";
                int i = await _communicationservice.UpdateAppointments(p);
                return RedirectToPage(page);

            }
            else
            {
                return Page();
            }

        }

    }
}