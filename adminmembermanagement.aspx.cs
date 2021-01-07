using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElibraryManagement
{
    public partial class adminmembermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Go
            GetMemberById();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            // active
            updateMemberStatusById("active");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            updateMemberStatusById("pending");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            // deactivate
            updateMemberStatusById("deactive");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            // delete
            deleteMemberById();
        }

        // User defined functions

        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox7.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox5.Text = "";
            GridView1.DataBind();
        }

        void deleteMemberById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM member_master_tbl WHERE " +
                        "member_id='" + TextBox1.Text.Trim() + "';", con);

                    cmd.ExecuteNonQuery();
                    con.Close();

                    Response.Write("This member is deleted permanently");

                }
                GridView1.DataBind();
                clearForm();
            }

            catch (Exception ex)
            {
                Response.Write("Exception occured - " + ex.Message);

            }
        }
        void GetMemberById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id='" + TextBox1.Text.Trim() + "';", con);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            TextBox2.Text = dr.GetValue(0).ToString();
                            TextBox7.Text = dr.GetValue(10).ToString();
                            TextBox3.Text = dr.GetValue(1).ToString();
                            TextBox4.Text = dr.GetValue(2).ToString();
                            TextBox8.Text = dr.GetValue(3).ToString();
                            TextBox9.Text = dr.GetValue(4).ToString();
                            TextBox10.Text = dr.GetValue(5).ToString();
                            TextBox11.Text = dr.GetValue(6).ToString();
                            TextBox5.Text = dr.GetValue(7).ToString();
                        }
                       
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

        void updateMemberStatusById(string status)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl set account_status = '" + status + "' WHERE member_id='" + TextBox1.Text.Trim() + "';", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("Member status updated!!! ");
                }
            }

            catch (Exception ex)
            {
                Response.Write("Exception occured - " + ex.Message);

            }
        }
    }
}