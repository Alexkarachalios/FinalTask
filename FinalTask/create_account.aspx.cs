using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using NpgsqlTypes;

namespace FinalTask
{
    public partial class create_account : System.Web.UI.Page
    {
        string localhost="127.0.0.1";
        string port = "5432";
        string user = "postgres";
        string pass = "1021989Alex";
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
        }

        protected void first_text_TextChanged(object sender, EventArgs e)
        {

        }

        protected void last_text_TextChanged(object sender, EventArgs e)
        {

        }

        protected void username_text_TextChanged(object sender, EventArgs e)
        {

        }

        protected void password_text_TextChanged(object sender, EventArgs e)
        {

        }

        protected void create_button_Click(object sender, EventArgs e)
        {

            var cmd = new NpgsqlCommand("INSERT INTO users(name,surname,username,password) VALUES('"+first_text.Text.ToString()+"','"+last_text.Text.ToString()+"','"+username_text.Text.ToString()+"','"+password_text.Text.ToString()+"')",conn);
           
            //cmd.Prepare();
            // Set parameters
            cmd.ExecuteNonQuery();
            // And so on
        }
    }
}