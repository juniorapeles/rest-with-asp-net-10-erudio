using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNET10Erudio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MathController : ControllerBase
    {
        private const double DIVISOR_MEDIA = 2d;

        [HttpGet("avr/{firstNumber}/{secondNumber}")]
        public IActionResult Average(string firstNumber, string secondNumber)
        {   
            if(!TryConvertToDouble(firstNumber,out var num1) ||
                !TryConvertToDouble(secondNumber, out var num2))
            {
                return BadRequest("Invalid input!");
            }

            var response = (num1 + num2) / DIVISOR_MEDIA;
            return Ok(response);
        }

        [HttpGet("sqrt/{firstNumber}")]
        public IActionResult Sqrt(string firstNumber)
        {
            if(!TryConvertToDouble(firstNumber, out var number))
                return BadRequest("Invalid input!");

            var response = Math.Sqrt(number);
            return Ok(response);
           
        }


        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult Div(string firstNumber, string secondNumber)
        {
            if (!TryConvertToDecimal(firstNumber,out var num1) ||
                !TryConvertToDecimal(secondNumber,out var num2))
            {
                return BadRequest("Invalid input");
            }

            if (num2 == decimal.Zero)
                return BadRequest("Division by Zero is not Allowed.");

            var response = num1 / num2;
            return Ok(response);
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (!TryConvertToDecimal(firstNumber, out var num1) ||
                !TryConvertToDecimal(secondNumber, out var num2))
            {
                return BadRequest("Invalid input");
            }

        
            var response = num1 + num2;
            return Ok(response);
        }

        [HttpGet("mul/{firstNumber}/{secondNumber}")]
        public IActionResult Mul(string firstNumber, string secondNumber)
        {
            if (!TryConvertToDecimal(firstNumber, out var num1) ||
                !TryConvertToDecimal(secondNumber, out var num2))
            {
                return BadRequest("Invalid input");
            }

        
            var response = num1 * num2;
            return Ok(response);
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Sub(string firstNumber, string secondNumber)
        {
            if (!TryConvertToDecimal(firstNumber, out var num1) ||
                !TryConvertToDecimal(secondNumber, out var num2))
            {
                return BadRequest("Invalid input");
            }

        
            var response = num1 - num2;
            return Ok(response);
        }

        private bool TryConvertToDouble(string strNumber, out double result)
        {
            return double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out result
            );
        }

        private bool TryConvertToDecimal(string strNumber, out decimal result)
        {
            return decimal.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out result
            );
        }
    }
}
