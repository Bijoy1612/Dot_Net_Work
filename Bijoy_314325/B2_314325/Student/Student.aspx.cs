using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace B2_314325.Student
{
    public partial class Student : System.Web.UI.Page
    {
        string ConnectionStr = @"Data Source = BIJOY\ASUS; Initial Catalog = DotNetB1; User ID = sa; Password = 123";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divMsg.Visible = false;
                LoadGridData();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckFieldValue())
            {
                int saveStat = saveUserReg();
                if (saveStat > 0)
                {
                    ClearFieldValue();
                    divMsg.Visible = true;
                    lblMsg.Text = "Save Successful";
                    LoadGridData();
                }
                else
                {
                    divMsg.Visible = true;
                    lblMsg.Text = "Save Failed";
                }
            }
        }

        private bool CheckFieldValue()
        {
            bool isRequired = false;

            if (txtFirstName.Text == "")
            {
                isRequired = true;
                lblMsg.Text = "First Name cannot be empty!";
            }
            else if (txtContact1.Text == "")
            {
                isRequired = true;
                lblMsg.Text = "Contact number cannot be empty!";
            }
            else if (txtEmail.Text == "")
            {
                isRequired = true;
                lblMsg.Text = "Email cannot be empty!";
            }
            else if (ddlGender.SelectedValue == "0")
            {
                isRequired = true;
                lblMsg.Text = "Please select a gender!";
            }
            else if (ddlstype.SelectedValue == "0")
            {
                isRequired = true;
                lblMsg.Text = "Please select Student Type!";
            }

            if (isRequired)
            {
                divMsg.Visible = true;
            }
            else
            {
                divMsg.Visible = false;
            }
            return isRequired;
        }
        private void ClearFieldValue()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtFatherName.Text = "";
            txtMotherName.Text = "";
            txtContact1.Text = "";
            txtContact2.Text = "";
            txtEmail.Text = "";
            txtDOB.Text = "";
            ddlGender.SelectedValue = "0";
            ddlstype.SelectedValue = "0";
            txtPostCode.Text = "";
            txtAddress.Text = "";
        }

        private int saveUserReg()
        {
            int save = 0;
            SqlConnection cnn;
            cnn = new SqlConnection(ConnectionStr);
            string query = @"INSERT INTO [dbo].[StudentForm]
                        ([FirstName],[LastName],[FatherName],[MotherName],[Contact1],[Contact2],[Email],[DateofBirth],[Gender],[StudentType],[PostCode],[Address])
                             VALUES
                        (@FirstName,@LastName,@FatherName,@MotherName,@Contact1,@Contact2,@Email,@DateofBirth,@Gender,@StudentType,@PostCode,@Address)";

            using (SqlCommand cmd = new SqlCommand(query, cnn))
            {
                cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                cmd.Parameters.AddWithValue("@FatherName", txtFatherName.Text.Trim());
                cmd.Parameters.AddWithValue("@MotherName", txtMotherName.Text.Trim());
                cmd.Parameters.AddWithValue("@Contact1", txtContact1.Text.Trim());
                cmd.Parameters.AddWithValue("@Contact2", txtContact1.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@DateofBirth", txtDOB.Text.Trim());
                cmd.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue);
                cmd.Parameters.AddWithValue("@StudentType", ddlstype.SelectedValue);
                cmd.Parameters.AddWithValue("@PostCode", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim()); 
                cnn.Open();
                save = cmd.ExecuteNonQuery();
            }

            //Console.WriteLine(query);
            SqlDataAdapter sda = new SqlDataAdapter();
            return save;
        }
        private void LoadGridData()
        {
            DataTable dt = new DataTable();
            SqlConnection cnn;
            cnn = new SqlConnection(ConnectionStr);


            string query = @"SELECT * from [dbo].[StudentForm]";
            

            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();

            using (SqlCommand cmd = new SqlCommand(query, cnn))
            {
                cnn.Open();
                sda.SelectCommand = cmd;
                sda.Fill(ds);
                dt = ds.Tables[0];
            }

            if (dt.Rows.Count > 0)
            {
                gvUserInfo.DataSource = dt;
                gvUserInfo.DataBind();
            }
        }
    }

}