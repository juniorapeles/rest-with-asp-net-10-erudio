namespace RestWithASPNET10Erudio.Services
{
    public class MathService
    {

        private const double DIVISOR_MEDIA = 2d;

        public decimal Sum(decimal firstNumber, decimal secondNumber) => firstNumber + secondNumber;

        public decimal Mean(double firstNumber, double secondNumber)
        {
            return (decimal)((firstNumber + secondNumber) / DIVISOR_MEDIA);
        }

        public decimal Sub(decimal firstNumber, decimal secondNumber) => firstNumber - secondNumber;
        public decimal Mul(decimal firstNumber, decimal secondNumber) => firstNumber * secondNumber;

        public decimal Div(decimal firstNumber, decimal secondNumber)
        {
            if (secondNumber == 0) throw new DivideByZeroException("Division by zero is not Allowed.");
            return firstNumber / secondNumber;
        }

        public double Sqrt(double number)
        {
            if (number < 0) throw new ArgumentOutOfRangeException(
                "Cannot calculate the square root of negative number.");
            return Math.Sqrt(number);
        }
    }
}
