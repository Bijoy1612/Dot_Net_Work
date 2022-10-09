using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealProjectB2
{
    public partial class TestOne : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] != null && Session["UserId"] != null)
                {
                    //lblUsername.Text = Session["Username"].ToString();
                    //string userImg = Session["UserImg"].ToString();
                    //imgUser.ImageUrl = "~/assets/img/users/" + userImg;
                }
                else
                {
                    Response.Redirect("~/login.aspx");
                }
            }

        }
    }
}