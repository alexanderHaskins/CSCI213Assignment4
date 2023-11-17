using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSCI213Assignment4
{
    public partial class Instructor1 : System.Web.UI.Page
    {
        KarateSchoolDataContext dbcon;
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\alexj\\OneDrive\\Desktop\\HaskinsAlexanderAssignment4\\CSCI213Assignment4\\App_Data\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";

        
        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon=new KarateSchoolDataContext(conn);

            // string myUserName=User.Identity.Name;
            string myUserName = "user2";
            NetUser myKRMember = (from x in dbcon.NetUsers
                                  where x.UserName == myUserName
                                  select x).First();
            int myUserId = myKRMember.UserID;

            Instructor myInstructor =(from x in dbcon.Instructors
                                      where x.InstructorID==myUserId
                                      select x).First();
            firstNameLabel.Text = myInstructor.InstructorFirstName;
            lastNameLabel.Text = myInstructor.InstructorLastName;

            var result=from x in dbcon.Sections
                       join  y in dbcon.Members
                       on x.Member_ID equals y.Member_UserID
                       select new {
                           x.SectionName,
                           y.MemberFirstName,
                           y.MemberLastName
                       };
            sectionAndMembersGridView.DataSource = result;
            sectionAndMembersGridView.DataBind();
        }
    }
}