using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRAPractice
{
    public class Machine
    {
        //private variables
        private string severity;
        private string likelyhood;
        private string frequency;
        private string numberOFPersons;
        private double risk;

        //paramaterized constructor
        public Machine(string severity, string likelyhood, string frequency, string numberOfPersons) {
            
            this.severity = severity;
            this.likelyhood = likelyhood;
            this.frequency = frequency;
            this.numberOFPersons = numberOfPersons;
             
        }

        //public properties
        public String Severity { get; set; }
        public String Likelyhood
        {
            get
            {
                return likelyhood;
            }
            set
            {
                likelyhood = value;
                //CalculateRisk();
            }
        }
        public string Frequency
        {
            get
            {
                return frequency;
            }
            set
            {
                frequency = value;
                //CalculateRisk();
            }
        }
        public string NumberOfPersons
        {
            get
            {
                return numberOFPersons;
            }
            set
            {
                numberOFPersons = value;
                //CalculateRisk();
            }
        }
        //risk doesn't need a 'set' because we are just retrieving the value
        public double Risk
        {
            get
            {
                return risk;
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

            //convert to double so they can be manipulated mathematically
            Double.TryParse(Severity, out severityNum);
            Double.TryParse(Likelyhood, out likelyhoodNum);
            Double.TryParse(Frequency, out frequencyNum);
            Double.TryParse(NumberOfPersons, out numberOfPersonsNum);

            //calculate risk, declared above
            risk = Math.Round((severityNum * likelyhoodNum * frequencyNum * numberOfPersonsNum), 2);
            string riskString = risk.ToString();


        }

    }
}