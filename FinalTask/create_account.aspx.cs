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
        string pass = "13898301153KSXK"; 
        string database = "postgres";
        NpgsqlConnection conn;
        //Label loc;
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


            if (!IsPostBack)
            {
                NpgsqlCommand cmnd = new NpgsqlCommand("SELECT name, surname, username, birth, experience, latlng FROM users WHERE username = '" + Session["username"] + "'", conn);
                NpgsqlDataReader reader = cmnd.ExecuteReader();

                if (reader.Read())
                {
                    update_button.Visible = true;
                    create_button.Visible = false;
                    back.Visible = false;
                    backtochoice.Visible = true;
                    first_text.Text = reader.GetString(0);
                    last_text.Text = reader.GetString(1);
                    username_text.Text = reader.GetString(2);
                    username_text.Enabled = false;
                    password_label.Text = "Set new password: ";
                    password_text.Text = "";
                    birth_text.Text = reader.GetString(3);
                    exp_text.Text = reader.GetString(4);
                    location.Value = reader.GetString(5);

                }
                reader.Close();
                cmnd.Cancel();

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

            if (first_text.Text=="" | last_text.Text=="" | username_text.Text=="" | password_text.Text=="" | birth_text.Text==""|exp_text.Text=="")
            {
                string msg = "Empty field detected!!!";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + msg + "');", true);
            }
            else
            {
                var cmd1 = new NpgsqlCommand("SELECT username FROM users WHERE username='" + username_text.Text.ToString() + "'", conn);
                var result = cmd1.ExecuteScalar();

                if (result != null)
                {
                    string msg = "Username already exists!!!";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + msg + "');", true);

                }
                else
                {
                    var cmd = new NpgsqlCommand("INSERT INTO users(name,surname,username,password,latlng,birth,experience) VALUES('" + first_text.Text.ToString() + "','" + last_text.Text.ToString() + "','" + username_text.Text.ToString() + "','" + password_text.Text.ToString() + "','" + location.Value + "','" + birth_text.Text.ToString() + "','" + exp_text.Text.ToString() + "')", conn);
                    
                    //cmd.Prepare();
                    // Set parameters
                    cmd.ExecuteNonQuery();
                    Response.Redirect("login.aspx");
                    // And so on
                }
            }
            


        }

        protected void back_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }



        protected void update_button_Click(object sender, EventArgs e)
        {
            if (first_text.Text == "" | last_text.Text == "" | username_text.Text == "" | birth_text.Text == "" | exp_text.Text == "")
            {
                string msg = "Empty field detected!!!";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + msg + "');", true);
            }
            else
            {
                var cmd = new NpgsqlCommand("UPDATE users SET name='" + first_text.Text.ToString() + "', surname='" + last_text.Text.ToString() + "' , latlng='" + location.Value.ToString() + "', birth='" + birth_text.Text.ToString() + "' , experience='" + exp_text.Text.ToString() + "' WHERE username='" + Session["username"] + "'", conn);
                cmd.ExecuteNonQuery();


                if(password_text.Text.ToString() != "")
                {
                    cmd = new NpgsqlCommand("UPDATE users SET password='" + password_text.Text.ToString() + "' WHERE username='" + Session["username"] + "'", conn);
                    cmd.ExecuteNonQuery();
                }
            }
        }



        protected void backtochoice_button_Click(object sender, EventArgs e)
        {
            Response.Redirect("choice.aspx");

        }
    }
}