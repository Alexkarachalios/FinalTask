﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalTask
{
    public partial class choice : System.Web.UI.Page
    {


       

        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "Welcome "+Session["username"].ToString()+"!";
               
           
        }

       

       

        protected void Search_Click(object sender, EventArgs e)
        {

        }

        protected void NewEntry_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}