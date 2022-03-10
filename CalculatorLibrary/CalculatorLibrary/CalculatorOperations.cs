using System.Resources;

namespace CalculatorLibrary
{
    public class CalculatorOperations
    {   
        public decimal AddNumbers (decimal Number1, decimal Number2)
        {
            return Number1 + Number2;
        }
        public decimal SubtractNumbers(decimal Number1, decimal Number2)
        {
            return Number1 - Number2;
        }
        public decimal MultiplyNumbers(decimal Number1, decimal Number2)
        {
            return Number1 * Number2;
        }
        public decimal DivideNumbers(decimal Number1, decimal Number2)
        {
            if(Number2 == 0)
            {
                ResourceManager rm = new ResourceManager("CalculatorLibrary.StringResourcesEnglish", typeof(CalculatorOperations).Assembly);
                throw new DivideByZeroException(rm.GetString("DivideByZeroError"));
            }
            
            return Number1 / Number2;
        }
        public double GetLog(double Number)
        {
            return Math.Log10(Number);
        }
        public double GetExp(double Number)
        {
            return Math.Exp(Number);
        }
        public double GetTrigoSin(double Number)
        {
            return Math.Sin(Number);
        }
        public double GetTrigoCos(double Number)
        {
            return Math.Cos(Number);
        }
        public double GetTrigoTan(double Number)
        {
            return Math.Tan(Number);
        }
        public decimal? SolveEquation(string? Equation)
        {
            if(!String.IsNullOrEmpty(Equation))
            {
                decimal Result = InfixToPostfixThenEval(Equation);
                return Result;
            }
            return 0;
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

        // Function to convert an infix expression to a postfix expression.
        private decimal InfixToPostfixThenEval(string Infix)
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
                        Console.WriteLine("Pushed Value is : {0}", Value);
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
                            EvalExpression();
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
                        EvalExpression();
                    }
                    Stack.Push(Character);
                }  
            }
            if(!justPushed)
            Postfix.Push(Value);
            while (Stack.Count != 0)
            {
                EvalExpression();
            }
            return Postfix.Pop();

            void EvalExpression()
            {
                decimal Number2 = Postfix.Pop();
                decimal Number1 = Postfix.Pop();
                Console.WriteLine(Number1 + " " +Stack.Peek()+ " " + Number2);
                switch (Stack.Pop())
                {
                    case '+':
                        Postfix.Push(AddNumbers(Number1, Number2));
                        break;
                    case '-':
                        Postfix.Push(SubtractNumbers(Number1, Number2));
                        break;
                    case '*':
                        Postfix.Push(MultiplyNumbers(Number1, Number2));
                        break;
                    case '/':
                        Postfix.Push(DivideNumbers(Number1, Number2));
                        break;
                }
            }
        }
    }
}