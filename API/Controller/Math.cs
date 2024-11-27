using Microsoft.AspNetCore.Mvc;

namespace API.Controller {
  // TODO Task 5
  [Route("math")]
  public class MathController : ControllerBase {
    [HttpGet("fibonacci")]
    public IActionResult Fibonacci(int a) {
      // TODO Task 1

      int first = 0, second = 1, result = 0;

      if (a == 0) return Ok(first);
      if (a == 1) return Ok(second);

      for (int i = 2; i <= a; i++) {
        result = first + second;
        first = second;
        second = result;
      }

      return Ok(result);
    }

    [HttpGet("factorial")]
    public IActionResult Factorial(int n) {
      // TODO Task 2
      throw new System.NotImplementedException();
    }

    // TODO Task 3 

    // TODO Task 4
    [HttpGet("isprime")]
    public IActionResult IsPrime(int n) {
      if (n <= 1) return Ok(false);
      for (int i = 2; i < n; i++) {
        if (n % i == 0) return Ok(false);
      }
      return Ok(true);
    }
  }
}