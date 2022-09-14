namespace InventoryApp.Api.Application.Dtos.Usuarios
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public int PerfilesId { get; set; }
        public string Login { get; set; }
        public string Nombres { get; set; }
        public string Primerapellido { get; set; }
        public string? Segundoapellido { get; set; }
    }
}
