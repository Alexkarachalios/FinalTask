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
        string pass = "1234qwer";//13898301153KSXK";
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

            NpgsqlCommand cmnd, cmdphoto;
            NpgsqlDataReader reader;

            cmnd = new NpgsqlCommand("SELECT model, cc, km, year, price FROM cars WHERE carowner = '" + Session["interested"] + "'", conn);
            reader = cmnd.ExecuteReader();
            reader.Read();

            model_text.Text = reader.GetString(0);
            cc_text.Text = reader.GetString(1);
            km_text.Text = reader.GetString(2);
            year_text.Text = reader.GetString(3);
            price_text.Text = reader.GetString(4);

            reader.Close();
            cmnd.Cancel();


            cmnd = new NpgsqlCommand("SELECT name,surname,rating,people FROM users WHERE username = '" + Session["interested"] + "'", conn);
            reader = cmnd.ExecuteReader();

            reader.Read();
            oname.Text = reader.GetString(0);
            olastname.Text = reader.GetString(1);
            if (reader.GetString(3) != "0")
            {
                oarating.Text = (Convert.ToInt32(reader.GetString(2)) / Convert.ToInt32(reader.GetString(3))).ToString();
            }
            else
            {
                oarating.Text = "No rating yet!";
            }

            reader.Close();
            cmnd.Cancel();

            owner.Text = Session["interested"].ToString() + " information";

            string pic = "";
            cmdphoto = new NpgsqlCommand("SELECT photo FROM CARS WHERE carowner= '" + Session["interested"] + "'", conn);
            reader = cmdphoto.ExecuteReader();
            while (reader.Read())
            {
                pic = reader["photo"].ToString();
                
            }
            Label2.Text = pic;
            reader.Close();
            Image1.ImageUrl = "Content/Themes/" + pic;


            state_label.Visible = true;
            NpgsqlCommand cmd_state = new NpgsqlCommand("SELECT accept FROM dibs WHERE buyer='" + Session["username"] + "'", conn);
            reader = cmd_state.ExecuteReader();
            while (reader.Read())
            {
                if (reader["accept"].ToString() != "ended" && reader["accept"].ToString() != "no")
                {
                    dibs_button.Text = "END RENTAL";
                }

                if (reader["accept"].ToString() == "yes")
                {
                    state_label.Text = "STATE : ACCEPTED";
                }
                else if (reader["accept"].ToString() == "pending")
                {
                    dibs_button.Text = "CANCEL RENTAL";
                }

            }
            reader.Close();


        }

        protected void contact_button_Click(object sender, EventArgs e)
        {
            if (dibs_button.Text == "DIB CAR")
            {
                var check = new NpgsqlCommand("SELECT renter FROM dibs WHERE renter='" + Session["interested"] + "'", conn);
                var result = check.ExecuteScalar();
                if (result != null)
                {
                    string msg = "CAR IS NOT AVAILABLE! TRY AGAIN LATER";
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + msg + "');", true);
                }
                else
                {

                    NpgsqlCommand cmd_dibs = new NpgsqlCommand("INSERT INTO dibs (renter,buyer) VALUES('" + Session["interested"] + "','" + Session["username"] + "')", conn);
                    cmd_dibs.ExecuteNonQuery();
                    //state_label.Visible = true;
                    state_label.Text = "STATE : PENDING";
                }
                dibs_button.Text = "CANCEL RENTAL";
            }
            else if (dibs_button.Text == "END RENTAL")
            {
                NpgsqlCommand end = new NpgsqlCommand("UPDATE dibs SET accept='ended' WHERE buyer='" + Session["username"] + "'", conn);
                end.ExecuteNonQuery();
                rate_label.Visible = true;
                rate_list.Visible = true;
                Button1.Visible = true;
                dibs_button.Text = "DIB CAR";
                state_label.Text = "";
            }
            else if (dibs_button.Text == "CANCEL RENTAL")
            {
                NpgsqlCommand end = new NpgsqlCommand("DELETE FROM dibs WHERE renter='" + Session["interested"] + "' AND buyer ='"+Session["username"]+"'", conn);
                end.ExecuteNonQuery();
                dibs_button.Text = "DIB CAR";
                state_label.Text = "";
            }




        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            conn.Close();
            Response.Redirect("Search.aspx");
        }

        protected void oarating_TextChanged(object sender, EventArgs e)
        {

        }

        protected void rate_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string curr, curp, newer;
            int r, p, temp;
            NpgsqlCommand rate = new NpgsqlCommand("SELECT rating, people FROM users WHERE username='" + Session["interested"] + "'", conn);
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

            NpgsqlCommand set_rating = new NpgsqlCommand("UPDATE users SET rating='" + r + "', people='" + p + "'WHERE username='" + Session["interested"] + "'", conn);
            set_rating.ExecuteNonQuery();
            Button1.Visible = false;
            rate_list.Visible = false;
            rate_label.Visible = false;
            Response.Redirect("Choice.aspx");
        }
    }
}