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
    public partial class adminpublishermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // add new publisher
            if (checkIfPublisherExists())
            {
                Response.Write("This publisher already exists");
            }
            else
            {
                addNewPublisher();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            // update publisher
            if (checkIfPublisherExists())
            {
                updatePublisher();
                Response.Write("Publisher updated");
            }
            else
            {
                Response.Write("This Publisher does not exist");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            // delete publisher
            if (checkIfPublisherExists())
            {
                deletePublisher();
                Response.Write("Publisher deleted");
            }
            else
            {
                Response.Write("This publisher does not exist");
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

        void deletePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM publisher_master_tbl WHERE " +
                        "publisher_id='" + TextBox1.Text.Trim() + "';", con);

                    cmd.ExecuteNonQuery();
                    con.Close();

                    Response.Write("publisher deleted");

                }
                GridView1.DataBind();
                clearForm();
            }

            catch (Exception ex)
            {
                Response.Write("Exception occured - " + ex.Message);

            }

        }

        void updatePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE publisher_master_tbl SET publisher_name = @publisher_name WHERE " +
                        "publisher_id='" + TextBox1.Text.Trim() + "';", con);
                    cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());

                    cmd.ExecuteNonQuery();
                    con.Close();

                    Response.Write("publisher update successful");
                    GridView1.DataBind();
                    clearForm();

                }
            }

            catch (Exception ex)
            {
                Response.Write("Exception occured - " + ex.Message);

            }

        }


        bool checkIfPublisherExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM publisher_master_tbl WHERE publisher_id='" + TextBox1.Text.Trim() + "';", con);
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

        void addNewPublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO publisher_master_tbl" +
                        "(publisher_id,publisher_name)" +
                        "values(@publisher_id,@publisher_name)", con);

                    cmd.Parameters.AddWithValue("@publisher_id", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());

                    cmd.ExecuteNonQuery();
                    con.Close();

                    Response.Write("publisher added successfully");
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