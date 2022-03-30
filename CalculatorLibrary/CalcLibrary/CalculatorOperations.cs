using System;
using System.Collections.Generic;
using System.Resources;

namespace CalcLibrary
{
    public class CalculatorOperations
    {
        public double ArithmeticOperation(double Number1, double Number2, char Operator)
        {
            string Equation = Number1.ToString() + Operator + Number2;
            return SolveEquation(Equation);
        }
        public double AdvancedOperations(double Number, String Operation)
        {
            List<string> Operations = new List<string> { "Log", "Exp", "Root", "Sin", "Cos", "Tan" };
            var MathLibMethods = new Func<double, double>[] { Math.Log10, Math.Exp, Math.Sqrt, Math.Sin, Math.Cos, Math.Tan };
            Number = Operations.IndexOf(Operation) > 2 ? DegreeToRadian(Number) : Number;
            return MathLibMethods[Operations.IndexOf(Operation)](Number);
        }
        private double DegreeToRadian(double Degree)
        {
            return (Math.PI / 180) * Degree;
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
            return (Character >= '0' && Character <= '9' || Character == '.');
        }
        public double SolveEquation(string Infix)
        {
            ResourceManager rm = new ResourceManager("CalcLibrary.StringResourcesEnglish", typeof(CalculatorOperations).Assembly);
            Stack<char> Stack = new Stack<char>();                  //To convert Infix to Postfix
            Stack<double> Postfix = new Stack<double>();          //To Evaluate the Postfix whenever an operator is pushed to it
            double Value = 0;
            bool justPushed = false;
            int PointCount = -1;                                //For numbers with decimal point (like 3.45)
            try
            {
                foreach (char Character in Infix)
                {
                    if (!IsOperand(Character) && !Character.Equals('(') && !justPushed)
                    {
                        Value = PointCount == -1 ? Value : Value / Math.Pow(10, PointCount);
                        PointCount = -1;
                        Postfix.Push(Value);
                        Value = 0;
                        justPushed = true;
                    }
                    // Case 1. If the current token is an opening bracket '(',
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
                    // Case 3. If the current token is an operand
                    else if (IsOperand(Character))
                    {
                        PointCount = PointCount > -1 ? ++PointCount: PointCount;
                        if (Character == '.')
                        {
                            PointCount++;
                            continue;
                        }
                        Value *= 10;
                        Value += Character - 48;
                        justPushed = false;
                    }
                    // Case 4. If the current token is an operator
                    else
                    {               // remove operators from the stack with higher or equal precedence
                        while (Stack.Count != 0 && GetOperatorPrecedence(Character) >= GetOperatorPrecedence(Stack.Peek()))
                        {
                            EvalExpression();
                        }
                        Stack.Push(Character);
                    }
                }
                if (!justPushed)
                {
                    Value = PointCount == -1 ? Value : Value / Math.Pow(10, PointCount);
                    Postfix.Push(Value);
                }
                while (Stack.Count != 0)
                {
                    EvalExpression();
                }
                return Postfix.Pop();

                void EvalExpression()
                {
                    double Number2 = Postfix.Pop();
                    if (Postfix.Count == 0)
                    {
                        throw new InvalidOperationException();
                    }
                    double Number1 = Postfix.Pop();
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
                            if (Number2 == 0)
                                throw new DivideByZeroException();
                            Postfix.Push(Number1 / Number2);
                            break;
                    }
                }
            }
            catch (DivideByZeroException)
            {
                throw new DivideByZeroException(rm.GetString("DivideByZeroError"));
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException(rm.GetString("ExpressionErrorMessage"));
            }
        }
    }
}
