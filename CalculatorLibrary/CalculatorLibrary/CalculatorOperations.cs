namespace CalculatorLibrary
{
    public class CalculatorOperations
    {
        public static decimal addNumbers (decimal number1, decimal number2)
        {
            return number1 + number2;
        }
        public static decimal subtractNumbers(decimal number1, decimal number2)
        {
            return number1 - number2;
        }
        public static decimal multiplyNumbers(decimal number1, decimal number2)
        {
            return number1 * number2;
        }
        public static decimal divideNumbers(decimal number1, decimal number2)
        {
            if(number2 == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero");
            } 
            return number1 / number2;
        }
    }
  
}