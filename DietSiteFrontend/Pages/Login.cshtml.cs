using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DietSite.Helpers;
using DietSite.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace DietSite.Pages
{
    public class LoginModel : PageModel
    {
        [Required(ErrorMessage = "Please enter your email ID", AllowEmptyStrings = false)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email ID")]
        [BindProperty(SupportsGet = true)]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "Please enter your password", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [BindProperty(SupportsGet = true)]
        public string Password { get; set; }
        public Constant Constant;
        private ICommunicationService _communicationService;
        public LoginModel(ICommunicationService serv)
        {
            _communicationService = serv;
        }
        [BindProperty(SupportsGet = true)]
        public string LoginMessage { get; set; }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnGetSignIn()
        {

            if (await _communicationService.CheckLogin(Username, Password))
            {
                List<User> users = await _communicationService.getuserdetails(Username);
                DietSite.User u = users.Where(p => p.Username == Username).FirstOrDefault<User>();
                SessionHelpers.StoreObject(HttpContext.Session, Constant.IsLoggedIn, true);
                SessionHelpers.StoreObject(HttpContext.Session, Constant.UserDetails, u);
                LoginMessage = "Successfully Logged In";
                if (HttpContext.Session.Keys.Contains(Constant.RedirectPage))
                {
                    string page = SessionHelpers.GetObject<string>(HttpContext.Session, Constant.RedirectPage);
                    HttpContext.Session.Remove(Constant.RedirectPage);
                    return RedirectToPage(page);
                }
                return RedirectToPage("Index");
            }
            else
            {
                LoginMessage = "UserID or Password is incorrect";
                return Page();
            }

        }
    }
}