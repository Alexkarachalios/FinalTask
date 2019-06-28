using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;

namespace FinalTask
{
    public partial class login : System.Web.UI.Page
    {
        string localhost = "127.0.0.1";
        string port = "5432";
        string user = "postgres";
        string pass = "13898301153KSXK";//
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

        

        protected void username_text_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void login_button_Click(object sender, EventArgs e)
        {
            
            var cmd1 = new NpgsqlCommand("SELECT username,password FROM users WHERE username='" + username_text.Text.ToString() + "' AND password='" + password_text.Text.ToString() + "'", conn);
            var result = cmd1.ExecuteScalar();

            if (result != null)
            {
                Session["username"] = username_text.Text.ToString();

                var cmd2 = new NpgsqlCommand("SELECT latlng FROM users WHERE username='" + username_text.Text.ToString() + "'", conn);
                var result2 = cmd2.ExecuteScalar();
                Session["latlng"] = result2;

                Response.Redirect("choice.aspx");

            }
            else
            {
                string msg = "Wrong username or password!!";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + msg + "');", true);
            }
        }

        protected void create_account_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("create_account.aspx");
        }
    }
}