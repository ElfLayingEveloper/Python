using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projectnewgadi
{
    public partial class TopPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("LoReUpForm.aspx");
            }
       
        }

        protected void MainPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void TypeRacer_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.html");
        }

        protected void UserStats_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProfilePage.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("LoReUpForm.aspx");
        }

        protected void TextReview_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reviews.aspx");
        }
    }
}