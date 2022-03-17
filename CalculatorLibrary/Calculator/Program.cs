using CalcLibrary;
using System.Resources;

enum AdvancedArithmeticOperation
{
    Log = 5,
    Exp = 6,
    Sin = 1,
    Cos = 2,
    Tan = 3,
}
class ConsoleCalculator
{
    static void Main()
    {   
        ResourceManager rm = new ResourceManager("ConsoleCalculatorApp.StringResourcesEnglish", typeof(ConsoleCalculator).Assembly);
        do
        {
            Console.Clear();   
            ConsoleCalculatorUI UI = new ConsoleCalculatorUI();
            UI.TakeUserChoice();
            Console.WriteLine("");
            Console.WriteLine(rm.GetString("RunAgainMessage"));
        } while (Console.ReadKey().KeyChar == 13);
    }  
}


class ConsoleCalculatorUI
{
    double FirstNumber;
    double SecondNumber;
    ResourceManager rm = new ResourceManager("ConsoleCalculatorApp.StringResourcesEnglish", typeof(ConsoleCalculator).Assembly);

    private void GetOperands()
    {
        Console.Write(rm.GetString("InputFirstNumberMessage"));
        FirstNumber = GetInputNumber();
        Console.Write(rm.GetString("InputSecondNumberMessage"));
        SecondNumber = GetInputNumber();
    }
    private double GetInputNumber()
    {
        double Number;
        try
        {
            Number = Convert.ToDouble(Console.ReadLine());
            return Number;
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);
            Console.Write(rm.GetString("EnterAgain"));
            return GetInputNumber();
        }
    }
    public void TakeUserChoice()
    {  
        int choice;
        for(int i = 1; i < 10; i++)
        {
            Console.WriteLine(rm.GetString("TakeUserChoiceMessage"+i));
        }
            Console.Write(rm.GetString("EnterChoiceMessage"));
        try
        {
            choice = Convert.ToInt32(Console.ReadLine());
            HandleUserChoice(choice);
        }
        catch (FormatException e)
        {
            Console.Clear();
            Console.WriteLine(e.Message);
            TakeUserChoice();
        }
    }
    public void HandleUserChoice(int choice)
    {
        List<char> ArithmeticOperator = new List<char> { '+', '-', '*', '/' };
        if (choice >= 1 && choice <= 4)
        {
            PerformArithmeticOperation(ArithmeticOperator[choice - 1]);
        }
        else if (choice > 4 && choice <= 8)
        {
            PerformAdvancedArithmeticOp(choice);
        }
        else
        {
            Console.WriteLine(rm.GetString("WrongInputMessage"));
        }
    }

    CalculatorOperations Operation = new CalculatorOperations();

    public void PerformArithmeticOperation(char operatr)
    {
        GetOperands();
        try
        {
            double Result = Operation.ArithmeticOperation(FirstNumber, SecondNumber, operatr);
            Console.Write(rm.GetString("AnswerMessage"));
            Console.WriteLine(Result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public void PerformAdvancedArithmeticOp(int choice)
    {
        if(choice == 8)
        {
            SolveEquation();
        }
        else
        {
            if(choice == 7)
            {
                choice = TakeTrigoChoice();
            }
            else
            {
                Console.Write(rm.GetString("EnterNumber"));
                FirstNumber = GetInputNumber();
            }
            string? OperationToBePerformed = Enum.GetName(typeof(AdvancedArithmeticOperation), choice);
            Console.Write(rm.GetString("AnswerMessage"));
            Console.WriteLine(Operation.AdvancedOperations(FirstNumber, OperationToBePerformed));
        }
    }
    private int TakeTrigoChoice()
    {
        for(int i = 1; i <= 3; i++)
        {
            Console.WriteLine(rm.GetString("TrigoRatio"+i));
        }
        Console.Write(rm.GetString("EnterChoiceMessage"));
        int choice = Convert.ToInt32(Console.ReadLine());
        if(choice >= 1 && choice <= 3)
        {
            Console.Write(rm.GetString("EnterAngle"));
            FirstNumber = GetInputNumber();
        }
        else
        {
            Console.WriteLine(rm.GetString("InvalidChoiceMessage"));
            Console.Clear();
            choice = TakeTrigoChoice();
        }
        return choice;
    }
    public void SolveEquation()
    {
        Console.Write(rm.GetString("EnterEquationMessage"));
        string equation = Console.ReadLine();
        try
        {
            double result = Operation.SolveEquation(equation);
            Console.Write(rm.GetString("AnswerMessage"));
            Console.WriteLine(result);
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}