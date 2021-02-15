using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Assignment_NRDCL.Utils
{
    public class CustomEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {

            Regex rgx = new Regex(@"[a-z0-9._%+-]+@mit.edu");
            if (!rgx.IsMatch(value.ToString()))
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return $"Please enter a valid email which ends with @mit.edu";
        }
    }
}