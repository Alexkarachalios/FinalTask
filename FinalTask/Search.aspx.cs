using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;

namespace FinalTask
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            location.Value = Session["latlng"].ToString();

            //kwdikas gia na emfanizei ta stoixeia twn 4 kontinoterwn autokinhtwn
            car1_label.Text = "";
            car2_label.Text = "";
            car3_label.Text = "";
            car4_label.Text = "";
        }

        protected void location_ValueChanged(object sender, EventArgs e)
        {

        }

        protected void car1button_Click(object sender, EventArgs e)
        {

        }

        protected void car2_button_Click(object sender, EventArgs e)
        {

        }

        protected void car3_button_Click(object sender, EventArgs e)
        {

        }

        protected void car4__button_Click(object sender, EventArgs e)
        {

        }
    }
}