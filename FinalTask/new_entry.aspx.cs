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
        string client;
        string localhost = "127.0.0.1";
        string port = "5432";
        string user = "postgres";
        string pass = "1234qwer";//13898301153KSXK";
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

                string pic = "";
                NpgsqlCommand cmdphoto = new NpgsqlCommand("SELECT photo FROM CARS WHERE carowner= '" + Session["username"] + "'", conn);
                reader = cmdphoto.ExecuteReader();
                while (reader.Read())
                {
                    pic = reader["photo"].ToString();
                    Image1.Visible = true;

                }
                reader.Close();
                Image1.ImageUrl = "Content/Themes/" + pic;

            }

            NpgsqlCommand cmd_dibs = new NpgsqlCommand("SELECT * FROM dibs WHERE renter='" + Session["username"] + "'", conn);
            var check = cmd_dibs.ExecuteScalar();
            if (check != null)
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
                else if (read_dibs.GetString(0) != null & read_dibs.GetString(2) == "ended")
                {
                    client = read_dibs.GetString(1);
                    dibs1_label.Visible = false;
                    dibs1_button.Visible = false;
                    decline_button.Visible = false;
                    rate_label.Visible = true;
                    rate_list.Visible = true;
                    rate_button.Visible = true;
                    
                }
                cmd_dibs.Cancel();


                NpgsqlCommand cmnd3 = new NpgsqlCommand("SELECT name,surname,rating,birth,experience,people FROM users WHERE username='" + read_dibs.GetString(1) + "'", conn2);
                NpgsqlDataReader reader3 = cmnd3.ExecuteReader();
                reader3.Read();
                exp_lab.Visible = true;
                exp.Visible = true;
                exp.Text = reader3.GetString(4);
                age_lab.Visible = true;
                age.Visible = true;
                age.Text = reader3.GetString(3);
                rrate_lab.Visible = true;
                rrating.Visible = true;
                if (reader3.GetString(5) != "0")
                {
                    rrating.Text = (Convert.ToInt32(reader3.GetString(2)) / Convert.ToInt32(reader3.GetString(5))).ToString();
                }
                else
                {
                    rrating.Text = "No rating yet!";
                }
                rlast_lab.Visible = true;
                rlastname.Visible = true;
                rlastname.Text = reader3.GetString(1);
                rname_lab.Visible = true;
                rname.Visible = true;
                rname.Text = reader3.GetString(0);
                reader3.Close();


                read_dibs.Close();

            }

        }

        protected void add_button_Click(object sender, EventArgs e)
        {
            string s = FileUpload1.FileName;
            if (model_text.Text == "" | cc_text.Text == "" | km_text.Text == "" | year_text.Text == "" | price_text.Text == "" | s == "")
            {
                string msg = "Empty field detected!!!";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + msg + "');", true);
            }
            else
            {
                var cmd = new NpgsqlCommand("INSERT INTO cars(carowner,model,cc,price,km,year) VALUES('" + Session["username"].ToString() + "','" + model_text.Text.ToString() + "','" + cc_text.Text.ToString() + "','" + price_text.Text.ToString() + "','" + km_text.Text.ToString() + "','" + year_text.Text.ToString() + "')", conn);
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
                var cmd = new NpgsqlCommand("UPDATE cars SET model='" + model_text.Text.ToString() + "', cc='" + cc_text.Text.ToString() + "' , price='" + price_text.Text.ToString() + "', km='" + km_text.Text.ToString() + "' , year='" + year_text.Text.ToString() + "' , photo='" + s.ToString() + "' WHERE carowner='" + Session["username"] + "'", conn);
                cmd.ExecuteNonQuery();


                Response.Redirect("choice.aspx");
            }
        }

        protected void dibs1_button_Click(object sender, EventArgs e)
        {
            NpgsqlCommand cmd_accept = new NpgsqlCommand("UPDATE dibs SET accept='yes' WHERE renter='" + Session["username"] + "'", conn);
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

        protected void back_button_Click(object sender, EventArgs e)
        {
            conn.Close();
            conn2.Close();
            Response.Redirect("Choice.aspx");
        }

        protected void rate_button_Click(object sender, EventArgs e)
        {
            string curr, curp, newer;
            int r, p, temp;
            NpgsqlCommand rate = new NpgsqlCommand("SELECT rating, people FROM users WHERE username='" + client + "'", conn);
            NpgsqlDataReader reader;

            reader = rate.ExecuteReader();
            reader.Read();

            curr = reader.GetString(0);
            curp = reader.GetString(1);

            r = Convert.ToInt32(curr);
            p = Convert.ToInt32(curp);

            newer = rate_list.Text.ToString();
            temp = Convert.ToInt32(newer);

            p++;
            r += temp;

            reader.Close();

            NpgsqlCommand set_rating = new NpgsqlCommand("UPDATE users SET rating='" + r + "', people='"+ p +"'WHERE username='" + client + "'", conn);
            set_rating.ExecuteNonQuery();
            rate_label.Visible = false;
            rate_list.Visible = false;
            rate_button.Visible = false;
            NpgsqlCommand delete = new NpgsqlCommand("DELETE FROM dibs WHERE renter='" + Session["username"] + "'", conn);
            delete.ExecuteNonQuery();
            Response.Redirect("Choice.aspx");
        }
    }
}