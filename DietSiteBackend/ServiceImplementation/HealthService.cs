using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using HealthService.DataContract;
using HealthService.ServiceContract;

namespace HealthService.ServiceImplementation
{
    public class HealthService : IHealthService
    {
        #region Create User
        public int createUser(Param p)
        {
            
            bool success = false;
            int clientID = 0;
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            if (!da.authenticateUser(p))
            {
                CustomException ce = new CustomException();
                ce.o_statusCode = 1;
                ce.o_statusMessage = "User is not authorised to access the service";
                ce.Title = "Unauthroised Access Denied";
                throw new FaultException<CustomException>(ce, "Reason : Unauthorised Access");
            }
            else
            {
                string o_statusMessage = "";
                int o_status = -1;
                clientID = da.registerUser(p, out o_status, out o_statusMessage, 1);
                if (o_status != 0)
                {
                    success = false;
                    clientID = 0;
                    CustomException ce = new CustomException();
                    ce.o_statusCode = o_status;
                    ce.o_statusMessage = o_statusMessage;
                    ce.Title = "Exception Occured in Registering the User";
                    throw new FaultException<CustomException>(ce, "Reason : Error Occured");
                }
            }
            return clientID;
            
        }
        #endregion
        #region Check User
        public bool CheckUser(Param p)
        {
            
            bool success = false;
            bool clientID = false;
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            if (!da.authenticateUser(p))
            {
                CustomException ce = new CustomException();
                ce.o_statusCode = 1;
                ce.o_statusMessage = "User is not authorised to access the service";
                ce.Title = "Unauthroised Access Denied";
                throw new FaultException<CustomException>(ce, "Reason : Unauthorised Access");
            }
            else
            {
                string o_statusMessage = "";
                int o_status = -1;
                clientID = da.checkUser(p, out o_status, out o_statusMessage, 1);
                if (clientID)
                {
                    return true;
                }
                else
                {
                    return false;
                }
               /* if (o_status != 0)
                {
                    success = false;
                    clientID = false;
                    CustomException ce = new CustomException();
                    ce.o_statusCode = o_status;
                    ce.o_statusMessage = o_statusMessage;
                    ce.Title = "Exception Occured in Registering the User";
                    throw new FaultException<CustomException>(ce, "Reason : Error Occured");
                }*/
            }
            

        }
        #endregion
        #region get countries
        public List<country> getCountries(Param p)
        {
            List<country> cList = new List<country>();
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            if (!da.authenticateUser(p))
            {
                CustomException ce = new CustomException();
                ce.o_statusCode = 1;
                ce.o_statusMessage = "User is not authorised to access the service";
                ce.Title = "Unauthroised Access Denied";
                throw new FaultException<CustomException>(ce, "Reason : Unauthorised Access");
            }
            else
            {
                string o_statusMessage = "";
                int o_status = -1;
                cList = da.getCountries(out o_status, out o_statusMessage, 1);
                if (o_status != 0)
                {
                    CustomException ce = new CustomException();
                    ce.o_statusCode = o_status;
                    ce.o_statusMessage = o_statusMessage;
                    ce.Title = "Exception Occured in Getting COuntries";
                    throw new FaultException<CustomException>(ce, "Reason : Error Occured");
                }
            }
            return cList;
        }
        #endregion
        #region create appoinments
        public int createappoinments(Param p)
        {

            bool success = false;
            int clientID = 0;
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            if (!da.authenticateUser(p))
            {
                CustomException ce = new CustomException();
                ce.o_statusCode = 1;
                ce.o_statusMessage = "User is not authorised to access the service";
                ce.Title = "Unauthroised Access Denied";
                throw new FaultException<CustomException>(ce, "Reason : Unauthorised Access");
            }
            else
            {
                string o_statusMessage = "";
                int o_status = -1;
                clientID = da.registerappoinments(p, out o_status, out o_statusMessage, 1);
                if (o_status != 0)
                {
                    success = false;
                    clientID = 0;
                    CustomException ce = new CustomException();
                    ce.o_statusCode = o_status;
                    ce.o_statusMessage = o_statusMessage;
                    ce.Title = "Exception Occured in Registering the appoinment";
                    throw new FaultException<CustomException>(ce, "Reason : Error Occured");
                }
            }
            return clientID;

        }
        #endregion
        #region Update appoinments
        public int Updateappoinments(Param p)
        {

            bool success = false;
            int clientID = 0;
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            if (!da.authenticateUser(p))
            {
                CustomException ce = new CustomException();
                ce.o_statusCode = 1;
                ce.o_statusMessage = "User is not authorised to access the service";
                ce.Title = "Unauthroised Access Denied";
                throw new FaultException<CustomException>(ce, "Reason : Unauthorised Access");
            }
            else
            {
                string o_statusMessage = "";
                int o_status = -1;
                clientID = da.updateappoinments(p, out o_status, out o_statusMessage, 1);
                if (o_status != 0)
                {
                    success = false;
                    clientID = 0;
                    CustomException ce = new CustomException();
                    ce.o_statusCode = o_status;
                    ce.o_statusMessage = o_statusMessage;
                    ce.Title = "Exception Occured in Updating the appoinment";
                    throw new FaultException<CustomException>(ce, "Reason : Error Occured");
                }
            }
            return clientID;

        }
        #endregion
        #region  Update/Insert Basket
        public int Basket(Param p)
        {

            bool success = false;
            int clientID = 0;
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            if (!da.authenticateUser(p))
            {
                CustomException ce = new CustomException();
                ce.o_statusCode = 1;
                ce.o_statusMessage = "User is not authorised to access the service";
                ce.Title = "Unauthroised Access Denied";
                throw new FaultException<CustomException>(ce, "Reason : Unauthorised Access");
            }
            else
            {
                string o_statusMessage = "";
                int o_status = -1;
                clientID = da.Basket(p, out o_status, out o_statusMessage, 1);
                if (o_status != 0)
                {
                    success = false;
                    clientID = 0;
                    CustomException ce = new CustomException();
                    ce.o_statusCode = o_status;
                    ce.o_statusMessage = o_statusMessage;
                    ce.Title = "Exception Occured in Updating/Inserting the Basket";
                    throw new FaultException<CustomException>(ce, "Reason : Error Occured");
                }
            }
            return clientID;

        }
        #endregion
        #region get Payment Details
        public List<payment> getPaymentDetails(Param p)
        {
            List<payment> cList = new List<payment>();
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            if (!da.authenticateUser(p))
            {
                CustomException ce = new CustomException();
                ce.o_statusCode = 1;
                ce.o_statusMessage = "User is not authorised to access the service";
                ce.Title = "Unauthroised Access Denied";
                throw new FaultException<CustomException>(ce, "Reason : Unauthorised Access");
            }
            else
            {
                string o_statusMessage = "";
                int o_status = -1;
                cList = da.getPaymentDetails(p, out o_status, out o_statusMessage, 1);
                if (o_status != 0)
                {
                    CustomException ce = new CustomException();
                    ce.o_statusCode = o_status;
                    ce.o_statusMessage = o_statusMessage;
                    ce.Title = "Exception Occured in Getting payment Details";
                    throw new FaultException<CustomException>(ce, "Reason : Error Occured");
                }
            }
            return cList;
        }
        #endregion
        #region  User Selection
        public int UserSelection(Param p)
        {

            bool success = false;
            int val = 0;
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            if (!da.authenticateUser(p))
            {
                CustomException ce = new CustomException();
                ce.o_statusCode = 1;
                ce.o_statusMessage = "User is not authorised to access the service";
                ce.Title = "Unauthroised Access Denied";
                throw new FaultException<CustomException>(ce, "Reason : Unauthorised Access");
            }
            else
            {
                string o_statusMessage = "";
                int o_status = -1;
                val = da.UserSelection(p, out o_status, out o_statusMessage, 1);
                if (o_status != 0)
                {
                    CustomException ce = new CustomException();
                    ce.o_statusCode = o_status;
                    ce.o_statusMessage = o_statusMessage;
                    ce.Title = "Exception Occured in Getting User Selection";
                    throw new FaultException<CustomException>(ce, "Reason : Error Occured");
                }
            }
            return val;

        }
        #endregion
        #region get Deit Details
        public List<DeitTable> getDeitDetails(Param p)
        {
            List<DeitTable> cList = new List<DeitTable>();
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            if (!da.authenticateUser(p))
            {
                CustomException ce = new CustomException();
                ce.o_statusCode = 1;
                ce.o_statusMessage = "User is not authorised to access the service";
                ce.Title = "Unauthroised Access Denied";
                throw new FaultException<CustomException>(ce, "Reason : Unauthorised Access");
            }
            else
            {
                string o_statusMessage = "";
                int o_status = -1;
                cList = da.getDeitDetails( out o_status, out o_statusMessage, 1);
                if (o_status != 0)
                {
                    CustomException ce = new CustomException();
                    ce.o_statusCode = o_status;
                    ce.o_statusMessage = o_statusMessage;
                    ce.Title = "Exception Occured in Getting Deit Details";
                    throw new FaultException<CustomException>(ce, "Reason : Error Occured");
                }
            }
            return cList;
        }
        #endregion
        #region Update Deit Details
        public int UpdateDeitTable(Param p)
        {

            bool success = false;
            int clientID = 0;
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            if (!da.authenticateUser(p))
            {
                CustomException ce = new CustomException();
                ce.o_statusCode = 1;
                ce.o_statusMessage = "User is not authorised to access the service";
                ce.Title = "Unauthroised Access Denied";
                throw new FaultException<CustomException>(ce, "Reason : Unauthorised Access");
            }
            else
            {
                string o_statusMessage = "";
                int o_status = -1;
                clientID = da.UpdateDeitDetails(p, out o_status, out o_statusMessage, 1);
                if (o_status != 0)
                {
                    success = false;
                    clientID = 0;
                    CustomException ce = new CustomException();
                    ce.o_statusCode = o_status;
                    ce.o_statusMessage = o_statusMessage;
                    ce.Title = "Exception Occured in Updating the Deit Table";
                    throw new FaultException<CustomException>(ce, "Reason : Error Occured");
                }
            }
            return clientID;

        }
        #endregion
        #region Create Deit Details
        public int CreateDiet(Param p)
        {

            bool success = false;
            int clientID = 0;
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            if (!da.authenticateUser(p))
            {
                CustomException ce = new CustomException();
                ce.o_statusCode = 1;
                ce.o_statusMessage = "User is not authorised to access the service";
                ce.Title = "Unauthroised Access Denied";
                throw new FaultException<CustomException>(ce, "Reason : Unauthorised Access");
            }
            else
            {
                string o_statusMessage = "";
                int o_status = -1;
                clientID = da.CreateDiet(p, out o_status, out o_statusMessage, 1);
                if (o_status != 0)
                {
                    success = false;
                    clientID = 0;
                    CustomException ce = new CustomException();
                    ce.o_statusCode = o_status;
                    ce.o_statusMessage = o_statusMessage;
                    ce.Title = "Exception Occured in Updating the Deit Table";
                    throw new FaultException<CustomException>(ce, "Reason : Error Occured");
                }
            }
            return clientID;

        }
        #endregion
        #region Delete Deit Details
        public int DeleteDiet(Param p)
        {

            bool success = false;
            int clientID = 0;
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            if (!da.authenticateUser(p))
            {
                CustomException ce = new CustomException();
                ce.o_statusCode = 1;
                ce.o_statusMessage = "User is not authorised to access the service";
                ce.Title = "Unauthroised Access Denied";
                throw new FaultException<CustomException>(ce, "Reason : Unauthorised Access");
            }
            else
            {
                string o_statusMessage = "";
                int o_status = -1;
                clientID = da.DeleteDiet(p, out o_status, out o_statusMessage, 1);
                if (o_status != 0)
                {
                    success = false;
                    clientID = 0;
                    CustomException ce = new CustomException();
                    ce.o_statusCode = o_status;
                    ce.o_statusMessage = o_statusMessage;
                    ce.Title = "Exception Occured in Updating the Deit Table";
                    throw new FaultException<CustomException>(ce, "Reason : Error Occured");
                }
            }
            return clientID;

        }
        #endregion
        #region get Local Appoinments
        public List<appparam> getLocalAppoinmenets(Param p)
        {
            List<appparam> cList = new List<appparam>();
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            if (!da.authenticateUser(p))
            {
                CustomException ce = new CustomException();
                ce.o_statusCode = 1;
                ce.o_statusMessage = "User is not authorised to access the service";
                ce.Title = "Unauthroised Access Denied";
                throw new FaultException<CustomException>(ce, "Reason : Unauthorised Access");
            }
            else
            {
                string o_statusMessage = "";
                int o_status = -1;
                cList = da.getlocalappparameter(p ,out o_status, out o_statusMessage, 1);
                if (o_status != 0)
                {
                    CustomException ce = new CustomException();
                    ce.o_statusCode = o_status;
                    ce.o_statusMessage = o_statusMessage;
                    ce.Title = "Exception Occured in Getting Local Appoinments";
                    throw new FaultException<CustomException>(ce, "Reason : Error Occured");
                }
            }
            return cList;
        }
        #endregion
        #region get Out City Appoinments
        public List<appparam> getOutCityAppoinmenets(Param p)
        {
            List<appparam> cList = new List<appparam>();
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            if (!da.authenticateUser(p))
            {
                CustomException ce = new CustomException();
                ce.o_statusCode = 1;
                ce.o_statusMessage = "User is not authorised to access the service";
                ce.Title = "Unauthroised Access Denied";
                throw new FaultException<CustomException>(ce, "Reason : Unauthorised Access");
            }
            else
            {
                string o_statusMessage = "";
                int o_status = -1;
                cList = da.getoutcityappparameter(p, out o_status, out o_statusMessage, 1);
                if (o_status != 0)
                {
                    CustomException ce = new CustomException();
                    ce.o_statusCode = o_status;
                    ce.o_statusMessage = o_statusMessage;
                    ce.Title = "Exception Occured in Getting Out city appoinment";
                    throw new FaultException<CustomException>(ce, "Reason : Error Occured");
                }
            }
            return cList;
        }
        #endregion
        #region get User Details
        public List<User> getuserDetails(Param p)
        {
            List<User> cList = new List<User>();
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            if (!da.authenticateUser(p))
            {
                CustomException ce = new CustomException();
                ce.o_statusCode = 1;
                ce.o_statusMessage = "User is not authorised to access the service";
                ce.Title = "Unauthroised Access Denied";
                throw new FaultException<CustomException>(ce, "Reason : Unauthorised Access");
            }
            else
            {
                string o_statusMessage = "";
                int o_status = -1;
                cList = da.getuserdetails(p, out o_status, out o_statusMessage, 1);
                if (o_status != 0)
                {
                    CustomException ce = new CustomException();
                    ce.o_statusCode = o_status;
                    ce.o_statusMessage = o_statusMessage;
                    ce.Title = "Exception Occured in Getting User Details";
                    throw new FaultException<CustomException>(ce, "Reason : Error Occured");
                }
            }
            return cList;
        }
        #endregion
        #region get User Address
        public List<address> getaddress(Param p)
        {
            List<address> cList = new List<address>();
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            if (!da.authenticateUser(p))
            {
                CustomException ce = new CustomException();
                ce.o_statusCode = 1;
                ce.o_statusMessage = "User is not authorised to access the service";
                ce.Title = "Unauthroised Access Denied";
                throw new FaultException<CustomException>(ce, "Reason : Unauthorised Access");
            }
            else
            {
                string o_statusMessage = "";
                int o_status = -1;
                cList = da.getuseraddress(p, out o_status, out o_statusMessage, 1);
                if (o_status != 0)
                {
                    CustomException ce = new CustomException();
                    ce.o_statusCode = o_status;
                    ce.o_statusMessage = o_statusMessage;
                    ce.Title = "Exception Occured in Geting User Address";
                    throw new FaultException<CustomException>(ce, "Reason : Error Occured");
                }
            }
            return cList;
        }
        #endregion
        #region Create User  Address
        public int createUseraddress(Param p)
        {

            bool success = false;
            int clientID = 0;
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            if (!da.authenticateUser(p))
            {
                CustomException ce = new CustomException();
                ce.o_statusCode = 1;
                ce.o_statusMessage = "User is not authorised to access the service";
                ce.Title = "Unauthroised Access Denied";
                throw new FaultException<CustomException>(ce, "Reason : Unauthorised Access");
            }
            else
            {
                string o_statusMessage = "";
                int o_status = -1;
                clientID = da.registerUseraddress(p, out o_status, out o_statusMessage, 1);
                if (o_status != 0)
                {
                    success = false;
                    clientID = 0;
                    CustomException ce = new CustomException();
                    ce.o_statusCode = o_status;
                    ce.o_statusMessage = o_statusMessage;
                    ce.Title = "Exception Occured in Registering the User Address";
                    throw new FaultException<CustomException>(ce, "Reason : Error Occured");
                }
            }
            return clientID;

        }
        #endregion
        #region get User Contact
        public List<Contact> getusercontact(Param p)
        {
            List<Contact> cList = new List<Contact>();
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            if (!da.authenticateUser(p))
            {
                CustomException ce = new CustomException();
                ce.o_statusCode = 1;
                ce.o_statusMessage = "User is not authorised to access the service";
                ce.Title = "Unauthroised Access Denied";
                throw new FaultException<CustomException>(ce, "Reason : Unauthorised Access");
            }
            else
            {
                string o_statusMessage = "";
                int o_status = -1;
                cList = da.getusercontact(p, out o_status, out o_statusMessage, 1);
                if (o_status != 0)
                {
                    CustomException ce = new CustomException();
                    ce.o_statusCode = o_status;
                    ce.o_statusMessage = o_statusMessage;
                    ce.Title = "Exception Occured in Geting User Address";
                    throw new FaultException<CustomException>(ce, "Reason : Error Occured");
                }
            }
            return cList;
        }
        #endregion
        #region Create User Contact
        public int createUsercontact(Param p)
        {

            bool success = false;
            int clientID = 0;
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            if (!da.authenticateUser(p))
            {
                CustomException ce = new CustomException();
                ce.o_statusCode = 1;
                ce.o_statusMessage = "User is not authorised to access the service";
                ce.Title = "Unauthroised Access Denied";
                throw new FaultException<CustomException>(ce, "Reason : Unauthorised Access");
            }
            else
            {
                string o_statusMessage = "";
                int o_status = -1;
                clientID = da.registerUseraddress(p, out o_status, out o_statusMessage, 1);
                if (o_status != 0)
                {
                    success = false;
                    clientID = 0;
                    CustomException ce = new CustomException();
                    ce.o_statusCode = o_status;
                    ce.o_statusMessage = o_statusMessage;
                    ce.Title = "Exception Occured in Registering the User Address";
                    throw new FaultException<CustomException>(ce, "Reason : Error Occured");
                }
            }
            return clientID;

        }
        #endregion
        #region Update Contact
        public int UpdateUsercontact(Param p)
        {

            bool success = false;
            int clientID = 0;
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            if (!da.authenticateUser(p))
            {
                CustomException ce = new CustomException();
                ce.o_statusCode = 1;
                ce.o_statusMessage = "User is not authorised to access the service";
                ce.Title = "Unauthroised Access Denied";
                throw new FaultException<CustomException>(ce, "Reason : Unauthorised Access");
            }
            else
            {
                string o_statusMessage = "";
                int o_status = -1;
                clientID = da.updateappoinments(p, out o_status, out o_statusMessage, 1);
                if (o_status != 0)
                {
                    success = false;
                    clientID = 0;
                    CustomException ce = new CustomException();
                    ce.o_statusCode = o_status;
                    ce.o_statusMessage = o_statusMessage;
                    ce.Title = "Exception Occured in Updating the appoinment";
                    throw new FaultException<CustomException>(ce, "Reason : Error Occured");
                }
            }
            return clientID;

        }
        #endregion
        #region get User interest
        public List<Services> getuserinterest(Param p)
        {
            List<Services> cList = new List<Services>();
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            if (!da.authenticateUser(p))
            {
                CustomException ce = new CustomException();
                ce.o_statusCode = 1;
                ce.o_statusMessage = "User is not authorised to access the service";
                ce.Title = "Unauthroised Access Denied";
                throw new FaultException<CustomException>(ce, "Reason : Unauthorised Access");
            }
            else
            {
                string o_statusMessage = "";
                int o_status = -1;
                cList = da.getuserinterest(p, out o_status, out o_statusMessage, 1);
                if (o_status != 0)
                {
                    CustomException ce = new CustomException();
                    ce.o_statusCode = o_status;
                    ce.o_statusMessage = o_statusMessage;
                    ce.Title = "Exception Occured in Geting User Address";
                    throw new FaultException<CustomException>(ce, "Reason : Error Occured");
                }
            }
            return cList;
        }
        #endregion
        #region get User Disease
        public List<Disease> getuserdisease(Param p)
        {
            List<Disease> cList = new List<Disease>();
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            if (!da.authenticateUser(p))
            {
                CustomException ce = new CustomException();
                ce.o_statusCode = 1;
                ce.o_statusMessage = "User is not authorised to access the service";
                ce.Title = "Unauthroised Access Denied";
                throw new FaultException<CustomException>(ce, "Reason : Unauthorised Access");
            }
            else
            {
                string o_statusMessage = "";
                int o_status = -1;
                cList = da.getuserDisease(p, out o_status, out o_statusMessage, 1);
                if (o_status != 0)
                {
                    CustomException ce = new CustomException();
                    ce.o_statusCode = o_status;
                    ce.o_statusMessage = o_statusMessage;
                    ce.Title = "Exception Occured in Geting User Address";
                    throw new FaultException<CustomException>(ce, "Reason : Error Occured");
                }
            }
            return cList;
        }
        #endregion
        #region Update Username
        public int updateusername(Param p)
        {

            bool success = false;
            int clientID = 0;
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            if (!da.authenticateUser(p))
            {
                CustomException ce = new CustomException();
                ce.o_statusCode = 1;
                ce.o_statusMessage = "User is not authorised to access the service";
                ce.Title = "Unauthroised Access Denied";
                throw new FaultException<CustomException>(ce, "Reason : Unauthorised Access");
            }
            else
            {
                string o_statusMessage = "";
                int o_status = -1;
                clientID = da.Updateusername(p, out o_status, out o_statusMessage, 1);
                if (o_status != 0)
                {
                    success = false;
                    clientID = 0;
                    CustomException ce = new CustomException();
                    ce.o_statusCode = o_status;
                    ce.o_statusMessage = o_statusMessage;
                    ce.Title = "Exception Occured in Registering the User";
                    throw new FaultException<CustomException>(ce, "Reason : Error Occured");
                }
            }
            return clientID;

        }
        #endregion
        #region Update password
        public int updatepassword(Param p)
        {

            bool success = false;
            int clientID = 0;
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            if (!da.authenticateUser(p))
            {
                CustomException ce = new CustomException();
                ce.o_statusCode = 1;
                ce.o_statusMessage = "User is not authorised to access the service";
                ce.Title = "Unauthroised Access Denied";
                throw new FaultException<CustomException>(ce, "Reason : Unauthorised Access");
            }
            else
            {
                string o_statusMessage = "";
                int o_status = -1;
                clientID = da.Updatepassword(p, out o_status, out o_statusMessage, 1);
                if (o_status != 0)
                {
                    success = false;
                    clientID = 0;
                    CustomException ce = new CustomException();
                    ce.o_statusCode = o_status;
                    ce.o_statusMessage = o_statusMessage;
                    ce.Title = "Exception Occured in Registering the User";
                    throw new FaultException<CustomException>(ce, "Reason : Error Occured");
                }
            }
            return clientID;

        }
        #endregion
        #region get Basket
        public List<Basket> GetBaskets(Param p)
        {
            List<Basket> cList = new List<Basket>();
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            if (!da.authenticateUser(p))
            {
                CustomException ce = new CustomException();
                ce.o_statusCode = 1;
                ce.o_statusMessage = "User is not authorised to access the service";
                ce.Title = "Unauthroised Access Denied";
                throw new FaultException<CustomException>(ce, "Reason : Unauthorised Access");
            }
            else
            {
                string o_statusMessage = "";
                int o_status = -1;
                cList = da.getbasket(p,out o_status, out o_statusMessage, 1);
                if (o_status != 0)
                {
                    CustomException ce = new CustomException();
                    ce.o_statusCode = o_status;
                    ce.o_statusMessage = o_statusMessage;
                    ce.Title = "Exception Occured in Getting COuntries";
                    throw new FaultException<CustomException>(ce, "Reason : Error Occured");
                }
            }
            return cList;
        }
        #endregion
        #region Create User slots
        public int createUserslots(Param p)
        {

            bool success = false;
            int clientID = 0;
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            if (!da.authenticateUser(p))
            {
                CustomException ce = new CustomException();
                ce.o_statusCode = 1;
                ce.o_statusMessage = "User is not authorised to access the service";
                ce.Title = "Unauthroised Access Denied";
                throw new FaultException<CustomException>(ce, "Reason : Unauthorised Access");
            }
            else
            {
                string o_statusMessage = "";
                int o_status = -1;
                clientID = da.registeruserslots(p, out o_status, out o_statusMessage, 1);
                if (o_status != 0)
                {
                    success = false;
                    clientID = 0;
                    CustomException ce = new CustomException();
                    ce.o_statusCode = o_status;
                    ce.o_statusMessage = o_statusMessage;
                    ce.Title = "Exception Occured in Registering the User Address";
                    throw new FaultException<CustomException>(ce, "Reason : Error Occured");
                }
            }
            return clientID;

        }
        #endregion
        #region Check slots
        public int checkslots(Param p)
        {

            bool success = false;
            int clientID = 0;
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            if (!da.authenticateUser(p))
            {
                CustomException ce = new CustomException();
                ce.o_statusCode = 1;
                ce.o_statusMessage = "User is not authorised to access the service";
                ce.Title = "Unauthroised Access Denied";
                throw new FaultException<CustomException>(ce, "Reason : Unauthorised Access");
            }
            else
            {
                string o_statusMessage = "";
                int o_status = -1;
                clientID = da.checkslots(p, out o_status, out o_statusMessage, 1);
                if (o_status != 0)
                {
                    success = false;
                    clientID = 0;
                    CustomException ce = new CustomException();
                    ce.o_statusCode = o_status;
                    ce.o_statusMessage = o_statusMessage;
                    ce.Title = "Exception Occured in Registering the User Address";
                    throw new FaultException<CustomException>(ce, "Reason : Error Occured");
                }
            }
            return clientID;

        }
        #endregion
        #region get states
        public List<state> getstates(Param p)
        {
            List<state> cList = new List<state>();
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            if (!da.authenticateUser(p))
            {
                CustomException ce = new CustomException();
                ce.o_statusCode = 1;
                ce.o_statusMessage = "User is not authorised to access the service";
                ce.Title = "Unauthroised Access Denied";
                throw new FaultException<CustomException>(ce, "Reason : Unauthorised Access");
            }
            else
            {
                string o_statusMessage = "";
                int o_status = -1;
                cList = da.getstate(p, out o_status, out o_statusMessage, 1);
                if (o_status != 0)
                {
                    CustomException ce = new CustomException();
                    ce.o_statusCode = o_status;
                    ce.o_statusMessage = o_statusMessage;
                    ce.Title = "Exception Occured in Getting COuntries";
                    throw new FaultException<CustomException>(ce, "Reason : Error Occured");
                }
            }
            return cList;
        }
        #endregion
        #region get cities
        public List<city> getcities(Param p)
        {
            List<city> cList = new List<city>();
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            if (!da.authenticateUser(p))
            {
                CustomException ce = new CustomException();
                ce.o_statusCode = 1;
                ce.o_statusMessage = "User is not authorised to access the service";
                ce.Title = "Unauthroised Access Denied";
                throw new FaultException<CustomException>(ce, "Reason : Unauthorised Access");
            }
            else
            {
                string o_statusMessage = "";
                int o_status = -1;
                cList = da.getcity(p, out o_status, out o_statusMessage, 1);
                if (o_status != 0)
                {
                    CustomException ce = new CustomException();
                    ce.o_statusCode = o_status;
                    ce.o_statusMessage = o_statusMessage;
                    ce.Title = "Exception Occured in Getting COuntries";
                    throw new FaultException<CustomException>(ce, "Reason : Error Occured");
                }
            }
            return cList;
        }
        #endregion
    }
}