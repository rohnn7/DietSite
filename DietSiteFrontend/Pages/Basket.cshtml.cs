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
    public class BasketModel : PageModel
    {
        public List<Basket> Baskets;
        public User user;
        private ICommunicationService _communicationService;
        public BasketModel(ICommunicationService serv)
        {
            _communicationService = serv;
        }
        public async void OnGet()
        {
            user = SessionHelpers.GetObject<User>(HttpContext.Session, Constant.UserDetails);
            Baskets = await _communicationService.GetBaskets(user.UserID);
            SessionHelpers.StoreObject(HttpContext.Session, Constant.Basket, Baskets);
        }
    }
}