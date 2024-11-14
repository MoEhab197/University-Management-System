using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UMS
{
    internal class Program
    {
        static void Main(string[] args)
        {

            UniversityManager manager = new UniversityManager();
            // File path to save/load XML data
            string filePath = "D:\\000-KADD\\00-UMS\\Source Code\\UMS\\bin\\Debug\\universityData.xml";

            //Load data from XML if exists
            try
            {
                manager.LoadData(filePath);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            bool exit = false;

            while (!exit)
            {
                string[] mainMenu = { "Manage Universities", "Manage Colleges", "Manage Departments", "Manage Students and Subjects", "Manage Student Evaluations", "Save & Exit" };
                int selectedIndex = DisplayMenu(mainMenu);

                switch (selectedIndex)
                {
                    case 0:
                        ManageUniversities(manager);
                        break;
                    case 1:
                        ManageColleges(manager);
                        break;
                    case 2:
                        ManageDepartments(manager);
                        break;
                    case 3:
                        ManageStudentsAndSubjects(manager);
                        break;
                    case 4:
                        ManageStudentEvaluations(manager);
                        break;
                    case 5:
                        //Save data and exit
                        try
                        {
                            manager.SaveData(filePath);
                           
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error saving data: {ex.Message}");
                        }
                        exit = true;
                        break;
                }
            }
            
            Console.ReadKey();
        }

        static int DisplayMenu(string[] options)
        {
            int currentSelection = 0;
            ConsoleKey key;

            do
            {
                Console.Clear();
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == currentSelection)
                        Console.ForegroundColor = ConsoleColor.Green; // Highlight the selected option
                    else
                        Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine(options[i]);
                }
                key = Console.ReadKey().Key;

                if (key == ConsoleKey.UpArrow)
                {
                    currentSelection = (currentSelection == 0) ? options.Length - 1 : currentSelection - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    currentSelection = (currentSelection == options.Length - 1) ? 0 : currentSelection + 1;
                }

            } while (key != ConsoleKey.Enter);

            return currentSelection;
        }

        static void ManageUniversities(UniversityManager manager)
        {
            string[] universityMenu = { "Create University", "Read University", "Update University", "Delete University", "Display All Universities", "Return to Main Menu" };
            int selectedIndex = DisplayMenu(universityMenu);

            switch (selectedIndex)
            {
                case 0:
                    manager.CreateUniversity();
                    break;
                case 1:
                    manager.ReadUniversity();
                    break;
                case 2:
                    manager.UpdateUniversity();
                    break;
                case 3:
                    manager.DeleteUniversity();
                    break;
                case 4:
                    manager.DisplayAllUniversities();
                    break;
                case 5:
                    // Return to main menu
                    break;
            }
        }

        static void ManageColleges(UniversityManager manager)
        {
            string[] collegeMenu = { "Assign College", "Unassign College", "Read Colleges", "Update College", "Display All Colleges", "Return to Main Menu" };
            int selectedIndex = DisplayMenu(collegeMenu);

            switch (selectedIndex)
            {
                case 0:
                    manager.AssignCollege();
                    break;
                case 1:
                    manager.UnassignCollege();
                    break;
                case 2:
                    manager.ReadColleges();
                    break;
                case 3:
                    manager.UpdateCollege();
                    break;
                case 4:
                    manager.DisplayAllColleges();  // New method to display all colleges
                    break;
                case 5:
                    // Return to main menu
                    break;
            }
        }

        static void ManageDepartments(UniversityManager manager)
        {
            string[] departmentMenu = { "Assign Department", "Unassign Department", "Read Departments", "Update Department", "Display All Departments", "Return to Main Menu" };

            int selectedIndex = DisplayMenu(departmentMenu);

            switch (selectedIndex)
            {
                case 0:
                    manager.AssignDepartment();
                    break;
                case 1:
                    manager.UnassignDepartment();
                    break;
                case 2:
                    manager.ReadDepartment();
                    break;
                case 3:
                    manager.UpdateDepartment();
                    break;
                case 4:
                    manager.DisplayAllDepartments();  // New method to display all departments
                    break;
                case 5:
                    // Return to main menu
                    break;
            }
        }
        static void ManageStudentsAndSubjects(UniversityManager manager)
        {
            string[] studentSubjectMenu = { "Assign Student", "Unassign Student", "Read Students", "Update Student", "Display All Students", "Assign Subject", "Unassign Subject", "Read Subjects", "Update Subject", "Display All Subjects", "Assign Grades", "Return to Main Menu" };
            int selectedIndex = DisplayMenu(studentSubjectMenu);

            switch (selectedIndex)
            {
                case 0:
                    manager.AssignStudent();
                    break;
                case 1:
                    manager.UnassignStudent();
                    break;
                case 2:
                    manager.ReadStudent();
                    break;
                case 3:
                    manager.UpdateStudent();
                    break;
                case 4:
                    manager.DisplayAllStudents();
                    break;
                case 5:
                    manager.AssignSubject();
                    break;
                case 6:
                    manager.UnassignSubject();
                    break;
                case 7:
                    manager.ReadSubject();
                    break;
                case 8:
                    manager.UpdateSubject();
                    break;
                case 9:
                    manager.DisplayAllSubjects();
                    break;
                case 10: // New case for assigning grades
                    manager.AssignGrade();
                    break;
                case 11:
                    // Return to main menu
                    break;
            }
        }
        static void ManageStudentEvaluations(UniversityManager manager)
        {
            // Directly call the existing method in UniversityManager
            manager.ManageStudentEvaluations();
        }
    }
}
