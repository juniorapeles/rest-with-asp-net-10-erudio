using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10Erudio.Services;
using RestWithASPNET10Erudio.Utils;

namespace RestWithASPNET10Erudio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MathController : ControllerBase
    {   
        private readonly MathService _service;
 

        public MathController(MathService service)
        {
            _service = service;
        }

        [HttpGet("avr/{firstNumber}/{secondNumber}")]
        public IActionResult Average(string firstNumber, string secondNumber)
        {   
            if(!NumberHelper.TryConvertToDouble(firstNumber,out var num1) ||
                !NumberHelper.TryConvertToDouble(secondNumber, out var num2))
            {
                return BadRequest("Invalid input!");
            }

            var response = _service.Mean(num1, num2);
            return Ok(response);
        }

        [HttpGet("sqrt/{firstNumber}")]
        public IActionResult Sqrt(string firstNumber)
        {
            if(!NumberHelper.TryConvertToDouble(firstNumber, out var number))
                return BadRequest("Invalid input!");

            var response = _service.Sqrt(number);
            return Ok(response);
        }


        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult Div(string firstNumber, string secondNumber)
        {
            if (!NumberHelper.TryConvertToDecimal(firstNumber,out var num1) ||
                !NumberHelper.TryConvertToDecimal(secondNumber,out var num2))
            {
                return BadRequest("Invalid input");
            }

            var response = _service.Div(num1, num2);
            return Ok(response);
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (!NumberHelper.TryConvertToDecimal(firstNumber, out var num1) ||
                !NumberHelper.TryConvertToDecimal(secondNumber, out var num2))
            {
                return BadRequest("Invalid input");
            }

        
            var response = _service.Sum(num1, num2);
            return Ok(response);
        }

        [HttpGet("mul/{firstNumber}/{secondNumber}")]
        public IActionResult Mul(string firstNumber, string secondNumber)
        {
            if (!NumberHelper.TryConvertToDecimal(firstNumber, out var num1) ||
                !NumberHelper.TryConvertToDecimal(secondNumber, out var num2))
            {
                return BadRequest("Invalid input");
            }

        
            var response = _service.Mul(num1, num2);
            return Ok(response);
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Sub(string firstNumber, string secondNumber)
        {
            if (!NumberHelper.TryConvertToDecimal(firstNumber, out var num1) ||
                !NumberHelper.TryConvertToDecimal(secondNumber, out var num2))
            {
                return BadRequest("Invalid input");
            }
        
            var response = _service.Sub(num1, num2);
            return Ok(response);
        }
    }
}
