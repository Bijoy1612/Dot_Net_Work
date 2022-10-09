using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Windows;

namespace RealProjectB2.auth
{
    public partial class ContactInfo : System.Web.UI.Page
    {
     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
                btnSave.Text = "Save";
            }
            txtContactNo.Attributes.Add("OnKeyUp", "chkNumber('"+txtContactNo.ClientID+"')");

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int result = 0;

            if (btnSave.Text=="Save")
            {
                result= SaveUReg();
                if (result>0)
                {
                    LoadGrid();
                    MessageBox.Show("Save");
                }
                else
                {
                    MessageBox.Show("Save Fail");
                }
               
            }
            else
            {
                result = UpdateUReg();
                if (result > 0)
                {
                    LoadGrid();
                    MessageBox.Show("Update");
                }
                else
                {
                    MessageBox.Show("Update Fail");
                }
            }
          
        }
        string Constr = "Data Source=DOT-NET; Initial Catalog=DotNetB2; Integrated Security=true; ";
        private int SaveUReg()
        {
            int result = 0;
            SqlConnection cnn;
            cnn = new SqlConnection(Constr);
            // SqlCommand cmd;
            string query = @"INSERT INTO dbo.ContactInfo
           (Name
           ,ContactNo
           ,Email
           ,Social
           ,EntryBy
           ,EntryDate)
     VALUES
           (@Name
           ,@ContactNo
           ,@Email
           ,@Social
           ,@EntryBy
           ,Getdate())";

            using (SqlCommand cmd = new SqlCommand(query, cnn))
            {
                cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@ContactNo", txtContactNo.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Social", txtSocial.Text.Trim());
                cmd.Parameters.AddWithValue("@EntryBy", Session["UserId"].ToString());
               
                cnn.Open();
                result = cmd.ExecuteNonQuery();
                cnn.Close();
            }


            return result;
        }

        private int UpdateUReg()
        {
            int result = 0;
            SqlConnection cnn;
            cnn = new SqlConnection(Constr);
            // SqlCommand cmd;
            string query = @"Update ContactInfo
                    SET
                    Name = @Name,
                    ContactNo=@ContactNo,
                    Email=@Email,
                    Social=@Social,
                    UpdateBy=@UpdateBy,
                    UpdateDate=getdate()
                    where Cid= @Cid";

            using (SqlCommand cmd = new SqlCommand(query, cnn))
            {
                cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@ContactNo", txtContactNo.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Social", txtSocial.Text.Trim());
                cmd.Parameters.AddWithValue("@UpdateBy", Session["UserId"].ToString());
                cmd.Parameters.AddWithValue("@Cid", hdnEditCid.Value);

                cnn.Open();
                result = cmd.ExecuteNonQuery();
                cnn.Close();
            }


            return result;
        }
        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            SqlConnection cnn;
            cnn = new SqlConnection(Constr);
            // SqlCommand cmd;
            string query = @"Select Name,ContactNo,Email,Social,EntryBy,EntryDate,Cid From dbo.ContactInfo";
            using (SqlCommand cmd = new SqlCommand(query, cnn))
            {
                DataSet ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                sda.Fill(ds);
                dt = ds.Tables[0];
            }
            if (dt.Rows.Count>0)
            {
                gvCon.DataSource = dt;
                gvCon.DataBind();
            }
        }

        protected void gvCon_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName== "editc")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                HiddenField hdncid = (HiddenField)gvCon.Rows[rowIndex].Cells[0].FindControl("hdncid");
                FillControl(int.Parse(hdncid.Value));
            }
        }

        private void FillControl(int cid)
        {
            DataTable dt = new DataTable();
            SqlConnection cnn;
            cnn = new SqlConnection(Constr);
            // SqlCommand cmd;
            string query = @"Select Name,ContactNo,Email,Social,EntryBy,EntryDate,Cid 
                            From dbo.ContactInfo where Cid = "+cid+" ";
            using (SqlCommand cmd = new SqlCommand(query, cnn))
            {
                DataSet ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                sda.Fill(ds);
                dt = ds.Tables[0];
            }
            if (dt.Rows.Count > 0)
            {
                txtName.Text = dt.Rows[0]["Name"].ToString();
                txtContactNo.Text = dt.Rows[0]["ContactNo"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtSocial.Text = dt.Rows[0]["Social"].ToString();
                hdnEditCid.Value = dt.Rows[0]["Cid"].ToString();

                btnSave.Text = "Update";
            }
        }

    }
}