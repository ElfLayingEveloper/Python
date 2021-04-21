using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projectnewgadi
{
    public partial class ProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("LoReUpForm.aspx");
            }
            UserStats user = new UserStats();
            LoReUp name = (LoReUp)Session["user"];
            Username.Text = "Username: " + name.GetUser();
            Password.Text = "Password: " + name.Getpass();
            TimePlayed.Text = "Time played: " + user.ReturnUserTIME(name.GetUser());
            WPM.Text = "WPM: " + user.ReturnUserVPM_AVG(name.GetUser());
            Acurracy.Text = "Accuracy: " + user.ReturnUserACC_AVG(name.GetUser());
            Trails.Text = "Trails: " + user.ReturnUserTrails(name.GetUser());
            Points.Text = "Points: " + user.ReturnUserPoints(name.GetUser());
        }

        protected void MainPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void TypeRacer_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.html");
        }

        protected void TOP_Click(object sender, EventArgs e)
        {
            Response.Redirect("TopPage.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("LoReUpForm.aspx");
        }

        protected void PasswordChange_Click(object sender, EventArgs e)
        {
            string newpassword = PasswordChange.Text + "";
            LoReUp user = (LoReUp)Session["user"];
            user.SetPass(newpassword);
            Session["user"] = user;//c# update
            UserStats Changepassword = new UserStats();
            Changepassword.ChangeUserPassword(user.GetUser(), newpassword);//SQL update
            Password.Text = "Password: " + user.Getpass();//Visual update
        }

        protected void TextReview_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reviews.aspx");
        }
    }
}