using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericsExercise.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            int menuOption = 1;
            PersistenceService persistenceService = new PersistenceService();

            System.Console.WriteLine("\n\tWelcome!");
            System.Console.WriteLine("\tChoose the option most suitable for you: \n");

            while ((menuOption >= 1) && (menuOption <= 4))
            {
                System.Console.WriteLine("\t1. Insert new student.");
                System.Console.WriteLine("\t2. Insert new university.");
                System.Console.WriteLine("\t3. View existing students.");
                System.Console.WriteLine("\t4. View existing universities.");
                System.Console.WriteLine("\t5. Exit.");

                // Get user's menu choice
                menuOption = Convert.ToInt32(System.Console.ReadLine());

                switch (menuOption)
                {
                    case 1:

                        // Insert new student 
                        Student student = new Student();

                        // Get student info
                        System.Console.WriteLine("\n\tInsert the id of the student: ");
                        student.Id = System.Console.ReadLine();

                        System.Console.WriteLine("\n\tInsert the firstname of the student: ");
                        student.FisrtName = System.Console.ReadLine();

                        System.Console.WriteLine("\n\tInsert the lastname of the student: ");
                        student.LastName = System.Console.ReadLine();

                        // Call function to insert the new student 
                        try
                        {
                            persistenceService.InsertEntity(student);
                        }
                        catch (ArgumentException argumentException)
                        {
                            System.Console.WriteLine(argumentException.Message);
                        }
                        catch (InvalidOperationException exception)
                        {
                            System.Console.WriteLine("\tEntry not registered. Reason: Cannot register more than 3 students.");
                        }

                        break;
                    case 2:
                        // Insert new university
                        University university = new University();

                        // Get university info
                        System.Console.WriteLine("\n\tInsert the id of the university: ");
                        university.Id = System.Console.ReadLine();

                        System.Console.WriteLine("\n\tInsert the name of the university: ");
                        university.Name = System.Console.ReadLine();

                        System.Console.WriteLine("\n\tInsert the address of the university: ");
                        university.Address = System.Console.ReadLine();

                        // Call function to insert the new university
                        try
                        {
                            persistenceService.InsertEntity(university);  
                        }
                        catch(ArgumentException argumentException)
                        {
                            System.Console.WriteLine(argumentException.Message);
                        }
                        catch (InvalidOperationException exception)
                        {
                            System.Console.WriteLine("\tEntry not registered. Reason: Cannot register more than 3 universities.");
                        }

                        break;
                    case 3:
                        // View existing students
                        try
                        {
                            IEnumerable<Student> students = persistenceService.ViewAllEntities<Student>();
                            foreach (Student existingStudent in students)
                            {
                                System.Console.WriteLine("\t\t Student ID: " + existingStudent.Id +
                                    "\n\t\t Student First Name: " + existingStudent.FisrtName +
                                    "\n\t\t Student Last Name: " + existingStudent.LastName + "\n");
                            }
                        }
                        catch (InvalidOperationException exception)
                        {
                            System.Console.WriteLine("\n\tOops...looks like there are no students registered yet.");
                        }
                        
                        break;

                    case 4:
                        // View existing universities
                        try
                        {
                            IEnumerable<University> universities = persistenceService.ViewAllEntities<University>();
                            foreach (University existingUniversity in universities)
                            {
                                System.Console.WriteLine("\t\t University ID: " + existingUniversity.Id +
                                    "\n\t\t University Name: " + existingUniversity.Name +
                                    "\n\t\t University Address: " + existingUniversity.Address + "\n");
                            }
                        }
                        catch (InvalidOperationException exception)
                        {
                            System.Console.WriteLine("\n\tOops...looks like there are no universities registered yet.");
                        }

                        break;

                    case 5:
                        // Exit program
                        System.Console.WriteLine("\n\tGoodbye for now...\n");
                        break;
                    default:
                        System.Console.WriteLine("\n\tOops...looks like you entered an undefined command.");
                        break;
                }

                if (menuOption != 5)
                {
                    System.Console.WriteLine("\n\tGo back to menu?");
                    System.Console.WriteLine("\t\tYes - 1\n\t\tNo - 0");

                    menuOption = Convert.ToInt32(System.Console.ReadLine());
                    if (menuOption == 0)
                    {
                        System.Console.WriteLine("\n\tGoodbye for now...\n");
                    }
                }
            }
        }
    }
}