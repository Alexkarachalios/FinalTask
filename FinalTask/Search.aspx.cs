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
        string pass = "1234qwer"; //13898301153KSXK
        string database = "postgres";
        NpgsqlConnection conn;

        protected void Page_Load(object sender, EventArgs e)
        {
            location.Value = "(37.9417861, 23.6540173)"; //Session["latlng"].ToString();

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

            NpgsqlCommand cmnd = new NpgsqlCommand("SELECT latlng FROM users WHERE username != '" + "asd" + "'", conn);//Session["username"]
            NpgsqlDataReader reader = cmnd.ExecuteReader();
            {
                while (reader.Read())
                {
                    cars_loc.Value += "/" + reader.GetString(0);
                }
                reader.Close();
            }
            cmnd.Cancel();

            cmnd = new NpgsqlCommand("SELECT username FROM users WHERE username != '" + "asd" + "'", conn); //Session["username"]
            reader = cmnd.ExecuteReader();
            {
                while (reader.Read())
                {
                    cars_user.Value += "/" + reader.GetString(0);
                }
                reader.Close();
            }
            cmnd.Cancel();
        }
    }
}