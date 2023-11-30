using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSCI213Assignment4
{
    public partial class Logon : System.Web.UI.Page
    {
        KarateSchoolDataContext dbcon;
        //  string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Logan\\Source\\Repos\\CSCI213Assignment4-Logan-1-2\\App_Data\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";
        string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Logan\\source\\repos\\CSCI213Assignment4-Logan-1-2\\App_Data\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";

        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon = new KarateSchoolDataContext(connString);

            UnobtrusiveValidationMode =
            UnobtrusiveValidationMode.None;
        }

        protected void Login2_Authenticate(object sender, AuthenticateEventArgs e)
        {



        }

        protected void Login2_Authenticate1(object sender, AuthenticateEventArgs e)
        {

            string nUserName = Login2.UserName;

            string nPassword = Login2.Password;


            HttpContext.Current.Session["nUserName"] = nUserName;
            HttpContext.Current.Session["uPass"] = nPassword;



            // Search for the current User, validate UserName and Password
            NetUser myUser = (from x in dbcon.NetUsers
                              where x.UserName.Trim() == HttpContext.Current.Session["nUserName"].ToString().Trim()
                              && x.UserPassword.Trim() == HttpContext.Current.Session["uPass"].ToString().Trim()
                              select x).First();

            if (myUser != null)
            {
                //Add UserID and User type to the Session
                HttpContext.Current.Session["userID"] = myUser.UserID;
                HttpContext.Current.Session["userType"] = myUser.UserType;

            }
            if (myUser != null && HttpContext.Current.Session["userType"].ToString().Trim() == "Member")
            {

                FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.Session["nUserName"].ToString(), true);

                Response.Redirect("~/KarateMembers/memberpage.aspx");
            }
            else if (myUser != null && HttpContext.Current.Session["userType"].ToString().Trim() == "Instructor")
            {

                FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.Session["nUserName"].ToString(), true);

                Response.Redirect("~/KarateInstructors/Instructorpage.aspx");
            }
            else
                Response.Redirect("Logon.aspx", true);

        }
    }
}