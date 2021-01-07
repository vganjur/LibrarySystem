using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElibraryManagement
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(Session["role"].Equals(""))
                {
                    LinkButton1.Visible = true; // user login
                    LinkButton2.Visible = true; // signUp login

                    LinkButton3.Visible = false; // logout
                    LinkButton7.Visible = false; // hello user

                    LinkButton6.Visible = true; // admin login
                    LinkButton11.Visible = false; // author management
                    LinkButton12.Visible = false; // publisher management
                    LinkButton8.Visible = false; // book issuing
                    LinkButton9.Visible = false; // book invenory
                    LinkButton10.Visible = false; // member management
                }
                else if(Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = false; // user login
                    LinkButton2.Visible = false; // signUp login

                    LinkButton3.Visible = true; // logout
                    LinkButton7.Visible = true; // hello user
                    LinkButton7.Text = Session["username"].ToString();

                    LinkButton6.Visible = true; // admin login
                    LinkButton11.Visible = false; // author management
                    LinkButton12.Visible = false; // publisher management
                    LinkButton8.Visible = false; // book issuing
                    LinkButton9.Visible = false; // book invenory
                    LinkButton10.Visible = false; // member management

                }
                else if (Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false; // user login
                    LinkButton2.Visible = false; // signUp login

                    LinkButton3.Visible = true; // logout
                    LinkButton7.Visible = true; // hello user
                    LinkButton7.Text = "Hello Admin!";

                    LinkButton6.Visible = false; // admin login
                    LinkButton11.Visible = true; // author management
                    LinkButton12.Visible = true; // publisher management
                    LinkButton8.Visible = true; // book issuing
                    LinkButton9.Visible = true; // book invenory
                    LinkButton10.Visible = true; // member management

                }

            }
            catch(Exception ex)
            {

            }

        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminauthormanagement.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminpublishermanagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookinventory.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookissuing.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmembermanagement.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
           // Response.Redirect("adminlogin.aspx"); - view books link ??
        }

        //logout page
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            Session["status"] = "";

            //visibility set to default values for all the links
            LinkButton1.Visible = true; // user login
            LinkButton2.Visible = true; // signUp login

            LinkButton3.Visible = false; // logout
            LinkButton7.Visible = false; // hello user

            LinkButton6.Visible = true; // admin login
            LinkButton11.Visible = false; // author management
            LinkButton12.Visible = false; // publisher management
            LinkButton8.Visible = false; // book issuing
            LinkButton9.Visible = false; // book invenory
            LinkButton10.Visible = false; // member management

            Response.Redirect("homepage.aspx");

        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("userprofile.aspx");
        }
    }
}