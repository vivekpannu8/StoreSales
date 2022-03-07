using CalculatorLibrary;

class ConsoleCalculator
{
    static void Main()
    {
        const string AddMessage = "Addition is : ";
        const string SubtractionMessage = "Subtraction is : ";
        const string MultiplyMessage = "Multiplication is : ";
        const string DivisionMessage = "Division is : ";
        const string InputFirstNumberMessage = "Enter two numbers : \n\tFirst Number: ";
        const string InputSecondNumberMessage = "\tSecond Number: ";
        const string WrongInputMessage = "Wrong Input !!!";
        const string TakeUserChoiceMessage = @"Which operation you want to perfom ?
            1. Addition
            2. Subtraction
            3. Multiplication
            4. Division
        Enter your Choice : ";
        decimal FirstNumber;
        decimal SecondNumber;


        void TakeInputNumbers()
        {
            while (true)
            {
                try
                {
                    Console.Write(InputFirstNumberMessage);
                    FirstNumber = Convert.ToDecimal(Console.ReadLine());
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            while (true)
            {
                try
                {
                    Console.Write(InputSecondNumberMessage);
                    SecondNumber = Convert.ToDecimal(Console.ReadLine());
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }


        char choice;
        do
        {
            while (true)
            {
                Console.Clear();
                try
                {
                    Console.Write(TakeUserChoiceMessage);
                    choice = Convert.ToChar(Console.ReadLine());
                    break;
                }
                catch (FormatException e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }
            }

            switch (choice)
            {
                case '1':
                    TakeInputNumbers();
                    Console.Write(AddMessage);
                    Console.WriteLine(CalculatorOperations.AddNumbers(FirstNumber, SecondNumber));
                    break;
                case '2':
                    TakeInputNumbers();
                    Console.Write(SubtractionMessage);
                    Console.WriteLine(CalculatorOperations.SubtractNumbers(FirstNumber, SecondNumber));
                    break;
                case '3':
                    TakeInputNumbers();
                    Console.Write(MultiplyMessage);
                    Console.WriteLine(CalculatorOperations.MultiplyNumbers(FirstNumber, SecondNumber));
                    break;
                case '4':
                    TakeInputNumbers();
                    try
                    {
                        decimal DivisionResult = CalculatorOperations.DivideNumbers(FirstNumber, SecondNumber);
                        Console.Write(DivisionMessage);
                        Console.WriteLine(DivisionResult);
                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                default:
                    Console.WriteLine(WrongInputMessage);
                    break;
            }
            Console.WriteLine("");
            Console.WriteLine("Do you want to perform more operations ? y/n");
            choice = Convert.ToChar(Console.Read());
        } while (choice != 'n');

    }
}