using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietSite.Service
{
    public interface ICommunicationService
    {
        Task<bool> CheckLogin(string username, string password);
        Task<int> Register1(string name, int gender, DateTime dob, string username, string password, int height, int weight );
        Task<List<User>> getuserdetails(string email);
        Task<List<DeitTable>> GetAllDeits();
        Task<int> UserSelection(int userid, int did);
        Task<List<Basket>> GetBaskets(int userid);
        Task<int> AddToBasket(int userid, int did);
        Task<int> InsertSlots(int userid, DateTime slots);
        Task<int> CheckSlots( DateTime slots);
        Task<List<appparam>> GetAppParams(string city);
        Task<int> InsertUserAddress(int userid, string Add1, string Add2, int cityid);
        Task<int> InsertUserContact(int userid, string mobile, string email);
        Task<List<country>> GetCountries();
        Task<List<state>> GetState(int countryid);
        Task<List<city>> GetCities(int stateid);
        Task<int> UpdateDiet(Param p);
        Task<int> CreateDiet(Param p);
        Task<int> DeleteDiet(Param p);
        Task<int> CreateAppointments(Param p);
        Task<int> UpdateAppointments(Param p);
    }
}
