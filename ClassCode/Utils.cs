using System;
using System.Data;
using System.Data.SqlClient;

namespace SRA.ClassCode
{
    
    public class Utils
    {
        private string connectionString;
        private string machineNumber;
        private string machineType;
        private string machineDate;
       
        //parameterless constructor
        public Utils() 
        {
            GetConnectionString();    
        }
        public Utils(int num)
        {
            GetConnectionString();
            GetSpecifiedMachineNumber(num);
            GetSpecifiedMachineType(num);
            GetSpecifiedMachineDate(num);
        }

        //public property for ConnectionString doesn't need a set because we are just retrieving value
        public String ConnectionString 
        {
            get 
            {
                return connectionString;
            }   
        }
        public String MachineNumber {
            get
            {
                return machineNumber;
            }
        }
        public String MachineType
        {
            get
            {
                return machineType;
            }
        }
        public String MachineDate
        {
            get
            {
                return machineDate;
            }
        }

        //Get connection to db, "myConnectionString" is in Web.config
        private void GetConnectionString()
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        }
        
        //get the machine number from the specified machineId
        private String GetSpecifiedMachineNumber(int num) {
            using (SqlConnection con = new SqlConnection(ConnectionString)) {
                SqlCommand cmd = new SqlCommand("spGetMachineNumber", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@machineId", num);
                con.Open();
                machineNumber = cmd.ExecuteScalar().ToString();
                con.Close();
                return machineNumber;
            }        
        }

        ////get machine type from specified machineId
        private String GetSpecifiedMachineType(int num)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetMachineType", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@machineId", num);
                con.Open();
                machineType = cmd.ExecuteScalar().ToString();
                con.Close();
                return machineType;
            }
        }
        private String GetSpecifiedMachineDate(int num)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetMachineDate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@machineId", num);
                con.Open();
                string d = cmd.ExecuteScalar().ToString();
                con.Close();
                //parse string representations from database
                DateTime dt = DateTime.Parse(d);
                //set desired date format
                machineDate = dt.ToString("MM/dd/yyyy");
                return machineDate;
            }
        }
    }
}