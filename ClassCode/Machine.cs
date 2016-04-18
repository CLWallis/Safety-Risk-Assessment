using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRA.ClassCode
{
    public class Machine
    {
        //declare private variables 
        private string risk;
        private string message;
        private double riskNum;
        private string messageColor;
        //private string dropdownName;
        //private string dropdownValue;
        
        //paramaterized constructors
        //public Machine(string dropdownName, string dropdownValue) {
        //    DropdownName = dropdownName;
        //    DropdownValue = dropdownValue;
        //}

        public Machine(string severity, string likelyhood, string frequency, string numberOfPersons) {

            Severity = severity;
            Likelyhood = likelyhood;
            Frequency = frequency;
            NumberOfPersons = numberOfPersons;

            //risk needs to be calculated every time the class is instantiated
            CalculateRisk();
            DetermineMessage();
        }

        //public properties
        public string DropdownName { get; set; }
        public string DropdownValue { get; set; }

        public string Severity { get; set; }
        public string Likelyhood { get; set; }
        public string Frequency { get; set; }
        public string NumberOfPersons { get; set; }
       
        //risk doesn't need a 'set' because we are just retrieving the value
        public string Risk {
            get 
            {
                return risk;
            }
        }

        public double RiskNum {
            get 
            {
                return riskNum;
            }
        }

        public string Message {
            get 
            {
                return message;
            }
        }
        public string MessageColor
        {
            get
            {
                return messageColor;
            }
        }

        //method to calculate risk, private because we are using public variables
        //to hold values as double for calculation
        private void CalculateRisk()
        {   
            //declare variables to work within method
            double severityNum;
            double likelyhoodNum;
            double frequencyNum;
            double numberOfPersonsNum;
            //double riskNum;
            
            //convert to double so they can be manipulated mathematically
            Double.TryParse(Severity, out severityNum);
            Double.TryParse(Likelyhood, out likelyhoodNum);
            Double.TryParse(Frequency, out frequencyNum);
            Double.TryParse(NumberOfPersons, out numberOfPersonsNum);
            
            //calculate risk, declared above
            riskNum = Math.Round((severityNum * likelyhoodNum * frequencyNum * numberOfPersonsNum), 2);
            risk = riskNum.ToString();
        }

        private void DetermineMessage(){

            //if-else is better handling ranges than switch
            if (riskNum >= 0 && riskNum <= 5)
            {
                message = "Negligible";
                messageColor = "Green";
            }
            else if (riskNum > 5 && riskNum <= 50)
            {
                message = "Significant";
                messageColor = "Orange";
            }
            else if (riskNum > 50 && riskNum <= 500)
            {
                message = "High";
                messageColor = "Orange";
            }
            else if (riskNum > 500)
            {
                message = "Unacceptable";
                messageColor = "Red";
            }

        }
    }
}