using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS
{
    public class Department
    {
        // Define Attributes (Fields)
        int Id;
        string deptName;
        List<Student> Students = new List<Student>();
        List<Subject> Subjects= new List<Subject>();
        int collegeId;

        //set properities
        public int id
        {
            get { return Id; }
            set
            {
                if (value <= 0)
                { throw new ArgumentException("Sorry, ID must be a positive integer."); }
                Id = value;
            }
        }

        public string deptname
        {
            get { return deptName; }
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
                deptName = value;
            }
        }
        public List<Student> students
        {
            get { return Students; }
            set { Students = value; }
        }
        public List<Subject> subjects
        {
            get { return Subjects; }
            set { subjects = value; }
        }
        public int collegeid
        {
            get { return collegeId; }
            set { collegeId = value; }
        }

        //set Constructor 
        public Department(int id, string name, int CollId)
        {
            Id = id;
            deptName= name;
            collegeId= CollId;
            Students = new List<Student>(); 
            Subjects = new List<Subject>();
        }
        // Parameterless constructor required for XML serialization
        public Department()
        {
            students = new List<Student>();
            subjects = new List<Subject>();
        }
    }
}
