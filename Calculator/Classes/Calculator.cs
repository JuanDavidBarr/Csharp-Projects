namespace Calculator.Classes;
public class Calculator
{
    public static double Addition(double number1, double number2)
    {
        double result = number1 + number2;
        return result;
    }

    public static double Substraction(double number1, double number2)
    {
        double result = number1 - number2;
        return result;
    }

    public static double Multiplication(double number1, double number2)
    {
        double result = number1 * number2;
        return result;
    }
    public static double Division(double number1, double number2)
    {
        if (number2 == 0)
        {
            Console.WriteLine("Cannot divide by zero");
            return 0;
        }
        double result = number1 / number2;
        return result;
    }

    public static List<double> Input()
    {
        Console.WriteLine("Enter the first number: ");
        double number1 = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter the second number: ");
        double number2 = Convert.ToDouble(Console.ReadLine());
        List<double> numbers = new List<double>() { number1, number2 };
        
        return numbers;
    }

    public static void ShowResult(double result)
    {
        Console.WriteLine($"\nResult: {result}");
    }
}