using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealProjectB2.auth
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divMsg.Visible = false;
            }
        }

    
       
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckFieldValue() == false)
            {
                int result = SaveUReg();
                if (result > 0)
                {
                    ClearFieldValue();
                    divMsg.Visible = true;
                    lblMsg.Text = "Save Success";

                }
                else
                {
                    divMsg.Visible = true;
                    lblMsg.Text = "Save Fail";
                }
            }    
           
        }
        #region Method
        private void ClearFieldValue()
        {
            txtuserName.Text = "";
            txtFirstName.Text = "";
            txtMidName.Text = "";
            txtLastName.Text = "";
            ddlGender.SelectedValue = "0";
            txtDateOfBirth.Text = "";

            flUserImage.PostedFile.InputStream.Dispose();
        }
        /// <summary>
         /// /
         /// </summary>
         /// <returns></returns>
        private int SaveUReg()
        {

            int result = 0;

            string Constr = "Data Source=DOT-NET; Initial Catalog=DotNetB2; Integrated Security=true; ";
            SqlConnection cnn;
            cnn = new SqlConnection(Constr);
            // SqlCommand cmd;

            string query = @"INSERT INTO dbo.UserRegistration
                (UserName,Firstname,MidleName,LastName,Gender,DateofBirth,ContactNo
                ,Email,Address,ReligionId,EntryDate,UserImage)
                VALUES
                (@UserName,@Firstname,@MidleName,@LastName,@Gender,@DateofBirth
                ,@ContactNo,@Email,@Address,@ReligionId,GETDATE(),@UserImage)";

            using (SqlCommand cmd = new SqlCommand(query, cnn))
            {
                cmd.Parameters.AddWithValue("@UserName", txtuserName.Text.Trim());
                cmd.Parameters.AddWithValue("@Firstname", txtFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@MidleName", txtMidName.Text.Trim());
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                cmd.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue);
                cmd.Parameters.AddWithValue("@DateofBirth", txtDateOfBirth.Text);
                cmd.Parameters.AddWithValue("@ContactNo", txtContact.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@ReligionId", ddlReligion.SelectedValue);
                //cmd.Parameters.AddWithValue("@EntryDate", txtuserName.Text);
                cmd.Parameters.AddWithValue("@UserImage", "1.png");
                cnn.Open();
                result = cmd.ExecuteNonQuery();
                cnn.Close();
            }


            return result;
        }
        private bool CheckFieldValue()
        {
            bool IsReq = false;

            if (txtuserName.Text == "")
            {
                lblMsg.Text = "Username can't be empty";
                txtuserName.Focus();
                IsReq = true;
            }
            else if (txtFirstName.Text == "")
            {
                lblMsg.Text = "First name can't be empty";
                txtFirstName.Focus();
                IsReq = true;
            }
            else if (txtLastName.Text == "")
            {
                lblMsg.Text = "First name can't be empty";
                txtLastName.Focus();
                IsReq = true;
            }
            else if (ddlGender.SelectedValue == "0")
            {
                lblMsg.Text = "Select gender";
                IsReq = true;
            }

            if (IsReq == true)
            {
                divMsg.Visible = true;
            }
            else
            {
                divMsg.Visible = false;
            }

            return IsReq;

        } 
        #endregion

    }
}