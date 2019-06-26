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
        protected void Page_Load(object sender, EventArgs e)
        {

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

            }
        }
    }
}