using CalculatorLibrary;
using System.Resources;

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
    decimal FirstNumber;
    decimal SecondNumber;
    ResourceManager rm = new ResourceManager("ConsoleCalculatorApp.StringResourcesEnglish", typeof(ConsoleCalculator).Assembly);

    private void GetOperands()
    {
        Console.Write(rm.GetString("InputFirstNumberMessage"));
        FirstNumber = GetInputNumber();
        Console.Write(rm.GetString("InputSecondNumberMessage"));
        SecondNumber = GetInputNumber();
    }
    private decimal GetInputNumber()
    {
        decimal Number;
        try
        {
            Number = Convert.ToDecimal(Console.ReadLine());
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
        var AdvancedOperation = new Func<int>[] { GetLog, GetExponential, GetTrigonometricRatio, SolveEquation };
        if (choice >= 1 && choice <= 4)
        {
            PerformArithmeticOperation(ArithmeticOperator[choice - 1]);
        }
        else if (choice > 4 && choice <= 8)
        {
            AdvancedOperation[choice - 5]();
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
        decimal? Result = Operation.ArithmeticOperation(FirstNumber, SecondNumber, operatr);
        if (Result.HasValue)
        {
            Console.Write(rm.GetString("AnswerMessage"));
            Console.WriteLine(Result);
        }
        else
        {
            Console.WriteLine(rm.GetString("DivideByZeroError"));
        }
    }
    public int GetLog()
    {
        Console.Write(rm.GetString("EnterNumber"));
        FirstNumber = GetInputNumber();
        Console.Write(rm.GetString("AnswerMessage"));
        Console.WriteLine(Operation.GetLog(Convert.ToDouble(FirstNumber)));
        return 0;
    }

    public int GetExponential()
    {
        Console.Write(rm.GetString("EnterNumber"));
        FirstNumber = GetInputNumber();
        Console.Write(rm.GetString("AnswerMessage"));
        Console.WriteLine(Operation.GetExp(Convert.ToDouble(FirstNumber)));
        return 0;
    }
    public int GetTrigonometricRatio()
    {
        var TrigoFunctions = new Func<double,double>[] { Operation.GetTrigoSin, Operation.GetTrigoCos, Operation.GetTrigoTan };
        int choice = TakeTrigoChoice();
        Console.Write(rm.GetString("AnswerMessage"));
        if(choice <= 3)
        {
            Console.WriteLine(TrigoFunctions[choice-1]((double)FirstNumber));
        }
        else
        {
            choice -= 3;
            Console.WriteLine(1/TrigoFunctions[choice-1]((double)FirstNumber));
        }
        
        return 0;
    }
    private int TakeTrigoChoice()
    {
        for(int i = 1; i <= 6; i++)
        {
            Console.WriteLine(rm.GetString("TrigoRatio"+i));
        }
        Console.Write(rm.GetString("EnterChoiceMessage"));
        int choice = Convert.ToInt32(Console.ReadLine());
        if(choice >= 1 && choice <= 6)
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
    public int SolveEquation()
    {
        Console.Write(rm.GetString("EnterEquationMessage"));
        string? equation = Console.ReadLine();
        decimal? result = Operation.SolveEquation(equation);
        if (result.HasValue)
        {
            Console.Write(rm.GetString("AnswerMessage"));
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine(rm.GetString("ExpressionErrorMessage"));
        }
        return 0;
    }
}