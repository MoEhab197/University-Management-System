using System.Xml.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UMS
{
    public class UniversityManager
    {
        public List<University> universities = new List<University>();
        public List<College> colleges = new List<College>();
        public List<Department> departments = new List<Department>();
        public List<Student> students = new List<Student>();
        public List<Subject> subjects = new List<Subject>();


        // CREATE: Create a new university
        public void CreateUniversity()
        {
            Console.Clear();
            Console.WriteLine("Enter University ID:");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter University Name:");
            string name = Console.ReadLine();

            if (universities.Any(u => u.id == id))
            {
                Console.WriteLine("University with the same ID already exists.");
            }
            else
            {
                universities.Add(new University(id, name));
                Console.WriteLine("University added successfully.");
            }

            // Pause to display the message
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
            Console.Clear();
        }
        // READ: Read the data of the university
        public void ReadUniversity()
        {
            Console.Clear();
            Console.WriteLine("Enter University ID to search:");
            int id = Convert.ToInt32(Console.ReadLine());

            University university = universities.FirstOrDefault(u => u.id == id);
            if (university != null)
            {
                Console.WriteLine($"ID: {university.id}, Name: {university.uniname}");
            }
            else
            {
                Console.WriteLine("University not found.");
            }
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
            Console.Clear();
        }
        // UPDATE: Modify an existing University's name
        public void UpdateUniversity()
        {
            Console.Clear();
            Console.WriteLine("Enter University ID to update:");
            int id = Convert.ToInt32(Console.ReadLine());

            University university = universities.FirstOrDefault(u => u.id == id);
            if (university != null)
            {
                Console.WriteLine("Enter new University Name:");
                string newName = Console.ReadLine();
                university.uniname = newName;
                Console.WriteLine("University updated successfully.");
            }
            else
            {
                Console.WriteLine("University not found.");
            }

            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
            Console.Clear();
        }
        // DELETE: Remove a University by Id
        public void DeleteUniversity()
        {
            Console.Clear();
            Console.WriteLine("Enter University ID to delete:");
            int id = Convert.ToInt32(Console.ReadLine());

            University university = universities.FirstOrDefault(u => u.id == id);
            if (university != null)
            {
                universities.Remove(university);
                Console.WriteLine("University deleted successfully.");
            }
            else
            {
                Console.WriteLine("University not found.");
            }
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
            Console.Clear();
        }
        public void DisplayAllUniversities()
        {
            Console.Clear();
            if (universities.Count == 0)
            {
                Console.WriteLine("No universities available.");
            }
            else
            {
                foreach (var university in universities)
                {
                    Console.WriteLine($"ID: {university.id}, Name: {university.uniname}");
                }
            }
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
            Console.Clear();
        }
        // Assiging colleges to universities
        public void AssignCollege()
        {
            Console.Clear();
            Console.WriteLine("Enter University ID to assign a college:");
            int universityId = Convert.ToInt32(Console.ReadLine());

            University university = universities.FirstOrDefault(u => u.id == universityId);
            if (university != null)
            {
                Console.WriteLine("Enter College ID:");
                int collegeId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter College Name:");
                string collegeName = Console.ReadLine();

                if (university.colleges.Any(c => c.id == collegeId))
                {
                    Console.WriteLine("A college with this ID already exists in the university.");
                }
                else
                {
                    College newCollege = new College(collegeId, collegeName, universityId);
                    university.colleges.Add(newCollege);
                    Console.WriteLine("College assigned successfully.");
                }
            }
            else
            {
                Console.WriteLine("University not found.");
            }

            // Pause to display the message
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
            Console.Clear();
        }

        // Unassiging colleges to universities
        public void UnassignCollege()
        {
            Console.Clear();
            Console.WriteLine("Enter University ID to unassign a college:");
            int universityId = Convert.ToInt32(Console.ReadLine());

            University university = universities.FirstOrDefault(u => u.id == universityId);
            if (university != null)
            {
                Console.WriteLine("Enter College ID to remove:");
                int collegeId = Convert.ToInt32(Console.ReadLine());

                College college = university.colleges.FirstOrDefault(c => c.id == collegeId);
                if (college != null)
                {
                    university.colleges.Remove(college);
                    Console.WriteLine("College unassigned successfully.");
                }
                else
                {
                    Console.WriteLine("College not found in this university.");
                }
            }
            else
            {
                Console.WriteLine("University not found.");
            }

            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
            Console.Clear();
        }


        //Reading(Displaying) Colleges
        public void ReadColleges()
        {
            Console.Clear();
            Console.WriteLine("Enter University ID to view its Colleges:");

            // Read input and validate
            if (!int.TryParse(Console.ReadLine(), out int universityId))
            {
                Console.WriteLine("Invalid input. Please enter a valid University ID.");
                return;
            }

            var university = universities.FirstOrDefault(u => u.id == universityId);
            if (university != null)
            {
                if (university.colleges.Count > 0)
                {
                    Console.WriteLine($"Colleges in {university.uniname}:");
                    foreach (var college in university.colleges)
                    {
                        Console.WriteLine($"ID: {college.id}, Name: {college.collname}");
                    }
                }
                else
                {
                    Console.WriteLine("No colleges found for this university.");
                }
            }
            else
            {
                Console.WriteLine("University not found.");
            }

            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
            Console.Clear();
        }

        //Updating College
        public void UpdateCollege()
        {
            Console.WriteLine("Enter College ID to update:");
            int collegeId = Convert.ToInt32(Console.ReadLine());

            var collegeToUpdate = universities.SelectMany(u => u.colleges).FirstOrDefault(c => c.id == collegeId);
            if (collegeToUpdate != null)
            {
                Console.WriteLine("Enter new College Name (leave blank to keep current name):");
                string newName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newName))
                {
                    collegeToUpdate.collname = newName;
                    Console.WriteLine("College updated successfully.");
                }
                else
                {
                    Console.WriteLine("No changes made.");
                }
            }
            else
            {
                Console.WriteLine("College not found.");
            }
        }
        //Displaying all colleges
        public void DisplayAllColleges()
        {
            Console.Clear();
            Console.WriteLine("Enter the University Id");
            int universityId = int.Parse(Console.ReadLine());
            var university = universities.FirstOrDefault(u => u.id == universityId);

            if (university == null)
            {
                Console.WriteLine("University not found.");
            }
            else if (university.colleges.Count == 0)
            {
                Console.WriteLine("No colleges available.");
            }
            else
            {
                foreach (var college in university.colleges)
                {
                    Console.WriteLine($"ID: {college.id}, Name: {college.collname}");
                }
            }

            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
            Console.Clear();
        }

        public void AssignDepartment()
        {
            // Ensure universities list is not null
            if (universities == null || universities.Count == 0)
            {
                Console.WriteLine("No universities available.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Get the university ID and verify its existence
            Console.WriteLine("Enter University ID:");
            if (!int.TryParse(Console.ReadLine(), out int universityId))
            {
                Console.WriteLine("Invalid University ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            var university = universities.FirstOrDefault(u => u.id == universityId);
            if (university == null)
            {
                Console.WriteLine("University not found.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Ensure the university has colleges
            if (university.colleges == null || university.colleges.Count == 0)
            {
                Console.WriteLine($"No colleges available for {university.uniname}.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Display colleges and get the college ID
            Console.WriteLine($"Colleges in {university.uniname}:");
            foreach (var college in university.colleges)
            {
                Console.WriteLine($"ID: {college.id}, Name: {college.collname}");
            }

            Console.WriteLine("Enter College ID:");
            if (!int.TryParse(Console.ReadLine(), out int collegeId))
            {
                Console.WriteLine("Invalid College ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            var selectedCollege = university.colleges.FirstOrDefault(c => c.id == collegeId);
            if (selectedCollege == null)
            {
                Console.WriteLine("College not found.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Get the department details
            Console.WriteLine("Enter Department ID:");
            if (!int.TryParse(Console.ReadLine(), out int departmentId))
            {
                Console.WriteLine("Invalid Department ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            Console.WriteLine("Enter Department Name:");
            string departmentName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(departmentName))
            {
                Console.WriteLine("Department name cannot be empty.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Ensure department list is initialized
            if (selectedCollege.departments == null)
            {
                selectedCollege.departments = new List<Department>();
            }

            // Check if the department ID already exists
            var existingDepartment = selectedCollege.departments.FirstOrDefault(d => d.id == departmentId);
            if (existingDepartment != null)
            {
                Console.WriteLine("A department with this ID already exists.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Assign department to the college
            selectedCollege.departments.Add(new Department(departmentId, departmentName, collegeId));
            Console.WriteLine($"Department '{departmentName}' assigned successfully to {selectedCollege.collname}.");

            PauseAndReturnToMainMenu();  // Pause and message after assigning department
        }

        // Helper method to pause and return to the main menu
        private void PauseAndReturnToMainMenu()
        {
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
            Console.Clear();
        }
        public void UnassignDepartment()
        {
            if (universities == null || universities.Count == 0)
            {
                Console.WriteLine("No universities available.");
                PauseAndReturnToMainMenu();
                return;
            }

            Console.WriteLine("Enter University ID:");
            if (!int.TryParse(Console.ReadLine(), out int universityId))
            {
                Console.WriteLine("Invalid University ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            var university = universities.FirstOrDefault(u => u.id == universityId);
            if (university == null)
            {
                Console.WriteLine("University not found.");
                PauseAndReturnToMainMenu();
                return;
            }

            if (university.colleges == null || university.colleges.Count == 0)
            {
                Console.WriteLine($"No colleges available for {university.uniname}.");
                PauseAndReturnToMainMenu();
                return;
            }

            Console.WriteLine($"Colleges in {university.uniname}:");
            foreach (var college in university.colleges)
            {
                Console.WriteLine($"ID: {college.id}, Name: {college.collname}");
            }

            Console.WriteLine("Enter College ID:");
            if (!int.TryParse(Console.ReadLine(), out int collegeId))
            {
                Console.WriteLine("Invalid College ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            var selectedCollege = university.colleges.FirstOrDefault(c => c.id == collegeId);
            if (selectedCollege == null)
            {
                Console.WriteLine("College not found.");
                PauseAndReturnToMainMenu();
                return;
            }

            if (selectedCollege.departments == null || selectedCollege.departments.Count == 0)
            {
                Console.WriteLine("No departments available for this college.");
                PauseAndReturnToMainMenu();
                return;
            }

            Console.WriteLine("Enter Department ID:");
            if (!int.TryParse(Console.ReadLine(), out int departmentId))
            {
                Console.WriteLine("Invalid Department ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            var department = selectedCollege.departments.FirstOrDefault(d => d.id == departmentId);
            if (department == null)
            {
                Console.WriteLine("Department not found.");
                PauseAndReturnToMainMenu();
                return;
            }

            selectedCollege.departments.Remove(department);
            Console.WriteLine($"Department '{department.deptname}' unassigned successfully from {selectedCollege.collname}.");

            PauseAndReturnToMainMenu();
        }
        public void ReadDepartment()
        {
            if (universities == null || universities.Count == 0)
            {
                Console.WriteLine("No universities available.");
                PauseAndReturnToMainMenu();
                return;
            }

            Console.WriteLine("Enter University ID:");
            if (!int.TryParse(Console.ReadLine(), out int universityId))
            {
                Console.WriteLine("Invalid University ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            var university = universities.FirstOrDefault(u => u.id == universityId);
            if (university == null)
            {
                Console.WriteLine("University not found.");
                PauseAndReturnToMainMenu();
                return;
            }

            if (university.colleges == null || university.colleges.Count == 0)
            {
                Console.WriteLine($"No colleges available for {university.uniname}.");
                PauseAndReturnToMainMenu();
                return;
            }

            Console.WriteLine($"Colleges in {university.uniname}:");
            foreach (var college in university.colleges)
            {
                Console.WriteLine($"ID: {college.id}, Name: {college.collname}");
            }

            Console.WriteLine("Enter College ID:");
            if (!int.TryParse(Console.ReadLine(), out int collegeId))
            {
                Console.WriteLine("Invalid College ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            var selectedCollege = university.colleges.FirstOrDefault(c => c.id == collegeId);
            if (selectedCollege == null)
            {
                Console.WriteLine("College not found.");
                PauseAndReturnToMainMenu();
                return;
            }

            if (selectedCollege.departments == null || selectedCollege.departments.Count == 0)
            {
                Console.WriteLine("No departments available for this college.");
                PauseAndReturnToMainMenu();
                return;
            }

            Console.WriteLine($"Departments in {selectedCollege.collname}:");
            foreach (var department in selectedCollege.departments)
            {
                Console.WriteLine($"ID: {department.id}, Name: {department.deptname}");
            }

            PauseAndReturnToMainMenu();
        }
        public void UpdateDepartment()
        {
            if (universities == null || universities.Count == 0)
            {
                Console.WriteLine("No universities available.");
                PauseAndReturnToMainMenu();
                return;
            }

            Console.WriteLine("Enter University ID:");
            if (!int.TryParse(Console.ReadLine(), out int universityId))
            {
                Console.WriteLine("Invalid University ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            var university = universities.FirstOrDefault(u => u.id == universityId);
            if (university == null)
            {
                Console.WriteLine("University not found.");
                PauseAndReturnToMainMenu();
                return;
            }

            if (university.colleges == null || university.colleges.Count == 0)
            {
                Console.WriteLine($"No colleges available for {university.uniname}.");
                PauseAndReturnToMainMenu();
                return;
            }

            Console.WriteLine($"Colleges in {university.uniname}:");
            foreach (var college in university.colleges)
            {
                Console.WriteLine($"ID: {college.id}, Name: {college.collname}");
            }

            Console.WriteLine("Enter College ID:");
            if (!int.TryParse(Console.ReadLine(), out int collegeId))
            {
                Console.WriteLine("Invalid College ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            var selectedCollege = university.colleges.FirstOrDefault(c => c.id == collegeId);
            if (selectedCollege == null)
            {
                Console.WriteLine("College not found.");
                PauseAndReturnToMainMenu();
                return;
            }

            if (selectedCollege.departments == null || selectedCollege.departments.Count == 0)
            {
                Console.WriteLine("No departments available for this college.");
                PauseAndReturnToMainMenu();
                return;
            }

            Console.WriteLine("Enter Department ID to update:");
            if (!int.TryParse(Console.ReadLine(), out int departmentId))
            {
                Console.WriteLine("Invalid Department ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            var department = selectedCollege.departments.FirstOrDefault(d => d.id == departmentId);
            if (department == null)
            {
                Console.WriteLine("Department not found.");
                PauseAndReturnToMainMenu();
                return;
            }

            Console.WriteLine("Enter new Department Name:");
            string newDepartmentName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newDepartmentName))
            {
                Console.WriteLine("Department name cannot be empty.");
                PauseAndReturnToMainMenu();
                return;
            }

            department.deptname = newDepartmentName;
            Console.WriteLine("Department updated successfully.");

            PauseAndReturnToMainMenu();
        }
        public void DisplayAllDepartments()
        {
            if (universities == null || universities.Count == 0)
            {
                Console.WriteLine("No universities available.");
                PauseAndReturnToMainMenu();
                return;
            }

            foreach (var university in universities)
            {
                if (university.colleges != null)
                {
                    foreach (var college in university.colleges)
                    {
                        if (college.departments != null && college.departments.Count > 0)
                        {
                            Console.WriteLine($"Departments in {college.collname} (University: {university.uniname}):");
                            foreach (var department in college.departments)
                            {
                                Console.WriteLine($"ID: {department.id}, Name: {department.deptname}");
                            }
                        }
                    }
                }
            }

            PauseAndReturnToMainMenu();
        }


        public void AssignStudent()
        {
            Console.Clear();

            // Ensure universities list is not null or empty
            if (universities == null || universities.Count == 0)
            {
                Console.WriteLine("No universities available.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Get the university ID and verify its existence
            Console.WriteLine("Enter University ID:");
            if (!int.TryParse(Console.ReadLine(), out int universityId))
            {
                Console.WriteLine("Invalid University ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            var university = universities.FirstOrDefault(u => u.id == universityId);
            if (university == null)
            {
                Console.WriteLine("University not found.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Ensure the university has colleges
            if (university.colleges == null || university.colleges.Count == 0)
            {
                Console.WriteLine($"No colleges available for {university.uniname}.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Display colleges and get the college ID
            Console.WriteLine($"Colleges in {university.uniname}:");
            foreach (var college in university.colleges)
            {
                Console.WriteLine($"ID: {college.id}, Name: {college.collname}");
            }

            Console.WriteLine("Enter College ID:");
            if (!int.TryParse(Console.ReadLine(), out int collegeId))
            {
                Console.WriteLine("Invalid College ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            var selectedCollege = university.colleges.FirstOrDefault(c => c.id == collegeId);
            if (selectedCollege == null)
            {
                Console.WriteLine("College not found.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Ensure the college has departments
            if (selectedCollege.departments == null || selectedCollege.departments.Count == 0)
            {
                Console.WriteLine($"No departments available for {selectedCollege.collname}.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Display departments and get the department ID
            Console.WriteLine($"Departments in {selectedCollege.collname}:");
            foreach (var department in selectedCollege.departments)
            {
                Console.WriteLine($"ID: {department.id}, Name: {department.deptname}");
            }

            Console.WriteLine("Enter Department ID:");
            if (!int.TryParse(Console.ReadLine(), out int departmentId))
            {
                Console.WriteLine("Invalid Department ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            var selectedDepartment = selectedCollege.departments.FirstOrDefault(d => d.id == departmentId);
            if (selectedDepartment == null)
            {
                Console.WriteLine("Department not found.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Get student details
            Console.WriteLine("Enter Student ID:");
            if (!int.TryParse(Console.ReadLine(), out int studentId))
            {
                Console.WriteLine("Invalid Student ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            Console.WriteLine("Enter Student Name:");
            string studentName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(studentName))
            {
                Console.WriteLine("Student name cannot be empty.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Ensure students list is initialized in the department
            if (selectedDepartment.students == null)
            {
                selectedDepartment.students = new List<Student>();
            }

            // Check if the student ID already exists in the department
            if (selectedDepartment.students.Any(s => s.id == studentId))
            {
                Console.WriteLine("A student with this ID already exists in this department.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Assign student to the department
            selectedDepartment.students.Add(new Student(studentId, studentName, departmentId));
            Console.WriteLine($"Student '{studentName}' assigned successfully to {selectedDepartment.deptname}.");

            PauseAndReturnToMainMenu(); // Pause and message after assigning student
        }
        public void UnassignStudent()
        {
            Console.WriteLine("Enter University ID:");
            int universityId = Convert.ToInt32(Console.ReadLine());
            var university = universities.FirstOrDefault(u => u.id == universityId);

            if (university != null)
            {
                Console.WriteLine("Enter College ID:");
                int collegeId = Convert.ToInt32(Console.ReadLine());
                var college = university.colleges.FirstOrDefault(c => c.id == collegeId);

                if (college != null)
                {
                    Console.WriteLine("Enter Department ID:");
                    int departmentId = Convert.ToInt32(Console.ReadLine());
                    var department = college.departments.FirstOrDefault(d => d.id == departmentId);

                    if (department != null)
                    {
                        Console.WriteLine("Enter Student ID:");
                        int studentId = Convert.ToInt32(Console.ReadLine());
                        var student = department.students.FirstOrDefault(s => s.id == studentId);

                        if (student != null)
                        {
                            department.students.Remove(student);
                            Console.WriteLine("Student unassigned successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Student not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Department not found.");
                    }
                }
                else
                {
                    Console.WriteLine("College not found.");
                }
            }
            else
            {
                Console.WriteLine("University not found.");
            }
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
            Console.Clear();
        }
        public void ReadStudent()
        {
            Console.WriteLine("Enter University ID:");
            if (!int.TryParse(Console.ReadLine(), out int universityId))
            {
                Console.WriteLine("Invalid University ID.");
                return;
            }

            var university = universities.FirstOrDefault(u => u.id == universityId);
            if (university != null)
            {
                Console.WriteLine("Enter College ID:");
                if (!int.TryParse(Console.ReadLine(), out int collegeId))
                {
                    Console.WriteLine("Invalid College ID.");
                    return;
                }

                var college = university.colleges.FirstOrDefault(c => c.id == collegeId);
                if (college != null)
                {
                    Console.WriteLine("Enter Department ID:");
                    if (!int.TryParse(Console.ReadLine(), out int departmentId))
                    {
                        Console.WriteLine("Invalid Department ID.");
                        return;
                    }

                    var department = college.departments.FirstOrDefault(d => d.id == departmentId);
                    if (department != null)
                    {
                        // Ask for the student ID to retrieve
                        Console.WriteLine("Enter Student ID to retrieve:");
                        if (!int.TryParse(Console.ReadLine(), out int studentId))
                        {
                            Console.WriteLine("Invalid Student ID.");
                            return;
                        }

                        var student = department.students.FirstOrDefault(s => s.id == studentId);
                        if (student != null)
                        {
                            // Display student details
                            Console.WriteLine($"Student Details: ID: {student.id}, Name: {student.stdname}");
                        }
                        else
                        {
                            Console.WriteLine("Student not found in this department.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Department not found.");
                    }
                }
                else
                {
                    Console.WriteLine("College not found.");
                }
            }
            else
            {
                Console.WriteLine("University not found.");
            }

            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
            Console.Clear();
        }
        public void UpdateStudent()
        {
            Console.WriteLine("Enter University ID:");
            int universityId = Convert.ToInt32(Console.ReadLine());
            var university = universities.FirstOrDefault(u => u.id == universityId);

            if (university != null)
            {
                Console.WriteLine("Enter College ID:");
                int collegeId = Convert.ToInt32(Console.ReadLine());
                var college = university.colleges.FirstOrDefault(c => c.id == collegeId);

                if (college != null)
                {
                    Console.WriteLine("Enter Department ID:");
                    int departmentId = Convert.ToInt32(Console.ReadLine());
                    var department = college.departments.FirstOrDefault(d => d.id == departmentId);

                    if (department != null)
                    {
                        Console.WriteLine("Enter Student ID to update:");
                        int studentId = Convert.ToInt32(Console.ReadLine());
                        var student = department.students.FirstOrDefault(s => s.id == studentId);

                        if (student != null)
                        {
                            Console.WriteLine("Enter new Student Name:");
                            student.stdname = Console.ReadLine();
                            Console.WriteLine("Student updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Student not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Department not found.");
                    }
                }
                else
                {
                    Console.WriteLine("College not found.");
                }
            }
            else
            {
                Console.WriteLine("University not found.");
            }
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
            Console.Clear();
        }
        public void DisplayAllStudents()
        {
            Console.WriteLine("Enter University ID:");
            int universityId = Convert.ToInt32(Console.ReadLine());
            var university = universities.FirstOrDefault(u => u.id == universityId);

            if (university != null)
            {
                Console.WriteLine("Enter College ID:");
                int collegeId = Convert.ToInt32(Console.ReadLine());
                var college = university.colleges.FirstOrDefault(c => c.id == collegeId);

                if (college != null)
                {
                    Console.WriteLine("Enter Department ID:");
                    int departmentId = Convert.ToInt32(Console.ReadLine());
                    var department = college.departments.FirstOrDefault(d => d.id == departmentId);

                    if (department != null && department.students.Count > 0)
                    {
                        Console.WriteLine($"All Students in Department {department.deptname}:");
                        foreach (var student in department.students)
                        {
                            Console.WriteLine($"ID: {student.id}, Name: {student.stdname}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No students found in this department.");
                    }
                }
                else
                {
                    Console.WriteLine("College not found.");
                }
            }
            else
            {
                Console.WriteLine("University not found.");
            }
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
            Console.Clear();
        }
        public void AssignSubject()
        {
            Console.Clear();

            // Ensure universities list is not null or empty
            if (universities == null || universities.Count == 0)
            {
                Console.WriteLine("No universities available.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Get the university ID and verify its existence
            Console.WriteLine("Enter University ID:");
            if (!int.TryParse(Console.ReadLine(), out int universityId))
            {
                Console.WriteLine("Invalid University ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            var university = universities.FirstOrDefault(u => u.id == universityId);
            if (university == null)
            {
                Console.WriteLine("University not found.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Ensure the university has colleges
            if (university.colleges == null || university.colleges.Count == 0)
            {
                Console.WriteLine($"No colleges available for {university.uniname}.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Display colleges and get the college ID
            Console.WriteLine($"Colleges in {university.uniname}:");
            foreach (var college in university.colleges)
            {
                Console.WriteLine($"ID: {college.id}, Name: {college.collname}");
            }

            Console.WriteLine("Enter College ID:");
            if (!int.TryParse(Console.ReadLine(), out int collegeId))
            {
                Console.WriteLine("Invalid College ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            var selectedCollege = university.colleges.FirstOrDefault(c => c.id == collegeId);
            if (selectedCollege == null)
            {
                Console.WriteLine("College not found.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Ensure the college has departments
            if (selectedCollege.departments == null || selectedCollege.departments.Count == 0)
            {
                Console.WriteLine($"No departments available for {selectedCollege.collname}.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Display departments and get the department ID
            Console.WriteLine($"Departments in {selectedCollege.collname}:");
            foreach (var department in selectedCollege.departments)
            {
                Console.WriteLine($"ID: {department.id}, Name: {department.deptname}");
            }

            Console.WriteLine("Enter Department ID:");
            if (!int.TryParse(Console.ReadLine(), out int departmentId))
            {
                Console.WriteLine("Invalid Department ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            var selectedDepartment = selectedCollege.departments.FirstOrDefault(d => d.id == departmentId);
            if (selectedDepartment == null)
            {
                Console.WriteLine("Department not found.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Get subject details
            Console.WriteLine("Enter Subject ID:");
            if (!int.TryParse(Console.ReadLine(), out int subjectId))
            {
                Console.WriteLine("Invalid Subject ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            Console.WriteLine("Enter Subject Name:");
            string subjectName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(subjectName))
            {
                Console.WriteLine("Subject name cannot be empty.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Ensure subjects list is initialized in the department
            if (selectedDepartment.subjects == null)
            {
                selectedDepartment.subjects = new List<Subject>();
            }

            // Check if the subject ID already exists in the department
            if (selectedDepartment.subjects.Any(s => s.id == subjectId))
            {
                Console.WriteLine("A subject with this ID already exists in this department.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Assign subject to the department
            selectedDepartment.subjects.Add(new Subject(subjectId, subjectName, departmentId));
            Console.WriteLine($"Subject '{subjectName}' assigned successfully to {selectedDepartment.deptname}.");

            PauseAndReturnToMainMenu(); // Pause and message after assigning subject
        }

        public void UnassignSubject()
        {
            Console.Clear();

            // Ensure universities list is not null or empty
            if (universities == null || universities.Count == 0)
            {
                Console.WriteLine("No universities available.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Get the university ID and verify its existence
            Console.WriteLine("Enter University ID:");
            if (!int.TryParse(Console.ReadLine(), out int universityId))
            {
                Console.WriteLine("Invalid University ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            var university = universities.FirstOrDefault(u => u.id == universityId);
            if (university == null)
            {
                Console.WriteLine("University not found.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Ensure the university has colleges
            if (university.colleges == null || university.colleges.Count == 0)
            {
                Console.WriteLine($"No colleges available for {university.uniname}.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Display colleges and get the college ID
            Console.WriteLine($"Colleges in {university.uniname}:");
            foreach (var college in university.colleges)
            {
                Console.WriteLine($"ID: {college.id}, Name: {college.collname}");
            }

            Console.WriteLine("Enter College ID:");
            if (!int.TryParse(Console.ReadLine(), out int collegeId))
            {
                Console.WriteLine("Invalid College ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            var selectedCollege = university.colleges.FirstOrDefault(c => c.id == collegeId);
            if (selectedCollege == null)
            {
                Console.WriteLine("College not found.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Ensure the college has departments
            if (selectedCollege.departments == null || selectedCollege.departments.Count == 0)
            {
                Console.WriteLine($"No departments available for {selectedCollege.collname}.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Display departments and get the department ID
            Console.WriteLine($"Departments in {selectedCollege.collname}:");
            foreach (var department in selectedCollege.departments)
            {
                Console.WriteLine($"ID: {department.id}, Name: {department.deptname}");
            }

            Console.WriteLine("Enter Department ID:");
            if (!int.TryParse(Console.ReadLine(), out int departmentId))
            {
                Console.WriteLine("Invalid Department ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            var selectedDepartment = selectedCollege.departments.FirstOrDefault(d => d.id == departmentId);
            if (selectedDepartment == null)
            {
                Console.WriteLine("Department not found.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Get subject ID to unassign
            Console.WriteLine("Enter Subject ID to unassign:");
            if (!int.TryParse(Console.ReadLine(), out int subjectId))
            {
                Console.WriteLine("Invalid Subject ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Find and remove the subject
            var subjectToRemove = selectedDepartment.subjects?.FirstOrDefault(s => s.id == subjectId);
            if (subjectToRemove == null)
            {
                Console.WriteLine("Subject not found in this department.");
                PauseAndReturnToMainMenu();
                return;
            }

            selectedDepartment.subjects.Remove(subjectToRemove);
            Console.WriteLine($"Subject '{subjectToRemove.subjectname}' unassigned successfully from {selectedDepartment.deptname}.");

            PauseAndReturnToMainMenu(); // Pause and message after unassigning subject
        }
        public void ReadSubject()
        {
            Console.Clear();

            // Ensure universities list is not null or empty
            if (universities == null || universities.Count == 0)
            {
                Console.WriteLine("No universities available.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Get the university ID and verify its existence
            Console.WriteLine("Enter University ID:");
            if (!int.TryParse(Console.ReadLine(), out int universityId))
            {
                Console.WriteLine("Invalid University ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            var university = universities.FirstOrDefault(u => u.id == universityId);
            if (university == null)
            {
                Console.WriteLine("University not found.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Ensure the university has colleges
            if (university.colleges == null || university.colleges.Count == 0)
            {
                Console.WriteLine($"No colleges available for {university.uniname}.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Display colleges and get the college ID
            Console.WriteLine($"Colleges in {university.uniname}:");
            foreach (var college in university.colleges)
            {
                Console.WriteLine($"ID: {college.id}, Name: {college.collname}");
            }

            Console.WriteLine("Enter College ID:");
            if (!int.TryParse(Console.ReadLine(), out int collegeId))
            {
                Console.WriteLine("Invalid College ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            var selectedCollege = university.colleges.FirstOrDefault(c => c.id == collegeId);
            if (selectedCollege == null)
            {
                Console.WriteLine("College not found.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Ensure the college has departments
            if (selectedCollege.departments == null || selectedCollege.departments.Count == 0)
            {
                Console.WriteLine($"No departments available for {selectedCollege.collname}.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Display departments and get the department ID
            Console.WriteLine($"Departments in {selectedCollege.collname}:");
            foreach (var department in selectedCollege.departments)
            {
                Console.WriteLine($"ID: {department.id}, Name: {department.deptname}");
            }

            Console.WriteLine("Enter Department ID:");
            if (!int.TryParse(Console.ReadLine(), out int departmentId))
            {
                Console.WriteLine("Invalid Department ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            var selectedDepartment = selectedCollege.departments.FirstOrDefault(d => d.id == departmentId);
            if (selectedDepartment == null)
            {
                Console.WriteLine("Department not found.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Ensure the department has subjects
            if (selectedDepartment.subjects == null || selectedDepartment.subjects.Count == 0)
            {
                Console.WriteLine($"No subjects available in {selectedDepartment.deptname}.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Ask for the subject ID
            Console.WriteLine("Enter Subject ID:");
            if (!int.TryParse(Console.ReadLine(), out int subjectId))
            {
                Console.WriteLine("Invalid Subject ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Find and display the specific subject
            var selectedSubject = selectedDepartment.subjects.FirstOrDefault(s => s.id == subjectId);
            if (selectedSubject == null)
            {
                Console.WriteLine("Subject not found.");
            }
            else
            {
                Console.WriteLine($"Subject found: ID: {selectedSubject.id}, Name: {selectedSubject.subjectname}");
            }

            PauseAndReturnToMainMenu(); // Pause after displaying the subject
        }
        public void UpdateSubject()
        {
            Console.Clear();

            // Ensure universities list is not null or empty
            if (universities == null || universities.Count == 0)
            {
                Console.WriteLine("No universities available.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Get the university ID and verify its existence
            Console.WriteLine("Enter University ID:");
            if (!int.TryParse(Console.ReadLine(), out int universityId))
            {
                Console.WriteLine("Invalid University ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            var university = universities.FirstOrDefault(u => u.id == universityId);
            if (university == null)
            {
                Console.WriteLine("University not found.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Ensure the university has colleges
            if (university.colleges == null || university.colleges.Count == 0)
            {
                Console.WriteLine($"No colleges available for {university.uniname}.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Display colleges and get the college ID
            Console.WriteLine($"Colleges in {university.uniname}:");
            foreach (var college in university.colleges)
            {
                Console.WriteLine($"ID: {college.id}, Name: {college.collname}");
            }

            Console.WriteLine("Enter College ID:");
            if (!int.TryParse(Console.ReadLine(), out int collegeId))
            {
                Console.WriteLine("Invalid College ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            var selectedCollege = university.colleges.FirstOrDefault(c => c.id == collegeId);
            if (selectedCollege == null)
            {
                Console.WriteLine("College not found.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Ensure the college has departments
            if (selectedCollege.departments == null || selectedCollege.departments.Count == 0)
            {
                Console.WriteLine($"No departments available for {selectedCollege.collname}.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Display departments and get the department ID
            Console.WriteLine($"Departments in {selectedCollege.collname}:");
            foreach (var department in selectedCollege.departments)
            {
                Console.WriteLine($"ID: {department.id}, Name: {department.deptname}");
            }

            Console.WriteLine("Enter Department ID:");
            if (!int.TryParse(Console.ReadLine(), out int departmentId))
            {
                Console.WriteLine("Invalid Department ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            var selectedDepartment = selectedCollege.departments.FirstOrDefault(d => d.id == departmentId);
            if (selectedDepartment == null)
            {
                Console.WriteLine("Department not found.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Get subject ID to update
            Console.WriteLine("Enter Subject ID to update:");
            if (!int.TryParse(Console.ReadLine(), out int subjectId))
            {
                Console.WriteLine("Invalid Subject ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            var subjectToUpdate = selectedDepartment.subjects?.FirstOrDefault(s => s.id == subjectId);
            if (subjectToUpdate == null)
            {
                Console.WriteLine("Subject not found in this department.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Update subject name
            Console.WriteLine("Enter new Subject Name:");
            string newSubjectName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newSubjectName))
            {
                Console.WriteLine("Subject name cannot be empty.");
                PauseAndReturnToMainMenu();
                return;
            }

            subjectToUpdate.subjectname = newSubjectName;
            Console.WriteLine($"Subject '{subjectToUpdate.subjectname}' updated successfully in {selectedDepartment.deptname}.");

            PauseAndReturnToMainMenu(); // Pause after updating subject
        }
        public void DisplayAllSubjects()
        {
            Console.WriteLine("Enter University ID:");
            if (!int.TryParse(Console.ReadLine(), out int universityId))
            {
                Console.WriteLine("Invalid University ID.");
                return;
            }

            var university = universities.FirstOrDefault(u => u.id == universityId);
            if (university != null)
            {
                Console.WriteLine("Enter College ID:");
                if (!int.TryParse(Console.ReadLine(), out int collegeId))
                {
                    Console.WriteLine("Invalid College ID.");
                    return;
                }

                var college = university.colleges.FirstOrDefault(c => c.id == collegeId);
                if (college != null)
                {
                    Console.WriteLine("Enter Department ID:");
                    if (!int.TryParse(Console.ReadLine(), out int departmentId))
                    {
                        Console.WriteLine("Invalid Department ID.");
                        return;
                    }

                    var department = college.departments.FirstOrDefault(d => d.id == departmentId);
                    if (department != null)
                    {
                        if (department.subjects != null && department.subjects.Count > 0)
                        {
                            Console.WriteLine($"Subjects in Department {department.deptname}:");
                            foreach (var subject in department.subjects)
                            {
                                Console.WriteLine($"ID: {subject.id}, Name: {subject.subjectname}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No subjects found for this department.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Department not found.");
                    }
                }
                else
                {
                    Console.WriteLine("College not found.");
                }
            }
            else
            {
                Console.WriteLine("University not found.");
            }

            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
            Console.Clear();
        }
        public void AssignGrade()
        {
            Console.Clear();

            // Ensure universities list is not null or empty
            if (universities == null || universities.Count == 0)
            {
                Console.WriteLine("No universities available.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Get the university ID and verify its existence
            Console.WriteLine("Enter University ID:");
            if (!int.TryParse(Console.ReadLine(), out int universityId))
            {
                Console.WriteLine("Invalid University ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            var university = universities.FirstOrDefault(u => u.id == universityId);
            if (university == null)
            {
                Console.WriteLine("University not found.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Ensure the university has colleges
            if (university.colleges == null || university.colleges.Count == 0)
            {
                Console.WriteLine($"No colleges available for {university.uniname}.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Display colleges and get the college ID
            Console.WriteLine($"Colleges in {university.uniname}:");
            foreach (var college in university.colleges)
            {
                Console.WriteLine($"ID: {college.id}, Name: {college.collname}");
            }

            Console.WriteLine("Enter College ID:");
            if (!int.TryParse(Console.ReadLine(), out int collegeId))
            {
                Console.WriteLine("Invalid College ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            var selectedCollege = university.colleges.FirstOrDefault(c => c.id == collegeId);
            if (selectedCollege == null)
            {
                Console.WriteLine("College not found.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Ensure the college has departments
            if (selectedCollege.departments == null || selectedCollege.departments.Count == 0)
            {
                Console.WriteLine($"No departments available for {selectedCollege.collname}.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Display departments and get the department ID
            Console.WriteLine($"Departments in {selectedCollege.collname}:");
            foreach (var department in selectedCollege.departments)
            {
                Console.WriteLine($"ID: {department.id}, Name: {department.deptname}");
            }

            Console.WriteLine("Enter Department ID:");
            if (!int.TryParse(Console.ReadLine(), out int departmentId))
            {
                Console.WriteLine("Invalid Department ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            var selectedDepartment = selectedCollege.departments.FirstOrDefault(d => d.id == departmentId);
            if (selectedDepartment == null)
            {
                Console.WriteLine("Department not found.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Ensure the department has students
            if (selectedDepartment.students == null || selectedDepartment.students.Count == 0)
            {
                Console.WriteLine($"No students available for {selectedDepartment.deptname}.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Display students and get the student ID
            Console.WriteLine($"Students in {selectedDepartment.deptname}:");
            foreach (var student in selectedDepartment.students)
            {
                Console.WriteLine($"ID: {student.id}, Name: {student.stdname}");
            }

            Console.WriteLine("Enter Student ID:");
            if (!int.TryParse(Console.ReadLine(), out int studentId))
            {
                Console.WriteLine("Invalid Student ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            var selectedStudent = selectedDepartment.students.FirstOrDefault(s => s.id == studentId);
            if (selectedStudent == null)
            {
                Console.WriteLine("Student not found.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Get the grade
            Console.WriteLine("Enter Grade:");
            if (!double.TryParse(Console.ReadLine(), out double grade))
            {
                Console.WriteLine("Invalid Grade.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Add the grade to the student's grades list
            selectedStudent.Grades.Add(grade);
            Console.WriteLine($"Grade '{grade}' assigned to {selectedStudent.stdname}.");

            PauseAndReturnToMainMenu();
        }

       public  void ManageStudentEvaluations()
        {
            string[] evaluationMenu = { "Calculate Success Percentage", "Display Passed/Failed Students", "Classify Universities", "Classify Colleges", "Return to Main Menu" };
            int selectedIndex = DisplayMenu(evaluationMenu);

            switch (selectedIndex)
            {
                case 0:
                    CalculateSuccessPercentage();
                    break;
                case 1:
                    DisplayPassedFailedStudents();
                    break;
                case 2:
                    ClassifyUniversities();
                    break;
                case 3:
                    ClassifyColleges();
                    break;
                case 4:
                    // Return to Main Menu
                    break;
            }
        }

        public void CalculateSuccessPercentage()
        {
            Console.Clear();

            // Ensure universities list is not null or empty
            if (universities == null || universities.Count == 0)
            {
                Console.WriteLine("No universities available.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Get the university ID and verify its existence
            Console.WriteLine("Enter University ID:");
            if (!int.TryParse(Console.ReadLine(), out int universityId))
            {
                Console.WriteLine("Invalid University ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            var university = universities.FirstOrDefault(u => u.id == universityId);
            if (university == null)
            {
                Console.WriteLine("University not found.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Ensure the university has colleges
            if (university.colleges == null || university.colleges.Count == 0)
            {
                Console.WriteLine($"No colleges available for {university.uniname}.");
                PauseAndReturnToMainMenu();
                return;
            }

            double totalStudents = 0;
            double passedStudents = 0;

            foreach (var college in university.colleges)
            {
                foreach (var department in college.departments)
                {
                    if (department.students != null)
                    {
                        foreach (var student in department.students)
                        {
                            totalStudents++;
                            if (student.Grades.Average() >= 50) // Assuming 50 is the passing grade
                            {
                                passedStudents++;
                            }
                        }
                    }
                }
            }

            double successPercentage = (passedStudents / totalStudents) * 100;
            Console.WriteLine($"Success Percentage for {university.uniname}: {successPercentage:F2}%");

            PauseAndReturnToMainMenu();
        }
        public void DisplayPassedFailedStudents()
        {
            Console.Clear();

            // Ensure universities list is not null or empty
            if (universities == null || universities.Count == 0)
            {
                Console.WriteLine("No universities available.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Get the university ID and verify its existence
            Console.WriteLine("Enter University ID:");
            if (!int.TryParse(Console.ReadLine(), out int universityId))
            {
                Console.WriteLine("Invalid University ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            var university = universities.FirstOrDefault(u => u.id == universityId);
            if (university == null)
            {
                Console.WriteLine("University not found.");
                PauseAndReturnToMainMenu();
                return;
            }

            foreach (var college in university.colleges)
            {
                Console.WriteLine($"College: {college.collname}");
                foreach (var department in college.departments)
                {
                    Console.WriteLine($"\nDepartment: {department.deptname}");
                    Console.WriteLine("Passed Students:");

                    var passedStudents = department.students.Where(s => s.Grades.Average() >= 50).ToList();
                    foreach (var student in passedStudents)
                    {
                        Console.WriteLine($"ID: {student.id}, Name: {student.stdname}, Avg Grade: {student.Grades.Average():F2}");
                    }

                    Console.WriteLine("\nFailed Students:");
                    var failedStudents = department.students.Where(s => s.Grades.Average() < 50).ToList();
                    foreach (var student in failedStudents)
                    {
                        Console.WriteLine($"ID: {student.id}, Name: {student.stdname}, Avg Grade: {student.Grades.Average():F2}");
                    }
                }
            }

            PauseAndReturnToMainMenu();
        }
        public void ClassifyUniversities()
        {
            Console.Clear();

            // Ensure universities list is not null or empty
            if (universities == null || universities.Count == 0)
            {
                Console.WriteLine("No universities available.");
                PauseAndReturnToMainMenu();
                return;
            }

            var classifiedUniversities = universities.Select(u =>
            {
                double totalStudents = 0;
                double passedStudents = 0;

                foreach (var college in u.colleges)
                {
                    foreach (var department in college.departments)
                    {
                        totalStudents += department.students.Count;
                        passedStudents += department.students.Count(s => s.Grades.Average() >= 50);
                    }
                }

                double successPercentage = totalStudents > 0 ? (passedStudents / totalStudents) * 100 : 0;
                string classification = GetClassification(successPercentage);

                return new
                {
                    University = u.uniname,
                    SuccessPercentage = successPercentage,
                    Classification = classification
                };
            }).OrderByDescending(u => u.SuccessPercentage);

            Console.WriteLine("University Classification:");
            foreach (var uni in classifiedUniversities)
            {
                Console.WriteLine($"University: {uni.University}, Success Rate: {uni.SuccessPercentage:F2}%, Classification: {uni.Classification}");
            }

            PauseAndReturnToMainMenu();
        }

        private string GetClassification(double successPercentage)
        {
            if (successPercentage >= 90) return "A";
            if (successPercentage >= 75) return "B";
            if (successPercentage >= 60) return "C";
            if (successPercentage >= 50) return "D";
            return "E";
        }
        public void ClassifyColleges()
        {
            Console.Clear();

            // Ensure universities list is not null or empty
            if (universities == null || universities.Count == 0)
            {
                Console.WriteLine("No universities available.");
                PauseAndReturnToMainMenu();
                return;
            }

            // Get the university ID and verify its existence
            Console.WriteLine("Enter University ID:");
            if (!int.TryParse(Console.ReadLine(), out int universityId))
            {
                Console.WriteLine("Invalid University ID.");
                PauseAndReturnToMainMenu();
                return;
            }

            var university = universities.FirstOrDefault(u => u.id == universityId);
            if (university == null)
            {
                Console.WriteLine("University not found.");
                PauseAndReturnToMainMenu();
                return;
            }

            var classifiedColleges = university.colleges.Select(c =>
            {
                double totalStudents = 0;
                double passedStudents = 0;

                foreach (var department in c.departments)
                {
                    totalStudents += department.students.Count;
                    passedStudents += department.students.Count(s => s.Grades.Average() >= 50);
                }

                double successPercentage = totalStudents > 0 ? (passedStudents / totalStudents) * 100 : 0;
                string classification = GetClassification(successPercentage);

                return new
                {
                    College = c.collname,
                    SuccessPercentage = successPercentage,
                    Classification = classification
                };
            }).OrderByDescending(c => c.SuccessPercentage);

            Console.WriteLine($"Classification for Colleges in {university.uniname}:");
            foreach (var college in classifiedColleges)
            {
                Console.WriteLine($"College: {college.College}, Success Rate: {college.SuccessPercentage:F2}%, Classification: {college.Classification}");
            }

            PauseAndReturnToMainMenu();
        }
        public static int DisplayMenu(string[] options)
        {
            int selectedIndex = 0;

            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                Console.WriteLine("Please select an option:\n");

                // Loop through each menu option and highlight the selected one
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.WriteLine(options[i]);

                    // Reset the console colors after displaying the highlighted option
                    Console.ResetColor();
                }

                // Handle key presses to navigate the menu
                keyPressed = Console.ReadKey().Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex < 0)
                    {
                        selectedIndex = options.Length - 1; // Wrap around to the last option
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex >= options.Length)
                    {
                        selectedIndex = 0; // Wrap around to the first option
                    }
                }

            } while (keyPressed != ConsoleKey.Enter); // Exit loop when Enter is pressed

            return selectedIndex;
        }

        public void SaveData(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<University>)); 

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, universities);
            }

            Console.WriteLine("Data saved successfully.");
        }

        public void LoadData(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("No saved data found.");
                return;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<University>));

            using (StreamReader reader = new StreamReader(filePath))
            {
                universities = (List<University>)serializer.Deserialize(reader);
            }
            Console.WriteLine("Data loaded successfully.");
        }
    }
}

