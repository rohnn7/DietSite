using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DietSite.Helpers;
using DietSite.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;

namespace DietSite.Pages
{
    public class Register1Model : PageModel
    {
        
        public List<string> dd = new List<string>() {"Male", "Female", "Other" };
        public List<SelectListItem> GenderL { get; set; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Gender { get; set; }
        [BindProperty]
        public DateTime Dob { get; set; }
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public int Height { get; set; }
        [BindProperty]
        public int Weight { get; set; }
        public int Sex { get; set; }
        public Constant Constant;
        private ICommunicationService _communicationService;
        public Register1Model(ICommunicationService serv)
        {
            _communicationService = serv;
        }
        [BindProperty]
        public string RegisterMessage { get; set; }
        public List<SelectListItem> Countries { get; set; }
             
        public void OnGet()
        {
           // Countries = new List<SelectListItem>();
            GenderL = new List<SelectListItem> { new SelectListItem { Text = "Male", Value = "1" }, new SelectListItem { Text = "Female", Value = "2 "}, new SelectListItem { Text = "Other", Value = "3" } };
         //   List<country> cnList = SessionHelpers.GetObject<List<country>>(HttpContext.Session, "_country");
            /*foreach(var c in cnList)
            {
                SelectListItem s = new SelectListItem();
                s.Text = c.CountryName;
                s.Value = c.CountryID.ToString();
                Countries.Add(s);
            }
            Countries.OrderBy(p => p.Text);*/
        }
        public async Task<IActionResult> OnPostRegister()
        {
            SelectListItem s = GenderL.Where(p => p.Selected).FirstOrDefault();
            string g = s.ToString();
           /* SelectListItem s = Countries.Where(p => p.Selected).FirstOrDefault();
            //if(s!=null)
            List<country> cnList = SessionHelpers.GetObject<List<country>>(HttpContext.Session, "_country");
            country c = cnList.Where(p => p.CountryID == int.Parse(s.Value)).First<country>();*/
             
            if (g == "Male")
            {
                Sex = 1;
            }
            else if (g == "Female")
                Sex = 0;
            else if (g == "Other")
                Sex = 2;
            if(!await _communicationService.CheckLogin(Username, Password))
            { 
             int uid = await _communicationService.Register1(Name, Sex, Dob, Username, Password, Height, Weight);
             if (uid>0)
             {
                 DietSite.User user = new User();
                 user.UserID = uid;
                 user.Name = Name;
                 user.Sex = Sex;
                 user.DOB = Dob;
                 user.Username = Username;
                 user.Password = Password;
                 user.Height = Height;
                 user.Weight = Weight;
                 SessionHelpers.StoreObject(HttpContext.Session, Constant.IsLoggedIn, true);
                 SessionHelpers.StoreObject(HttpContext.Session,Constant.UserDetails , user);
                 return RedirectToPage("Index");
             }
          
             else
             {
                 RegisterMessage = "There is some problem registering";
                 return Page();
             }
            }
            else
            {
                return RedirectToPage("Login");
            }
        }
    }
}