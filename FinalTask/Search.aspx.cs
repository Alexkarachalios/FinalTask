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
        string pass = "13898301153KSXK";//"13898301153KSXK";
        string database = "postgres";
        NpgsqlConnection conn;
        NpgsqlConnection conn2;

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
                conn2 = new NpgsqlConnection(connstring);
                conn2.Open();
            }
            catch (Exception msg)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + msg + "');", true);
                throw;
            }

            NpgsqlCommand cmnd = new NpgsqlCommand("SELECT username,latlng FROM users WHERE username != '" + Session["username"] + "' AND availability = 'true'", conn);//
            NpgsqlDataReader reader = cmnd.ExecuteReader();
            {
                NpgsqlCommand cmnd2;
                NpgsqlDataReader reader2;

                while (reader.Read())
                {
                    cars_user.Value += "/" + reader.GetString(0);
                    cars_loc.Value += "/" + reader.GetString(1);

                    cmnd2 = new NpgsqlCommand("SELECT model, price FROM cars WHERE carowner = '" + reader.GetString(0) + "'", conn2);
                    reader2 = cmnd2.ExecuteReader();
                    {
                        while (reader2.Read())
                        {
                            cars_model.Value += "/" + reader2.GetString(0);
                            cars_price.Value += "/" + reader2.GetString(1);
                        }
                        reader2.Close();
                    }
                    cmnd2.Cancel();


                }
                reader.Close();
            }
            cmnd.Cancel();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var cmnd = new NpgsqlCommand("SELECT username FROM users WHERE username='" + TextBox1.Text.ToString() + "'AND username != '" + Session["username"] + "' AND availability = 'true'", conn);
            var result = cmnd.ExecuteScalar();

            if (result != null)
            {
                Session["interested"] = result.ToString();

                conn.Close();
                Response.Redirect("Details.aspx");

            }
            else
            {
                string msg = "User unavailable or does not exist!";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + msg + "');", true);
            }
        }
    }
}