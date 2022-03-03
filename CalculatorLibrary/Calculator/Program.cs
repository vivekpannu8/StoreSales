using CalculatorLibrary;

class ConsoleCalculator
{
   static void Main()
    {
        Console.Write("Enter two numbers : \n\tFirst Number: ");
        decimal firstNumber = Convert.ToDecimal(Console.ReadLine());
        Console.Write("\tSecond Number: ");
        decimal secondNumber = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine($"You entered {firstNumber} and {secondNumber}");
        Console.Write("Addition is : ");
        Console.WriteLine(CalculatorOperations.addNumbers(firstNumber, secondNumber));

        Console.Write("Subtraction is : ");
        Console.WriteLine(CalculatorOperations.subtractNumbers(firstNumber, secondNumber));

        Console.Write("Multiplication is : ");
        Console.WriteLine(CalculatorOperations.multiplyNumbers(firstNumber, secondNumber));

        Console.Write("Division is : ");
        Console.WriteLine(CalculatorOperations.divideNumbers(firstNumber, secondNumber));
    }
}