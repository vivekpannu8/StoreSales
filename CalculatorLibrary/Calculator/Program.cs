using CalculatorLibrary;

class ConsoleCalculator
{
   static void Main()
    {
        const string addMessage = "Addition is : ";
        const string subtractionMessage = "Subtraction is : ";
        const string multiplyMessage = "Multiplication is : ";
        const string divisionMessage = "Division is : ";
        const string inputFirstNumberMessage = "Enter two numbers : \n\tFirst Number: ";
        const string inputSecondNumberMessage = "\tSecond Number: ";
        const string wrongInputMessage = "Wrong Input !!!";
        const string takeUserChoiceMessage = @"Which operation you want to perfom ?
            1. Addition
            2. Subtraction
            3. Multiplication
            4. Division
            5. Exit
        Enter your Choice : ";
        decimal firstNumber;
        decimal secondNumber;
        
        
        void takeInputNumbers()
        {
            while (true)
            {
                try
                {
                    Console.Write(inputFirstNumberMessage);
                    firstNumber = Convert.ToDecimal(Console.ReadLine());
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
                    Console.Write(inputSecondNumberMessage);
                    secondNumber = Convert.ToDecimal(Console.ReadLine());
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
       
        
        int choice;
        do
        {
            while (true)
            {
                try
                {
                    Console.Write(takeUserChoiceMessage);
                    choice = Convert.ToInt32(Console.ReadLine());
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
                case 1:
                    takeInputNumbers();
                    Console.Write(addMessage);
                    Console.WriteLine(CalculatorOperations.addNumbers(firstNumber, secondNumber));
                    break;
                case 2:
                    takeInputNumbers();
                    Console.Write(subtractionMessage);
                    Console.WriteLine(CalculatorOperations.subtractNumbers(firstNumber, secondNumber));
                    break;
                case 3:
                    takeInputNumbers();
                    Console.Write(multiplyMessage);
                    Console.WriteLine(CalculatorOperations.multiplyNumbers(firstNumber, secondNumber));
                    break;
                case 4:
                    takeInputNumbers();
                    try
                    {
                        decimal divisionResult = CalculatorOperations.divideNumbers(firstNumber, secondNumber);
                        Console.Write(divisionMessage);
                        Console.WriteLine(divisionResult);
                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine(wrongInputMessage);
                    break;
            }
            Console.WriteLine("");
            Console.WriteLine("Do you want to perform more operations ? y/n");
            if(Console.ReadLine() == "n")
            {
                choice = 5;
            }
            else 
            Console.Clear();
        } while (choice != 5); 

    }
}