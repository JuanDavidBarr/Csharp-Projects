namespace Students.Classes;

public class Menu
{
    Student studentManager = new Student();
    public void ShowMenu()
    {
        bool leaveMenu = false;
        while (!leaveMenu)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Add student");
            Console.WriteLine("2. Show student information");
            Console.WriteLine("3. Leave this menu");
            string userOption = Console.ReadLine();
            switch (userOption)
            {
                case "1":
                    string studentName = EmptyInputValidation("Student name: ");
                    int studentAge = IntegerInputValidation("Student age: ");
                    string studentGrade = EmptyInputValidation("Student grade: ");
                    studentManager.AddStudent(studentName, studentAge, studentGrade);
                    break;
                case "2": 
                    string name = EmptyInputValidation("Type student name: ");
                    studentManager.ShowStudent(name);
                    break;
                case "3":
                    leaveMenu = true;
                    Console.WriteLine("Leaving this menu...");
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }

    public string EmptyInputValidation(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            var input = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(input))
            {
                return input;
            }
            else
            {
                Console.WriteLine("Value required, try again");
            }
        }
    }

    public int IntegerInputValidation(string prompt)
    {
        while (true)
        {
            var input = EmptyInputValidation(prompt);
            if (int.TryParse(input, out var age))
            {
                return age;
            }
            else
            {
                Console.WriteLine("Value is not a number, try again");
            }
        }
    }
    
}