using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using CourierServices.Models;
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Web;
using System.Net.Mail;
using System.Net;
using System.Threading;
using System.IO;

namespace CourierServices.Controllers
{
    public class AccountController : ApiController
    {
        //private const string LocalLoginProvider = "Local";

        public AccountController()
        {
        }

        #region insertRole
        [Route("api/Account/insertRole")]
        [HttpPost]
        public void insertRole(Role roleObj)
        {
            DataTable dt = new DataTable();
            string strSQL = "";
            using (MySqlConnection conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MasterMani"].ConnectionString))
            {
                try
                {                 
                    strSQL = "INSERT INTO role(RoleName,RoleDescription) VALUES(@RoleName,@RoleDescription)";
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(strSQL, conn);
                    //cmd.Parameters.AddWithValue("@UserId", new);
                    cmd.Parameters.AddWithValue("@RoleName", roleObj.RoleName);
                    cmd.Parameters.AddWithValue("@RoleDescription", roleObj.RoleDescription);
                  
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    // conn.Close();
                }


                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        #endregion

        #region insertDepartment
        [Route("api/Account/insertDepartment")]
        [HttpPost]
        public void insertDepartment(Department deptObj)
        {
            DataTable dt = new DataTable();
            string strSQL = "";
            using (MySqlConnection conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MasterMani"].ConnectionString))
            {
                try
                {
                    strSQL = "INSERT INTO department(DepartmentName,DepartmentDescription) VALUES(@DepartmentName,@DepartmentDescription)";
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(strSQL, conn);
                    //cmd.Parameters.AddWithValue("@UserId", new);
                    cmd.Parameters.AddWithValue("@DepartmentName", deptObj.DepartmentName);
                    cmd.Parameters.AddWithValue("@DepartmentDescription", deptObj.DepartmentDescription);

                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    // conn.Close();
                }


                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        #endregion


        #region insertNewUser
        [Route("api/Account/InsertNewUserCreation")]
        [HttpPost]
        public void InsertNewUserCreation(NewUser newUserDetails)
        {
            DataTable dt = new DataTable();
            string strSQL = "";
          //  int Id = -1;
            using (MySqlConnection conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MasterMani"].ConnectionString))
            {
                try
                {

                    
                        newUserDetails.CreatedDate = DateTime.Now;
                        newUserDetails.ModfiedDate = DateTime.Now;
                        strSQL = "INSERT INTO usernew(FirstName,LastName,UserName,Password,CreatedBy,CreatedDate,ModifiedBy,ModfiedDate,PhoneNo,Email,ActiveFlag,appFlag,RoleId,DeptId) VALUES(@FirstName,@LastName,@UserName,@Password,@CreatedBy,@CreatedDate,@ModifiedBy,@ModfiedDate,@PhoneNo,@Email,@ActiveFlag,@appFlag,@RoleId,@DeptId)";
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(strSQL, conn);
                        //cmd.Parameters.AddWithValue("@UserId", new);
                        cmd.Parameters.AddWithValue("@FirstName", newUserDetails.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", newUserDetails.LastName);
                        cmd.Parameters.AddWithValue("@UserName", newUserDetails.UserName);
                        cmd.Parameters.AddWithValue("@Password", newUserDetails.Password);
                        cmd.Parameters.AddWithValue("@CreatedBy", newUserDetails.cby);
                        cmd.Parameters.AddWithValue("@CreatedDate", newUserDetails.CreatedDate);
                        cmd.Parameters.AddWithValue("@ModifiedBy", newUserDetails.mby);
                        cmd.Parameters.AddWithValue("@ModfiedDate", newUserDetails.ModfiedDate);
                        cmd.Parameters.AddWithValue("@PhoneNo", newUserDetails.PhoneNo);
                        cmd.Parameters.AddWithValue("@Email", newUserDetails.Email);
                        cmd.Parameters.AddWithValue("@ActiveFlag", newUserDetails.activeflag);
                        cmd.Parameters.AddWithValue("@appFlag", newUserDetails.appFlag);
                        cmd.Parameters.AddWithValue("@RoleId", newUserDetails.RoleId);
                        cmd.Parameters.AddWithValue("@DeptId", newUserDetails.DepId);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                       // conn.Close();
                    }
                    
                
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        #endregion


        #region getDashboardUsers
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [Route("api/Account/getDashboardUsers")]
        [HttpGet]
        public int getDashboardUsers()
        {
            int newuser = 0;
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MasterMani"].ConnectionString))
            {
                try
                {                    
                    string strSQL = "SELECT Count(*) as userCount FROM usernew";
                    conn.Open();
                    MySqlDataAdapter mydata = new MySqlDataAdapter(strSQL, conn);
                    MySqlCommandBuilder cmd = new MySqlCommandBuilder(mydata);
                    DataSet ds = new DataSet();
                    mydata.Fill(ds);
                    dt = ds.Tables[0];
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr != null)
                        {                            
                            newuser = Convert.ToInt32(dr["userCount"]);                                                       
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
                return newuser;
            }
        }
        #endregion


        #region getTotalDepartment
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [Route("api/Account/getTotalDepartment")]
        [HttpGet]
        public int getTotalDepartment()
        {
            int depCount = 0;
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MasterMani"].ConnectionString))
            {
                try
                {
                    string strSQL = "SELECT SUM(DepartmentId) as depCount FROM department";
                    conn.Open();
                    MySqlDataAdapter mydata = new MySqlDataAdapter(strSQL, conn);
                    MySqlCommandBuilder cmd = new MySqlCommandBuilder(mydata);
                    DataSet ds = new DataSet();
                    mydata.Fill(ds);
                    dt = ds.Tables[0];
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr != null)
                        {
                            depCount = Convert.ToInt32(dr["depCount"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
                return depCount;
            }
        }
        #endregion





        //getunApprovedUserCount

        #region getunApprovedUserCount
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [Route("api/Account/getunApprovedUserCount")]
        [HttpGet]
        public int getunApprovedUserCount()
        {
            int userCount = 0;
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MasterMani"].ConnectionString))
            {
                try
                {
                    int appFlag = 0;
                    string strSQL = "SELECT Count(*) as userCount FROM usernew where appFlag='" + appFlag + "'";
                    conn.Open();
                    MySqlDataAdapter mydata = new MySqlDataAdapter(strSQL, conn);
                    MySqlCommandBuilder cmd = new MySqlCommandBuilder(mydata);
                    DataSet ds = new DataSet();
                    mydata.Fill(ds);
                    dt = ds.Tables[0];
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr != null)
                        {
                            userCount = Convert.ToInt32(dr["userCount"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
                return userCount;
            }
        }
        #endregion


        #region getAdminUserCount
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [Route("api/Account/getAdminUserCount")]
        [HttpGet]
        public int getAdminUserCount()
        {
            int userCount = 0;
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MasterMani"].ConnectionString))
            {
                try
                {
                    int RoleId = 1;
                    string strSQL = "SELECT SUM(RoleId) as userCount FROM usernew where RoleId='" + RoleId + "'";
                    conn.Open();
                    MySqlDataAdapter mydata = new MySqlDataAdapter(strSQL, conn);
                    MySqlCommandBuilder cmd = new MySqlCommandBuilder(mydata);
                    DataSet ds = new DataSet();
                    mydata.Fill(ds);
                    dt = ds.Tables[0];
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr != null)
                        {
                            userCount = Convert.ToInt32(dr["userCount"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
                return userCount;
            }
        }
        #endregion


        #region getAllApprovedUser
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [Route("api/Account/getAllApprovedUser")]
        [HttpGet]
        public List<NewUser> getAllApprovedUser()
        {
            List<NewUser> lstnewUser = new List<NewUser>();
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MasterMani"].ConnectionString))
            {
                try
                {
                    int activeFlag = 0;
                    int appFlag = 1;
                    string strSQL = "SELECT * FROM usernew where activeflag='"+ activeFlag + "' and appFlag='"+ appFlag + "'";
                    conn.Open();
                    MySqlDataAdapter mydata = new MySqlDataAdapter(strSQL, conn);
                    MySqlCommandBuilder cmd = new MySqlCommandBuilder(mydata);
                    DataSet ds = new DataSet();
                    mydata.Fill(ds);
                    dt = ds.Tables[0];
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr != null)
                        {
                            NewUser newuser = new NewUser();

                            newuser.UserId = Convert.ToInt32(dr["UserId"]);
                            newuser.FirstName = dr["FirstName"].ToString();
                            newuser.LastName = dr["LastName"].ToString();
                            newuser.UserName = dr["UserName"].ToString();
                            newuser.Password = dr["Password"].ToString();
                            newuser.cby = Convert.ToInt32(dr["CreatedBy"]);
                            newuser.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                            newuser.ModfiedDate = Convert.ToDateTime(dr["ModfiedDate"]);
                            newuser.PhoneNo = dr["PhoneNo"].ToString();
                            newuser.Email = dr["Email"].ToString();
                            newuser.activeflag = Convert.ToInt32(dr["activeflag"]);
                            newuser.appFlag = Convert.ToInt32(dr["appFlag"]);

                            lstnewUser.Add(newuser);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
                return lstnewUser;
            }
        }
        #endregion

        #region getAllUnApprovedUser
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [Route("api/Account/getAllUnApprovedUser")]
        [HttpGet]
        public List<NewUser> getAllUnApprovedUser()
        {
            List<NewUser> lstnewUser = new List<NewUser>();
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MasterMani"].ConnectionString))
            {
                try
                {
                    int activeFlag = 0;
                    int appFlag = 0;
                    string strSQL = "SELECT * FROM usernew where activeflag='" + activeFlag + "' and appFlag='" + appFlag + "'";
                    conn.Open();
                    MySqlDataAdapter mydata = new MySqlDataAdapter(strSQL, conn);
                    MySqlCommandBuilder cmd = new MySqlCommandBuilder(mydata);
                    DataSet ds = new DataSet();
                    mydata.Fill(ds);
                    dt = ds.Tables[0];
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr != null)
                        {
                            NewUser newuser = new NewUser();

                            newuser.UserId = Convert.ToInt32(dr["UserId"]);
                            newuser.FirstName = dr["FirstName"].ToString();
                            newuser.LastName = dr["LastName"].ToString();
                            newuser.UserName = dr["UserName"].ToString();
                            newuser.Password = dr["Password"].ToString();
                            newuser.cby = Convert.ToInt32(dr["CreatedBy"]);
                            newuser.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                            newuser.ModfiedDate = Convert.ToDateTime(dr["ModfiedDate"]);
                            newuser.PhoneNo = dr["PhoneNo"].ToString();
                            newuser.Email = dr["Email"].ToString();
                            newuser.activeflag = Convert.ToInt32(dr["activeflag"]);
                            newuser.appFlag = Convert.ToInt32(dr["appFlag"]);

                            lstnewUser.Add(newuser);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
                return lstnewUser;
            }
        }
        #endregion

        #region getAllDeactivatedUser
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [Route("api/Account/getAllDeactivatedUser")]
        [HttpGet]
        public List<NewUser> getAllDeactivatedUser()
        {
            List<NewUser> lstnewUser = new List<NewUser>();
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MasterMani"].ConnectionString))
            {
                try
                {
                    int activeFlag = 1;             
                    string strSQL = "SELECT * FROM usernew where activeflag='" + activeFlag + "'";
                    conn.Open();
                    MySqlDataAdapter mydata = new MySqlDataAdapter(strSQL, conn);
                    MySqlCommandBuilder cmd = new MySqlCommandBuilder(mydata);
                    DataSet ds = new DataSet();
                    mydata.Fill(ds);
                    dt = ds.Tables[0];
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr != null)
                        {
                            NewUser newuser = new NewUser();

                            newuser.UserId = Convert.ToInt32(dr["UserId"]);
                            newuser.FirstName = dr["FirstName"].ToString();
                            newuser.LastName = dr["LastName"].ToString();
                            newuser.UserName = dr["UserName"].ToString();
                            newuser.Password = dr["Password"].ToString();
                            newuser.cby = Convert.ToInt32(dr["CreatedBy"]);
                            newuser.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                            newuser.ModfiedDate = Convert.ToDateTime(dr["ModfiedDate"]);
                            newuser.PhoneNo = dr["PhoneNo"].ToString();
                            newuser.Email = dr["Email"].ToString();
                            newuser.activeflag = Convert.ToInt32(dr["activeflag"]);
                            newuser.appFlag = Convert.ToInt32(dr["appFlag"]);

                            lstnewUser.Add(newuser);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
                return lstnewUser;
            }
        }
        #endregion

        #region UpdateUserToApprove
        [Route("api/Account/UpdateUserToApprove")]
        [HttpPost]
        public void UpdateUserToApprove(NewUser userDetails)
        {
            DataTable dt = new DataTable();
            string strSQL = "";
             int flag = 1;
            using (MySqlConnection conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MasterMani"].ConnectionString))
            {
                try
                {                    
                    strSQL = "update usernew set appFlag='" + flag+ "' where UserId="+ userDetails.UserId;
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(strSQL, conn);                    
                    cmd.ExecuteNonQuery();
                    // conn.Close();
                }


                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        #endregion


        #region UpdateUserToUnApprove
        [Route("api/Account/UpdateUserToUnApprove")]
        [HttpPost]
        public void UpdateUserToUnApprove(NewUser userDetails)
        {
            DataTable dt = new DataTable();
            string strSQL = "";
             int flag = 0;
            using (MySqlConnection conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MasterMani"].ConnectionString))
            {
                try
                {
                    strSQL = "update usernew set appFlag='" + flag + "' where UserId=" + userDetails.UserId;
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(strSQL, conn);
                    cmd.ExecuteNonQuery();
                    // conn.Close();
                }


                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        #endregion

        #region DeactivateUser
        [Route("api/Account/DeactivateUser")]
        [HttpPost]
        public void DeactivateUser(NewUser userDetails)
        {
            DataTable dt = new DataTable();
            string strSQL = "";
              int flag = 1;
            using (MySqlConnection conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MasterMani"].ConnectionString))
            {
                try
                {
                    strSQL = "update usernew set activeflag='" + flag + "' where UserId=" + userDetails.UserId;
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(strSQL, conn);
                    cmd.ExecuteNonQuery();
                    // conn.Close();
                }


                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        #endregion


        #region ActivateUser
        [Route("api/Account/ActivateUser")]
        [HttpPost]
        public void ActivateUser(NewUser userDetails)
        {
            DataTable dt = new DataTable();
            string strSQL = "";
             int flag = 0;
            using (MySqlConnection conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MasterMani"].ConnectionString))
            {
                try
                {
                    strSQL = "update usernew set activeflag='" + flag + "' where UserId=" + userDetails.UserId;
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(strSQL, conn);
                    cmd.ExecuteNonQuery();
                    // conn.Close();
                }


                catch (Exception ex)
                {
                    Console.Write(ex);
                }
            }
        }

        #endregion

        #region getAllNewUser
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [Route("api/Account/getAllNewUser")]
        [HttpGet]
        public List<NewUser> getAllNewUser()
        {
            List<NewUser> lstnewUser = new List<NewUser>();
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MasterMani"].ConnectionString))
            {
                try
                {

                    string strSQL = "SELECT * FROM usernew";
                    conn.Open();
                    MySqlDataAdapter mydata = new MySqlDataAdapter(strSQL, conn);
                    MySqlCommandBuilder cmd = new MySqlCommandBuilder(mydata);
                    DataSet ds = new DataSet();
                    mydata.Fill(ds);
                    dt = ds.Tables[0];
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr != null)
                        {
                            NewUser newuser = new NewUser();

                            newuser.UserId = Convert.ToInt32(dr["UserId"]);
                            newuser.FirstName = dr["FirstName"].ToString();
                            newuser.LastName = dr["LastName"].ToString();
                            newuser.UserName = dr["UserName"].ToString();
                            newuser.Password = dr["Password"].ToString();
                            newuser.cby = Convert.ToInt32(dr["cby"]);
                            newuser.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);
                            newuser.ModfiedDate = Convert.ToDateTime(dr["ModfiedDate"]);
                            newuser.PhoneNo = dr["PhoneNo"].ToString();
                            newuser.Email = dr["Email"].ToString();
                            newuser.activeflag = Convert.ToInt32(dr["activeflag"]);
                            newuser.appFlag = Convert.ToInt32(dr["appFlag"]);

                            lstnewUser.Add(newuser);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
                return lstnewUser;
            }
        }
        #endregion

        #region getAllRole
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [Route("api/Account/getAllRole")]
        [HttpGet]
        public List<Role> getAllRole()
        {
            List<Role> lstRole = new List<Role>();
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MasterMani"].ConnectionString))
            {
                try
                {

                    string strSQL = "SELECT * FROM role";
                    conn.Open();
                    MySqlDataAdapter mydata = new MySqlDataAdapter(strSQL, conn);
                    MySqlCommandBuilder cmd = new MySqlCommandBuilder(mydata);
                    DataSet ds = new DataSet();
                    mydata.Fill(ds);
                    dt = ds.Tables[0];
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr != null)
                        {
                            Role addrole = new Role();

                            addrole.RoleId = Convert.ToInt32(dr["RoleId"]);
                            addrole.RoleDescription = dr["RoleDescription"].ToString();
                            addrole.RoleName = dr["RoleName"].ToString();
                            lstRole.Add(addrole);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
                return lstRole;
            }
        }
        #endregion

        #region getAllDepartment
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        [Route("api/Account/getAllDepartment")]
        [HttpGet]
        public List<Department> getAllDepartment()
        {
            List<Department> lstdept = new List<Department>();
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MasterMani"].ConnectionString))
            {
                try
                {

                    string strSQL = "SELECT * FROM department";
                    conn.Open();
                    MySqlDataAdapter mydata = new MySqlDataAdapter(strSQL, conn);
                    MySqlCommandBuilder cmd = new MySqlCommandBuilder(mydata);
                    DataSet ds = new DataSet();
                    mydata.Fill(ds);
                    dt = ds.Tables[0];
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr != null)
                        {
                            Department adddepartment = new Department();

                            adddepartment.DepartmentID = Convert.ToInt32(dr["DepartmentID"]);
                            adddepartment.DepartmentDescription = dr["DepartmentDescription"].ToString();
                            adddepartment.DepartmentName = dr["DepartmentName"].ToString();
                            lstdept.Add(adddepartment);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                }
                return lstdept;
            }
        }
        #endregion
    }
}

