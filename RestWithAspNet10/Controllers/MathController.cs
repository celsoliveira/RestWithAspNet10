using Microsoft.AspNetCore.Mvc;
using RestWithAspNet10.Services;
using RestWithAspNet10.Utils;

namespace RestWithAspNet10.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MathController : ControllerBase
    {

        private readonly MathService _service;

        public MathController(MathService service)
        {
            this._service = service;
        }

        //https://localhost:7131/math/sum/2/3

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (NumberHelper.IsNumeric(firstNumber) && NumberHelper.IsNumeric(secondNumber))
            {
                var sum = _service.Sum(NumberHelper.ConvertToDecimal(firstNumber), NumberHelper.ConvertToDecimal(secondNumber));
                return Ok(sum);
            }
            return BadRequest("Invalid input.");
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult subtraction(string firstNumber, string secondNumber)
        {
            if (NumberHelper.IsNumeric(firstNumber) && NumberHelper.IsNumeric(secondNumber))
            {
                var subtraction = _service.Subtraction(NumberHelper.ConvertToDecimal(firstNumber),NumberHelper.ConvertToDecimal(secondNumber));
                return Ok(subtraction);
            }
            return BadRequest("Invalid input.");
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (NumberHelper.IsNumeric(firstNumber) && NumberHelper.IsNumeric(secondNumber))
            {
                var multiplication = _service.Multiplication(NumberHelper.ConvertToDecimal(firstNumber), NumberHelper.ConvertToDecimal(secondNumber));
                return Ok(multiplication);
            }
            return BadRequest("Invalid input.");
        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult division(string firstNumber, string secondNumber)
        {
            if (NumberHelper.IsNumeric(firstNumber) && NumberHelper.IsNumeric(secondNumber))
            {
                var division = _service.Division(NumberHelper.ConvertToDecimal(firstNumber), NumberHelper.ConvertToDecimal(secondNumber));
                return Ok(division);
            }
            return BadRequest("Invalid input.");
        }

        [HttpGet("squareroot/{number}")]
        public IActionResult squareroot(string number)
        {
            if (NumberHelper.IsNumeric(number))
            {
                var sqrNumber = _service.SquareRoot(NumberHelper.ConvertToDecimal(number));
                return Ok(sqrNumber);
            }
            return BadRequest("Invalid input.");
        }


    }
}
