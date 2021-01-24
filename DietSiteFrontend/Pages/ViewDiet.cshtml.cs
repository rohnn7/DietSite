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
    public class ViewDietModel : PageModel
    {
        public List<DeitTable> CList;
        public DeitTable Deit;
        public User u;
        private ICommunicationService _communicationservice;
        public int flag = -1;
        public int id = 0;
        public ViewDietModel(ICommunicationService serv)
        {
            _communicationservice = serv;
        }
        public async void OnGet(int ID)
        {
            HttpContext.Session.Remove(Constant.RedirectPage);
            id = ID;
            CList = SessionHelpers.GetObject<List<DeitTable>>(HttpContext.Session, Constant.AllDeits);
            Deit = CList.Where(p => p.DeitID == ID).FirstOrDefault<DeitTable>();
            u = SessionHelpers.GetObject<User>(HttpContext.Session, Constant.UserDetails);
            flag = await _communicationservice.UserSelection(u.UserID, ID);
            SessionHelpers.StoreObject(HttpContext.Session, Constant.Flag, flag);
            SessionHelpers.StoreObject(HttpContext.Session, Constant.Diet, Deit);
        }
        public async Task<IActionResult> OnGetRedirectAsync()
        {
            SessionHelpers.StoreObject(HttpContext.Session, Constant.RedirectPage, "ViewDiet");
            return RedirectToPage("Purchase",id);
        }
        public async void OnGetAddToBasketAsync()
        {
           await _communicationservice.AddToBasket(u.UserID, id);
        }
        
    }
}