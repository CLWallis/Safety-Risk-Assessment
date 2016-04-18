using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRA.ClassCode
{
    
    /*Currently - class used to house method to access SRA database connection string because this 
     connection is used in multiple classes*/
    
    public class Utils
    {
        private string connectionString;

        //parameterless constructor
        public Utils() 
        {
            GetConnectionString();    
        }

        //public property for ConnectionString doesn't need a set because we are just retrieving value
        public String ConnectionString 
        {
            get 
            {
                return connectionString;
            }   
        }

        //Get connection to db, "myConnectionString" is in Web.config
        private void GetConnectionString()
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
        }
    }
}