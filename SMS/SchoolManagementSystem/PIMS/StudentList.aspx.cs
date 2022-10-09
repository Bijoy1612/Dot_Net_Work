using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.PIMS
{
    public partial class StudentList : System.Web.UI.Page
    {
        StudentProfileBll objStuBll = new StudentProfileBll();
        StudentProfileDAL objStuDAL = new StudentProfileDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonDAL.Fillddl(ddlDistrict, "SELECT DistrictId,DistrictName FROM Conf_District Order By DistrictName", "DistrictName", "DistrictId");
                LoadGrid();

                if (hdnUpdateCount.Value== "true")
                {
                    LoadGrid();
                }
            }
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonDAL.Fillddl(ddlUpazila, "SELECT UpazilaId,UpazilaName FROM Conf_Upazila  Where (DistrictId=" + ddlDistrict.SelectedValue + ") Order By UpazilaName", "UpazilaName", "UpazilaId");

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
        private void LoadGrid()
        {
            int Upazila = 0;
            if (ddlUpazila.SelectedIndex!=-1)
            {
                Upazila = int.Parse(ddlUpazila.SelectedValue);
            }

            DataTable dt = new DataTable();
            dt = objStuBll.StudentListforAddmissionInfo(txtFirstName.Text, int.Parse(ddlDistrict.SelectedValue), Upazila, txtContactNumber.Text);

            if (dt.Rows.Count > 0)
            {
                gvStudentProfile.DataSource = dt;
                gvStudentProfile.DataBind();
            }
            else
            {
                gvStudentProfile.DataSource = null;
                gvStudentProfile.DataBind();
            }
        }

        protected void gvStudentProfile_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowindex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnStudentId = (HiddenField)gvStudentProfile.Rows[rowindex].FindControl("hdnStudentId");
            HiddenField hdnAdmissionId = (HiddenField)gvStudentProfile.Rows[rowindex].FindControl("hdnAdmissionId");

            if (e.CommandName == "admission")
            {
              
                string url = "StudentAdmission.aspx?StudentId=" + hdnStudentId.Value+"&adId=1";
                string totalUrl = "var Mleft = (screen.width/2)-(800/2);var Mtop = (screen.height/2)-(500/2);window.open( '" + url + "', null, 'height=500,width=820,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );";
                ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", totalUrl, true);

            }
            else if (e.CommandName == "adcancel")
            {
               int det= objStuDAL.DeleteAdmission(int.Parse(hdnAdmissionId.Value));
                if (det>0 )
                {
                    rmMsg.SuccessMessage = "Delete Done.";
                    LoadGrid();
                }
            }
        }

        protected void gvStudentProfile_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            for (int i = 0; i < gvStudentProfile.Rows.Count; i++)
            {
                Label lblClass = (Label)gvStudentProfile.Rows[i].FindControl("lblClass");
                LinkButton lblAdCancel = (LinkButton)gvStudentProfile.Rows[i].FindControl("lblAdCancel");
                ImageButton imgEdit = (ImageButton)gvStudentProfile.Rows[i].FindControl("imgEdit");
                imgEdit.Visible = false;

                if (lblClass.Text=="")
                {
                    lblClass.Text = "Not Admited";
                    lblAdCancel.Visible = false;
                    imgEdit.Visible = true;
                }
            }
        }
    }
}