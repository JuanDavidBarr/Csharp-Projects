namespace Students.Classes;

public class Student
{
    public string name { get; set; }
    public int age { get; set; }
    public string grade { get; set; }
    public List<Student> students = new List<Student>();

    public void AddStudent(string studentName, int studentAge, string studentGrade)
    {
        students.Add(new Student {name = studentName, age = studentAge, grade = studentGrade});
    }

    public void ShowStudent(string studentName)
    {
        var result = students.FirstOrDefault(student => student.name == studentName);
        if (result != null)
        {
            Console.WriteLine("Student information:");
            Console.WriteLine($"Student name: {result.name}, \nStudent age: {result.age}, \nStudent grade: {result.grade}");
        }
        else
        {
            Console.WriteLine("Student not found");
        }
    }
}


