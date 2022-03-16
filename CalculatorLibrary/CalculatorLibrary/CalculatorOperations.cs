using System.Resources;

namespace CalculatorLibrary
{  
    public class CalculatorOperations
    {
        public decimal? ArithmeticOperation(decimal Number1, decimal Number2, char Operator)
        {
            string Equation = Number1.ToString() + Operator + Number2;
            return InfixToPostfixThenEval(Equation);
        }
        public double AdvancedOperations(double Number, String Operation)
        {
            List<string> Operations = new List<string> { "Log", "Exp", "Sin", "Cos", "Tan" };
            var MathLibMethods = new Func<double, double>[] { Math.Log10, Math.Exp, Math.Sin, Math.Cos, Math.Tan };
            if(Operations.IndexOf(Operation) > 1)
            {
                Number = DegreeToRadian(Number);
            }
            return MathLibMethods[Operations.IndexOf(Operation)](Number);
        }
        private double DegreeToRadian(double Degree)
        {
            return (Math.PI / 180) * Degree;
        }
        public decimal? SolveEquation(string? Equation)
        {
            if (!String.IsNullOrEmpty(Equation))
            {
                decimal? Result = InfixToPostfixThenEval(Equation);
                return Result;
            }
            return null;
        }
        private int GetOperatorPrecedence(char Character)
        {
            if (Character == '*' || Character == '/')
            {
                return 3;
            }
            if (Character == '+' || Character == '-')
            {
                return 4;
            }
            return 10;            // for opening bracket '('
        }
        private bool IsOperand(char Character)
        {
            return (Character >= '0' && Character <= '9');
        }
        private decimal? InfixToPostfixThenEval(string Infix)
        {
            Stack<char> Stack = new Stack<char>();                  //To convert Infix to Postfix
            Stack<decimal> Postfix = new Stack<decimal>();          //To Evaluate the Postfix whenever an operator is pushed to it
            decimal Value = 0;
            bool justPushed = false;
            foreach (char Character in Infix)
            {
                if (!IsOperand(Character) && !Character.Equals('('))
                {
                    if (!justPushed)
                    {
                        Postfix.Push(Value);
                        Value = 0;
                        justPushed = true;
                    }
                }
                // Case 1. If the current token is an opening bracket '(',
                // push it into the stack
                if (Character == '(')
                {
                    Stack.Push(Character);
                }
                // Case 2. If the current token is a closing bracket ')'
                else if (Character == ')')
                {
                    while (Stack.Peek() != '(')
                    {
                        try
                        {
                            EvalExpression();
                        }
                        catch (Exception)
                        {
                            break;
                        }
                    }
                    Stack.Pop();
                }
                // Case 3. If the current token is an operand, append it at the end of the
                // postfix expression
                else if (IsOperand(Character))
                {
                    Value *= 10;
                    Value += Character - 48;
                    justPushed = false;
                }
                // Case 4. If the current token is an operator
                else
                {
                    // remove operators from the stack with higher or equal precedence
                    while (Stack.Count != 0 && GetOperatorPrecedence(Character) >= GetOperatorPrecedence(Stack.Peek()))
                    {
                        try
                        {
                            EvalExpression();
                        }
                        catch (Exception)
                        {
                            break;
                        }
                    }
                    Stack.Push(Character);
                }
            }
            if (!justPushed)
                Postfix.Push(Value);
            while (Stack.Count != 0)
            {
                try
                {
                    EvalExpression();
                }
                catch (Exception)
                {
                    break;
                }
            }
            try
            {
                return Postfix.Pop();
            }
            catch (Exception) 
            {
                return null;
            }

            void EvalExpression()
            {
                decimal Number2 = Postfix.Pop();
                if (Postfix.Count == 0)
                {
                    throw new InvalidOperationException();
                }
                decimal Number1 = Postfix.Pop();
                switch (Stack.Pop())
                {
                    case '+':
                        Postfix.Push(Number1 + Number2);
                        break;
                    case '-':
                        Postfix.Push(Number1 - Number2);
                        break;
                    case '*':
                        Postfix.Push(Number1 * Number2);
                        break;
                    case '/':
                        Postfix.Push(DivideNumbers(Number1, Number2));
                        break;
                }
            }
        }
        public decimal DivideNumbers(decimal Number1, decimal Number2)
        {
            if (Number2 == 0)
            {
                ResourceManager rm = new ResourceManager("CalculatorLibrary.StringResourcesEnglish", typeof(CalculatorOperations).Assembly);
                throw new DivideByZeroException(rm.GetString("DivideByZeroError"));
            }

            return Number1 / Number2;
        }
    }
}