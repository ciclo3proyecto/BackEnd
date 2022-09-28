namespace InventoryApp.Api.Application.Dtos.Usuarios
{
    public class UsuarioQueryDto
    {
        public int Id { get; set; }
        public int PerfilesId { get; set; }
        public int TiposdocumentosId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public decimal Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Primerapellido { get; set; }
        public string? Segundoapellido { get; set; }
    }
}
