using System;
using System.Data;
using System.Data.SqlClient;
using SRA.ClassCode;

namespace SRA
{
    public partial class AddRisk : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if the page is being loaded for the first time
            if (!IsPostBack) {
                //fill dropdown menus
                
                /*NOTE: for variety dropdowns are filled using 3 different procedures.
                 1. Fill dropdown directly in code from an array of values. FillDropDowns()
                 NumberOfPersons dropdowns are filled this way.
                 2. Create a stored procedure to select records, create method GetFrequencyValues()
                 to connect to the SRA database, retrieve the appropriate rows and bind them to a 
                 dropdown. Frequency dropdowns are filled this way.
                 3. Create a stored procedure, use the datasource control to fill the dropdowns. Severity
                 and Likelihood dropdowns are filled this way.*/
                 
                FillDropDowns();
                GetFrequencyValues();
                GetMachineIdentity();
               
                //if (Session["lastInsertedMachineID"] != null)
                //{
                //    int last = (int)(Session["lastInsertedMachineID"]);
                //    testMessage.Text = last.ToString();
                //}
            }
        }

        //variables used by several methods
        private string dropdownName;
        private string dropdownValue;
     
        //dropdowns must be filled with strings
        protected void FillDropDowns()
        {
            string[] numberOfPersonsValues = new string[] { "1", "2", "4", "8", "12" };

            //add values to number of persons dropdowns
            for (int i = 0; i < numberOfPersonsValues.Length; i++)
            {
                ddlHazardNumberOfPersons.Items.Add(numberOfPersonsValues[i]);
                ddlReductionSolutionNumberOfPersons.Items.Add(numberOfPersonsValues[i]);
                ddlAdminSolutionNumberOfPersons.Items.Add(numberOfPersonsValues[i]);
            }
        }

        //use code to establish a connection to SRA db and fill Frequency dropdowns
        public void GetFrequencyValues()
        {
            Utils ut = new Utils();
            string connectionString = ut.ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("spLoadFrequencyValues", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                con.Open();

                da.Fill(ds);
                ddlHazardFrequency.DataSource = ds;
                ddlHazardFrequency.DataTextField = "frequencyValue"; //column name
                ddlHazardFrequency.DataValueField = "frequencyValue";
                ddlHazardFrequency.DataBind();

                ddlReductionSolutionFrequency.DataSource = ds;
                ddlReductionSolutionFrequency.DataTextField = "frequencyValue";
                ddlReductionSolutionFrequency.DataValueField = "frequencyValue";
                ddlReductionSolutionFrequency.DataBind();

                ddlAdminSolutionFrequency.DataSource = ds;
                ddlAdminSolutionFrequency.DataTextField = "frequencyValue";
                ddlAdminSolutionFrequency.DataValueField = "frequencyValue";
                ddlAdminSolutionFrequency.DataBind();

            }
            catch (Exception ex)
            {
                testMessage.Text = ex.Message;
            }
            finally 
            {
                con.Close(); 
            }
        }

        //get machine number and type
        public void GetMachineIdentity()
        {    
            //last is machineId of selected machine
            int last = 2;
            //int last = (int)(Session["lastInsertedMachineID"]);

            try
            {
                Utils ut = new Utils(last);
                lblMachineNumber.Text = "Machine Number: " + ut.MachineNumber;
                lblMachineType.Text = "Machine Type: " + ut.MachineType;
            }
            catch (Exception ex)//right now set up for testing
            {
                lblMachineNumber.Text = ex.Message;
            }
        }
/*
        //get the machine number to display
        public void GetMachineNumber()
        {
            //last is machineId of selected machine
            int last = 2;
            //int last = (int)(Session["lastInsertedMachineID"]);
            try
            {
                Utils ut = new Utils(last);
                lblMachineNumber.Text = "Machine Number: " + ut.MachineNumber;
            }
            catch (Exception ex)//right now set up for testing
            {
                lblMachineNumber.Text = ex.Message;
            }
            //Utils ut = new Utils();
            //string connectionString = ut.ConnectionString;
            //'using' instead of try/catch/finally, just because...
            //using calls Dispose(), therefore don't explicitly need to close connection
            //using (SqlConnection con = new SqlConnection(connectionString))
            //{
            //    SqlCommand cmd = new SqlCommand("spGetMachineNumber", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@machineId", last);
            //    con.Open();
            //    lblMachineNumber.Text = "Machine Number: " + cmd.ExecuteScalar().ToString();
            //}
        }
*/        
        //get the machine type to display
