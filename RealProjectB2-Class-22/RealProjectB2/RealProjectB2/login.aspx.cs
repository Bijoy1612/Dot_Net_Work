using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealProjectB2
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divMsg.Visible = false;
                RememberMe();
            }
            
        }

        private void RememberMe()
        {
            if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
            {
                txtUsername.Text = Request.Cookies["UserName"].Value;
                txtPassword.Attributes["Value"] = Request.Cookies["Password"].Value;
            }
            else
            {
                txtUsername.Text = "";
                txtPassword.Attributes["Value"] = "";

            }
        }

        private DataTable LoginCheck(string UserName, string UPass)
        {
            DataTable dt = new DataTable();
            string Constr = "Data Source=DOT-NET; Initial Catalog=DotNetB2; User ID=sa; Password=123 ";
            SqlConnection cnn;
            cnn = new SqlConnection(Constr);
            SqlCommand cmd;

            string sqlStr = @"Select UserAuth.UserId,
            (ur.Firstname + ' ' + ISNULL(ur.MidleName, '') + ' ' + ur.LastName) as FullName,
            [UserImage]
            from UserAuth inner join
            UserRegistration ur on UserAuth.UserId = ur.UserId
            WHERE IsActive = 1 and UserAuth.UserName = '"+UserName+"' and UPassword = '"+UPass+"' ";
            SqlDataAdapter sda = new SqlDataAdapter();
            try
            {
                cnn.Open();
                cmd = new SqlCommand(sqlStr,cnn);

                sda.SelectCommand = cmd;
                sda.Fill(dt);

                cnn.Close();
            }
            catch (Exception)
            {

            }
            return dt;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (CheckFieldValue()==false)
            {
                DataTable dtloginInfo = new DataTable();
                dtloginInfo = LoginCheck(txtUsername.Text.Trim(), txtPassword.Text);

                if (dtloginInfo.Rows.Count>0)
                {
                    Session["UserId"] = dtloginInfo.Rows[0]["UserId"].ToString();
                    Session["Username"] = dtloginInfo.Rows[0]["FullName"].ToString();
                    Session["UserImg"] = dtloginInfo.Rows[0]["UserImage"].ToString();
                    CreateCookie();
                    Response.Redirect("~/AdminHome.aspx");
                }
                else
                {
                    lblMsg.Text = "Incorrect Username or Password";
                    divMsg.Visible = true;
                }
            }

        }

        private void CreateCookie()
        {
            if (cbRemember.Checked)
            {

                HttpCookie auth = new HttpCookie("auth");
                auth["UserName"] = "";
                auth["Password"] = "";
                Response.Cookies.Add(auth);

                Response.Cookies["UserName"].Expires = DateTime.Now.AddMinutes(30);
                Response.Cookies["Password"].Expires = DateTime.Now.AddMinutes(30);

                Response.Cookies["UserName"].Value = txtUsername.Text.Trim();
                Response.Cookies["Password"].Value = txtPassword.Text.Trim();

            }
            else
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddMinutes(-1);
                Response.Cookies["Password"].Expires = DateTime.Now.AddMinutes(-1);
            }

            
        }

        private bool CheckFieldValue()
        {
            bool IsReq = false;

            if (txtUsername.Text=="")
            {
                lblMsg.Text = "Username can't be empty";
                txtUsername.Focus();
                IsReq = true;
            }
            else if (txtPassword.Text=="")
            {
                lblMsg.Text = "Password can't be empty";
                txtPassword.Focus();
                IsReq = true;
            }

            if (IsReq==true)
            {
                divMsg.Visible = true;
            }
            else
            {
                divMsg.Visible = false;
            }

            return IsReq;

        }

    }
}