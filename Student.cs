using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS
{
    public class Student
    {
        // Define Attributes (Fields)
        int Id;
        string stdName;
        public List<double> Grades { get; set; }
        int deptId;
        
        //set Properties
        public int id
        {
            get { return Id; }
            set 
            {
                if(value <=0)
                {
                    throw new ArgumentException("Sorry, ID must be a positive integer.");
                }
                Id = value; 
            }
        }
        public string stdname
        {
            get { return stdName; }
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
                stdName = value;
            }
        }      
        public int deptid
        {
            get { return deptId; }
            set { deptId = value; }
        }
        //set Constructor
        public Student(int id, string name, int departmentId)
        {
            Id = id;
            stdname = name;
            deptId = departmentId;
            this.Grades = new List<double>(); // Initialize the Grades list
        }
        // Parameterless constructor (required for XML serialization)
        public Student()
        {
            this.Grades = new List<double>();
        }
    }
}
