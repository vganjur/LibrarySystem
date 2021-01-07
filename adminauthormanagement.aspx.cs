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
    public partial class adminauthormanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // add new author
            if(checkIfAuthorExists())
            {
                Response.Write("This author already exists");
            }
            else
            {
                addNewAuthor();
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            // update author
            if (checkIfAuthorExists())
            {
                updateAuthor();
                Response.Write("Author updated");
            }
            else
            {
                Response.Write("This author does not exist");
            }

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            // delete author
            if (checkIfAuthorExists())
            {
                deleteAuthor();
                Response.Write("Author deleted");
            }
            else
            {
                Response.Write("This author does not exist");
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Go
        }

        //user defined methods

        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

        void deleteAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM author_master_tbl WHERE " +
                        "author_id='" + TextBox1.Text.Trim() + "';", con);

                    cmd.ExecuteNonQuery();
                    con.Close();

                    Response.Write("query successful");

                }
                GridView1.DataBind();
                clearForm();
            }

            catch (Exception ex)
            {
                Response.Write("Exception occured - " + ex.Message);

            }

        }

        void updateAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE author_master_tbl SET author_name = @author_name WHERE " +
                        "author_id='" + TextBox1.Text.Trim()+ "';", con);
                    cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());

                    cmd.ExecuteNonQuery();
                    con.Close();

                    Response.Write("author update successful");
                    GridView1.DataBind();
                    clearForm();

                }
            }

            catch (Exception ex)
            {
                Response.Write("Exception occured - " + ex.Message);

            }

        }


        bool checkIfAuthorExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM author_master_tbl WHERE author_id='" + TextBox1.Text.Trim() + "';", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();
                    if (dt.Rows.Count >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            catch (Exception ex)
            {
                Response.Write("Exception occured - " + ex.Message);

            }

            return false;
        }

        void addNewAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tbl" +
                        "(author_id,author_name)" +
                        "values(@author_id,@author_name)", con);

                    cmd.Parameters.AddWithValue("@author_id", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());

                    cmd.ExecuteNonQuery();
                    con.Close();

                    Response.Write("author added successfully");
                    GridView1.DataBind();
                    clearForm();

                }
            }

            catch (Exception ex)
            {
                Response.Write("Exception occured - " + ex.Message);

            }
        }

    }
}