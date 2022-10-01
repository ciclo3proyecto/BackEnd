namespace InventoryApp.Api.Infraestructure.Constanst
{
    public static class  ValidationErrorMessage
    {
        public const string Obligatorio = "El campo '{PropertyName}' es obligatorio.";
        public const string NoExiste = "El dato ingresado de '{PropertyName}' no exite en la base de datos.";
        public const string SiExiste = "El dato ingresado de '{PropertyName}' ya exite en la base de datos.";
        public const string Min4 = "El campo '{PropertyName}' admite como minimo 4 caracteres.";
        public const string Min8 = "El campo '{PropertyName}' admite como minimo 8 caracteres.";
        public const string Max10 = "El campo '{PropertyName}' admite hasta 10 caracteres.";
        public const string Max40 = "El campo '{PropertyName}' admite hasta 40 caracteres.";
        public const string Max50 = "El campo '{PropertyName}' admite hasta 50 caracteres.";
        public const string Max60 = "El campo '{PropertyName}' admite hasta 60 caracteres.";
        public const string Max100 = "El campo '{PropertyName}' admite hasta 100 caracteres.";
        public const string Max200 = "El campo '{PropertyName}' admite hasta 200 caracteres.";
        public const string InvalidPassword = "La contraseña ingresada no cumple con el estandar.";
        public const string Rango_1_100000000 = "El rango permitido es de 1 a 100000000.";
    }
}
