using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DietSite.Service;
using DietSite.Helpers;
namespace DietSite.Pages
{
    public class PurchaseModel : PageModel
    {
        public List<DeitTable> CList;
        public DeitTable Deit;
        private ICommunicationService _communicationservice;
        public PurchaseModel(ICommunicationService serv)
        {
            _communicationservice = serv;
        }
        public void OnGet(int id)
        {
            CList = SessionHelpers.GetObject<List<DeitTable>>(HttpContext.Session, Constant.AllDeits);
            Deit = CList.Where(p => p.DeitID == id).FirstOrDefault<DeitTable>();
            User u = SessionHelpers.GetObject<User>(HttpContext.Session, Constant.UserDetails);
            SessionHelpers.StoreObject(HttpContext.Session, Constant.Diet, Deit);

        }
        public void OnGet()
        {

        }
    }
}