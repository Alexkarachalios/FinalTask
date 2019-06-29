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
        string pass = "13898301153KSXK";//"13898301153KSXK";
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

            NpgsqlCommand cmnd,cmdphoto;
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


            cmnd = new NpgsqlCommand("SELECT name,surname FROM users WHERE username = '" + Session["interested"] + "'", conn);
            reader = cmnd.ExecuteReader();

            reader.Read();
            oname.Text = reader.GetString(0);
            olastname.Text = reader.GetString(1);

            reader.Close();
            cmnd.Cancel();

            owner.Text = Session["interested"].ToString() + " information";

            string pic="";
            cmdphoto=new NpgsqlCommand("SELECT photo FROM CARS WHERE carowner= '" + Session["interested"] + "'", conn);
            reader=cmdphoto.ExecuteReader();
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
            while(reader.Read())
            {
                if (reader["accept"].ToString() == "yes")
                {
                    state_label.Text = "STATE : ACCEPTED";
                }
                dibs_button.Text = "END RENTAL";
                
            }
            reader.Close();

 
        }

        protected void contact_button_Click(object sender, EventArgs e)
        {
            if (dibs_button.Text=="DIB CAR")
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
            }
            else if (dibs_button.Text=="END RENTAL")
            {
                NpgsqlCommand end = new NpgsqlCommand("DELETE FROM dibs WHERE buyer='" + Session["username"] + "'", conn);
                end.ExecuteNonQuery();
                dibs_button.Text = "DIB CAR";
                state_label.Text = "";
            }
            



        }
    }
}