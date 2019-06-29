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
        string pass = "13898301153KSXK";
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

            if (!IsPostBack)
            {
                NpgsqlCommand cmnd = new NpgsqlCommand("SELECT model, cc, km, year, price FROM cars WHERE carowner = '" + Session["username"] + "'", conn);
                NpgsqlDataReader reader = cmnd.ExecuteReader();

                if (reader.Read())
                {
                    updatebutton.Visible = true;
                    add_button.Visible = false;
                    model_text.Text = reader.GetString(0);
                    cc_text.Text = reader.GetString(1);
                    km_text.Text = reader.GetString(2);
                    year_text.Text = reader.GetString(3);
                    price_text.Text = reader.GetString(4);

                }
                reader.Close();
                cmnd.Cancel();

                NpgsqlCommand cmnd2 = new NpgsqlCommand("SELECT availability FROM users WHERE username='" + Session["username"] + "'", conn);
                NpgsqlDataReader reader2 = cmnd2.ExecuteReader();

                reader2.Read();
                if (reader2.GetString(0) == "true")
                {
                    DropDownList1.DataBind();
                    DropDownList1.Items.FindByValue("true").Selected = true;
                }
                else
                {
                    DropDownList1.DataBind();
                    DropDownList1.Items.FindByValue("false").Selected = true;
                }
                reader2.Close();
                cmnd2.Cancel();

            }

            NpgsqlCommand cmd_dibs = new NpgsqlCommand("SELECT * FROM dibs WHERE renter='" + Session["username"] + "'", conn);
            var check = cmd_dibs.ExecuteScalar();
            if (check!=null)
            {
                NpgsqlDataReader read_dibs = cmd_dibs.ExecuteReader();
                read_dibs.Read();
                if (read_dibs.GetString(0) != null & read_dibs.GetString(2) == "pending")
                {
                    dibs1_label.Text = read_dibs.GetString(1) + " WANTS TO RENT YOUR CAR";
                    dibs1_button.Visible = true;
                    decline_button.Visible = true;
                }
                else if (read_dibs.GetString(0) != null & read_dibs.GetString(2) == "yes")
                {
                    dibs1_label.Text = read_dibs.GetString(1) + " IS RENTING YOUR CAR";
                    dibs1_button.Visible = false;
                    decline_button.Visible = false;
                }
                read_dibs.Close();
            }
            
        }

        protected void add_button_Click(object sender, EventArgs e)
        {
            string s = FileUpload1.FileName;
            if (model_text.Text=="" | cc_text.Text=="" | km_text.Text=="" | year_text.Text=="" | price_text.Text=="" | s=="")
            {
                string msg = "Empty field detected!!!";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + msg + "');", true);
            }
            else
            {
                var cmd = new NpgsqlCommand("INSERT INTO cars(carowner,model,cc,price,km,year) VALUES('" + Session["username"].ToString() + "','" + model_text.Text.ToString() + "','" + cc_text.Text.ToString() + "','" + price_text.Text.ToString() + "','" + km_text.Text.ToString() + "','" + year_text.Text.ToString() + "')", conn);
                var cmd2 = new NpgsqlCommand("UPDATE users SET availability = "+ DropDownList1.SelectedValue +" WHERE username='" + Session["username"]+"'", conn);
                //cmd.Prepare();
                // Set parameters
                cmd2.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                Response.Redirect("choice.aspx");

            }

        }

        protected void UpdateButton_click(object sender, EventArgs e)
        {
            string s = FileUpload1.FileName;
            if (model_text.Text == "" | cc_text.Text == "" | km_text.Text == "" | year_text.Text == "" | price_text.Text == "" | s == "")
            {
                string msg = "Empty field detected!!!";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + msg + "');", true);
            }
            else
            {
                var cmd = new NpgsqlCommand("UPDATE cars SET model='"+ model_text.Text.ToString() +"', cc='" + cc_text.Text.ToString() + "' , price='" + price_text.Text.ToString() + "', km='" + km_text.Text.ToString() + "' , year='" + year_text.Text.ToString() + "' , photo='" + s.ToString() +  "' WHERE carowner='" + Session["username"] + "'", conn);
                cmd.ExecuteNonQuery();

                var cmd2 = new NpgsqlCommand("UPDATE users SET availability = " + DropDownList1.SelectedValue + " WHERE username='" + Session["username"] + "'", conn);
                cmd2.ExecuteNonQuery();

                Response.Redirect("choice.aspx");

            }

        }

        protected void dibs1_button_Click(object sender, EventArgs e)
        {
            NpgsqlCommand cmd_accept = new NpgsqlCommand("UPDATE dibs SET accept='yes' WHERE renter='" + Session["username"] + "'" , conn);
            cmd_accept.ExecuteNonQuery();
            dibs1_button.Visible = false;
            decline_button.Visible = false;
            dibs1_label.Text = "YOUR CAR IS RENTED";
        }

        protected void decline_button_Click(object sender, EventArgs e)
        {
            NpgsqlCommand cmd_decline = new NpgsqlCommand("DELETE FROM dibs WHERE renter='" + Session["username"] + "'", conn);
            cmd_decline.ExecuteNonQuery();
            dibs1_button.Visible = false;
            decline_button.Visible = false;

        }
    }
}