using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolSystem
{
    public class School
    {
        public static List<Student> Students = new List<Student>
        {
            new Student { StudentId = 1, StudentName = "Ali", ClassId = 1 },
            new Student { StudentId = 2, StudentName = "Ayşe", ClassId = 2 },
            new Student { StudentId = 3, StudentName = "Mehmet", ClassId = 1 },
            new Student { StudentId = 4, StudentName = "Elif", ClassId = 3 },
            new Student { StudentId = 5, StudentName = "Ahmet", ClassId = 2 }
        };

        public static List<Class> Classes = new List<Class>
        {
            new Class { ClassId = 1, ClassName = "Mathematics" },
            new Class { ClassId = 2, ClassName = "Physics" },
            new Class { ClassId = 3, ClassName = "Chemistry" }
        };

        public static void DisplayClassesWithStudents()
        {
            var groupedData = from cls in Classes
                              join student in Students on cls.ClassId equals student.ClassId into studentGroup
                              select new { cls.ClassName, Students = studentGroup };

            Console.WriteLine("Classes and their Students:");
            Console.WriteLine("----------------------------");

            foreach (var classGroup in groupedData)
            {
                Console.WriteLine($"Class: {classGroup.ClassName}");
                if (classGroup.Students.Any())
                {
                    foreach (var student in classGroup.Students)
                    {
                        Console.WriteLine($"  - {student.StudentName}");
                    }
                }
                else
                {
                    Console.WriteLine("  No students enrolled.");
                }
                Console.WriteLine("----------------------------");
            }
        }
    }
}
