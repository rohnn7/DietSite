using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DietSite;
using DietSite.Service;
using Newtonsoft.Json;

namespace DietSite.Service
{
    public class CommunicationService : ICommunicationService
    {
        public string URL { get; set; } = "localhost";
        #region CheckLogin
        //DataAccess da;
        public async Task<bool> CheckLogin(string username, string password)
        {
            //return da.checkLogin(email, password);
            bool success = false;
            try
            {
                Param p = new Param();
                User us = new User();
                us.Username = username;
                us.Password = password;
                p.UserDetail = us;
                JsonSerializerSettings js = new JsonSerializerSettings();
                js.MissingMemberHandling = MissingMemberHandling.Ignore;
                js.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                js.NullValueHandling = NullValueHandling.Include;
                string jContent = JsonConvert.SerializeObject(p, js);
                var content = new StringContent(jContent, Encoding.UTF8, "application/json");
                string serviceURL = "http://" + URL + ":8040/Host/HealthService.svc/checkuser";
                HttpClient client = new HttpClient();
                var result = client.PostAsync(serviceURL, content).Result;
                if (result.StatusCode == HttpStatusCode.OK)
                {

                    string jresult = await result.Content.ReadAsStringAsync();
                    success = (bool)Newtonsoft.Json.JsonConvert.DeserializeObject(jresult, typeof(bool));
                }
            }
            catch (Exception ex)
            {

            }
            return success;
        }
        #endregion
        #region Register1
        //DataAccess da;
        public async Task<int> Register1(string name, int gender, DateTime dob, string username, string password, int height, int weight)
        {
            //return da.checkLogin(email, password);
            int clientid = 0;
            try
            {
                Param p = new Param();
                p.UserDetail.Name = name;
                p.UserDetail.Sex = gender;
                p.UserDetail.DOB = dob;
                p.UserDetail.Username = username;
                p.UserDetail.Password = password;
                p.UserDetail.Height = height;
                p.UserDetail.Weight = weight;
                JsonSerializerSettings js = new JsonSerializerSettings();
                js.MissingMemberHandling = MissingMemberHandling.Ignore;
                js.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                js.NullValueHandling = NullValueHandling.Include;
                string jContent = JsonConvert.SerializeObject(p, js);
                var content = new StringContent(jContent, Encoding.UTF8, "application/json");
                string serviceURL = "http://" + URL + ":8040/Host/HealthService.svc/registeruser";
                HttpClient client = new HttpClient();
                var result = client.PostAsync(serviceURL, content).Result;
                if (result.StatusCode == HttpStatusCode.OK)
                {

                    string jresult = await result.Content.ReadAsStringAsync();
                    clientid = (int)Newtonsoft.Json.JsonConvert.DeserializeObject(jresult, typeof(bool));
                }
            }
            catch (Exception ex)
            {

            }
            return clientid;
        }
        #endregion
        #region Get User Details
        //DataAccess da;
        public async Task<List<User>> getuserdetails(string email)
        {
            //return da.checkLogin(email, password);
            List<User> clist = new List<User>();
            try
            {
                Param p = new Param();
                p.UserDetail.Username = email;
                JsonSerializerSettings js = new JsonSerializerSettings();
                js.MissingMemberHandling = MissingMemberHandling.Ignore;
                js.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                js.NullValueHandling = NullValueHandling.Include;
                string jContent = JsonConvert.SerializeObject(p, js);
                var content = new StringContent(jContent, Encoding.UTF8, "application/json");
                string serviceURL = "http://" + URL + ":8040/Host/HealthService.svc/UsetDetailsr";
                HttpClient client = new HttpClient();
                var result = client.PostAsync(serviceURL, content).Result;
                if (result.StatusCode == HttpStatusCode.OK)
                {

                    string jresult = await result.Content.ReadAsStringAsync();
                    clist = (List<User>)Newtonsoft.Json.JsonConvert.DeserializeObject(jresult, typeof(bool));
                }
            }
            catch (Exception ex)
            {

            }
            return clist;
        }
        #endregion
        #region Get Deit Details
        //DataAccess da;
        public async Task<List<DeitTable>> GetAllDeits()
        {
            //return da.checkLogin(email, password);
            List<DeitTable> clist = new List<DeitTable>();
            try
            {
                Param p = new Param();              
                JsonSerializerSettings js = new JsonSerializerSettings();
                js.MissingMemberHandling = MissingMemberHandling.Ignore;
                js.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                js.NullValueHandling = NullValueHandling.Include;
                string jContent = JsonConvert.SerializeObject(p, js);
                var content = new StringContent(jContent, Encoding.UTF8, "application/json");
                string serviceURL = "http://" + URL + ":8040/Host/HealthService.svc/Dietdetails";
                HttpClient client = new HttpClient();
                var result = client.PostAsync(serviceURL, content).Result;
                if (result.StatusCode == HttpStatusCode.OK)
                {

                    string jresult = await result.Content.ReadAsStringAsync();
                    clist = (List<DeitTable>)Newtonsoft.Json.JsonConvert.DeserializeObject(jresult, typeof(bool));
                }
            }
            catch (Exception ex)
            {

            }
            return clist;
        }
        #endregion
        #region User Selection
        //DataAccess da;
        public async Task<int> UserSelection(int userid, int did)
        {
            //return da.checkLogin(email, password);
            int clientid = 0;
            try
            {
                Param p = new Param();
                p.Userselection.UserID = userid;
                p.Userselection.DeitID = did;
                JsonSerializerSettings js = new JsonSerializerSettings();
                js.MissingMemberHandling = MissingMemberHandling.Ignore;
                js.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                js.NullValueHandling = NullValueHandling.Include;
                string jContent = JsonConvert.SerializeObject(p, js);
                var content = new StringContent(jContent, Encoding.UTF8, "application/json");
                string serviceURL = "http://" + URL + ":8040/Host/HealthService.svc/registeruser";
                HttpClient client = new HttpClient();
                var result = client.PostAsync(serviceURL, content).Result;
                if (result.StatusCode == HttpStatusCode.OK)
                {

                    string jresult = await result.Content.ReadAsStringAsync();
                    clientid = (int)Newtonsoft.Json.JsonConvert.DeserializeObject(jresult, typeof(bool));
                }
            }
            catch (Exception ex)
            {

            }
            return clientid;
        }
        #endregion
        #region Get Basket Details
        //DataAccess da;
        public async Task<List<Basket>> GetBaskets(int userid)
        {
            //return da.checkLogin(email, password);
            List<Basket> clist = new List<Basket>();
            try
            {
                Param p = new Param();
                p.BasketDetails.UserID = userid;
                JsonSerializerSettings js = new JsonSerializerSettings();
                js.MissingMemberHandling = MissingMemberHandling.Ignore;
                js.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                js.NullValueHandling = NullValueHandling.Include;
                string jContent = JsonConvert.SerializeObject(p, js);
                var content = new StringContent(jContent, Encoding.UTF8, "application/json");
                string serviceURL = "http://" + URL + ":8040/Host/HealthService.svc/Basket";
                HttpClient client = new HttpClient();
                var result = client.PostAsync(serviceURL, content).Result;
                if (result.StatusCode == HttpStatusCode.OK)
                {

                    string jresult = await result.Content.ReadAsStringAsync();
                    clist = (List<Basket>)Newtonsoft.Json.JsonConvert.DeserializeObject(jresult, typeof(bool));
                }
            }
            catch (Exception ex)
            {

            }
            return clist;
        }
        #endregion
        #region Add To Basket
        //DataAccess da;
        public async Task<int> AddToBasket(int userid, int did)
        {
            //return da.checkLogin(email, password);
            int clientid = 0;
            try
            {
                Param p = new Param();
                p.BasketDetails.UserID = userid;
                p.DeitTable.DeitID = did;
                JsonSerializerSettings js = new JsonSerializerSettings();
                js.MissingMemberHandling = MissingMemberHandling.Ignore;
                js.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                js.NullValueHandling = NullValueHandling.Include;
                string jContent = JsonConvert.SerializeObject(p, js);
                var content = new StringContent(jContent, Encoding.UTF8, "application/json");
                string serviceURL = "http://" + URL + ":8040/Host/HealthService.svc/AddToBasket";
                HttpClient client = new HttpClient();
                var result = client.PostAsync(serviceURL, content).Result;
                if (result.StatusCode == HttpStatusCode.OK)
                {

                    string jresult = await result.Content.ReadAsStringAsync();
                    clientid = (int)Newtonsoft.Json.JsonConvert.DeserializeObject(jresult, typeof(bool));
                }
            }
            catch (Exception ex)
            {

            }
            return clientid;
        }
        #endregion
        #region Register Slots
        //DataAccess da;
        public async Task<int> InsertSlots(int userid, DateTime slots)
        {
            //return da.checkLogin(email, password);
            int clientid = 0;
            try
            {
                Param p = new Param();
                p.UserApp.UserID=userid;
                p.UserApp.Slots = slots;
                JsonSerializerSettings js = new JsonSerializerSettings();
                js.MissingMemberHandling = MissingMemberHandling.Ignore;
                js.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                js.NullValueHandling = NullValueHandling.Include;
                string jContent = JsonConvert.SerializeObject(p, js);
                var content = new StringContent(jContent, Encoding.UTF8, "application/json");
                string serviceURL = "http://" + URL + ":8040/Host/HealthService.svc/registeruserslots";
                HttpClient client = new HttpClient();
                var result = client.PostAsync(serviceURL, content).Result;
                if (result.StatusCode == HttpStatusCode.OK)
                {

                    string jresult = await result.Content.ReadAsStringAsync();
                    clientid = (int)Newtonsoft.Json.JsonConvert.DeserializeObject(jresult, typeof(bool));
                }
            }
            catch (Exception ex)
            {

            }
            return clientid;
        }
        #endregion
        #region Check Slots
        //DataAccess da;
        public async Task<int> CheckSlots(DateTime slots)
        {
            //return da.checkLogin(email, password);
            int clientid = 0;
            try
            {
                Param p = new Param();
                p.UserApp.Slots = slots;
                JsonSerializerSettings js = new JsonSerializerSettings();
                js.MissingMemberHandling = MissingMemberHandling.Ignore;
                js.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                js.NullValueHandling = NullValueHandling.Include;
                string jContent = JsonConvert.SerializeObject(p, js);
                var content = new StringContent(jContent, Encoding.UTF8, "application/json");
                string serviceURL = "http://" + URL + ":8040/Host/HealthService.svc/checkuserslots";
                HttpClient client = new HttpClient();
                var result = client.PostAsync(serviceURL, content).Result;
                if (result.StatusCode == HttpStatusCode.OK)
                {

                    string jresult = await result.Content.ReadAsStringAsync();
                    clientid = (int)Newtonsoft.Json.JsonConvert.DeserializeObject(jresult, typeof(bool));
                }
            }
            catch (Exception ex)
            {

            }
            return clientid;
        }
        #endregion
        #region Get App params
        //DataAccess da;
        public async Task<List<appparam>> GetAppParams(string city)
        {
            //return da.checkLogin(email, password);
            List<appparam> clist = new List<appparam>();
            try
            {
                Param p = new Param();
                p.CityDetails.CityName = city;
                JsonSerializerSettings js = new JsonSerializerSettings();
                js.MissingMemberHandling = MissingMemberHandling.Ignore;
                js.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                js.NullValueHandling = NullValueHandling.Include;
                string jContent = JsonConvert.SerializeObject(p, js);
                var content = new StringContent(jContent, Encoding.UTF8, "application/json");
                string serviceURL = "http://" + URL + ":8040/Host/HealthService.svc/Dietdetails";
                HttpClient client = new HttpClient();
                var result = client.PostAsync(serviceURL, content).Result;
                if (result.StatusCode == HttpStatusCode.OK)
                {

                    string jresult = await result.Content.ReadAsStringAsync();
                    clist = (List<appparam>)Newtonsoft.Json.JsonConvert.DeserializeObject(jresult, typeof(bool));
                }
            }
            catch (Exception ex)
            {

            }
            return clist;
        }
        #endregion
        #region Register User Address
        //DataAccess da;
        public async Task<int> InsertUserAddress(int userid, string Add1, string Add2, int cityid)
        {
            //return da.checkLogin(email, password);
            int clientid = 0;
            try
            {
                Param p = new Param();
                p.AddressDetails.UserID = userid;
                p.AddressDetails.Add1 = Add1;
                p.AddressDetails.Add2 = Add2;
                p.AddressDetails.CityID = cityid;
                JsonSerializerSettings js = new JsonSerializerSettings();
                js.MissingMemberHandling = MissingMemberHandling.Ignore;
                js.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                js.NullValueHandling = NullValueHandling.Include;
                string jContent = JsonConvert.SerializeObject(p, js);
                var content = new StringContent(jContent, Encoding.UTF8, "application/json");
                string serviceURL = "http://" + URL + ":8040/Host/HealthService.svc/registeruseraddress";
                HttpClient client = new HttpClient();
                var result = client.PostAsync(serviceURL, content).Result;
                if (result.StatusCode == HttpStatusCode.OK)
                {

                    string jresult = await result.Content.ReadAsStringAsync();
                    clientid = (int)Newtonsoft.Json.JsonConvert.DeserializeObject(jresult, typeof(bool));
                }
            }
            catch (Exception ex)
            {

            }
            return clientid;
        }
        #endregion
        #region Register User Contact
        //DataAccess da;
        public async Task<int> InsertUserContact(int userid, string mobile, string email)
        {
            //return da.checkLogin(email, password);
            int clientid = 0;
            try
            {
                Param p = new Param();
                p.ContactDetails.UserID = userid;
                p.ContactDetails.MobileNo = mobile;
                p.ContactDetails.Email = email;
                JsonSerializerSettings js = new JsonSerializerSettings();
                js.MissingMemberHandling = MissingMemberHandling.Ignore;
                js.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                js.NullValueHandling = NullValueHandling.Include;
                string jContent = JsonConvert.SerializeObject(p, js);
                var content = new StringContent(jContent, Encoding.UTF8, "application/json");
                string serviceURL = "http://" + URL + ":8040/Host/HealthService.svc/registerusercontact";
                HttpClient client = new HttpClient();
                var result = client.PostAsync(serviceURL, content).Result;
                if (result.StatusCode == HttpStatusCode.OK)
                {

                    string jresult = await result.Content.ReadAsStringAsync();
                    clientid = (int)Newtonsoft.Json.JsonConvert.DeserializeObject(jresult, typeof(bool));
                }
            }
            catch (Exception ex)
            {

            }
            return clientid;
        }
        #endregion
        #region Get Countries
        //DataAccess da;
        public async Task<List<country>> GetCountries()
        {
            //return da.checkLogin(email, password);
            List<country> clist = new List<country>();
            try
            {
                Param p = new Param();
                
                JsonSerializerSettings js = new JsonSerializerSettings();
                js.MissingMemberHandling = MissingMemberHandling.Ignore;
                js.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                js.NullValueHandling = NullValueHandling.Include;
                string jContent = JsonConvert.SerializeObject(p, js);
                var content = new StringContent(jContent, Encoding.UTF8, "application/json");
                string serviceURL = "http://" + URL + ":8040/Host/HealthService.svc/countries";
                HttpClient client = new HttpClient();
                var result = client.PostAsync(serviceURL, content).Result;
                if (result.StatusCode == HttpStatusCode.OK)
                {

                    string jresult = await result.Content.ReadAsStringAsync();
                    clist = (List<country>)Newtonsoft.Json.JsonConvert.DeserializeObject(jresult, typeof(bool));
                }
            }
            catch (Exception ex)
            {

            }
            return clist;
        }
        #endregion
        #region Get States
        //DataAccess da;
        public async Task<List<state>> GetState(int countryid)
        {
            //return da.checkLogin(email, password);
            List<state> clist = new List<state>();
            try
            {
                Param p = new Param();
                p.CountryDetails.CountryID = countryid;
                JsonSerializerSettings js = new JsonSerializerSettings();
                js.MissingMemberHandling = MissingMemberHandling.Ignore;
                js.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                js.NullValueHandling = NullValueHandling.Include;
                string jContent = JsonConvert.SerializeObject(p, js);
                var content = new StringContent(jContent, Encoding.UTF8, "application/json");
                string serviceURL = "http://" + URL + ":8040/Host/HealthService.svc/states";
                HttpClient client = new HttpClient();
                var result = client.PostAsync(serviceURL, content).Result;
                if (result.StatusCode == HttpStatusCode.OK)
                {

                    string jresult = await result.Content.ReadAsStringAsync();
                    clist = (List<state>)Newtonsoft.Json.JsonConvert.DeserializeObject(jresult, typeof(bool));
                }
            }
            catch (Exception ex)
            {

            }
            return clist;
        }
        #endregion
        #region Get Cities
        //DataAccess da;
        public async Task<List<city>> GetCities(int stateid)
        {
            //return da.checkLogin(email, password);
            List<city> clist = new List<city>();
            try
            {
                Param p = new Param();
                p.StateDetails.Stateid=stateid;
                JsonSerializerSettings js = new JsonSerializerSettings();
                js.MissingMemberHandling = MissingMemberHandling.Ignore;
                js.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                js.NullValueHandling = NullValueHandling.Include;
                string jContent = JsonConvert.SerializeObject(p, js);
                var content = new StringContent(jContent, Encoding.UTF8, "application/json");
                string serviceURL = "http://" + URL + ":8040/Host/HealthService.svc/cities";
                HttpClient client = new HttpClient();
                var result = client.PostAsync(serviceURL, content).Result;
                if (result.StatusCode == HttpStatusCode.OK)
                {

                    string jresult = await result.Content.ReadAsStringAsync();
                    clist = (List<city>)Newtonsoft.Json.JsonConvert.DeserializeObject(jresult, typeof(bool));
                }
            }
            catch (Exception ex)
            {

            }
            return clist;
        }
        #endregion
        #region Update Diet
        //DataAccess da;
        public async Task<int> UpdateDiet(Param p)
        {
            //return da.checkLogin(email, password);
            int clientid = 0;
            try
            {               
                JsonSerializerSettings js = new JsonSerializerSettings();
                js.MissingMemberHandling = MissingMemberHandling.Ignore;
                js.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                js.NullValueHandling = NullValueHandling.Include;
                string jContent = JsonConvert.SerializeObject(p, js);
                var content = new StringContent(jContent, Encoding.UTF8, "application/json");
                string serviceURL = "http://" + URL + ":8040/Host/HealthService.svc/UpdateDiet";
                HttpClient client = new HttpClient();
                var result = client.PostAsync(serviceURL, content).Result;
                if (result.StatusCode == HttpStatusCode.OK)
                {

                    string jresult = await result.Content.ReadAsStringAsync();
                    clientid = (int)Newtonsoft.Json.JsonConvert.DeserializeObject(jresult, typeof(bool));
                }
            }
            catch (Exception ex)
            {

            }
            return clientid;
        }
        #endregion
        #region Create Diet
        //DataAccess da;
        public async Task<int> CreateDiet(Param p)
        {
            //return da.checkLogin(email, password);
            int clientid = 0;
            try
            {
                JsonSerializerSettings js = new JsonSerializerSettings();
                js.MissingMemberHandling = MissingMemberHandling.Ignore;
                js.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                js.NullValueHandling = NullValueHandling.Include;
                string jContent = JsonConvert.SerializeObject(p, js);
                var content = new StringContent(jContent, Encoding.UTF8, "application/json");
                string serviceURL = "http://" + URL + ":8040/Host/HealthService.svc/CreateDiet";
                HttpClient client = new HttpClient();
                var result = client.PostAsync(serviceURL, content).Result;
                if (result.StatusCode == HttpStatusCode.OK)
                {

                    string jresult = await result.Content.ReadAsStringAsync();
                    clientid = (int)Newtonsoft.Json.JsonConvert.DeserializeObject(jresult, typeof(bool));
                }
            }
            catch (Exception ex)
            {

            }
            return clientid;
        }
        #endregion
        #region Delete Diet
        //DataAccess da;
        public async Task<int> DeleteDiet(Param p)
        {
            //return da.checkLogin(email, password);
            int clientid = 0;
            try
            {
                JsonSerializerSettings js = new JsonSerializerSettings();
                js.MissingMemberHandling = MissingMemberHandling.Ignore;
                js.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                js.NullValueHandling = NullValueHandling.Include;
                string jContent = JsonConvert.SerializeObject(p, js);
                var content = new StringContent(jContent, Encoding.UTF8, "application/json");
                string serviceURL = "http://" + URL + ":8040/Host/HealthService.svc/DeleteDiet";
                HttpClient client = new HttpClient();
                var result = client.PostAsync(serviceURL, content).Result;
                if (result.StatusCode == HttpStatusCode.OK)
                {

                    string jresult = await result.Content.ReadAsStringAsync();
                    clientid = (int)Newtonsoft.Json.JsonConvert.DeserializeObject(jresult, typeof(bool));
                }
            }
            catch (Exception ex)
            {

            }
            return clientid;
        }
        #endregion
        #region Create Appiontments
        //DataAccess da;
        public async Task<int> CreateAppointments(Param p)
        {
            //return da.checkLogin(email, password);
            int clientid = 0;
            try
            {
                JsonSerializerSettings js = new JsonSerializerSettings();
                js.MissingMemberHandling = MissingMemberHandling.Ignore;
                js.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                js.NullValueHandling = NullValueHandling.Include;
                string jContent = JsonConvert.SerializeObject(p, js);
                var content = new StringContent(jContent, Encoding.UTF8, "application/json");
                string serviceURL = "http://" + URL + ":8040/Host/HealthService.svc/registerappoinments";
                HttpClient client = new HttpClient();
                var result = client.PostAsync(serviceURL, content).Result;
                if (result.StatusCode == HttpStatusCode.OK)
                {

                    string jresult = await result.Content.ReadAsStringAsync();
                    clientid = (int)Newtonsoft.Json.JsonConvert.DeserializeObject(jresult, typeof(bool));
                }
            }
            catch (Exception ex)
            {

            }
            return clientid;
        }
        #endregion
        #region Update Appiontments
        //DataAccess da;
        public async Task<int> UpdateAppointments(Param p)
        {
            //return da.checkLogin(email, password);
            int clientid = 0;
            try
            {
                JsonSerializerSettings js = new JsonSerializerSettings();
                js.MissingMemberHandling = MissingMemberHandling.Ignore;
                js.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
                js.NullValueHandling = NullValueHandling.Include;
                string jContent = JsonConvert.SerializeObject(p, js);
                var content = new StringContent(jContent, Encoding.UTF8, "application/json");
                string serviceURL = "http://" + URL + ":8040/Host/HealthService.svc/updateappoinmets";
                HttpClient client = new HttpClient();
                var result = client.PostAsync(serviceURL, content).Result;
                if (result.StatusCode == HttpStatusCode.OK)
                {

                    string jresult = await result.Content.ReadAsStringAsync();
                    clientid = (int)Newtonsoft.Json.JsonConvert.DeserializeObject(jresult, typeof(bool));
                }
            }
            catch (Exception ex)
            {

            }
            return clientid;
        }
        #endregion
    }
}


