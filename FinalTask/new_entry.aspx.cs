using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalTask
{
    public partial class new_entry : System.Web.UI.Page
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

        protected void add_button_Click(object sender, EventArgs e)
        {
            string usr = "'" + Session["username"].ToString() + "'";
            string s = FileUpload1.FileName;
            if (model_text.Text=="" | cc_text.Text=="" | km_text.Text=="" | year_text.Text=="" | price_text.Text=="" | s=="")
            {
                string msg = "Empty field detected!!!";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + msg + "');", true);
            }
            else
            {
                
                var cmd = new NpgsqlCommand("INSERT INTO cars(carowner,model,cc,price,km,year,photo) VALUES('" + Session["username"].ToString() + "','" + model_text.Text.ToString() + "','" + cc_text.Text.ToString() + "','" + price_text.Text.ToString() + "','" + km_text.Text.ToString() + "','" + year_text.Text.ToString() + "','" + s + "')", conn);
                var cmd2 = new NpgsqlCommand("UPDATE USERS SET availability=true where username=" +  usr, conn);
                //cmd.Prepare();
                // Set parameters
                cmd2.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                Response.Redirect("main.aspx");
                // And so on
           
            }
        }
    }
}