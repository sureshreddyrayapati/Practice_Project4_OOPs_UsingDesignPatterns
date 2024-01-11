using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_Project4_OOPs_UsingDesignPatterns
{
    public class Program
    {
        static List<Student> student;
        static List<Teacher> teacher;
        static List<Subject> subject;
        static Program()
        {
            //for getting all options output we are addings some data already and user aslo add values 
            student = new List<Student>() 
            { 
                new Student(){Name="Suresh",ClassSection="Class A"},
                new Student(){Name="Ramesh",ClassSection="Class B"},
                new Student(){Name="Naresh",ClassSection="Class C"}
            }; 
            teacher = new List<Teacher>()
            {
                new Teacher(){Name="Teacher1" ,ClassSection="Class A"},
                new Teacher(){Name="Teacher2",ClassSection="Class C"}
            };
            subject = new List<Subject>()
            {
                new Subject(){Name="subject1",SubCode="A00",Teacher=teacher[0]},
                new Subject(){Name="subject2",SubCode="A10",Teacher=teacher[1]}
            };
        }
        static void AddStudents()
        {
            Student s1 = new Student()
            {

                Name = Console.ReadLine(),
                ClassSection = Console.ReadLine()

            };
            student.Add(s1);
        }
        static void AddTeachers()
        {
            Teacher s11 = new Teacher()
            {

                Name = Console.ReadLine(),
                ClassSection = Console.ReadLine()

            };
            teacher.Add(s11);
        }
        static void AddSubject()
        {
            Console.WriteLine("Enter Subject Name:");
            string subjectName = Console.ReadLine();
            Console.WriteLine("Enter Subject Code:");
            string subjectCode = Console.ReadLine();

            Console.WriteLine("Select Teacher by Index to which subject mentioned is to be assigned:");
            for (int i = 0; i < teacher.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {teacher[i].Name}");
            }

            int teacherIndex = int.Parse(Console.ReadLine()) - 1;
            subject.Add(new Subject { Name = subjectName, SubCode = subjectCode, Teacher = teacher[teacherIndex] });
        }

        static void DisplayByName(string a)
        {
            List<Student> matchingStudents = student.Where(x => x.ClassSection == a).ToList();

            if (matchingStudents.Count == 0)
            {
                Console.WriteLine("No Matching class here");
            }
            else
            {
                Console.WriteLine("Students in {0}:", a);
                foreach (var student in matchingStudents)
                {
                    Console.WriteLine(student.Name);
                }
            }
        }
        static public void ShowSubjectsTaughtByTeacher(string teacherName)
        {
            Console.WriteLine($"Subjects taught by {teacherName}: ");
            foreach (var su in subject)
            {
                if (su.Teacher.Name == teacherName)
                {
                    Console.WriteLine($"{su.Name} (Code: {su.SubCode})");
                }
            }
        }
        
        static void stdDisplay()//displaying the stundent data after adding
        {
            student.ForEach(x => { Console.WriteLine("Student Name :{0} Student Class :{1}", x.Name, x.ClassSection); });
        }
        static void TechDisplay()//display Teachers data
        {
            teacher.ForEach(x1 => { Console.WriteLine("Student Name :{0} Student Class :{1}", x1.Name, x1.ClassSection); });
        }
        static void SubDisplay()//Display Subjects DAta
        {
            subject.ForEach(x1 => { Console.WriteLine("Subject Name :{0} Subject Code :{1}, subject Teacher :{2}", x1.Name, x1.SubCode,x1.Teacher.Name); });
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Rainbow School\n");
            Console.WriteLine("1. Add students\n2. Add Teachers\n3. Add sujects\n4. Display Students in classes\n5. Display Subjects taught by a teacher");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n == 1)
            {
                Console.WriteLine("Enter how many number of Students you want to add");
                int n1= Convert.ToInt32(Console.ReadLine());
                for (int i = 1; i <=n1; i++)
                {
                    Console.WriteLine($"Enter Name and class of stundet {i}");
                    AddStudents();
                }
                stdDisplay();
            }
           else if (n == 2)
            {
                Console.WriteLine("Enter how many number of Teachers you want to add");
                int n1 = Convert.ToInt32(Console.ReadLine());
                for (int i = 1; i <=n1; i++)
                {
                    Console.WriteLine($"Enter Name and class of Teacher {i}");
                    AddTeachers();
                }
                TechDisplay() ;
            }
            else if (n == 3)
            {
                Console.WriteLine("Enter how many number of subjects you want to add");
                int n1 = Convert.ToInt32(Console.ReadLine());
                for (int i = 1; i <=n1; i++)
                {
                    Console.WriteLine($"Enter Name of subject code of suject {i}");
                    AddSubject();
                }
                SubDisplay() ;
            }
            else if(n == 4)
            {
                Console.WriteLine("which class Details do you want\t Class A\t2 Class B\t3 Class C\n Type same as above with space");
                Console.WriteLine("Enter class Name");
                DisplayByName(Console.ReadLine());  
            }
            else if(n==5)
            {
                Console.WriteLine("Enter Teacher Name\nenter Name exaplample---> Teacher1 ,Teacher2...");
                ShowSubjectsTaughtByTeacher(Console.ReadLine()) ;
            }
            else
            {
                Console.WriteLine("Wrong choice select again");
                Main(args);

            }
            Console.WriteLine("\nContinue Process Press 1 or Press Any number to Exit");
            int c2 = Convert.ToInt32(Console.ReadLine());
            if (c2 == 1)
            {
                Main(args);
            }
            else
            {
               
            }
        }
    }
}
