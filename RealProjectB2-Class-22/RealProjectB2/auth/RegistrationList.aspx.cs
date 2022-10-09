using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealProjectB2.auth
{
    public partial class RegistrationList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGridData();
            }
        }

        private void LoadGridData()
        {
            string religion = ddlReligion.SelectedValue;
            string gender = ddlGender.SelectedValue;
            DataTable dt = new DataTable();
            string Constr = "Data Source=DOT-NET; Initial Catalog=DotNetB2; Integrated Security=true; ";
            SqlConnection cnn;
            cnn = new SqlConnection(Constr);
            string query = @"select UserId, UserName, 
            (Firstname+' '+ISNULL(MidleName,'')+' '+LastName) AS Fullname ,
            (case when Gender=1 then 'Male' when Gender=2 then 'Female' else 'Others' end ) AS Gender
            ,convert(varchar(15),DateofBirth,103) as DateofBirth,ContactNo,ReligionName
            from [dbo].[UserRegistration] inner join
            Conf_Religion on UserRegistration.ReligionId =Conf_Religion.ReligionId
            where (UserRegistration.ReligionId = " + religion + " or "+ religion + @"=0)
            and (Gender ="+ gender + " or "+ gender + "=0)";

            using (SqlCommand cmd=new SqlCommand(query,cnn))
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                DataSet ds = new DataSet();
                cnn.Open();
                sda.SelectCommand = cmd;
                sda.Fill(ds);
                dt = ds.Tables[0];
            }

            if (dt.Rows.Count>0)
            {
                gvRegList.DataSource = dt;
                gvRegList.DataBind();
            }
            else
            {
                gvRegList.DataSource = null;
                gvRegList.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadGridData();
        }
    }
}