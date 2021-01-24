using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HealthService.DataContract;
using MySql.Data.MySqlClient;

namespace HealthService.DataAccess
{
    public class DataAccess
    {
        private string userID = "root";
        private string password = "cpr5063";
        private string server = "localhost";
        private string database = "health";
        private string connString = "";

        public DataAccess()
        {
            connString = "Persist Security Info=True;User Id=" + userID + "; password=" + password + ";server=" + server + ";database=" + database;
        }
        #region Authentication
        public bool authenticateUser(Param p)
        {
            return true;
        }
        #endregion
        #region Register User
        public int registerUser(Param uc, out int o_status, out string o_statusMessage, int in_transaction)
        {
            #region Register User
            bool success = false;
            int clientID = 0;
            try
            {
                //IN in_weight int, INOUT o_status int, INOUT o_statusMessage varchar(255),IN in_transaction INT)
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("user_insertuserdetails", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        MySqlParameter param_name = cmd.Parameters.Add("in_name", MySqlDbType.String);
                        MySqlParameter param_gender = cmd.Parameters.Add("in_usergender", MySqlDbType.Int16);
                        MySqlParameter param_dob = cmd.Parameters.Add("in_userdob", MySqlDbType.DateTime);
                        MySqlParameter param_loginname = cmd.Parameters.Add("in_username", MySqlDbType.String);
                        MySqlParameter param_password = cmd.Parameters.Add("in_password", MySqlDbType.String);
                        MySqlParameter param_height = cmd.Parameters.Add("in_height", MySqlDbType.Int32);
                        MySqlParameter param_weight = cmd.Parameters.Add("in_weight", MySqlDbType.Int32);
                        MySqlParameter param_transaction = cmd.Parameters.Add("in_transaction", MySqlDbType.Int32);
                        MySqlParameter param_status = cmd.Parameters.Add("o_status", MySqlDbType.Int32);
                        MySqlParameter param_statusMessage = cmd.Parameters.Add("o_statusMessage", MySqlDbType.String);
                        param_name.Value = uc.UserDetail.Name;
                        param_gender.Value = uc.UserDetail.Sex;
                        param_dob.Value = uc.UserDetail.DOB;
                        param_loginname.Value = uc.UserDetail.Username;
                        param_password.Value = uc.UserDetail.Password;
                        param_height.Value = uc.UserDetail.Height;
                        param_weight.Value = uc.UserDetail.Weight;
                        param_status.Direction = System.Data.ParameterDirection.InputOutput;
                        param_statusMessage.Direction = System.Data.ParameterDirection.InputOutput;
                        param_transaction.Value = 1;
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            o_status = Convert.ToInt32(param_status.Value);
                            o_statusMessage = Convert.ToString(param_statusMessage.Value);
                            if (o_status == 0)
                            {
                                success = true;
                                while (dr.Read())
                                {
                                    clientID = dr.GetInt32(0);
                                }
                            }
                            else
                            {
                                success = false;
                                clientID = 0;
                            }
                        }
                    }
                    conn.Close();

                }
            }
            catch (MySqlException ex)
            {
                o_status = 1;
                o_statusMessage = ex.Message;
                success = false;
                clientID = 0;
            }
            return clientID;
            #endregion
        }
        #endregion
        #region check User
        public bool checkUser(Param uc, out int o_status, out string o_statusMessage, int in_transaction)
        {
            #region check User
            bool success = false;
            int clientID = 0;
            try
            {
                //IN in_weight int, INOUT o_status int, INOUT o_statusMessage varchar(255),IN in_transaction INT)
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("user_checklogin", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        MySqlParameter param_userid = cmd.Parameters.Add("in_userid", MySqlDbType.Int32);
                        MySqlParameter param_loginname = cmd.Parameters.Add("in_username", MySqlDbType.String);
                        MySqlParameter param_password = cmd.Parameters.Add("in_password", MySqlDbType.String);
                        MySqlParameter param_transaction = cmd.Parameters.Add("in_transaction", MySqlDbType.Int32);
                        MySqlParameter param_status = cmd.Parameters.Add("o_status", MySqlDbType.Int32);
                        MySqlParameter param_statusMessage = cmd.Parameters.Add("o_statusMessage", MySqlDbType.String);
                        param_userid.Value = uc.UserDetail.UserID;
                        param_loginname.Value = uc.UserDetail.Username;
                        param_password.Value = uc.UserDetail.Password;
                        param_status.Direction = System.Data.ParameterDirection.InputOutput;
                        param_statusMessage.Direction = System.Data.ParameterDirection.InputOutput;
                        param_transaction.Value = 1;
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            o_status = Convert.ToInt32(param_status.Value);
                            o_statusMessage = Convert.ToString(param_statusMessage.Value);
                            if (o_status == 0)
                            {
                                success = true;
                                while (dr.Read())
                                {
                                    clientID = dr.GetInt32(0);
                                }
                                if (clientID == 0)
                                    return true;
                                else
                                    return false;
                            }
                            else
                            {
                                success = false;
                                                                
                            }
                        }
                    }
                    conn.Close();

                }
            }
            catch (MySqlException ex)
            {
                o_status = 1;
                o_statusMessage = ex.Message;
                success = false;
            }
            if (clientID == 0)
                return true;
            else
                return false;

            #endregion
        }
        #endregion
        #region Get Country
        public List<country> getCountries(out int o_status, out string o_statusMessage, int in_transaction)
        {
            #region Get the List of Country
            List<country> qList = new List<country>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("gen_getcountry", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        MySqlParameter param_transaction = cmd.Parameters.Add("in_transaction", MySqlDbType.Int32);
                        MySqlParameter param_status = cmd.Parameters.Add("o_status", MySqlDbType.Int32);
                        MySqlParameter param_statusMessage = cmd.Parameters.Add("o_statusMessage", MySqlDbType.String);
                        param_status.Direction = System.Data.ParameterDirection.InputOutput;
                        param_statusMessage.Direction = System.Data.ParameterDirection.InputOutput;
                        param_transaction.Value = in_transaction;
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            o_status = Convert.ToInt32(param_status.Value);
                            o_statusMessage = Convert.ToString(param_statusMessage.Value);
                            while (dr.Read())
                            {
                                country ct1 = new country();
                                ct1.CountryID = dr.GetInt32(0);
                                ct1.CountryName = dr.GetString(1);
                                ct1.CountryCode = dr.GetString(2);                                
                                qList.Add(ct1);
                            }
                            dr.Close();
                        }
                    }
                    conn.Close();

                }
            }
            catch (MySqlException ex)
            {
                o_status = 1;
                o_statusMessage = ex.Message;
                qList = new List<country>();
            }
            return qList;
            #endregion
        }
        #endregion
        #region Register Appoinments
        public int registerappoinments(Param ap, out int o_status, out string o_statusMessage, int in_transaction)
        {
            #region Register User
            bool success = false;
            int clientID = 0;
            try
            {
                //( IN time, IN  time, IN  time, IN  int, IN  datetime, IN  datetime, IN  varchar(255),IN  varchar(255),INOUT o_status int, INOUT o_statusMessage varchar(255),IN in_transaction int)

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("admin_createappparam", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        MySqlParameter param_avaetime = cmd.Parameters.Add("in_aveTime", MySqlDbType.Int32);
                        MySqlParameter param_morslotbegin = cmd.Parameters.Add("in_morslotbegin", MySqlDbType.Time);
                        MySqlParameter param_morslotend = cmd.Parameters.Add("in_morslotend ", MySqlDbType.Time);
                        MySqlParameter param_afnsslotbegin = cmd.Parameters.Add("in_afnslotbegin", MySqlDbType.String);
                        MySqlParameter param_afnsends = cmd.Parameters.Add("in_afnslotend ", MySqlDbType.Time);
                        MySqlParameter param_offday = cmd.Parameters.Add("in_offday", MySqlDbType.Int32);
                        MySqlParameter param_datefrom = cmd.Parameters.Add("in_datefrom", MySqlDbType.DateTime);
                        MySqlParameter param_dateto = cmd.Parameters.Add("in_dateto", MySqlDbType.DateTime);
                        MySqlParameter param_cityname = cmd.Parameters.Add("in_cityname", MySqlDbType.String);
                        MySqlParameter param_outcity = cmd.Parameters.Add("in_datefrom", MySqlDbType.DateTime);
                        MySqlParameter param_transaction = cmd.Parameters.Add("in_transaction", MySqlDbType.Int32);
                        MySqlParameter param_status = cmd.Parameters.Add("o_status", MySqlDbType.Int32);
                        MySqlParameter param_statusMessage = cmd.Parameters.Add("o_statusMessage", MySqlDbType.String);
                        param_avaetime.Value = ap.AppPara.Avgtime;
                        param_morslotbegin.Value = ap.AppPara.MorinigScheduleBegin;
                        param_morslotend.Value = ap.AppPara.MorningScheduleEnds;
                        param_afnsslotbegin.Value = ap.AppPara.AfternoonScheduleBegins;
                        param_afnsends.Value = ap.AppPara.AfternoonSCheduleEnds;
                        param_offday.Value = ap.AppPara.Offday;
                        param_datefrom.Value = ap.AppPara.Datefrom;
                        param_dateto.Value = ap.AppPara.Dateto;
                        param_cityname.Value = ap.AppPara.CityName;
                        param_outcity.Value = ap.AppPara.Outcity;
                        param_status.Direction = System.Data.ParameterDirection.InputOutput;
                        param_statusMessage.Direction = System.Data.ParameterDirection.InputOutput;
                        param_transaction.Value = 1;
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            o_status = Convert.ToInt32(param_status.Value);
                            o_statusMessage = Convert.ToString(param_statusMessage.Value);
                            if (o_status == 0)
                            {
                                success = true;
                                while (dr.Read())
                                {
                                    clientID = dr.GetInt32(0);
                                }
                            }
                            else
                            {
                                success = false;
                                clientID = 0;
                            }
                        }
                    }
                    conn.Close();

                }
            }
            catch (MySqlException ex)
            {
                o_status = 1;
                o_statusMessage = ex.Message;
                success = false;
                clientID = 0;
            }
            return clientID;
            #endregion
        }
        #endregion
        #region Update Appoinments
        public int updateappoinments(Param ap, out int o_status, out string o_statusMessage, int in_transaction)
        {
            #region Register User
            bool success = false;
            int clientID = 0;
            try
            {
                //( IN time, IN  time, IN  time, IN  int, IN  datetime, IN  datetime, IN  varchar(255),IN  varchar(255),INOUT o_status int, INOUT o_statusMessage varchar(255),IN in_transaction int)

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("admin_updateappparam", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        MySqlParameter param_avaetime = cmd.Parameters.Add("in_aveTime", MySqlDbType.Int32);
                        MySqlParameter param_morslotbegin = cmd.Parameters.Add("in_morslotbegin", MySqlDbType.Time);
                        MySqlParameter param_morslotend = cmd.Parameters.Add("in_morslotend ", MySqlDbType.Time);
                        MySqlParameter param_afnsslotbegin = cmd.Parameters.Add("in_afnslotbegin", MySqlDbType.String);
                        MySqlParameter param_afnsends = cmd.Parameters.Add("in_afnslotend ", MySqlDbType.Time);
                        MySqlParameter param_offday = cmd.Parameters.Add("in_offday", MySqlDbType.Int32);
                        MySqlParameter param_datefrom = cmd.Parameters.Add("in_datefrom", MySqlDbType.DateTime);
                        MySqlParameter param_dateto = cmd.Parameters.Add("in_dateto", MySqlDbType.DateTime);
                        MySqlParameter param_cityname = cmd.Parameters.Add("in_cityname", MySqlDbType.String);
                        MySqlParameter param_outcity = cmd.Parameters.Add("in_datefrom", MySqlDbType.DateTime);
                        MySqlParameter param_transaction = cmd.Parameters.Add("in_transaction", MySqlDbType.Int32);
                        MySqlParameter param_status = cmd.Parameters.Add("o_status", MySqlDbType.Int32);
                        MySqlParameter param_statusMessage = cmd.Parameters.Add("o_statusMessage", MySqlDbType.String);
                        param_avaetime.Value = ap.AppPara.Avgtime;
                        param_morslotbegin.Value = ap.AppPara.MorinigScheduleBegin;
                        param_morslotend.Value = ap.AppPara.MorningScheduleEnds;
                        param_afnsslotbegin.Value = ap.AppPara.AfternoonScheduleBegins;
                        param_afnsends.Value = ap.AppPara.AfternoonSCheduleEnds;
                        param_offday.Value = ap.AppPara.Offday;
                        param_datefrom.Value = ap.AppPara.Datefrom;
                        param_dateto.Value = ap.AppPara.Dateto;
                        param_cityname.Value = ap.AppPara.CityName;
                        param_outcity.Value = ap.AppPara.Outcity;
                        param_status.Direction = System.Data.ParameterDirection.InputOutput;
                        param_statusMessage.Direction = System.Data.ParameterDirection.InputOutput;
                        param_transaction.Value = 1;
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            o_status = Convert.ToInt32(param_status.Value);
                            o_statusMessage = Convert.ToString(param_statusMessage.Value);
                            if (o_status == 0)
                            {
                                success = true;
                                while (dr.Read())
                                {
                                    clientID = dr.GetInt32(0);
                                }
                            }
                            else
                            {
                                success = false;
                                clientID = 0;
                            }
                        }
                    }
                    conn.Close();

                }
            }
            catch (MySqlException ex)
            {
                o_status = 1;
                o_statusMessage = ex.Message;
                success = false;
                clientID = 0;
            }
            return clientID;
            #endregion
        }
        #endregion
        #region Insert/Update Basket
        public int Basket(Param bd, out int o_status, out string o_statusMessage, int in_transaction)
        {
            #region Register User
            bool success = false;
            int clientID = 0;
            try
            {
                //IN  int ,IN  int

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("gen_basket", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        MySqlParameter param_Userid = cmd.Parameters.Add("in_userid", MySqlDbType.Int32);
                        MySqlParameter param_Did = cmd.Parameters.Add("in_did", MySqlDbType.Int32);
                        MySqlParameter param_transaction = cmd.Parameters.Add("in_transaction", MySqlDbType.Int32);
                        MySqlParameter param_status = cmd.Parameters.Add("o_status", MySqlDbType.Int32);
                        MySqlParameter param_statusMessage = cmd.Parameters.Add("o_statusMessage", MySqlDbType.String);
                        param_Userid.Value = bd.BasketDetails.UserID;
                        param_Did.Value = bd.DeitTable.DeitID;
                        param_status.Direction = System.Data.ParameterDirection.InputOutput;
                        param_statusMessage.Direction = System.Data.ParameterDirection.InputOutput;
                        param_transaction.Value = 1;
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            o_status = Convert.ToInt32(param_status.Value);
                            o_statusMessage = Convert.ToString(param_statusMessage.Value);
                            if (o_status == 0)
                            {
                                success = true;
                                while (dr.Read())
                                {
                                    clientID = dr.GetInt32(0);
                                }
                            }
                            else
                            {
                                success = false;
                                clientID = 0;
                            }
                        }
                    }
                    conn.Close();

                }
            }
            catch (MySqlException ex)
            {
                o_status = 1;
                o_statusMessage = ex.Message;
                success = false;
                clientID = 0;
            }
            return clientID;
            #endregion
        }
        #endregion
        #region Get Payment Details
        public List<payment> getPaymentDetails(Param pd ,out int o_status, out string o_statusMessage, int in_transaction)
        {
            #region Get the List of Country
            List<payment> qList = new List<payment>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("gen_payment", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        MySqlParameter param_BasketID = cmd.Parameters.Add("in_bid", MySqlDbType.Int32);
                        MySqlParameter param_transaction = cmd.Parameters.Add("in_transaction", MySqlDbType.Int32);
                        MySqlParameter param_status = cmd.Parameters.Add("o_status", MySqlDbType.Int32);
                        MySqlParameter param_statusMessage = cmd.Parameters.Add("o_statusMessage", MySqlDbType.String);
                        param_BasketID.Value = pd.PaymentDetails.BasketID;
                        param_status.Direction = System.Data.ParameterDirection.InputOutput;
                        param_statusMessage.Direction = System.Data.ParameterDirection.InputOutput;
                        param_transaction.Value = in_transaction;
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            o_status = Convert.ToInt32(param_status.Value);
                            o_statusMessage = Convert.ToString(param_statusMessage.Value);
                            while (dr.Read())
                            {
                                payment ct1 = new payment();
                                ct1.BasketID = dr.GetInt32(0);
                                ct1.PaymentId = dr.GetInt32(1);
                                ct1.PaymentDate = dr.GetDateTime(2);
                                ct1.PaymentReference = dr.GetInt32(3);
                                qList.Add(ct1);
                            }
                            dr.Close();
                        }
                    }
                    conn.Close();

                }
            }
            catch (MySqlException ex)
            {
                o_status = 1;
                o_statusMessage = ex.Message;
                qList = new List<payment>();
            }
            return qList;
            #endregion
        }
        #endregion
        #region User selection
        public int UserSelection(Param us, out int o_status, out string o_statusMessage, int in_transaction)
        {
            #region User Selection
            bool success = false;
            int val = 0;
            try
            {
                //IN  int ,IN  int

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("gen_userselection", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        MySqlParameter param_Userid = cmd.Parameters.Add("in_userid", MySqlDbType.Int32);
                        MySqlParameter param_Did = cmd.Parameters.Add("in_did", MySqlDbType.Int32);
                        MySqlParameter param_transaction = cmd.Parameters.Add("in_transaction", MySqlDbType.Int32);
                        MySqlParameter param_status = cmd.Parameters.Add("o_status", MySqlDbType.Int32);
                        MySqlParameter param_statusMessage = cmd.Parameters.Add("o_statusMessage", MySqlDbType.String);
                        param_Userid.Value = us.Userselection.UserID;
                        param_Did.Value = us.Userselection.DeitID;
                        param_status.Direction = System.Data.ParameterDirection.InputOutput;
                        param_statusMessage.Direction = System.Data.ParameterDirection.InputOutput;
                        param_transaction.Value = 1;
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            o_status = Convert.ToInt32(param_status.Value);
                            o_statusMessage = Convert.ToString(param_statusMessage.Value);
                                success = true;
                            while (dr.Read())
                            {
                                val = dr.GetInt32(0);
                            }
                            
                        }
                    }
                    conn.Close();

                }
            }
            catch (MySqlException ex)
            {
                o_status = 1;
                o_statusMessage = ex.Message;
                success = false;
                val = 0;
            }
            return val;
            #endregion
        }
        #endregion
        #region Get Deit Details
        public List<DeitTable> getDeitDetails( out int o_status, out string o_statusMessage, int in_transaction)
        {
            #region Get the List of Deit
            List<DeitTable> qList = new List<DeitTable>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("user_getdietsavailable", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        MySqlParameter param_transaction = cmd.Parameters.Add("in_transaction", MySqlDbType.Int32);
                        MySqlParameter param_status = cmd.Parameters.Add("o_status", MySqlDbType.Int32);
                        MySqlParameter param_statusMessage = cmd.Parameters.Add("o_statusMessage", MySqlDbType.String);                        
                        param_status.Direction = System.Data.ParameterDirection.InputOutput;
                        param_statusMessage.Direction = System.Data.ParameterDirection.InputOutput;
                        param_transaction.Value = in_transaction;
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            o_status = Convert.ToInt32(param_status.Value);
                            o_statusMessage = Convert.ToString(param_statusMessage.Value);
                            while (dr.Read())
                            {
                                DeitTable ct1 = new DeitTable();
                                ct1.DeitID = dr.GetInt32(0);
                                ct1.Type = dr.GetInt32(1);
                                ct1.DeitSummary = dr.GetString(2);
                                ct1.Princing = dr.GetString(3);
                                ct1.TrialPeriod = dr.GetInt32(4);
                                ct1.DietName = dr.GetString(5);
                                qList.Add(ct1);
                            }
                            dr.Close();
                        }
                    }
                    conn.Close();

                }
            }
            catch (MySqlException ex)
            {
                o_status = 1;
                o_statusMessage = ex.Message;
                qList = new List<DeitTable>();
            }
            return qList;
            #endregion
        }
        #endregion
        #region Update Deit Details
        public int UpdateDeitDetails(Param dt, out int o_status, out string o_statusMessage, int in_transaction)
        {
            #region Update Deit Details
            bool success = false;
            int clientID = 0;
            try
            {
                //IN  int ,IN  int

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("gen_updateDeit", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;                        
                        MySqlParameter param_Did = cmd.Parameters.Add("in_did", MySqlDbType.Int32);
                        MySqlParameter param_DietContent = cmd.Parameters.Add("in_dietcontent", MySqlDbType.VarChar);
                        MySqlParameter param_DietName = cmd.Parameters.Add("in_dietname", MySqlDbType.VarChar);
                        MySqlParameter param_DietPrice = cmd.Parameters.Add("in_dietprice", MySqlDbType.VarChar);
                        MySqlParameter param_DietTrialPeriod = cmd.Parameters.Add("in_diettrialperiod", MySqlDbType.Int32);
                        MySqlParameter param_DietType = cmd.Parameters.Add("in_type", MySqlDbType.Int32);
                        MySqlParameter param_transaction = cmd.Parameters.Add("in_transaction", MySqlDbType.Int32);
                        MySqlParameter param_status = cmd.Parameters.Add("o_status", MySqlDbType.Int32);
                        MySqlParameter param_statusMessage = cmd.Parameters.Add("o_statusMessage", MySqlDbType.String);
                        param_Did.Value = dt.DeitTable.DeittypeID;
                        param_DietContent.Value = dt.DeitTable.DeitSummary;
                        param_DietName.Value = dt.DeitTable.DietName;
                        param_DietPrice.Value = dt.DeitTable.Princing;
                        param_DietTrialPeriod.Value = dt.DeitTable.TrialPeriod;
                        param_DietType.Value = dt.DeitTable.Type;
                        param_status.Direction = System.Data.ParameterDirection.InputOutput;
                        param_statusMessage.Direction = System.Data.ParameterDirection.InputOutput;
                        param_transaction.Value = 1;
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            o_status = Convert.ToInt32(param_status.Value);
                            o_statusMessage = Convert.ToString(param_statusMessage.Value);
                            if (o_status == 0)
                            {
                                success = true;
                                while (dr.Read())
                                {
                                    clientID = dr.GetInt32(0);
                                }
                            }
                            else
                            {
                                success = false;
                                clientID = 0;
                            }
                        }
                    }
                    conn.Close();

                }
            }
            catch (MySqlException ex)
            {
                o_status = 1;
                o_statusMessage = ex.Message;
                success = false;
                clientID = 0;
            }
            return clientID;
            #endregion
        }
        #endregion
        #region Create Deit Details
        public int CreateDiet(Param dt, out int o_status, out string o_statusMessage, int in_transaction)
        {
            #region Update Deit Details
            bool success = false;
            int clientID = 0;
            try
            {
                //IN  int ,IN  int

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("admin_creatediet", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        MySqlParameter param_DietContent = cmd.Parameters.Add("in_dietcontent", MySqlDbType.VarChar);
                        MySqlParameter param_DietName = cmd.Parameters.Add("in_dietname", MySqlDbType.VarChar);
                        MySqlParameter param_DietPrice = cmd.Parameters.Add("in_dietprice", MySqlDbType.VarChar);
                        MySqlParameter param_DietTrialPeriod = cmd.Parameters.Add("in_diettrialperiod", MySqlDbType.Int32);
                        MySqlParameter param_DietType = cmd.Parameters.Add("in_type", MySqlDbType.Int32);
                        MySqlParameter param_transaction = cmd.Parameters.Add("in_transaction", MySqlDbType.Int32);
                        MySqlParameter param_status = cmd.Parameters.Add("o_status", MySqlDbType.Int32);
                        MySqlParameter param_statusMessage = cmd.Parameters.Add("o_statusMessage", MySqlDbType.String);
                        param_DietContent.Value = dt.DeitTable.DeitSummary;
                        param_DietName.Value = dt.DeitTable.DietName;
                        param_DietPrice.Value = dt.DeitTable.Princing;
                        param_DietTrialPeriod.Value = dt.DeitTable.TrialPeriod;
                        param_DietType.Value = dt.DeitTable.Type;
                        param_status.Direction = System.Data.ParameterDirection.InputOutput;
                        param_statusMessage.Direction = System.Data.ParameterDirection.InputOutput;
                        param_transaction.Value = 1;
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            o_status = Convert.ToInt32(param_status.Value);
                            o_statusMessage = Convert.ToString(param_statusMessage.Value);
                            if (o_status == 0)
                            {
                                success = true;
                                while (dr.Read())
                                {
                                    clientID = dr.GetInt32(0);
                                }
                            }
                            else
                            {
                                success = false;
                                clientID = 0;
                            }
                        }
                    }
                    conn.Close();

                }
            }
            catch (MySqlException ex)
            {
                o_status = 1;
                o_statusMessage = ex.Message;
                success = false;
                clientID = 0;
            }
            return clientID;
            #endregion
        }
        #endregion
        #region Delete Deit Details
        public int DeleteDiet(Param dt, out int o_status, out string o_statusMessage, int in_transaction)
        {
            #region Update Deit Details
            bool success = false;
            int clientID = 0;
            try
            {
                //IN  int ,IN  int

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("admin_deletediet", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        MySqlParameter param_Did = cmd.Parameters.Add("in_did", MySqlDbType.Int32);
                        MySqlParameter param_transaction = cmd.Parameters.Add("in_transaction", MySqlDbType.Int32);
                        MySqlParameter param_status = cmd.Parameters.Add("o_status", MySqlDbType.Int32);
                        MySqlParameter param_statusMessage = cmd.Parameters.Add("o_statusMessage", MySqlDbType.String);
                        param_Did.Value = dt.DeitTable.DeittypeID;
                        param_status.Direction = System.Data.ParameterDirection.InputOutput;
                        param_statusMessage.Direction = System.Data.ParameterDirection.InputOutput;
                        param_transaction.Value = 1;
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            o_status = Convert.ToInt32(param_status.Value);
                            o_statusMessage = Convert.ToString(param_statusMessage.Value);
                            if (o_status == 0)
                            {
                                success = true;
                                while (dr.Read())
                                {
                                    clientID = dr.GetInt32(0);
                                }
                            }
                            else
                            {
                                success = false;
                                clientID = 0;
                            }
                        }
                    }
                    conn.Close();

                }
            }
            catch (MySqlException ex)
            {
                o_status = 1;
                o_statusMessage = ex.Message;
                success = false;
                clientID = 0;
            }
            return clientID;
            #endregion
        }
        #endregion
        #region Get Local Appoinmets 
        public List<appparam> getlocalappparameter(Param cd ,out int o_status, out string o_statusMessage, int in_transaction)
        {
            #region Get the List of Country
            List<appparam> qList = new List<appparam>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("user_getlocalappoinmentslots", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        MySqlParameter param_cityname = cmd.Parameters.Add("in_cityname", MySqlDbType.String);
                        MySqlParameter param_transaction = cmd.Parameters.Add("in_transaction", MySqlDbType.Int32);
                        MySqlParameter param_status = cmd.Parameters.Add("o_status", MySqlDbType.Int32);
                        MySqlParameter param_statusMessage = cmd.Parameters.Add("o_statusMessage", MySqlDbType.String);
                        param_cityname.Value = cd.CityDetails.CityName;
                        param_status.Direction = System.Data.ParameterDirection.InputOutput;
                        param_statusMessage.Direction = System.Data.ParameterDirection.InputOutput;
                        param_transaction.Value = in_transaction;
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            o_status = Convert.ToInt32(param_status.Value);
                            o_statusMessage = Convert.ToString(param_statusMessage.Value);
                            while (dr.Read())
                            {
                                appparam ct1 = new appparam();
                                ct1.AppparamID = dr.GetInt32(0);
                                ct1.Offday = dr.GetInt32(1);
                                ct1.MorinigScheduleBegin = dr.GetDateTime(2);
                                ct1.MorningScheduleEnds = dr.GetDateTime(3);
                                ct1.AfternoonScheduleBegins = dr.GetDateTime(4);
                                ct1.AfternoonSCheduleEnds = dr.GetDateTime(5);
                                ct1.Enabled = dr.GetInt32(6);
                                ct1.Avgtime = dr.GetInt32(7);
                                ct1.CID = dr.GetInt32(8);
                                ct1.CityID = dr.GetInt32(9);
                                ct1.CityName = dr.GetString(10);
                                ct1.Stateid = dr.GetInt32(11);
                                qList.Add(ct1);
                            }
                            dr.Close();
                        }
                    }
                    conn.Close();

                }
            }
            catch (MySqlException ex)
            {
                o_status = 1;
                o_statusMessage = ex.Message;
                qList = new List<appparam>();
            }
            return qList;
            #endregion
        }
        #endregion
        #region Get Out City Appoinmets 
        public List<appparam> getoutcityappparameter(Param cd, out int o_status, out string o_statusMessage, int in_transaction)
        {
            #region Get the List of Country
            List<appparam> qList = new List<appparam>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("user_getoutstationappoinmentslots", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        MySqlParameter param_cityname = cmd.Parameters.Add("in_cityname", MySqlDbType.String);
                        MySqlParameter param_transaction = cmd.Parameters.Add("in_transaction", MySqlDbType.Int32);
                        MySqlParameter param_status = cmd.Parameters.Add("o_status", MySqlDbType.Int32);
                        MySqlParameter param_statusMessage = cmd.Parameters.Add("o_statusMessage", MySqlDbType.String);
                        param_cityname.Value = cd.CityDetails.CityName;
                        param_status.Direction = System.Data.ParameterDirection.InputOutput;
                        param_statusMessage.Direction = System.Data.ParameterDirection.InputOutput;
                        param_transaction.Value = in_transaction;
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            o_status = Convert.ToInt32(param_status.Value);
                            o_statusMessage = Convert.ToString(param_statusMessage.Value);
                            while (dr.Read())
                            {
                                appparam ct1 = new appparam();
                                ct1.AppParamID = dr.GetInt32(0);
                                ct1.Offday = dr.GetInt32(1);
                                ct1.MorinigScheduleBegin = dr.GetDateTime(2);
                                ct1.MorningScheduleEnds = dr.GetDateTime(3);
                                ct1.AfternoonScheduleBegins = dr.GetDateTime(4);
                                ct1.AfternoonSCheduleEnds = dr.GetDateTime(5);
                                ct1.Enabled = dr.GetInt32(6);
                                ct1.Avgtime = dr.GetInt32(7);
                                ct1.CID = dr.GetInt32(8);
                                ct1.CityID = dr.GetInt32(9);
                                ct1.CityName = dr.GetString(10);
                                ct1.Stateid = dr.GetInt32(11);
                                ct1.AppparamID = dr.GetInt32(12);
                                ct1.Datefrom = dr.GetDateTime(13);
                                ct1.Dateto = dr.GetDateTime(14);
                                qList.Add(ct1);
                            }
                            dr.Close();
                        }
                    }
                    conn.Close();

                }
            }
            catch (MySqlException ex)
            {
                o_status = 1;
                o_statusMessage = ex.Message;
                qList = new List<appparam>();
            }
            return qList;
            #endregion
        }
        #endregion
        #region Get User Details
        public List<User> getuserdetails(Param ud, out int o_status, out string o_statusMessage, int in_transaction)
        {
            #region Get the List of Country
            List<User> qList = new List<User>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("user_getUserDetail", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        MySqlParameter param_username = cmd.Parameters.Add("in_email", MySqlDbType.VarChar);
                        MySqlParameter param_transaction = cmd.Parameters.Add("in_transaction", MySqlDbType.Int32);
                        MySqlParameter param_status = cmd.Parameters.Add("o_status", MySqlDbType.Int32);
                        MySqlParameter param_statusMessage = cmd.Parameters.Add("o_statusMessage", MySqlDbType.String);
                        param_username.Value = ud.UserDetail.Username;
                        param_status.Direction = System.Data.ParameterDirection.InputOutput;
                        param_statusMessage.Direction = System.Data.ParameterDirection.InputOutput;
                        param_transaction.Value = in_transaction;
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            o_status = Convert.ToInt32(param_status.Value);
                            o_statusMessage = Convert.ToString(param_statusMessage.Value);
                            while (dr.Read())
                            {
                                User ct1 = new User();
                                ct1.UserID = dr.GetInt32(0);
                                ct1.Name = dr.GetString(1);
                                ct1.Sex = dr.GetInt16(2);
                                ct1.DOB = dr.GetDateTime(3);                                
                                ct1.Height = dr.GetInt32(4);
                                ct1.Weight = dr.GetInt32(5);
                                ct1.Username = dr.GetString(6);
                                ct1.Password = dr.GetString(7);
                                qList.Add(ct1);
                            }
                            dr.Close();
                        }
                    }
                    conn.Close();

                }
            }
            catch (MySqlException ex)
            {
                o_status = 1;
                o_statusMessage = ex.Message;
                qList = new List<User>();
            }
            return qList;
            #endregion
        }
        #endregion
        #region Get User address
        public List<address> getuseraddress(Param ad, out int o_status, out string o_statusMessage, int in_transaction)
        {
            #region Get the List of Country
            List<address> qList = new List<address>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("user_getUseraddress", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        MySqlParameter param_userid = cmd.Parameters.Add("in_userID", MySqlDbType.Int32);
                        MySqlParameter param_addressid = cmd.Parameters.Add("in_adressid", MySqlDbType.Int32);
                        MySqlParameter param_transaction = cmd.Parameters.Add("in_transaction", MySqlDbType.Int32);
                        MySqlParameter param_status = cmd.Parameters.Add("o_status", MySqlDbType.Int32);
                        MySqlParameter param_statusMessage = cmd.Parameters.Add("o_statusMessage", MySqlDbType.String);
                        param_userid.Value = ad.UserDetail.UserID;
                        param_addressid.Value = ad.AddressDetails.AddressID;
                        param_status.Direction = System.Data.ParameterDirection.InputOutput;
                        param_statusMessage.Direction = System.Data.ParameterDirection.InputOutput;
                        param_transaction.Value = in_transaction;
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            o_status = Convert.ToInt32(param_status.Value);
                            o_statusMessage = Convert.ToString(param_statusMessage.Value);
                            while (dr.Read())
                            {
                                address ct1 = new address();
                                ct1.UserID = dr.GetInt32(0);
                                ct1.Add1 = dr.GetString(1);
                                ct1.Add2 = dr.GetString(2);
                                ct1.CityName = dr.GetString(3);
                                ct1.Statename = dr.GetString(4);
                                ct1.CountryName = dr.GetString(5);
                                qList.Add(ct1);
                            }
                            dr.Close();
                        }
                    }
                    conn.Close();

                }
            }
            catch (MySqlException ex)
            {
                o_status = 1;
                o_statusMessage = ex.Message;
                qList = new List<address>();
            }
            return qList;
            #endregion
        }
        #endregion
        #region Insert User Address
        public int registerUseraddress(Param ad, out int o_status, out string o_statusMessage, int in_transaction)
        {
            #region 
            bool success = false;
            int clientID = 0;
            try
            {
                //IN in_weight int, INOUT o_status int, INOUT o_statusMessage varchar(255),IN in_transaction INT)
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("user_insertuseraddress", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        MySqlParameter param_userid = cmd.Parameters.Add("in_userID", MySqlDbType.Int32);
                        MySqlParameter param_add1 = cmd.Parameters.Add("in_add1", MySqlDbType.VarChar);
                        MySqlParameter param_add2 = cmd.Parameters.Add("in_add2", MySqlDbType.VarChar);
                        MySqlParameter param_cityid = cmd.Parameters.Add("in_cityid", MySqlDbType.Int32);
                        MySqlParameter param_transaction = cmd.Parameters.Add("in_transaction", MySqlDbType.Int32);
                        MySqlParameter param_status = cmd.Parameters.Add("o_status", MySqlDbType.Int32);
                        MySqlParameter param_statusMessage = cmd.Parameters.Add("o_statusMessage", MySqlDbType.String);
                        param_userid.Value = ad.AddressDetails.UserID;
                        param_add1.Value = ad.AddressDetails.Add1;
                        param_add2.Value = ad.AddressDetails.Add2;
                        param_cityid.Value = ad.AddressDetails.CityID;
                        param_status.Direction = System.Data.ParameterDirection.InputOutput;
                        param_statusMessage.Direction = System.Data.ParameterDirection.InputOutput;
                        param_transaction.Value = 1;
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            o_status = Convert.ToInt32(param_status.Value);
                            o_statusMessage = Convert.ToString(param_statusMessage.Value);
                            if (o_status == 0)
                            {
                                success = true;
                                while (dr.Read())
                                {
                                    clientID = dr.GetInt32(0);
                                }
                            }
                            else
                            {
                                success = false;
                                clientID = 0;
                            }
                        }
                    }
                    conn.Close();

                }
            }
            catch (MySqlException ex)
            {
                o_status = 1;
                o_statusMessage = ex.Message;
                success = false;
                clientID = 0;
            }
            return clientID;
            #endregion
        }
        #endregion
        #region Get Contact Details
        public List<Contact> getusercontact(Param cd, out int o_status, out string o_statusMessage, int in_transaction)
        {
            #region Get the List of Country
            List<Contact> qList = new List<Contact>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("user_getUsercontact", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        MySqlParameter param_userid = cmd.Parameters.Add("in_userID", MySqlDbType.Int32);
                        MySqlParameter param_transaction = cmd.Parameters.Add("in_transaction", MySqlDbType.Int32);
                        MySqlParameter param_status = cmd.Parameters.Add("o_status", MySqlDbType.Int32);
                        MySqlParameter param_statusMessage = cmd.Parameters.Add("o_statusMessage", MySqlDbType.String);
                        param_userid.Value = cd.ContactDetails.UserID;
                        param_status.Direction = System.Data.ParameterDirection.InputOutput;
                        param_statusMessage.Direction = System.Data.ParameterDirection.InputOutput;
                        param_transaction.Value = in_transaction;
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            o_status = Convert.ToInt32(param_status.Value);
                            o_statusMessage = Convert.ToString(param_statusMessage.Value);
                            while (dr.Read())
                            {
                                Contact ct1 = new Contact();
                                ct1.ContactId = dr.GetInt32(0);
                                ct1.UserID = dr.GetInt32(1);
                                ct1.MobileNo = dr.GetString(2);
                                ct1.Email = dr.GetString(3);
                                qList.Add(ct1);
                            }
                            dr.Close();
                        }
                    }
                    conn.Close();

                }
            }
            catch (MySqlException ex)
            {
                o_status = 1;
                o_statusMessage = ex.Message;
                qList = new List<Contact>();
            }
            return qList;
            #endregion
        }
        #endregion
        #region Insert User Contact
        public int registerUsercontact(Param cd, out int o_status, out string o_statusMessage, int in_transaction)
        {
            #region 
            bool success = false;
            int clientID = 0;
            try
            {
                //IN in_weight int, INOUT o_status int, INOUT o_statusMessage varchar(255),IN in_transaction INT)
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("user_insertusercontact", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        MySqlParameter param_userid = cmd.Parameters.Add("in_userID", MySqlDbType.Int32);
                        MySqlParameter param_mobile = cmd.Parameters.Add("in_mobile", MySqlDbType.VarChar);
                        MySqlParameter param_email = cmd.Parameters.Add("in_email", MySqlDbType.VarChar);
                        MySqlParameter param_transaction = cmd.Parameters.Add("in_transaction", MySqlDbType.Int32);
                        MySqlParameter param_status = cmd.Parameters.Add("o_status", MySqlDbType.Int32);
                        MySqlParameter param_statusMessage = cmd.Parameters.Add("o_statusMessage", MySqlDbType.String);
                        param_userid.Value = cd.ContactDetails.UserID;
                        param_mobile.Value = cd.ContactDetails.MobileNo;
                        param_email.Value = cd.ContactDetails.Email;
                        param_status.Direction = System.Data.ParameterDirection.InputOutput;
                        param_statusMessage.Direction = System.Data.ParameterDirection.InputOutput;
                        param_transaction.Value = 1;
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            o_status = Convert.ToInt32(param_status.Value);
                            o_statusMessage = Convert.ToString(param_statusMessage.Value);
                            if (o_status == 0)
                            {
                                success = true;
                                while (dr.Read())
                                {

                                    clientID = dr.GetInt32(0);
                                }
                            }
                            else
                            {
                                success = false;
                                clientID = 0;
                            }
                        }
                    }
                    conn.Close();

                }
            }
            catch (MySqlException ex)
            {
                o_status = 1;
                o_statusMessage = ex.Message;
                success = false;
                clientID = 0;
            }
            return clientID;
            #endregion
        }
        #endregion
        #region Update Contact
        public int updateContact(Param cd, out int o_status, out string o_statusMessage, int in_transaction)
        {
            #region Register User
            bool success = false;
            int clientID = 0;
            try
            {
                //( IN time, IN  time, IN  time, IN  int, IN  datetime, IN  datetime, IN  varchar(255),IN  varchar(255),INOUT o_status int, INOUT o_statusMessage varchar(255),IN in_transaction int)

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("admin_updateappparam", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        MySqlParameter param_userid = cmd.Parameters.Add("in_userid", MySqlDbType.Int32);
                        MySqlParameter param_Mobile = cmd.Parameters.Add("in_mobile", MySqlDbType.String);
                        MySqlParameter param_email = cmd.Parameters.Add("in_email", MySqlDbType.String);
                        MySqlParameter param_transaction = cmd.Parameters.Add("in_transaction", MySqlDbType.Int32);
                        MySqlParameter param_status = cmd.Parameters.Add("o_status", MySqlDbType.Int32);
                        MySqlParameter param_statusMessage = cmd.Parameters.Add("o_statusMessage", MySqlDbType.String);
                        param_userid.Value = cd.ContactDetails.UserID;
                        param_Mobile.Value = cd.ContactDetails.MobileNo;
                        param_email.Value = cd.ContactDetails.Email;
                        param_status.Direction = System.Data.ParameterDirection.InputOutput;
                        param_statusMessage.Direction = System.Data.ParameterDirection.InputOutput;
                        param_transaction.Value = 1;
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            o_status = Convert.ToInt32(param_status.Value);
                            o_statusMessage = Convert.ToString(param_statusMessage.Value);
                            if (o_status == 0)
                            {
                                success = true;
                                while (dr.Read())
                                {
                                    clientID = dr.GetInt32(0);
                                }
                            }
                            else
                            {
                                success = false;
                                clientID = 0;
                            }
                        }
                    }
                    conn.Close();

                }
            }
            catch (MySqlException ex)
            {
                o_status = 1;
                o_statusMessage = ex.Message;
                success = false;
                clientID = 0;
            }
            return clientID;
            #endregion
        }
        #endregion
        #region Get User Interest
        public List<Services> getuserinterest(Param sd, out int o_status, out string o_statusMessage, int in_transaction)
        {
            #region Get the List of Country
            List<Services> qList = new List<Services>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("user_getUserinterest", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        MySqlParameter param_userid = cmd.Parameters.Add("in_userID", MySqlDbType.Int32);
                        MySqlParameter param_transaction = cmd.Parameters.Add("in_transaction", MySqlDbType.Int32);
                        MySqlParameter param_status = cmd.Parameters.Add("o_status", MySqlDbType.Int32);
                        MySqlParameter param_statusMessage = cmd.Parameters.Add("o_statusMessage", MySqlDbType.String);
                        param_userid.Value = sd.ServiceDetails.UserID;
                        param_status.Direction = System.Data.ParameterDirection.InputOutput;
                        param_statusMessage.Direction = System.Data.ParameterDirection.InputOutput;
                        param_transaction.Value = in_transaction;
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            o_status = Convert.ToInt32(param_status.Value);
                            o_statusMessage = Convert.ToString(param_statusMessage.Value);
                            while (dr.Read())
                            {
                                Services ct1 = new Services();
                                ct1.UserID = dr.GetInt32(0);
                                ct1.CategoryName = dr.GetString(1);
                                
                                qList.Add(ct1);
                            }
                            dr.Close();
                        }
                    }
                    conn.Close();

                }
            }
            catch (MySqlException ex)
            {
                o_status = 1;
                o_statusMessage = ex.Message;
                qList = new List<Services>();
            }
            return qList;
            #endregion
        }
        #endregion
        #region Get User Disease
        public List<Disease> getuserDisease(Param sd, out int o_status, out string o_statusMessage, int in_transaction)
        {
            #region Get the List of Country
            List<Disease> qList = new List<Disease>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("user_getuserdisease", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        MySqlParameter param_userid = cmd.Parameters.Add("in_userID", MySqlDbType.Int32);
                        MySqlParameter param_Diseaseid = cmd.Parameters.Add("in_diseaseid", MySqlDbType.Int32);
                        MySqlParameter param_transaction = cmd.Parameters.Add("in_transaction", MySqlDbType.Int32);
                        MySqlParameter param_status = cmd.Parameters.Add("o_status", MySqlDbType.Int32);
                        MySqlParameter param_statusMessage = cmd.Parameters.Add("o_statusMessage", MySqlDbType.String);
                        param_userid.Value = sd.Disease.UserID;
                        param_Diseaseid.Value = sd.Disease.DiseaseName;
                        param_status.Direction = System.Data.ParameterDirection.InputOutput;
                        param_statusMessage.Direction = System.Data.ParameterDirection.InputOutput;
                        param_transaction.Value = in_transaction;
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            o_status = Convert.ToInt32(param_status.Value);
                            o_statusMessage = Convert.ToString(param_statusMessage.Value);
                            while (dr.Read())
                            {
                                Disease ct1 = new Disease();
                                ct1.UserID = dr.GetInt32(0);
                                ct1.DiseaseName = dr.GetString(1);
                                qList.Add(ct1);
                            }
                            dr.Close();
                        }
                    }
                    conn.Close();

                }
            }
            catch (MySqlException ex)
            {
                o_status = 1;
                o_statusMessage = ex.Message;
                qList = new List<Disease>();
            }
            return qList;
            #endregion
        }
        #endregion
        #region update Username
        public int Updateusername(Param uc, out int o_status, out string o_statusMessage, int in_transaction)
        {
            #region Register User
            bool success = false;
            int clientID = 0;
            try
            {
                //IN in_weight int, INOUT o_status int, INOUT o_statusMessage varchar(255),IN in_transaction INT)
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("user_register", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        MySqlParameter param_newusername = cmd.Parameters.Add("in_newusername", MySqlDbType.String);
                        MySqlParameter param_userid = cmd.Parameters.Add("in_userid", MySqlDbType.Int16);
                        MySqlParameter param_transaction = cmd.Parameters.Add("in_transaction", MySqlDbType.Int32);
                        MySqlParameter param_status = cmd.Parameters.Add("o_status", MySqlDbType.Int32);
                        MySqlParameter param_statusMessage = cmd.Parameters.Add("o_statusMessage", MySqlDbType.String);
                        param_newusername.Value = uc.UserDetail.Username;
                        param_userid.Value = uc.UserDetail.UserID;
                        param_status.Direction = System.Data.ParameterDirection.InputOutput;
                        param_statusMessage.Direction = System.Data.ParameterDirection.InputOutput;
                        param_transaction.Value = 1;
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            o_status = Convert.ToInt32(param_status.Value);
                            o_statusMessage = Convert.ToString(param_statusMessage.Value);
                            if (o_status == 0)
                            {
                                success = true;
                                while (dr.Read())
                                {
                                    clientID = dr.GetInt32(0);
                                }
                            }
                            else
                            {
                                success = false;
                                clientID = 0;
                            }
                        }
                    }
                    conn.Close();

                }
            }
            catch (MySqlException ex)
            {
                o_status = 1;
                o_statusMessage = ex.Message;
                success = false;
                clientID = 0;
            }
            return clientID;
            #endregion
        }
        #endregion
        #region update Password
        public int Updatepassword(Param uc, out int o_status, out string o_statusMessage, int in_transaction)
        {
            #region Register User
            bool success = false;
            int clientID = 0;
            try
            {
                //IN in_weight int, INOUT o_status int, INOUT o_statusMessage varchar(255),IN in_transaction INT)
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("user_updatepassword", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        MySqlParameter param_newpassword = cmd.Parameters.Add("in_newpassword", MySqlDbType.String);
                        MySqlParameter param_userid = cmd.Parameters.Add("in_userid", MySqlDbType.Int16);
                        MySqlParameter param_transaction = cmd.Parameters.Add("in_transaction", MySqlDbType.Int32);
                        MySqlParameter param_status = cmd.Parameters.Add("o_status", MySqlDbType.Int32);
                        MySqlParameter param_statusMessage = cmd.Parameters.Add("o_statusMessage", MySqlDbType.String);
                        param_newpassword.Value = uc.UserDetail.Password;
                        param_userid.Value = uc.UserDetail.UserID;
                        param_status.Direction = System.Data.ParameterDirection.InputOutput;
                        param_statusMessage.Direction = System.Data.ParameterDirection.InputOutput;
                        param_transaction.Value = 1;
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            o_status = Convert.ToInt32(param_status.Value);
                            o_statusMessage = Convert.ToString(param_statusMessage.Value);
                            if (o_status == 0)
                            {
                                success = true;
                                while (dr.Read())
                                {
                                    clientID = dr.GetInt32(0);
                                }
                            }
                            else
                            {
                                success = false;
                                clientID = 0;
                            }
                        }
                    }
                    conn.Close();

                }
            }
            catch (MySqlException ex)
            {
                o_status = 1;
                o_statusMessage = ex.Message;
                success = false;
                clientID = 0;
            }
            return clientID;
            #endregion
        }
        #endregion
        #region Get Basket
        public List<Basket> getbasket(Param b, out int o_status, out string o_statusMessage, int in_transaction)
        {
            #region Get the List of Item in a Basket
            List<Basket> qList = new List<Basket>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("user_getbasket", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        MySqlParameter param_Userid = cmd.Parameters.Add("in_userid", MySqlDbType.Int32);
                        MySqlParameter param_transaction = cmd.Parameters.Add("in_transaction", MySqlDbType.Int32);
                        MySqlParameter param_status = cmd.Parameters.Add("o_status", MySqlDbType.Int32);
                        MySqlParameter param_statusMessage = cmd.Parameters.Add("o_statusMessage", MySqlDbType.String);
                        param_Userid.Value = b.BasketDetails.UserID;
                        param_status.Direction = System.Data.ParameterDirection.InputOutput;
                        param_statusMessage.Direction = System.Data.ParameterDirection.InputOutput;
                        param_transaction.Value = in_transaction;
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            o_status = Convert.ToInt32(param_status.Value);
                            o_statusMessage = Convert.ToString(param_statusMessage.Value);
                            while (dr.Read())
                            {
                                Basket ct1 = new Basket();
                                ct1.Dateofselection = dr.GetDateTime(0);
                                ct1.Didvalue = dr.GetInt32(1);
                                ct1.Taxvalue = dr.GetInt32(2);
                                ct1.Grossvalue = dr.GetInt32(3);
                                ct1.Summary = dr.GetString(4);
                                ct1.DName = dr.GetString(5);
                                ct1.TryPeriod = dr.GetString(6);
                                ct1.DietPrice = dr.GetString(7);
                                ct1.DietID = dr.GetInt32(8);
                                ct1.Type = dr.GetInt32(9);
                                qList.Add(ct1);
                            }
                            dr.Close();
                        }
                    }
                    conn.Close();

                }
            }
            catch (MySqlException ex)
            {
                o_status = 1;
                o_statusMessage = ex.Message;
                qList = new List<Basket>();
            }
            return qList;
            #endregion
        }
        #endregion
        #region Insert User Slots
        public int registeruserslots(Param ad, out int o_status, out string o_statusMessage, int in_transaction)
        {
            #region 
            bool success = false;
            int clientID = 0;
            try
            {
                //IN in_weight int, INOUT o_status int, INOUT o_statusMessage varchar(255),IN in_transaction INT)
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("user_insertslots", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        MySqlParameter param_userid = cmd.Parameters.Add("in_userid", MySqlDbType.Int32);
                        MySqlParameter param_Slots = cmd.Parameters.Add("in_slots", MySqlDbType.Time);
                        MySqlParameter param_transaction = cmd.Parameters.Add("in_transaction", MySqlDbType.Int32);
                        MySqlParameter param_status = cmd.Parameters.Add("o_status", MySqlDbType.Int32);
                        MySqlParameter param_statusMessage = cmd.Parameters.Add("o_statusMessage", MySqlDbType.String);
                        param_userid.Value = ad.UserApp.UserID;
                        param_Slots.Value = ad.UserApp.Slots;
                        param_status.Direction = System.Data.ParameterDirection.InputOutput;
                        param_statusMessage.Direction = System.Data.ParameterDirection.InputOutput;
                        param_transaction.Value = 1;
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            o_status = Convert.ToInt32(param_status.Value);
                            o_statusMessage = Convert.ToString(param_statusMessage.Value);
                            if (o_status == 0)
                            {
                                success = true;
                                while (dr.Read())
                                {
                                    clientID = dr.GetInt32(0);
                                }
                            }
                            else
                            {
                                success = false;
                                clientID = 0;
                            }
                        }
                    }
                    conn.Close();

                }
            }
            catch (MySqlException ex)
            {
                o_status = 1;
                o_statusMessage = ex.Message;
                success = false;
                clientID = 0;
            }
            return clientID;
            #endregion
        }
        #endregion
        #region Check Slots
        public int checkslots(Param ad, out int o_status, out string o_statusMessage, int in_transaction)
        {
            #region 
            bool success = false;
            int clientID = 0;
            try
            {
                //IN in_weight int, INOUT o_status int, INOUT o_statusMessage varchar(255),IN in_transaction INT)
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("user_insertslots", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        MySqlParameter param_Slots = cmd.Parameters.Add("in_slots", MySqlDbType.Time);
                        MySqlParameter param_transaction = cmd.Parameters.Add("in_transaction", MySqlDbType.Int32);
                        MySqlParameter param_status = cmd.Parameters.Add("o_status", MySqlDbType.Int32);
                        MySqlParameter param_statusMessage = cmd.Parameters.Add("o_statusMessage", MySqlDbType.String);
                        param_Slots.Value = ad.UserApp.Slots;
                        param_status.Direction = System.Data.ParameterDirection.InputOutput;
                        param_statusMessage.Direction = System.Data.ParameterDirection.InputOutput;
                        param_transaction.Value = 1;
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            o_status = Convert.ToInt32(param_status.Value);
                            o_statusMessage = Convert.ToString(param_statusMessage.Value);
                            if (o_status == 0)
                            {
                                success = true;
                                while (dr.Read())
                                {
                                    clientID = dr.GetInt32(0);
                                }
                            }
                            else
                            {
                                success = false;
                                clientID = 0;
                            }
                        }
                    }
                    conn.Close();

                }
            }
            catch (MySqlException ex)
            {
                o_status = 1;
                o_statusMessage = ex.Message;
                success = false;
                clientID = 0;
            }
            return clientID;
            #endregion
        }
        #endregion
        #region Get State
        public List<state> getstate(Param p,out int o_status, out string o_statusMessage, int in_transaction)
        {
            #region Get the List of Country
            List<state> qList = new List<state>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("gen_getstates", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        MySqlParameter param_countryid = cmd.Parameters.Add("in_countryid ", MySqlDbType.Int32);
                        MySqlParameter param_transaction = cmd.Parameters.Add("in_transaction", MySqlDbType.Int32);
                        MySqlParameter param_status = cmd.Parameters.Add("o_status", MySqlDbType.Int32);
                        MySqlParameter param_statusMessage = cmd.Parameters.Add("o_statusMessage", MySqlDbType.String);
                        param_countryid.Value = p.CountryDetails.CountryID;
                        param_status.Direction = System.Data.ParameterDirection.InputOutput;
                        param_statusMessage.Direction = System.Data.ParameterDirection.InputOutput;
                        param_transaction.Value = in_transaction;
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            o_status = Convert.ToInt32(param_status.Value);
                            o_statusMessage = Convert.ToString(param_statusMessage.Value);
                            while (dr.Read())
                            {
                                state ct1 = new state();
                                ct1.Stateid= dr.GetInt32(0);
                                ct1.Statename = dr.GetString(1);
                                qList.Add(ct1);
                            }
                            dr.Close();
                        }
                    }
                    conn.Close();

                }
            }
            catch (MySqlException ex)
            {
                o_status = 1;
                o_statusMessage = ex.Message;
                qList = new List<state>();
            }
            return qList;
            #endregion
        }
        #endregion
        #region Get cities
        public List<city> getcity(Param p, out int o_status, out string o_statusMessage, int in_transaction)
        {
            #region Get the List of Country
            List<city> qList = new List<city>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("gen_getcity", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        MySqlParameter param_stateid = cmd.Parameters.Add("in_stateid ", MySqlDbType.Int32);
                        MySqlParameter param_transaction = cmd.Parameters.Add("in_transaction", MySqlDbType.Int32);
                        MySqlParameter param_status = cmd.Parameters.Add("o_status", MySqlDbType.Int32);
                        MySqlParameter param_statusMessage = cmd.Parameters.Add("o_statusMessage", MySqlDbType.String);
                        param_stateid.Value = p.StateDetails.Stateid;
                        param_status.Direction = System.Data.ParameterDirection.InputOutput;
                        param_statusMessage.Direction = System.Data.ParameterDirection.InputOutput;
                        param_transaction.Value = in_transaction;
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            o_status = Convert.ToInt32(param_status.Value);
                            o_statusMessage = Convert.ToString(param_statusMessage.Value);
                            while (dr.Read())
                            {
                                city ct1 = new city();
                                ct1.CID = dr.GetInt32(0);
                                ct1.CityName = dr.GetString(1);
                                qList.Add(ct1);
                            }
                            dr.Close();
                        }
                    }
                    conn.Close();

                }
            }
            catch (MySqlException ex)
            {
                o_status = 1;
                o_statusMessage = ex.Message;
                qList = new List<city>();
            }
            return qList;
            #endregion
        }
        #endregion
    }
}