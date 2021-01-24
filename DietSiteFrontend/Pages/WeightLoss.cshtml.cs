using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DietSite.Service;

namespace DietSite.Pages
{
    public class WeightLossModel : PageModel
    {

        private ICommunicationService _communicationservice;
        public WeightLossModel(ICommunicationService serv)
        {
            _communicationservice = serv;
        }
        public void OnGet()
        {
        }
    }
}