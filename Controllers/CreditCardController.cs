using Microsoft.AspNetCore.Mvc;

namespace Dotnet_api.Controllers;

[ApiController]
[Route("[controller]")]
// API Controller for handling the credit card POST req
public class CreditCardController : ControllerBase
{
    // When a POST req is recevied, compute the following
    [HttpPost]
    public IActionResult LuhnValidateCard([FromBody] CreditcardDto cardDto)
    {
        // Add validation checking on credit card number.
        

        // Convert string of credit card number to an array of digits
        int[] digits = cardDto.CardNumber.Select(c => int.Parse(c.ToString())).ToArray();

        if (isLuhnValid(digits))
        {
            return Ok(true);
        }
        else
        {
            return Ok(false);
        }
    }

    // Helper functino that performs luhn validation on credit card number received
    static bool isLuhnValid(in int[] digits)
    {
        int check_digit = 0;
        for (int i = digits.Length - 2; i >= 0; --i)
            check_digit += ((i & 1) is 0) switch
            {
                true => digits[i] > 4 ? digits[i] * 2 - 9 : digits[i] * 2,
                false => digits[i]
            };

        return (10 - (check_digit % 10)) % 10 == digits.Last();
    }
}
