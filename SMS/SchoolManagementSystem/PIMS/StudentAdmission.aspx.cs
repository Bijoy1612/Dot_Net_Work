using DAL;
using DAL.Entity;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoolManagementSystem.PIMS
{
    public partial class StudentAdmission : System.Web.UI.Page
    {
        StudentProfileBll objStuBll = new StudentProfileBll();
        CommonDAL objc = new CommonDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdnStuId.Value = Request.QueryString["StudentId"].ToString();
                txtName.Text = objc.loadStr("SELECT FirstName+' '+LastName FROM StudentProfile WHERE (StudentId = "+ hdnStuId.Value + ")");
                loadSessionYear();
                CommonDAL.Fillddl(ddlShift, @"SELECT ShiftId, ShiftName FROM Conf_Shift", "ShiftName", "ShiftId");
                CommonDAL.Fillddl(ddlClass, @"
SELECT SchoolClassId, ClassName FROM Conf_SchoolClass", "ClassName", "SchoolClassId");
            }
        }
        public void RefreshParentPage()
        {
            runScript.Text = "<script>if (window.opener != null && !window.opener.closed){var hiddenfield=window.opener.ParentRefrash();hiddenfield.value='true';window.opener.document.forms[0].submit();}</script>";
        }
        private void LoadRegNo()
        {
            if (ddlShift.SelectedValue!="0" || ddlSession.SelectedValue != "0" || ddlClass.SelectedValue != "0"  )
            {
                string sYear = ddlSession.SelectedValue;
                string shift = ddlShift.SelectedValue;
                string aClass = ddlClass.SelectedValue;
             
                hdnRegsl.Value = objc.loadStr(@"SELECT  ISNULL(MAX(RegSl),'0') AS RegSl
            FROM Student_Admission WHERE(SessionYear = " + sYear + ") AND(Shift = " + shift + ") AND(ClassId = " + aClass + ")");

                string regno = "KR"+sYear.Substring(2, 2) + ddlShift.SelectedItem.Text.Substring(0,1) + aClass.PadLeft(2, '0') + (int.Parse(hdnRegsl.Value) + 1).ToString().PadLeft(3, '0');
                txtRegNo.Text = regno;
            }
            else
            {
                rmmsg.FailureMessage = "Select proper info first.";
                txtRegNo.Text = "";
            }
            
        }
        private void loadSessionYear()
        {
            ListItem li1 = new ListItem("Select.....", "0");
            ListItem li2 = new ListItem((DateTime.Now.Year+1).ToString(), (DateTime.Now.Year +1).ToString());

            ddlSession.Items.Insert(0, li1);
            ddlSession.Items.Insert(1, li2);
            for (int i = 2; i < 10; i++)
            {
                ListItem li = new ListItem((DateTime.Now.Year-(i-2)).ToString(), (DateTime.Now.Year - (i - 2)).ToString());
                ddlSession.Items.Insert(i, li);
            }
           
        }

        protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRegNo();
        }

        private void Save()
        {
            int save = 0;

            EStudentProfile objEStuPro = new EStudentProfile();

            objEStuPro.RegSl = int.Parse(hdnRegsl.Value)+1;
            objEStuPro.RegistrationNo = txtRegNo.Text;
            objEStuPro.RollNo = int.Parse(txtRoll.Text);
            objEStuPro.SessionYear = int.Parse(ddlSession.SelectedValue);
            objEStuPro.AdmissionDate = Convert.ToDateTime(txtDate.Text);
            objEStuPro.Shift = int.Parse(ddlShift.SelectedValue);
            objEStuPro.ClassId = int.Parse(ddlClass.SelectedValue);
            objEStuPro.StudentId = int.Parse(hdnStuId.Value);
            objEStuPro.EntryBy = int.Parse(Session["UserId"].ToString());

            save = objStuBll.InsertAdmissionInfo(objEStuPro);
            if (save > 0)
            {
                rmmsg.SuccessMessage = "Save Done";
                RefreshParentPage();
            }
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            Save();            
        }
    }
}