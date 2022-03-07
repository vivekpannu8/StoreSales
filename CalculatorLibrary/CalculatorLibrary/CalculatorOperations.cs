namespace CalculatorLibrary
{
    public class CalculatorOperations
    {
        public static decimal AddNumbers (decimal number1, decimal number2)
        {
            return number1 + number2;
        }
        public static decimal SubtractNumbers(decimal number1, decimal number2)
        {
            return number1 - number2;
        }
        public static decimal MultiplyNumbers(decimal number1, decimal number2)
        {
            return number1 * number2;
        }
        public static decimal DivideNumbers(decimal number1, decimal number2)
        {
            if(number2 == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero");
            } 
            return number1 / number2;
        }
    }
  
}