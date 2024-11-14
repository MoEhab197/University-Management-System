using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS
{
    public class College
    {
        // Define Attributes (Fields)
        int Id;
        string collName;
        List<Department> Departments;
        int universityId;
        
        // set properities 
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
        public string collname
        {
            get { return collName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Sorry, Name cannot be empty.");
                }
                if (value.Any(char.IsDigit))
                {
                    throw new ArgumentException("Sorry, Name cannot contain numbers.");
                }
                collName = value;
            }
        }
        public List<Department> departments
        {
            get { return Departments; }
            set { Departments = value; }
        }
        public int universityid
        {
            get { return universityId; }
            set {universityId = value; }
        }

        //set Constructor
        public College(int id,string name,int UniId) 
        {
            Id=id;
            collName = name;
            universityId = UniId;
            Departments = new List<Department>();
        }
        // Parameterless constructor required for XML serialization
        public College()
        {
            departments = new List<Department>();
        }
    }
}
