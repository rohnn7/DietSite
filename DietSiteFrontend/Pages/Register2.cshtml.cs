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
    public class Register2Model : PageModel
    {
        public int cityid;
        [BindProperty]
        public string Mobile { get; set; }
        [BindProperty]
        public string Add1 { get; set; }
        [BindProperty]
        public string Add2 { get; set; }
        public List<SelectListItem> Country { get; set; }
        public List<SelectListItem> City { get; set; }
        public List<SelectListItem> State { get; set; }
        private ICommunicationService _communicationservice;
        public Register2Model(ICommunicationService serv)
        {
            _communicationservice = serv;
        }
        public async void OnGet()
        {
            List<country> countries = await _communicationservice.GetCountries();
            foreach(var c in countries)
            {
                SelectListItem s = new SelectListItem();
                s.Text = c.CountryName;
                s.Value = c.CountryID.ToString();
                Country.Add(s);
            }
            SelectListItem x = Country.Where(p => p.Selected).FirstOrDefault();
            country coun = countries.Where(p => p.CountryID == int.Parse(x.Value)).First<country>();
            List<state> st = await _communicationservice.GetState(coun.CountryID);
            foreach (var c in st)
            {
                SelectListItem s = new SelectListItem();
                s.Text = c.Statename;
                s.Value = c.Stateid.ToString();
                State.Add(s);
            }
            SelectListItem y = State.Where(p => p.Selected).FirstOrDefault();
            state sta = st.Where(p => p.Stateid == int.Parse(y.Value)).First<state>();
            List<city> ct = await _communicationservice.GetCities(sta.Stateid);
            foreach (var c in ct)
            {
                SelectListItem s = new SelectListItem();
                s.Text = c.CityName;
                s.Value = c.CID.ToString();
                City.Add(s);
            }
            SelectListItem z = City.Where(p => p.Selected).FirstOrDefault();
            city cty = ct.Where(p => p.CID == int.Parse(z.Value)).First<city>();
            cityid = cty.CID;
        }
        public async Task<IActionResult> OnPostRegisterAsync()
        {
            User u = SessionHelpers.GetObject<User>(HttpContext.Session, Constant.UserDetails);
            if (HttpContext.Session.Keys.Contains(Constant.RedirectPage))
            {
                await _communicationservice.InsertUserAddress(u.UserID, Add1, Add2, cityid);
                await _communicationservice.InsertUserContact(u.UserID, Mobile, u.Username);
                string page = SessionHelpers.GetObject<string>(HttpContext.Session, Constant.RedirectPage);
                HttpContext.Session.Remove(Constant.RedirectPage);
                return RedirectToPage(page);
            }
            else
            {

                await _communicationservice.InsertUserAddress(u.UserID, Add1, Add2, cityid);
                await _communicationservice.InsertUserContact(u.UserID, Mobile, u.Username);
                return RedirectToPage("Index");
            }
        }
    }
}