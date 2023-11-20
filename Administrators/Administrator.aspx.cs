using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSCI213Assignment4
{
    public partial class Administrator : System.Web.UI.Page
    {
        KarateSchoolDataContext dbcon;
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\alexj\\OneDrive\\Desktop\\HaskinsAlexanderAssignment4\\CSCI213Assignment4\\App_Data\\KarateSchool.mdf;Integrated Security=True;Connect Timeout=30";
        protected void Page_Load(object sender, EventArgs e)
        {
            refresh1();
            refresh2();
            refresh3();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void refresh1() {
            dbcon = new KarateSchoolDataContext(conn);
            var result = from x in dbcon.Members
                         select new
                         {
                             x.Member_UserID,
                             x.MemberFirstName,
                             x.MemberLastName,
                             x.MemberPhoneNumber,
                             x.MemberDateJoined
                         };
            GridView1.DataSource = result;
            GridView1.DataBind();
        }
        private void refresh2()
        {
            dbcon = new KarateSchoolDataContext(conn);
            var result = from x in dbcon.Instructors
                         select new
                         {
                             x.InstructorID,
                             x.InstructorFirstName,
                             x.InstructorLastName
                         };
            GridView2.DataSource = result;
            GridView2.DataBind();
        }
        private void refresh3() {
            dbcon= new KarateSchoolDataContext(conn);
            var result = from x in dbcon.Sections
                         select new
                         {
                             x.SectionID,
                             x.SectionName,
                             x.SectionStartDate,
                             x.Member_ID,
                             x.Instructor_ID,
                             x.SectionFee
                         };
            GridView3.DataSource = result;
            GridView3.DataBind();
        }

        protected void addMemberButton_Click(object sender, EventArgs e)
        {
            dbcon = new KarateSchoolDataContext(conn);
            NetUser myUser = new NetUser();
            myUser.UserName=memberUserNameTextBox.Text;
            myUser.UserPassword=memberPasswordTextBox.Text;
            myUser.UserType = "Member";
            dbcon.NetUsers.InsertOnSubmit(myUser);
            dbcon.SubmitChanges();
            Member myMember = new Member {
                Member_UserID = myUser.UserID,
                MemberFirstName=firstNameTextBox.Text.Trim(),
                MemberLastName=lastNameTextBox.Text.Trim(),
                MemberDateJoined=DateTime.Today,
                MemberEmail=emailTextBox.Text.Trim(),
                MemberPhoneNumber=phoneTextBox.Text.Trim()
            };
            dbcon.Members.InsertOnSubmit(myMember);
            dbcon.SubmitChanges();
            refresh1();
                
        }

        
        protected void deleteMemberButton_Click(object sender, EventArgs e)
        {
            var delete2 = from x in dbcon.Members
                         where x.Member_UserID ==Convert.ToInt32(deleteMemberTextBox.Text)
                         select x;
            foreach (var x in delete2) {
                dbcon.Members.DeleteOnSubmit(x);
            }
            dbcon.SubmitChanges();

            dbcon = new KarateSchoolDataContext(conn);
            var delete = from x in dbcon.NetUsers
                         where x.UserID == Convert.ToInt32(deleteMemberTextBox.Text)
                         select x;
            foreach (var x in delete)
            {
                dbcon.NetUsers.DeleteOnSubmit(x);
            }
            dbcon.SubmitChanges();
            refresh1();
        }

        protected void addInstructorButton_Click(object sender, EventArgs e)
        {
            dbcon = new KarateSchoolDataContext(conn);
            NetUser myUser = new NetUser();
            myUser.UserName = instructorUsernameTextBox.Text;
            myUser.UserPassword = instructorPasswordTextBox.Text;
            myUser.UserType = "Instructor";
            dbcon.NetUsers.InsertOnSubmit(myUser);
            dbcon.SubmitChanges();
            Instructor myInstructor = new Instructor {
               InstructorID=myUser.UserID,
               InstructorFirstName=instructorFNameTextBox.Text,
               InstructorLastName=instructorLNameTextBox.Text,
               InstructorPhoneNumber=instructorPhoneTextBox.Text
            };
            dbcon.Instructors.InsertOnSubmit(myInstructor);
            dbcon.SubmitChanges();
            refresh2();
        }

        
        protected void deleteInstructorButton_Click(object sender, EventArgs e)
        {
            var delete2=from x in dbcon.Instructors
                        where x.InstructorID== Convert.ToInt32(deleteInstructorTextBox.Text)
                        select x;
            foreach (var x in delete2) {
                dbcon.Instructors.DeleteOnSubmit(x);
            }
            dbcon.SubmitChanges();
            refresh2();
            dbcon = new KarateSchoolDataContext(conn);
            var delete = from x in dbcon.NetUsers
                         where x.UserID == Convert.ToInt32(deleteInstructorTextBox.Text)
                         select x;
            foreach (var x in delete)
            {
                dbcon.NetUsers.DeleteOnSubmit(x);
            }
            dbcon.SubmitChanges();
        }

        protected void assignSessionButton_Click(object sender, EventArgs e)
        {
            dbcon = new KarateSchoolDataContext(conn);
            var result=from x in dbcon.Sections
                       where x.SectionID==Convert.ToInt32(sectionIDTextBox.Text)
                       select x;

            Section mySection = result.First();
            Section mySection2=new Section {
                SectionName=mySection.SectionName,
                SectionFee=mySection.SectionFee,
                SectionStartDate=mySection.SectionStartDate,
                Instructor_ID=mySection.Instructor_ID,
                Member_ID=Convert.ToInt32(assignMemberIDTextBox.Text)
            };
            dbcon.Sections.InsertOnSubmit(mySection2);
            dbcon.SubmitChanges();
            refresh3();
        }
    }
}