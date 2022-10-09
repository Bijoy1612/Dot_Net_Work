using DAL;
using DAL.Entity;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SchoolManagementSystem.PIMS
{
    public partial class StuAttendance : System.Web.UI.Page
    {
        StudentProfileBll objStuBll = new StudentProfileBll();
        CommonDAL objc = new CommonDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                CommonDAL.Fillddl(ddlShift, @"SELECT ShiftId, ShiftName FROM Conf_Shift", "ShiftName", "ShiftId");
                CommonDAL.Fillddl(ddlClass, @"
SELECT SchoolClassId, ClassName FROM Conf_SchoolClass", "ClassName", "SchoolClassId");

            }
        }
        private bool checkValue()
        {
            rmmsg.SetResponseMessageVisibleFalse();
            bool isReq = false;
            DataTable dt = new DataTable();

            if (gvClassShedule.Rows.Count > 0)
            {
               
            }

            return isReq;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Save();
        }
         
   
        List<EClassShedule> collection = new List<EClassShedule>();
        ClassSheduleBLL objclssBLL = new ClassSheduleBLL();
        private void Save()
        {
            if (gvClassShedule.Rows.Count>0)
            {
                int save = 0;
                DataTable dt = new DataTable();
                dt = (DataTable)ViewState["classShedule"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    EClassShedule objclss = new EClassShedule();
                    objclss.ShiftId =int.Parse(dt.Rows[i]["ShiftId"].ToString());
                    objclss.ClassID =int.Parse(dt.Rows[i]["ClassID"].ToString());
                    objclss.WeekDay =(dt.Rows[i]["WeekDay"].ToString());
                    objclss.SubjectId =int.Parse(dt.Rows[i]["SubjectId"].ToString());
                    objclss.StartTime =DateTime.Parse(dt.Rows[i]["StartTime"].ToString());
                    objclss.EndTime =DateTime.Parse(dt.Rows[i]["EndTime"].ToString());
                    objclss.EntryBy =int.Parse(Session["UserId"].ToString());
                    collection.Add(objclss);

                }
                save=objclssBLL.InsertUpdateDelete_InstituteBLL(collection);
                if (save>0)
                {
                    rmmsg.SuccessMessage = "Save Done";
                }
                else
                {
                    rmmsg.FailureMessage = "Save failure";
                }
            }
            else
            {
                rmmsg.FailureMessage = "There is no Class Shedule.";
            }
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string sqlStr = @"SELECT        StudentProfile.StudentId, Student_Admission.RollNo, StudentProfile.FirstName + N' ' + StudentProfile.LastName AS StuName, Student_Admission.Shift, Student_Admission.ClassId
            FROM            StudentProfile INNER JOIN
            Student_Admission ON StudentProfile.StudentId = Student_Admission.StudentId
            WHERE        (Student_Admission.IsActive = 1) AND (Student_Admission.Shift = "+ddlShift.SelectedValue+") AND (Student_Admission.ClassId = "+ddlClass.SelectedValue+")";
            dt = objc.loaddt(sqlStr);
            gvClassShedule.DataSource = dt;
            gvClassShedule.DataBind();
        }
    }
}