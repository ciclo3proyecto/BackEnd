namespace InventoryApp.Api.Infraestructure.Constanst
{
    public static class  ValidationErrorMessage
    {
        public const string Obligatorio = "El campo '{PropertyName}' es obligatorio.";
        public const string NoExiste = "El dato ingresado de '{PropertyName}' no exite en la base de datos.";
        public const string SiExiste = "El dato ingresado de '{PropertyName}' ya exite en la base de datos.";
        public const string Max40 = "El campo '{PropertyName}' admite hasta 40 caracteres.";
        public const string Max60 = "El campo '{PropertyName}' admite hasta 60 caracteres.";
    }
}
