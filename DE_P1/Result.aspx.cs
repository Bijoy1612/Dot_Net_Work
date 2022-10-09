using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DE_P1
{
    public partial class Result : System.Web.UI.Page
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
            }
        }

        protected void btnresult_Click(object sender, EventArgs e)
        {
            LoadGridData();
        }
        private void LoadGridData()
        {
            DataTable dt = new DataTable();
            SqlConnection cnn;
            cnn = new SqlConnection(ConnectionStr);


            //string query = @"SELECT [ClassName] as Class,[SubName] as Subject,[StuName] as Name,[Marks] as Grade
            //                     from [dbo].[StudentInfo]
            //where ClassName = '" + ddlClass.SelectedItem.Text + "'";

            string query = @"SELECT [StuName] as Name, convert(nvarchar(50), avg(Marks)) as Grade
                            from[dbo].[StudentInfo]
                            where ClassName = '" + ddlClass.SelectedItem.Text + "' group by[StuName] order by Grade desc";

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

                foreach (DataRow row in dt.Rows)
                {
                    if (int.Parse(row["Grade"].ToString()) > 80)
                    {
                        row["Grade"] = "A";
                    }
                    else if (int.Parse(row["Grade"].ToString()) > 70)
                    {
                        row["Grade"] = "B";
                    }
                    else if (int.Parse(row["Grade"].ToString()) > 60)
                    {
                        row["Grade"] = "C";
                    }
                    else if (int.Parse(row["Grade"].ToString()) > 50)
                    {
                        row["Grade"] = "D";
                    }
                    else if (int.Parse(row["Grade"].ToString()) > 40)
                    {
                        row["Grade"] = "E";
                    }
                    else if(int.Parse(row["Grade"].ToString()) < 40)
                    {
                        row["Grade"] = "F";
                    }
                }  
                gvUserInfo.DataSource = dt;
                gvUserInfo.DataBind();


            }
            else
            {
                gvUserInfo.DataSource = null;
                gvUserInfo.DataBind();
            }
        }
    }
}