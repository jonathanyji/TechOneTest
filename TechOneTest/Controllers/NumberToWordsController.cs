using Microsoft.AspNetCore.Mvc;

namespace TechOneTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumberToWordsController : ControllerBase
    {

        private static string[] ones = {
            "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN",
            "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN"
        };

        private static string[] tens = {
            "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY"
        };


        [HttpPost]
        [Route("/convert")]
        public IActionResult ConvertNumbersToWords(double? number)
        {
            if (number.HasValue)
            {
                try
                {
                    String result = Convert(number.Value);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return BadRequest("Error converting the number: " + ex.Message);
                }
            }
            else
            {
                return BadRequest("Invalid input");
            }
        }

        public static string Convert(double number)
        {
            if (number == 0)
                return "ZERO DOLLARS";

            if (number < 0)
                return "MINUS " + Convert(Math.Abs(number));

            if (number > 999999999999.99)
                return "Number out of range";

            string result = "";

            long dollars = (long)number;
            int cents = (int)Math.Round((number - dollars) * 100);

            if (dollars > 0)
            {
                result += ConvertToWords(dollars) + " DOLLARS";
            }

            if (cents > 0)
            {
                if (dollars > 0)
                    result += " AND ";

                result += ConvertToWords(cents) + " CENTS";
            }

            return result;
        }

        private static string ConvertToWords(long number)
        {
            string words = "";

            if ((number / 1000000000) > 0)
            {
                words += ConvertToWords(number / 1000000000) + " BILLION ";
                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                words += ConvertToWords(number / 1000000) + " MILLION ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += ConvertToWords(number / 1000) + " THOUSAND ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += ConvertToWords(number / 100) + " HUNDRED ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "AND ";

                if (number < 20)
                    words += ones[number];
                else
                {
                    words += tens[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + ones[number % 10];
                }
            }

            return words;
        }
    }
}
