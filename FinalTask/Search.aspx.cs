using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;

namespace FinalTask
{
    public partial class Default : System.Web.UI.Page
    {
        string localhost = "127.0.0.1";
        string port = "5432";
        string user = "postgres";
        string pass = "1234qwer";//13898301153KSXK";
        string database = "postgres";
        NpgsqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            location.Value = Session["latlng"].ToString(); // "(37.9417861, 23.6540173)";//

            try
            {
                string connstring = String.Format("Server={0};Port={1};" +
                   "User Id={2};Password={3};Database={4};",
                   localhost, port, user,
                   pass, database);
                // Making connection with Npgsql provider
                conn = new NpgsqlConnection(connstring);
                conn.Open();
            }
            catch (Exception msg)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + msg + "');", true);
                throw;
            }

            NpgsqlCommand cmnd = new NpgsqlCommand("SELECT u.username, u.latlng, c.model, c.price FROM users u LEFT JOIN dibs d ON u.username = d.renter LEFT JOIN cars c on u.username = c.carowner WHERE d.renter IS NULL AND c.carowner IS NOT NULL AND u.username !='" + Session["username"] + "'", conn);
            NpgsqlDataReader reader = cmnd.ExecuteReader();
            {

                while (reader.Read())
                {
                    cars_user.Value += "/" + reader.GetString(0);
                    cars_loc.Value += "/" + reader.GetString(1);
                    cars_model.Value += "/" + reader.GetString(2);
                    cars_price.Value += "/" + reader.GetString(3);
                }
                reader.Close();
            }
            cmnd.Cancel();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            NpgsqlCommand cmnd = new NpgsqlCommand("SELECT u.username FROM users u LEFT JOIN dibs d ON u.username = d.renter LEFT JOIN cars c on u.username = c.carowner WHERE (d.renter IS NULL OR d.accept ='pending') AND c.carowner IS NOT NULL AND u.username !='" + Session["username"] + "' AND u.username='"+TextBox1.Text+"'", conn);
            NpgsqlDataReader result = cmnd.ExecuteReader();


            if (result.Read())
            {
                Session["interested"] = result.GetString(0);

                conn.Close();
                Response.Redirect("Details.aspx");

            }
            else
            {
                string msg = "User unavailable or does not exist!";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + msg + "');", true);
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            conn.Close();
            Response.Redirect("Choice.aspx");
        }
    }
}