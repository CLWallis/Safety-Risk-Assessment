using SRA.ClassCode;
using System;

namespace SRA
{
    public partial class InProcessRiskAssessments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //!! get machineId from dropdown default.aspx !!
            int num2 = 2;
           
            Utils ut = new Utils(num2);
            lblMachineNumberUpdate.Text = "Machine Number: " + ut.MachineNumber;
            lblMachineTypeUpdate.Text = "Machine Type: " + ut.MachineType;
            lblMachineDateUpdate.Text = "Date: " + ut.MachineDate;
        }
    }
}