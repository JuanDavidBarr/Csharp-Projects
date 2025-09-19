namespace Calculator.Classes;

public class Menu
{
    public static void ShowMenu()
    {
        bool done = true;
        while (done)
        {
            Console.WriteLine(@"Welcome to RiwiCalculator.
Choose an option:
1 for Addition.
2 for Subtraction.
3 for Multiplication.
4 for Division.
5 to exit");
            List<double> numbers = new List<double>();
            double number1 = 0;
            double number2 = 0;
            int option = Convert.ToInt32(Console.ReadLine());
            if (option > 0 && option <= 4)
            {
                numbers = Calculator.Input();
                number1 = numbers[0];
                number2 = numbers[1];
            }
            double result = 0;
            switch (option)
            {
                case 1:
                    result = Calculator.Addition(number1, number2);
                    break;
                case 2:
                    result = Calculator.Substraction(number1, number2);
                    break;
                case 3:
                    result = Calculator.Multiplication(number1, number2);
                    break;
                case 4:
                    result = Calculator.Division(number1, number2);
                    break;
                case 5:
                    Console.WriteLine("Leaving this method");
                    done = false;
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
            Calculator.ShowResult(result);
        }
    }
}