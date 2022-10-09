using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Data;
using Microsoft.Reporting.WebForms;

namespace SchoolManagementSystem
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        CommonDAL objc = new CommonDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt = objc.loaddt("EXEC [SetupSp_GetStudentProfile] 1");
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.DataSources.Clear();
                //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DsStudentProfile", dt));
                //ReportViewer1.LocalReport.Refresh();

                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/rdlcTest.rdlc");
                //RVSInv.LocalReport.DataSources.Clear();
                ReportDataSource rdc = new ReportDataSource("StudentProfile", dt);
                ReportViewer1.LocalReport.DataSources.Add(rdc);
                ReportViewer1.LocalReport.Refresh();

            }
        }
    }
}