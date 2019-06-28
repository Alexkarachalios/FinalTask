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
        string pass = "13898301153KSXK"; //13898301153KSXK
        string database = "postgres";
        NpgsqlConnection conn;
        NpgsqlConnection conn2;
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
                conn2 = new NpgsqlConnection(connstring);
                conn2.Open();
            }
            catch (Exception msg)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + msg + "');", true);
                throw;
            }

        }
    }
}