/*        public void GetMachineType()
        {
            int last = 2;
            //int last = (int)(Session["lastInsertedMachineID"]);
            try
            {
                Utils ut = new Utils(last);
                lblMachineType.Text = "Machine Number: " + ut.MachineType;
            }
            catch (Exception ex)//right now set up for testing
            {
                lblMachineNumber.Text = ex.Message;
            }
            //Utils ut = new Utils();
            //string connectionString = ut.ConnectionString;
            //using (SqlConnection con = new SqlConnection(connectionString))
            //{
            //    SqlCommand cmd = new SqlCommand("spGetMachineType", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@machineId", last);
            //    con.Open();
            //    lblMachineType.Text = "Machine Type: " + cmd.ExecuteScalar().ToString();
            //}
        }
*/
        //when a new value is chosen in hazard severity dropdown then collect the dropdown name
        //and selected value then update the other severity dropdowns by calling UpdateDropDowns
        //and update all risks by calling UpdateRisks() etc...for whatever dropdown is changed

        /******************** HAZARD ********************/

        public void UpdateHazardRiskSeverity(Object sender, EventArgs e) 
        {
            dropdownValue = ddlHazardSeverity.SelectedValue;
            dropdownName = "ddlHazardSeverity";

            UpdateDropDowns(dropdownName, dropdownValue);
            UpdateRisks();
        }
        public void UpdateHazardRiskLikelyhood(Object sender, EventArgs e) 
        {
            dropdownValue = ddlHazardLikelyhood.SelectedValue;
            dropdownName = "ddlHazardLikelyhood";

            UpdateDropDowns(dropdownName, dropdownValue);
            UpdateRisks();
        }
        public void UpdateHazardRiskFrequency(Object sender, EventArgs e)
        {
            dropdownValue = ddlHazardFrequency.SelectedValue;
            dropdownName = "ddlHazardFrequency";

            UpdateDropDowns(dropdownName, dropdownValue);
            UpdateRisks();
        }
        public void UpdateHazardRiskNumberOfPersons(Object sender, EventArgs e)
        {
            dropdownValue = ddlHazardNumberOfPersons.SelectedValue;
            dropdownName = "ddlHazardNumberOfPersons";

            UpdateDropDowns(dropdownName, dropdownValue);
            UpdateRisks();
        }
        
        /******************** REDUCTION SOLUTION ********************/
        
        public void UpdateReductionSolutionRiskSeverity(Object sender, EventArgs e)
        {
            dropdownValue = ddlReductionSolutionSeverity.SelectedValue;
            dropdownName = "ddlReductionSolutionSeverity";

            UpdateDropDowns(dropdownName, dropdownValue);
            UpdateRisks();
        }
        public void UpdateReductionSolutionRiskLikelyhood(Object sender, EventArgs e)
        {
            dropdownValue = ddlReductionSolutionLikelyhood.SelectedValue;
            dropdownName = "ddlReductionSolutionLikelyhood";

            UpdateDropDowns(dropdownName, dropdownValue);
            UpdateRisks();
        }
        public void UpdateReductionSolutionRiskFrequency(Object sender, EventArgs e)
        {
            dropdownValue = ddlReductionSolutionFrequency.SelectedValue;
            dropdownName = "ddlReductionSolutionFrequency";

            UpdateDropDowns(dropdownName, dropdownValue);
            UpdateRisks();
        }
        public void UpdateReductionSolutionRiskNumberOfPersons(Object sender, EventArgs e)
        {
            dropdownValue = ddlReductionSolutionNumberOfPersons.SelectedValue;
            dropdownName = "ddlReductionSolutionNumberOfPersons";

            UpdateDropDowns(dropdownName, dropdownValue);
            UpdateRisks();
        }

        /******************** ADMINISTRATIVE SOLUTION ********************/

        public void UpdateAdminSolutionRiskSeverity(Object sender, EventArgs e)
        {
            dropdownValue = ddlAdminSolutionSeverity.SelectedValue;
            dropdownName = "ddlAdminSolutionSeverity";

            UpdateRisks();
        }
        public void UpdateAdminSolutionRiskLikelyhood(Object sender, EventArgs e)
        {
            dropdownValue = ddlAdminSolutionLikelyhood.SelectedValue;
            dropdownName = "ddlAdminSolutionLikelyhood";

            UpdateRisks();
        }
        public void UpdateAdminSolutionRiskFrequency(Object sender, EventArgs e)
        {
            dropdownValue = ddlAdminSolutionFrequency.SelectedValue;
            dropdownName = "ddlAdminSolutionFrequency";

            UpdateRisks();
        }
        public void UpdateAdminSolutionRiskNumberOfPersons(Object sender, EventArgs e)
        {
            dropdownValue = ddlAdminSolutionNumberOfPersons.SelectedValue;
            dropdownName = "ddlAdminSolutionNumberOfPersons";

            UpdateRisks();
        }

        /******************** UPDATE DROPDOWNS ********************/

        //determine what drop down was changed and update appropriate dropdown lists
        public void UpdateDropDowns(string dropdownName, string dropdownValue) { 
            
            /* NOTE: Strings can't be switched the same way integers values can so C# compiler generates
            code that is the same as an if/else chain. For a large number of string comparisons
            it is more efficient to use if/else */

            //if the ddlHazardSeverity is changed then we need to change ddlReductionSolutionSeverity and ddlAdminSolutionSeverity
            if (String.Equals("ddlHazardSeverity", dropdownName)) 
            {
                ddlReductionSolutionSeverity.SelectedValue = dropdownValue;
                ddlAdminSolutionSeverity.SelectedValue = dropdownValue;
            }
            else if (String.Equals("ddlHazardLikelyhood", dropdownName)) 
            {
                ddlReductionSolutionLikelyhood.SelectedValue = dropdownValue;
                ddlAdminSolutionLikelyhood.SelectedValue = dropdownValue;
            }
            else if (String.Equals("ddlHazardFrequency", dropdownName))
            {
                ddlReductionSolutionFrequency.SelectedValue = dropdownValue;
                ddlAdminSolutionFrequency.SelectedValue = dropdownValue;
            }
            else if (String.Equals("ddlHazardNumberOfPersons", dropdownName))
            {
                ddlReductionSolutionNumberOfPersons.SelectedValue = dropdownValue;
                ddlAdminSolutionNumberOfPersons.SelectedValue = dropdownValue;
            }
            else if (String.Equals("ddlReductionSolutionSeverity", dropdownName)) 
            {
                ddlAdminSolutionSeverity.SelectedValue = dropdownValue;
            }
            else if (String.Equals("ddlReductionSolutionLikelyhood", dropdownName))
            {
                ddlAdminSolutionLikelyhood.SelectedValue = dropdownValue;
            }
            else if (String.Equals("ddlReductionSolutionFrequency", dropdownName))
            {
                ddlAdminSolutionFrequency.SelectedValue = dropdownValue;
            }
            else if (String.Equals("ddlReductionSolutionNumberOfPersons", dropdownName))
            {
                ddlAdminSolutionNumberOfPersons.SelectedValue = dropdownValue;
            }
        }

        /******************** UPDATE RISK ********************/

        public void UpdateRisks(){

            string riskMessageColor = "";

            string hazardSeverity = ddlHazardSeverity.SelectedValue;
            string hazardFrequency = ddlHazardFrequency.SelectedValue;
            string hazardLikelyhood = ddlHazardLikelyhood.SelectedValue;
            string hazardNumberOfPersons = ddlHazardNumberOfPersons.SelectedValue;

            string reductionSolutionSeverity = ddlReductionSolutionSeverity.SelectedValue;
            string reductionSolutionLikelyhood = ddlReductionSolutionLikelyhood.SelectedValue;
            string reductionSolutionFrequency = ddlReductionSolutionFrequency.SelectedValue;
            string reductionSolutionNumberOfPersons = ddlReductionSolutionNumberOfPersons.SelectedValue;

            string adminSolutionSeverity = ddlAdminSolutionSeverity.SelectedValue;
            string adminSolutionLikelyhood = ddlAdminSolutionLikelyhood.SelectedValue;
            string adminSolutionFrequency = ddlAdminSolutionFrequency.SelectedValue;
            string adminSolutionNumberOfPersons = ddlAdminSolutionNumberOfPersons.SelectedValue;

            /***** FOR HAZARD *****/
           
            //instantiate class Machine, pass parameters, calculate new hazardRisk
            Machine mh = new Machine(hazardSeverity, hazardLikelyhood, hazardFrequency, hazardNumberOfPersons);

            //update risk and message
            lblHazardRisk.Text = mh.Risk;
            lblHazardRiskMessage.Text = mh.Message;

            //get risk message color and update label
            riskMessageColor = mh.MessageColor;
            lblHazardRiskMessage.ForeColor = System.Drawing.Color.FromName(riskMessageColor);

            /***** FOR REDUCTION SOLUTION *****/
            
            //instantiate class Machine, pass parameters, calculate new reductionSolutionRisk
            Machine mr = new Machine(reductionSolutionSeverity, reductionSolutionLikelyhood,
                reductionSolutionFrequency, reductionSolutionNumberOfPersons);

            //update ReductionSolution risk and message
            lblReductionSolutionRisk1.Text = mr.Risk;
            lblReductionSolutionRiskMessage.Text = mr.Message;

            //get risk message color and update label
            riskMessageColor = mr.MessageColor;
            lblReductionSolutionRiskMessage.ForeColor = System.Drawing.Color.FromName(riskMessageColor);

            /***** FOR ADMIN SOLUTION *****/
            
            //instantiate class Machine, pass parameters, calculate new reductionSolutionRisk
            Machine ma = new Machine(adminSolutionSeverity, adminSolutionLikelyhood,
                adminSolutionFrequency, adminSolutionNumberOfPersons);

            //update risk and message
            lblAdminSolutionRisk.Text = ma.Risk;
            lblAdminSolutionRiskMessage.Text = ma.Message;

            //get risk message color and update label
            riskMessageColor = ma.MessageColor;
            lblAdminSolutionRiskMessage.ForeColor = System.Drawing.Color.FromName(riskMessageColor);
         }

        /******************** INSERT NEW RISK INTO DATABASE ********************/
        
        //Call method to insert new risk into db on button click
        protected void btnNewRisk_Click(object sender, EventArgs e)
        {
            //InsertRisk();
        }
        
        //Method to insert a risk info into the db
        private void InsertRisk()
        {
            //variable to hold the value of machineID for the last inserted machine
            int last;
            //last = 2;
            last = (int)(Session["lastInsertedMachineID"]);

            //instantiate class to get connection string - used in multiple classes so method is shared via Utils class
            Utils ut = new Utils();
            string connectionString = ut.ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
                        
            try
            {

                SqlCommand cmd = new SqlCommand("spInsertRisk", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@machineId", last);
                cmd.Parameters.AddWithValue("@hazardDescription", txtHazardDescription.Text);
                cmd.Parameters.AddWithValue("@reductionSolutionDescription", txtReductionSolutionDescription.Text);
                cmd.Parameters.AddWithValue("@adminSolutionDescription", txtAdminSolutionDescription.Text);
                cmd.Parameters.AddWithValue("@hazardSeverity", ddlHazardSeverity.SelectedValue);
                cmd.Parameters.AddWithValue("@hazardLikelihood", ddlHazardLikelyhood.SelectedValue);
                cmd.Parameters.AddWithValue("@hazardFrequency", ddlHazardFrequency.SelectedValue);
                cmd.Parameters.AddWithValue("@hazardNumberOfPersons", ddlHazardNumberOfPersons.SelectedValue);
                cmd.Parameters.AddWithValue("@reductionSolutionSeverity", ddlReductionSolutionSeverity.SelectedValue);
                cmd.Parameters.AddWithValue("@reductionSolutionLikelihood", ddlReductionSolutionLikelyhood.SelectedValue);
                cmd.Parameters.AddWithValue("@reductionSolutionFrequency", ddlReductionSolutionFrequency.SelectedValue);
                cmd.Parameters.AddWithValue("@reductionSolutionNumberOfPersons", ddlReductionSolutionNumberOfPersons.SelectedValue);
                cmd.Parameters.AddWithValue("@adminSolutionSeverity", ddlAdminSolutionSeverity.SelectedValue);
                cmd.Parameters.AddWithValue("@adminSolutionLikelihood", ddlAdminSolutionLikelyhood.SelectedValue);
                cmd.Parameters.AddWithValue("@adminSolutionFrequency", ddlAdminSolutionFrequency.SelectedValue);
                cmd.Parameters.AddWithValue("@adminSolutionNumberOfPersons", ddlAdminSolutionNumberOfPersons.SelectedValue);
                cmd.Parameters.AddWithValue("@comments", txtComments.Text);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                string msg = "Insert Error";
                msg += ex.Message;
                testMessage.Text = msg;
            }
            finally
            {
                con.Close();

                //if we refresh here, error messages will never be seen
                //refresh page
                Response.Redirect(Request.RawUrl);
                Context.ApplicationInstance.CompleteRequest();
            }        
        }
        /*********** DONE: REDIRECT TO DEFAULT.ASPX MENU **********/

        //Done adding Risks, redirect to main page menu
        protected void btnDoneNewRisk_Click(object sender, EventArgs e)
        {
            //should clear all session variables
            Response.Redirect("Default.aspx");
        }     
    }
}
