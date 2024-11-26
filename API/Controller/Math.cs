using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    /// <summary>
    /// Controller providing mathematical operations.
    /// </summary>
    [Route("math")]
    public class MathController : ControllerBase
    {
        /// <summary>
        /// Calculates the Fibonacci number at the specified position.
        /// </summary>
        /// <param name="a">The position in the Fibonacci sequence.</param>
        /// <returns>The Fibonacci number at the specified position.</returns>
        [HttpGet("fibonacci")]
        public IActionResult Fibonacci(int a)
        {
            if (a < 0) return BadRequest("Invalid input");

            int first = 0, second = 1, result = 0;

            if (a == 0) return Ok(first);
            if (a == 1) return Ok(second);

            for (int i = 2; i <= a; i++)
            {
                result = first + second;
                first = second;
                second = result;
            }

            return Ok(result);
        }

        /// <summary>
        /// Calculates the factorial of the specified number.
        /// </summary>
        /// <param name="n">The number to calculate the factorial of.</param>
        /// <returns>The factorial of the specified number.</returns>
        [HttpGet("factorial")]
        public IActionResult Factorial(int n)
        {
            if (n < 0) return BadRequest("Invalid input");

            int result = 1;

            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }

            return Ok(result);
        }

        /// <summary>
        /// Calculates the greatest common divisor (GCD) of two numbers.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>The GCD of the two numbers.</returns>
        [HttpGet("gcd")]
        public IActionResult Gcd(int a, int b)
        {
            if (a < 0 || b < 0) return BadRequest("Invalid input");

            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return Ok(a);
        }

        /// <summary>
        /// Determines whether the specified number is prime.
        /// </summary>
        /// <param name="n">The number to check for primality.</param>
        /// <returns>True if the number is prime, otherwise false.</returns>
        [HttpGet("isprime")]
        public IActionResult IsPrime(int n)
        {
            if (n <= 1) return Ok(false);
            if (n <= 3) return Ok(true);
            if (n % 2 == 0 || n % 3 == 0) return Ok(false);

            for (int i = 5; i * i <= n; i += 6)
            {
                if (n % i == 0 || n % (i + 2) == 0) return Ok(false);
            }
            return Ok(true);
        }
    }
}
