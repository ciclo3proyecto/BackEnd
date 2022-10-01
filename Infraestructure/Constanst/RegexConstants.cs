namespace InventoryApp.Api.Infraestructure.Constanst
{
    public class RegexConstants
    {
        public const string Numeric = "0-9";

        public const string Alphabetical = "A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚñÑ";

        public const string Space = "\\s";

        public const string Alphanumeric = "0-9A-Za-zñÑ";

        public const string PunctuationSigns = ".:;,";

        public const string Parenthesis = "()";

        public const string Keys = "{}";

        public const string Brackets = "[]";

        public const string Hyphen = "-";

        public const string Grade = "°";

        public const string Underscore = "_";

        public const string Slash = "/";

        public const string Expressions = "¿?¡!";

        public const string Numeral = "#";

        public const string SentenceCase = Alphabetical + Space + PunctuationSigns;

        public const string Decimals = "^[0-9]+([.][0-9]+)?$";

        public const string Guid = "^[{]?[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}[}]?";

        public const string Password = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";

        public const string PhoneNumber = @"^(\+?\d{1,4}[\s-])?(?!0+\s+,?$)\d{10}\s*,?$";
    }
}
