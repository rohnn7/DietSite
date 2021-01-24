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
    public class AppointmentModel : PageModel
    {
        public List<appparam> Slots;
        public appparam todayslots;
        public string message;
        private ICommunicationService _communicationService;
        public AppointmentModel(ICommunicationService serv)
        {
            _communicationService = serv;
        }
        public async void OnGet()
        {
            Slots = await _communicationService.GetAppParams("Raipur");
            todayslots = Slots.Where(p => p.Enabled == 0).FirstOrDefault<appparam>();
            SessionHelpers.StoreObject(HttpContext.Session, Constant.TodaySlots, todayslots);
        }
        public async void OnPostBookAsync()
        {
            DietSite.User u = SessionHelpers.GetObject<User>(HttpContext.Session, Constant.UserDetails);
            if (SessionHelpers.GetObject<bool>(HttpContext.Session, Constant.IsLoggedIn))
            {
                DateTime slot = SessionHelpers.GetObject<DateTime>(HttpContext.Session, Constant.ParticularSlot);
                HttpContext.Session.Remove(Constant.ParticularSlot);
                int i = await _communicationService.CheckSlots(slot);
                if (i == 0)
                {
                    message = "Book";
                    int x = await _communicationService.InsertSlots(u.UserID, slot);

                }
                else
                {
                    message = "Not Available";
                }
            }
            else
            {
                message = "Not Logged in";
            }
            SessionHelpers.StoreObject(HttpContext.Session, Constant.Message, message);
        }
    }
}