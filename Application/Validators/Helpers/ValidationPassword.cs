using System.Text.RegularExpressions;

namespace InventoryApp.Api.Application.Validators.Helpers
{
    public class ValidationPassword
    {
        private int MinimumLenght { get; set; }
        private int MaximumLenght { get; set; }
        private int QuantityUpper { get; set; }
        private int QuantityLower { get; set; }
        private int QuantityNumber { get; set; }
        private int QuantitySpecial { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="minimumLenght">Minimum number of password characters.</param>
        /// <param name="maximumLenght">Maximum number of password characters.</param>
        /// <param name="quantityUpper">Minimum number of uppercase characters.</param>
        /// <param name="quantityLower">Minimum number of lowercase characters.</param>
        /// <param name="quantityNumber">Minimum number of numeric characters.</param>
        /// <param name="quantitySpecial">Minimum number of special characters.</param>
        public ValidationPassword(int minimumLenght = 8, int maximumLenght = 60, int quantityUpper = 1, int quantityLower = 1, int quantityNumber = 1, int quantitySpecial = 0)
        {
            MinimumLenght = minimumLenght;
            MaximumLenght = maximumLenght;
            QuantityUpper = quantityUpper;
            QuantityLower = quantityLower;
            QuantityNumber = quantityNumber;
            QuantitySpecial = quantitySpecial;
        }

        public bool IsValidPassword(string password)
        {

            //Replace [A-Z] with \p{Lu}, to allow for Unicode uppercase letters.
            var upper = new Regex("[A-Z]");
            var lower = new Regex("[a-z]");
            var number = new Regex("[0-9]");
            // Special is "none of the above".
            var special = new Regex("[^a-zA-Z0-9]");

            // Check the length.
            if (password.Trim().Length < MinimumLenght) { return false; }
            if (password.Trim().Length > MaximumLenght) { return false; }
            // Check for minimum number of occurrences.
            if (upper.Matches(password).Count < QuantityUpper) { return false; }
            if (lower.Matches(password).Count < QuantityLower) { return false; }
            if (number.Matches(password).Count < QuantityNumber) { return false; }
            if (special.Matches(password).Count < QuantitySpecial) { return false; }

            return true;
        }
    }
}
