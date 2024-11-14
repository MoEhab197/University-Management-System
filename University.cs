using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS
{
    public class University
    {
        // Define Attributes (Fields)
        int Id;
        string uniName;
        List<College> Colleges;

        // set Properities
        public int id
        {
            get { return Id; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Sorry, ID must be a positive integer.");
                }
                Id = value;
            }
        }
        public string uniname
        {
            get { return uniName; }
            set
            {
                if (string.IsNullOrEmpty(uniName))
                {
                    throw new ArgumentException("Sorry, Name cannot be empty.");
                }
                if (value.Any(char.IsDigit))
                {
                    throw new ArgumentException("Sorry, Name cannot contain numbers.");
                }
                uniName = value;
            }
        }
        public List<College> colleges
        {
            get { return Colleges; }
            set { Colleges = value; }
        }
        //set Constructor 
        public University(int id,string name)
        {
            Id = id;
            uniName = name;
            colleges = new List<College>();
        }
        // Parameterless constructor required for XML serialization
        public University()
        {
            colleges = new List<College>();
        }
    }
}
