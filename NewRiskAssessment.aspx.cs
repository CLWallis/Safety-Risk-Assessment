using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SRA.ClassCode;

namespace SRA
{
    public partial class NewRisk : System.Web.UI.Page
    {
        //create listOfFirstNames and listOfLastNames, list collections
        List<string> listOfFirstNames = new List<string>();
        List<string> listOfLastNames = new List<string>();
        List<string> listOfTitles = new List<string>();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            //if the page is not a postback then set the save the list to session variable
            //so it is != null
            if (!IsPostBack)
            {
                //automatically display current date
                DateTime d = new DateTime();
                d = DateTime.Now;
                lblDate.Text = d.ToString("MM/dd/yyyy");
                
                //save list of names to session variables
                Session["participantFirstName"] = listOfFirstNames;
                Session["participantLastName"] = listOfLastNames;
                Session["participantTitle"] = listOfTitles;

                //set focus on first textbox, txtMachineNumber
                txtMachineNumber.Focus(); 
            }  
        }
        
        protected void btnAddParticipant_Click(object sender, EventArgs e)
        {
            //declare variables to hold participant's first and last name
            string firstName = txtParticipantFirstName.Text;
            string lastName = txtParticipantLastName.Text;
            string title = txtParticipantTitle.Text;

            /* NOTE: first time through button click - on initial page load the list was 
            initialized and even though empty was saved in a session variable, so session 
            variable is empty (not null) and list is empty (not null) */
            listOfFirstNames = Session["participantFirstName"] as List<string>; //cast to type list
            listOfLastNames = Session["participantLastName"] as List<string>;
            listOfTitles = Session["participantTitle"] as List<string>;
            
            //add participant's names to respective lists
            listOfFirstNames.Add(firstName);
            listOfLastNames.Add(lastName);
            listOfTitles.Add(title);

            //save the lists back into their respective session variables
            Session["participantFirstName"] = listOfFirstNames;
            Session["participantLastName"] = listOfLastNames;
            Session["participantTitle"] = listOfTitles;

            //clear the label and textboxes from the last time a name was added - it will remain there
            //thanks to ViewState
            lblDisplayParticipants.Text = "";
            txtParticipantLastName.Text = "";
            txtParticipantFirstName.Text = "";
            txtParticipantTitle.Text = "";
            
            //set focus on first name in preparation for next participant
            txtParticipantFirstName.Focus(); 

            //cycle through the list and display all participants
            for (int i = 0; i < listOfFirstNames.Count; i++)
            {
                lblDisplayParticipants.Text += listOfFirstNames[i] + " " + listOfLastNames[i] + " " +  "<br />";
            }          
       }

        protected void btnCreateNewRiskAssessment(object sender, EventArgs e)
        {
            //code to add information to DB
            //InsertNewRiskAssessmentInfo(); //for machine
            //InsertMachineParticipants(); //for participants

            //Response.Redirect will begin a new session, therefore clearing session variable and viewState
            //however the false prevents this
            Response.Redirect("AddRisk.aspx", false);
            
            //remove list of names from their session variables but keeps last inserted machineID in session.
            //Session.Remove("participantFirstName");
            //Session.Remove("participantLastName");
        }

        //Insert new machine info into the db
        private void InsertNewRiskAssessmentInfo()
        {
            //variable to hold the value of machineID for the last inserted machine
            int last;
            
            //get database connection
            Utils ut = new Utils();
            string connectionString = ut.ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                SqlCommand cmd = new SqlCommand("spAddNewRiskAssessment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@machineNumber", txtMachineNumber.Text);
                cmd.Parameters.AddWithValue("@machineType", txtMachineType.Text);

                con.Open();
                //lblDisplayParticipants.Text = "Connection Established";
                //get value of last inserted machineID, save to session
                last = (int)cmd.ExecuteScalar();
                Session["lastInsertedMachineID"] = last;
            }
            catch (SqlException ex)
            {
                string msg = "Insert Error. Contact system administrator.";
                msg += ex.Message;
                lblError.Text = msg;
            }
            finally 
            {
                con.Close();
            }          
        }

        private void InsertMachineParticipants() 
        {
            //transfer lists from session to variables
            listOfFirstNames = Session["participantFirstName"] as List<string>; //cast to list type;
            listOfLastNames = Session["participantLastName"] as List<string>;
            listOfTitles = Session["participantTitle"] as List<string>;
            
            //get database connection
            Utils ut = new Utils();
            string connectionString = ut.ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            try
            {
                //open the connection
                con.Open();

                //iterate through list of participants, call the stored procedure, bind the values,
                //execute query
                 for (int i = 0; i < listOfFirstNames.Count; i++)
                 {

                     SqlCommand cmd = new SqlCommand("spAddMachineParticipants", con);
                     cmd.CommandType = CommandType.StoredProcedure;
                     
                     cmd.Parameters.AddWithValue("@lastName", listOfLastNames[i]);
                     cmd.Parameters.AddWithValue("@firstName", listOfFirstNames[i]);
                     cmd.Parameters.AddWithValue("@title", listOfTitles[i]);
                     cmd.Parameters.AddWithValue("@machineId", (int)(Session["lastInsertedMachineID"]));

                     cmd.ExecuteNonQuery();
                 }

                //cmd.Parameters.AddWithValue("@lastName", txtParticipantLastName.Text);
                //cmd.Parameters.AddWithValue("@firstName", txtParticipantFirstName.Text);
                //cmd.Parameters.AddWithValue("@title", txtParticipantTitle.Text);
                //cmd.Parameters.AddWithValue("@machineId", (int)(Session["lastInsertedMachineID"]));
                //con.Open();
                //cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                string msg = "Error. Contact system administrator.";
                msg += ex.Message;
                lblError.Text = msg;
            }
            finally
            {
                con.Close();
            }
        }
    }
}