using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalTask
{
    public partial class Details : System.Web.UI.Page
    {
        string localhost = "127.0.0.1";
        string port = "5432";
        string user = "postgres";
        string pass = "1234qwer";//"13898301153KSXK";
        string database = "postgres";
        NpgsqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
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

            NpgsqlCommand cmnd;
            NpgsqlDataReader reader;

            cmnd = new NpgsqlCommand("SELECT model, cc, km, year, price FROM cars WHERE carowner = '" + Session["interested"] + "'", conn);
            reader = cmnd.ExecuteReader();
            {
                reader.Read();
                model_text.Text = reader.GetString(0);
                cc_text.Text = reader.GetString(1);
                km_text.Text = reader.GetString(2);
                year_text.Text = reader.GetString(3);
                price_text.Text = reader.GetString(4);
                reader.Close();
            }
            cmnd.Cancel();

        }

        protected void contact_button_Click(object sender, EventArgs e)
        {

        }
    }
}