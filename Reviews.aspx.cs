using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projectnewgadi
{
    public partial class Reviews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("LoReUpForm.aspx");
            }
        }

        protected void TextCheck_Click(object sender, EventArgs e)
        {
            string text = Text.Text;
            if (text.Length > 50 && text.Length < 200) 
            {
                LoReUp name = (LoReUp)Session["user"];
                UserStats user = new UserStats();
                bool b = user.AddTextToData(name.GetUser(), text);
                if (b == true)
                {
                    ResultText.Text = "The text saved in data base";
                }
                else
                {
                    ResultText.Text = "You already saved this text in data base";
                }
            }
            else
            {
                ResultText.Text = "Not enough/too many chars";
            }
        }

        protected void TypeRacer_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.html");
        }

        protected void UserStats_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProfilePage.aspx");
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

        protected void MainPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
        protected void loles_Click(object sender, EventArgs e)
        {
            string usertext = "katriel";
            string text = "lol gg ez bot our jungle sucks 0/10 yasou player no brains mastery 5 with 1,000,000 points lol lol you noob without brains";
            UserStats gg = new UserStats();
            LoReUp bb = (LoReUp)Session["user"];
            gg.LikeAtext(text, usertext, bb.GetUser());
        }
    }
}