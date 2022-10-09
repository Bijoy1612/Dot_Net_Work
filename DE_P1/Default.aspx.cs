using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace DE_P1
{
    public partial class _Default : Page
    {
        string ConnectionStr = @"Data Source = BIJOY\ASUS; Initial Catalog = DataEdgeP1; User ID = sa; Password = 123";
        public static DropDownList FillClass(DropDownList ddl)
        {
            
            DataTable dt = new DataTable();
            String query = @"SELECT [ID] ,[ClassName] FROM [dbo].[Class]";
            dt = loaddt(query);
            ddl.DataSource = dt;
            ddl.DataTextField = "ClassName";
            ddl.DataValueField = "ID";
            ddl.DataBind();

            ListItem li = new ListItem("Select.....", "0");
            ddl.Items.Insert(0, li);
            return ddl;
        }
        public static DropDownList FillSubject(DropDownList ddl)
        {

            DataTable dt = new DataTable();
            String query = @"SELECT [ID] ,[SubName] FROM [dbo].[Subjects]";
            dt = loaddt(query);
            ddl.DataSource = dt;
            ddl.DataTextField = "SubName";
            ddl.DataValueField = "ID";
            ddl.DataBind();

            ListItem li = new ListItem("Select.....", "0");
            ddl.Items.Insert(0, li);
            return ddl;
        }
        private static DataTable loaddt(string query)
        {
            string ConnectionStr = @"Data Source = BIJOY\ASUS; Initial Catalog = DataEdgeP1; User ID = sa; Password = 123";

            DataTable dt = new DataTable();
            SqlConnection cnn;
            cnn = new SqlConnection(ConnectionStr);


            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();

            using (SqlCommand cmd = new SqlCommand(query, cnn))
            {
                cnn.Open();
                sda.SelectCommand = cmd;
                sda.Fill(ds);
                dt = ds.Tables[0];
            }
            return dt;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillClass(ddlClass);
                FillSubject(ddlSubject);
                LoadGridData();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int save = saveinfo();
            if(save > 0)
            {
                ClearFieldValue();
                LoadGridData();
            }
            
        }
        
        private int saveinfo()
        {
            int save = 0;
            SqlConnection cnn;
            cnn = new SqlConnection(ConnectionStr);

            string query = @"INSERT INTO [dbo].[StudentInfo]
           ([ClassName],[SubName],[StuName],[Marks])
                VALUES
           (@ClassName,@SubName,@StuName,@Marks)";

            using (SqlCommand cmd = new SqlCommand(query, cnn))
            {
                cmd.Parameters.AddWithValue("@ClassName", ddlClass.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@SubName", ddlSubject.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@StuName", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@Marks", txtMark.Text.Trim());
                cnn.Open();
                save = cmd.ExecuteNonQuery();
            }

                return save;
        }
        private void ClearFieldValue()
        {
            ddlClass.SelectedValue = "0";
            ddlSubject.SelectedValue = "0";
            txtName.Text = "";
            txtMark.Text = "";

        }

        private void LoadGridData()
        {
            DataTable dt = new DataTable();
            SqlConnection cnn;
            cnn = new SqlConnection(ConnectionStr);


            string query = @"SELECT [ClassName] as Class,[SubName] as Subject,[StuName] as Name,[Marks] from [dbo].[StudentInfo]";


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