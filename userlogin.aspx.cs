using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElibraryManagement
{
    public partial class userlogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Response.Write("button clicked");
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id='"+TextBox1.Text.Trim()+"' AND password='"+ TextBox2.Text.Trim()+"';", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    
                    if(dr.HasRows)
                    {
                        while(dr.Read())
                        {
                            //Response.Write("Reading data " + dr.GetValue(8).ToString());
                            Session["username"] = dr.GetValue(8).ToString();
                            Session["fullname"] = dr.GetValue(0).ToString();
                            Session["role"] ="user";
                            Session["status"] = dr.GetValue(0).ToString();
                        }
                        Response.Redirect("homepage.aspx");
                    }
                    else
                    {
                        Response.Write("User does not exist!!! ");
                    }
                }
            }

            catch (Exception ex)
            {
                Response.Write("Exception occured - " + ex.Message);

            }
        }
    }
}