using CalculatorLibrary;
using System.Resources;
enum UserChoice
{
    Add = 1,
    Subtract,
    Multiply,
    Divide,
    Log,
    Exponential,
    TrigonometricFunctions,
    Equation
}

enum TrigonometricRatio
{
    Sin = 1,
    Cos,
    Tan,
    Cosec,
    Sec,
    Cot
}

class ConsoleCalculator
{
    static void Main()
    {   
        ResourceManager rm = new ResourceManager("ConsoleCalculatorApp.StringResourcesEnglish", typeof(ConsoleCalculator).Assembly);
        do
        {
            //Console.Clear();   
            ConsoleCalculatorUI UI = new ConsoleCalculatorUI();
            
            switch(UI.TakeUserChoice())
            {
                case "Add":
                    UI.GetAddition();
                    break;
                case "Subtract":
                    UI.GetSubtraction();
                    break;
                case "Multiply":
                    UI.GetMultiplication();
                    break;
                case "Divide":
                    UI.GetDivision();
                    break;
                case "Log":
                    UI.GetLog();
                    break;
                case "Exponential":
                    UI.GetExponential();
                    break;
                case "TrigonometricFunctions":
                    UI.GetTrigonometricRatio();
                    break;
                case "Equation":
                    UI.SolveEquation();
                    break;
                default:
                    Console.WriteLine(rm.GetString("WrongInputMessage"));
                    break;
            }
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

    public string? TakeUserChoice()
    {
        int choice;
        try
        {
            Console.WriteLine(rm.GetString("AskUserMessage"));
            Console.WriteLine(rm.GetString("AddChoice"));
            Console.WriteLine(rm.GetString("SubtractChoice"));
            Console.WriteLine(rm.GetString("MultiplyChoice"));
            Console.WriteLine(rm.GetString("DivideChoice"));
            Console.WriteLine(rm.GetString("LogChoice"));
            Console.WriteLine(rm.GetString("ExponentialChoice"));
            Console.WriteLine(rm.GetString("TrigonometricChoice"));
            Console.WriteLine(rm.GetString("ExpressionChoice"));
            Console.Write(rm.GetString("EnterChoiceMessage"));
            choice = Convert.ToInt32(Console.ReadLine());
            
            return Enum.GetName(typeof(UserChoice),choice);
           
        }
        catch (FormatException e)
        {
            Console.Clear();
            Console.WriteLine(e.Message);
            return TakeUserChoice();
        }
    }

    CalculatorOperations Operation = new CalculatorOperations();

    public void GetAddition()
    {
        GetOperands();
        Console.Write(rm.GetString("AddMessage"));
        Console.WriteLine(Operation.AddNumbers(FirstNumber, SecondNumber));
    }

    public void GetSubtraction()
    {
        GetOperands();
        Console.Write(rm.GetString("SubtractionMessage"));
        Console.WriteLine(Operation.SubtractNumbers(FirstNumber, SecondNumber));
    }

    public void GetMultiplication()
    {
        GetOperands();
        Console.Write(rm.GetString("MultiplyMessage"));
        Console.WriteLine(Operation.MultiplyNumbers(FirstNumber, SecondNumber));
    }

    public void GetDivision()
    {
        GetOperands();
        try
        {
            decimal DivisionResult = Operation.DivideNumbers(FirstNumber, SecondNumber);
            Console.Write(rm.GetString("DivisionMessage"));
            Console.WriteLine(DivisionResult);
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void GetLog()
    {
        Console.Write(rm.GetString("EnterNumber"));
        FirstNumber = GetInputNumber();
        Console.WriteLine(Operation.GetLog(Convert.ToDouble(FirstNumber)));
    }

    public void GetExponential()
    {
        Console.Write(rm.GetString("EnterNumber"));
        FirstNumber = GetInputNumber();
        Console.WriteLine(Operation.GetExp(Convert.ToDouble(FirstNumber)));
    }
    public void GetTrigonometricRatio()
    {
        switch (TakeTrigoChoice())
        {
            case "Sin":
                Console.WriteLine(Operation.GetTrigoSin((double)(FirstNumber)));
                break;
            case "Cos":
                Console.WriteLine(Operation.GetTrigoCos((double)(FirstNumber)));
                break;
            case "Tan":
                Console.WriteLine(Operation.GetTrigoTan((double)(FirstNumber)));
                break;
            case "Cosec":
                Console.WriteLine(Operation.GetTrigoSin((double)(FirstNumber)));
                break;
            case "Sec":
                Console.WriteLine(Operation.GetTrigoCos((double)(FirstNumber)));
                break;
            case "Cot":
                Console.WriteLine(Operation.GetTrigoTan((double)(FirstNumber)));
                break;
        }
        
    }
    private string? TakeTrigoChoice()
    {
        Console.WriteLine(rm.GetString("Sin"));
        Console.WriteLine(rm.GetString("Cos"));
        Console.WriteLine(rm.GetString("Tan"));
        Console.WriteLine(rm.GetString("Cosec"));
        Console.WriteLine(rm.GetString("Sec"));
        Console.WriteLine(rm.GetString("Cot"));
        Console.Write(rm.GetString("EnterChoiceMessage"));
        int choice = Convert.ToInt32(Console.ReadLine());
        Console.Write(rm.GetString("EnterAngle"));
        FirstNumber = GetInputNumber();
        return Enum.GetName(typeof(TrigonometricRatio),choice);
    }
    public void SolveEquation()
    {
        Console.Write(rm.GetString("EnterEquationMessage"));
        string? equation = Console.ReadLine();
        Console.WriteLine(Operation.SolveEquation(equation));
    }
}