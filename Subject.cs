using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS
{
    public class Subject
    {
        // Define Attributes (Fields)
        int Id;
        string subjectName;
        int deptId;

        //set properties

        public int id
        {
            get { return Id; }
            set {
                if (value<=0) 
                {
                    throw new ArgumentException("Sorry, ID must be a positive integer.");
                }
                Id = value; }
        }
        public string subjectname
        {
            get { return subjectName; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Sorry, Name cannot be empty.");
                }
                if(value.Any(char.IsDigit))
                {
                    throw new ArgumentException("Sorry, Name cannot contain numbers.");
                }
                 subjectName = value;
            }
        }
        public int deptid
        {
            get { return deptId; }
            set { deptId = value; }
        }

        //set Constructor
        public Subject(int id,string name,int deptid)
        {
            Id = id;
            subjectName = name;
            deptId = deptid;
        }
        // Parameterless constructor (required for XML serialization)
        public Subject()
        {
        }

    }
}
