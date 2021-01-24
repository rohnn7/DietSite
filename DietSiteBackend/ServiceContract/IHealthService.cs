using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using HealthService.DataContract;

namespace HealthService.ServiceContract
{
    [ServiceContract]
    public interface IHealthService
    {
        #region Get Countries
            [OperationContract]
            [WebInvoke(Method = "POST", UriTemplate = "countries",
                BodyStyle = WebMessageBodyStyle.Bare,
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json)]
            [FaultContract(typeof(CustomException))]
            List<country> getCountries(Param p);
            #endregion
        #region Register User
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "registeruser",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(CustomException))]
        int createUser(Param p);
        #endregion
        #region Check User
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "checkuser",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(CustomException))]
        bool CheckUser(Param p);
        #endregion
        #region Register Appoinments
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "registerappoinments",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(CustomException))]
        int createappoinments(Param p);
        #endregion
        #region Update Appoinments
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "updateappoinmets",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(CustomException))]
        int Updateappoinments(Param p);
        #endregion
        #region Update/Insert Basket
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "AddToBasket",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(CustomException))]
        int Basket(Param p);
        #endregion
        #region Get Payment Details
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "paymentdetails",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(CustomException))]
        List<payment> getPaymentDetails(Param p);
        #endregion
        #region User Selection
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "userselection",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(CustomException))]
        int UserSelection(Param p);
        #endregion
        #region Get Deit Details
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Dietdetails",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(CustomException))]
        List<DeitTable> getDeitDetails(Param p);
        #endregion
        #region Update Diet 
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateDiet",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(CustomException))]
        int UpdateDeitTable(Param p);
        #endregion
        #region Create Diet 
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "CreateDiet",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(CustomException))]
        int CreateDiet(Param p);
        #endregion
        #region Delete Diet 
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "DeleteDiet",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(CustomException))]
        int DeleteDiet(Param p);
        #endregion
        #region Get Local Appoinments
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "LocalAppoinments",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(CustomException))]
        List<appparam> getLocalAppoinmenets(Param p);
        #endregion
        #region Get Out City Appoinments
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "OutCityAppoinments",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(CustomException))]
        List<appparam> getOutCityAppoinmenets(Param p);
        #endregion
        #region Get User Details
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UsetDetails",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(CustomException))]
        List<User> getuserDetails(Param p);
        #endregion
        #region Get User Address
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetAddress",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(CustomException))]
        List<address> getaddress(Param p);
        #endregion
        #region Register User Address
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "registeruseraddress",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(CustomException))]
        int createUseraddress(Param p);
        #endregion
        #region Get User contact
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Contact",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(CustomException))]
        List<Contact> getusercontact(Param p);
        #endregion
        #region Register User Contact
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "registerusercontact",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(CustomException))]
        int createUsercontact(Param p);
        #endregion
        #region Update User Contact
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateContact",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(CustomException))]
        int UpdateUsercontact(Param p);
        #endregion
        #region Get User Interest
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Userinterest",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(CustomException))]
        List<Services> getuserinterest(Param p);
        #endregion
        #region Get User Disease
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Userdisease",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(CustomException))]
        List<Disease> getuserdisease(Param p);
        #endregion
        #region Update username
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateUsername",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(CustomException))]
        int updateusername(Param p);
        #endregion
        #region Update Password
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UpdatePassword",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(CustomException))]
        int updatepassword(Param p);
        #endregion
        #region Get Basket
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Basket",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(CustomException))]
        List<Basket> GetBaskets(Param p);
        #endregion
        #region Register User Slots
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "registeruserslots",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(CustomException))]
        int createUserslots(Param p);
        #endregion
        #region Check Slots
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "checkuserslots",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(CustomException))]
        int checkslots(Param p);
        #endregion
        #region Get State
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "states",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(CustomException))]
        List<state> getstates(Param p);
        #endregion
        #region Get city
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "cities",
            BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        [FaultContract(typeof(CustomException))]
        List<city> getcities(Param p);
        #endregion
    }

}
