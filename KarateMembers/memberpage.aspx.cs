using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSCI213Assignment4.KarateMembers
{
    public partial class memberpage : System.Web.UI.Page
    {
        KarateSchoolDataContext mydbcon;
        string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Logan\\Source\\Repos\\CSCI213Assignment4-Logan-1-2\\App_Data\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";

        protected void Page_Load(object sender, EventArgs e)
        {
            mydbcon = new KarateSchoolDataContext(connString);

            if (Session.Count != 0)
            {
                if (HttpContext.Current.Session["userType"].ToString().Trim() == "instructor")
                {
                    Session.Clear();
                    Session.RemoveAll();
                    Session.Abandon();
                    Session.Abandon();
                    FormsAuthentication.SignOut();
                    Response.Redirect("Logon.aspx", true);
                }

            }


            string myUserName = User.Identity.Name;
            //string myUserName = "user1";

            NetUser myKRMember = (from x in mydbcon.NetUsers
                                  where x.UserName == myUserName
                                  select x).First(); ;

            int myUserID = myKRMember.UserID;

            //FirstLAST Names

            Member myMember = (from x in mydbcon.Members
                               where x.Member_UserID == myUserID
                               select x).FirstOrDefault();

            Label1.Text = myMember.MemberFirstName + " " + myMember.MemberLastName;
        }
    }
}